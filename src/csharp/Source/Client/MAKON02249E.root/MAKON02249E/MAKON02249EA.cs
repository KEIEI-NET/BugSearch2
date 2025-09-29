using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ---------->>>>>
    /// <summary>
    /// �d���摍�z�\�����@�敪�̗񋓑�
    /// </summary>
    public enum SuppTtlAmntDspWayCd : int
    {
        /// <summary>���z�\�����Ȃ��i�Ŕ����j</summary>
        NotShown = 0,
        /// <summary>���z�\������i�ō��݁j</summary>
        Shown = 1
    }

    /// <summary>
    /// �d�������œ]�ŕ����R�[�h�̗񋓑�
    /// </summary>
    public enum SuppCTaxLayCd : int
    {
        /// <summary>�`�[�P��</summary>
        BySlip = 0,
        /// <summary>���גP��</summary>
        ByDetails = 1,
        /// <summary>�x���e</summary>
        ParentPayment = 2,
        /// <summary>�x���q</summary>
        ChildPayment = 3,
        /// <summary>��ې�</summary>
        TaxExemption = 9
    }

    /// <summary>
    /// �ېŋ敪�̗񋓑�
    /// </summary>
    public enum TaxationCode : int
    {
        /// <summary>�O��</summary>
        OutsideTax = 0,
        /// <summary>��ې�</summary>
        TaxExemption = 1,
        /// <summary>����</summary>
        TaxIncluded = 2
    }
    // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ----------<<<<<

	/// <summary>
	/// �d���m�F�\(���גP��)���o���ʃf�[�^�e�[�u���X�L�[�}�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �d���m�F�\(���גP��)�̒��o���ʃe�[�u���X�L�[�}�ł��B</br>
	/// <br>Programmer : 22021�@�J���@�͍K</br>
	/// <br>Date       : 2006.01.27</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : �E�f�[�^���ڂ̒ǉ�/�C��</br>
    /// <br>Programmer : 30415 �ēc �ύK</br>
    /// <br>Date	   : 2008/07/16</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note: 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : 3H ���� </br>
    /// <br>Date	   : 2020/02/27</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note: 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j </br>
    /// <br>Programmer : ���O </br>
    /// <br>Date       : 2022/09/28</br>
    /// </remarks>
	public class MAKON02249EA
	{
		#region Public Members
        /// <summary>�d���m�F�\(���גP��)�f�[�^�e�[�u����</summary>
        public const string CT_StockConfDataTable = "StockConfDataTable";
        /// <summary>�d���m�F�\(���גP��)�o�b�t�@�f�[�^�e�[�u����</summary>
        public const string CT_StockConfBuffDataTable = "StockConfBuffDataTable";

		#region �d���m�F�\�i���גP�ʁj�J�������

        /// <summary>���_�R�[�h</summary>
        public const string CT_StockConf_SectionCodeRF = "SectionCodeRF";
        /// <summary>���_�K�C�h����</summary>
        public const string CT_StockConf_SectionGuideNmRF = "SectionGuideNmRF";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>�d����R�[�h</summary>
        public const string CT_StockConf_SupplierCd = "SupplierCd";
        /// <summary>�d���旪��</summary>
        public const string CT_StockConf_SupplierSnm = "SupplierSnm";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

        /// <summary>���͓��t</summary>
        public const string CT_StockConf_InputDayRF = "InputDayRF";
        /// <summary>�d�����t</summary>
        public const string CT_StockConf_StockDateRF = "StockDateRF";
        /// <summary>���ד��t</summary>
        public const string CT_StockConf_ArrivalGoodsDayRF = "ArrivalGoodsDayRF";

        // --- DEL 2008/07/16 -------------------------------->>>>>
        ///// <summary>���Ӑ�R�[�h</summary>
        //public const string CT_StockConf_CustomerCodeRF = "CustomerCodeRF";
        ///// <summary>���Ӑ於��</summary>
        //public const string CT_StockConf_CustomerNameRF = "CustomerNameRF";
        ///// <summary>���Ӑ於��2</summary>
        //public const string CT_StockConf_CustomerName2RF = "CustomerName2RF";
        // --- DEL 2008/07/16 --------------------------------<<<<< 

        /// <summary>���i�R�[�h</summary>
        public const string CT_StockConf_GoodsCodeRF = "GoodsCodeRF";
        /// <summary>���i����</summary>
        public const string CT_StockConf_GoodsNameRF = "GoodsNameRF";
        /// <summary>�d���`�[�ԍ�</summary>
        public const string CT_StockConf_SupplierSlipNoRF = "SupplierSlipNoRF";
        /// <summary>�d���s�ԍ�</summary>
        public const string CT_StockConf_StockRowNoRF = "StockRowNoRF";
        /// <summary>�d���ڍהԍ�</summary>
        public const string CT_StockConf_StckSlipExpNumRF = "StckSlipExpNumRF";
        /// <summary>�ԓ`�敪</summary>
        public const string CT_StockConf_DebitNoteDivRF = "DebitNoteDivRF";
        /// <summary>�ԓ`�敪��</summary>
        public const string CT_StockConf_DebitNoteDivNmRF = "DebitNoteDivNmRF";
        /// <summary>�d���`��</summary>
        public const string CT_StockConf_SupplierFormalRF = "SupplierFormalRF";
        /// <summary>�d���`����</summary>
        public const string CT_StockConf_SupplierFormalNmRF = "SupplierFormalNmRF";
        /// <summary>���|�敪</summary>
        public const string CT_StockConf_AccPayDivCdRF = "AccPayDivCdRF";
        /// <summary>���|�敪��</summary>
        public const string CT_StockConf_AccPayDivNmRF = "AccPayDivNmRF";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>�t�n�d���}�[�N�P</summary>
        public const string CT_StockConf_UoeRemark1 = "UoeRemark1";
        /// <summary>�t�n�d���}�[�N�Q</summary>
        public const string CT_StockConf_UoeRemark2 = "UoeRemark2";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

        // --- DEL 2008/07/16 -------------------------------->>>>>
        ///// <summary>���i�啪�ރR�[�h</summary>
        //public const string CT_StockConf_LargeGoodsGanreCodeRF = "LargeGoodsGanreCodeRF";
        ///// <summary>���i�啪�ޖ���</summary>
        //public const string CT_StockConf_LargeGoodsGanreNameRF = "LargeGoodsGanreNameRF";
        ///// <summary>���i�����ރR�[�h</summary>
        //public const string CT_StockConf_MediumGoodsGanreCodeRF = "MediumGoodsGanreCodeRF";
        ///// <summary>���i�����ޖ���</summary>
        //public const string CT_StockConf_MediumGoodsGanreNameRF = "MediumGoodsGanreNameRF";
        // --- DEL 2008/07/16 --------------------------------<<<<< 

		/// <summary>�d���S���҃R�[�h</summary>
        public const string CT_StockConf_StockAgentCodeRF = "StockAgentCodeRF";
        /// <summary>�d���S���Җ���</summary>
        public const string CT_StockConf_StockAgentNameRF = "StockAgentNameRF";
		/// <summary>�d����</summary>
        public const string CT_StockConf_StockCountRF = "StockCountRF";
        /// <summary>�d���P��</summary>
        public const string CT_StockConf_StockUnitPriceRF = "StockUnitPriceRF";
        /// <summary>�d�����z</summary>
        public const string CT_StockConf_StockPriceTaxExcRF = "StockPriceTaxExcRF";
        /// <summary>�d���`�[�敪</summary>
        public const string CT_StockConf_SupplierSlipCdRF = "SupplierSlipCdRF";
        /// <summary>�d���`�[�敪��</summary>
        public const string CT_StockConf_SupplierSlipNmRF = "SupplierSlipNmRF";
        /// <summary>�擪�o�͏ڍ׃t���O</summary>
        public const string CT_StockConf_FirstRowFlg = "FirstRowFlg";

		/// <summary>�����`�[�ԍ�</summary>
		public const string CT_StockConf_PartySaleSlipNumRF = "PartySaleSlipNumRF";

		/// <summary>���i�敪�ڍ׃R�[�h</summary>
		public const string CT_StockConf_DetailGoodsGanreCodeRF = "DetailGoodsGanreCodeRF";
		/// <summary>���i�敪�ڍז���</summary>
		public const string CT_StockConf_DetailGoodsGanreNameRF = "DetailGoodsGanreNameRF";

		/// <summary>���Е��ރR�[�h</summary>
		public const string CT_StockConf_EnterpriseGanreCodeRF = "EnterpriseGanreCodeRF";
		/// <summary>���Е��ޖ���</summary>
		public const string CT_StockConf_EnterpriseGanreNameRF = "EnterpriseGanreNameRF";
		/// <summary>���i���[�J�[�R�[�h</summary>
		public const string CT_StockConf_GoodsMakerCdRF = "GoodsMakerCdRF";
		/// <summary>���[�J�[����</summary>
		public const string CT_StockConf_MakerNameRF = "MakerNameRF";
		/// <summary>�d���݌Ɏ�񂹋敪</summary>
		public const string CT_StockConf_StockOrderDivCdRF = "StockOrderDivCdRF";
		/// <summary>�d���݌Ɏ�񂹖���</summary>
		public const string CT_StockConf_StockOrderDivNmRF = "StockOrderDivNmRF";
		/// <summary>�q�ɃR�[�h</summary>
		public const string CT_StockConf_WarehouseCodeRF = "WarehouseCodeRF";
		/// <summary>�q�ɖ���</summary>
		public const string CT_StockConf_WarehouseNameRF = "WarehouseNameRF";
		/// <summary>BL���i�R�[�h</summary>
		public const string CT_StockConf_BLGoodsCodeRF = "BLGoodsCodeRF";
		/// <summary>�d���`�[���ה��l1</summary>
		public const string CT_StockConf_StockDtiSlipNote1RF = "StockDtiSlipNote1RF";
		/// <summary>�P�ʃR�[�h</summary>
		public const string CT_StockConf_UnitCodeRF = "UnitCodeRF";
		/// <summary>�P�ʖ���</summary>
		public const string CT_StockConf_UnitNameRF = "UnitNameRF";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>�ύX�O�艿</summary>
        public const string CT_StockConf_BfListPriceRF = "BfListPriceRF";
        /// <summary>�ύX�O�d���P��</summary>
        public const string CT_StockConf_BfStockUnitPriceFlRF = "BfStockUnitPriceFlRF";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		/// <summary>�艿�i�����j</summary>
		public const string CT_StockConf_ListPriceFlRF = "ListPriceFlRF";
		/// <summary>�����ԍ�</summary>
		public const string CT_StockConf_OrderNumberRF = "OrderNumberRF";
		/// <summary>�����</summary>
		public const string CT_StockConf_TaxRF = "TaxRF";

		/// <summary>�d���`�[���l1</summary>
		public const string CT_StockConf_SupplierSlipNote1RF = "SupplierSlipNote1RF";
		/// <summary>�d���`�[���l2</summary>
		public const string CT_StockConf_SupplierSlipNote2RF = "SupplierSlipNote2RF";
		/// <summary>�d���旪��</summary>
		public const string CT_StockConf_CustomerSnmRF = "CustomerSnmRF";
		/// <summary>�d���v����t</summary>
		public const string CT_StockConf_StockAddUpADateRF = "StockAddUpADateRF";

		/// <summary>���͓��t(����p)</summary>
		public const string CT_StockConf_InputDayStringRF = "InputDayStringRF";
		/// <summary>�d�����t(����p)</summary>
		public const string CT_StockConf_StockDateStringRF = "StockDateStringRF";
		/// <summary>�d���v����t(����p)</summary>
		public const string CT_StockConf_StockAddUpADateStringRF = "StockAddUpADateStringRF";
		/// <summary>���ד��t(����p)</summary>
		public const string CT_StockConf_ArrivalGoodsDayStringRF = "ArrivalGoodsDayStringRF";

		/// <summary>�d�����i�敪</summary>
		public const string CT_StockConf_StockGoodsCdRF = "StockGoodsCdRF";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>����`�[�ԍ�</summary>
        public const string CT_StockConf_SalesSlipNum = "SalesSlipNum";
        /// <summary>���Ӑ�R�[�h</summary>
        public const string CT_StockConf_CustomerCodeRF = "CustomerCodeRF";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		/// <summary>�d�����v�E���͓��v</summary>
		public const string CT_StockConf_groupHeader1DataField = "groupHeader1DataField";
		/// <summary>�`�[�v</summary>
		public const string CT_StockConf_groupHeader2DataField = "groupHeader2DataField";
		/// <summary>�d����v</summary>
		public const string CT_StockConf_DailyHeaderDataField = "DailyHeaderDataField";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>�d�����z�i�ō��݁j</summary>
        public const string CT_StockConf_StockPriceTaxIncRF = "StockPriceTaxIncRF";
        /// <summary>�`�[����(����)</summary>
        public const string CT_StockConf_SalCntRF = "SalCntRF";
        /// <summary>�`�[����(�ԕi�l��)</summary>
        public const string CT_StockConf_DisCntRF = "DisCntRF";
        /// <summary>�`�[����(���v)</summary>
        public const string CT_StockConf_TotleCntRF = "TotleCntRF";

        /// <summary>�d�����z(����)</summary>
        public const string CT_StockConf_SalStockPricTaxExcRF = "SalStockPricTaxExcRF";
        /// <summary>�����(����)</summary>
        public const string CT_StockConf_SalStockPriceConsTaxRF = "SalStockPriceConsTaxRF";
        /// <summary>���v���z(����)</summary>
        public const string CT_StockConf_SalTotalPriceRF = "SalTotalPriceRF";

        // 2009.01.09 30413 ���� �l���̋��z��ǉ� >>>>>>START
        ///// <summary>�d�����z(�ԕi�l��)</summary>
        //public const string CT_StockConf_DisStockPricTaxExcRF = "DisStockPricTaxExcRF";
        ///// <summary>�����(�ԕi�l��)</summary>
        //public const string CT_StockConf_DisStockPriceConsTaxRF = "DisStockPriceConsTaxRF";
        ///// <summary>���v���z(�ԕi�l��)</summary>
        //public const string CT_StockConf_DisTotalPriceRF = "DisTotalPriceRF";
        /// <summary>�d�����z(�ԕi)</summary>
        public const string CT_StockConf_RetGdsStockPricTaxExcRF = "RetGdsStockPricTaxExcRF";
        /// <summary>�����(�ԕi)</summary>
        public const string CT_StockConf_RetGdsStockPriceConsTaxRF = "RetGdsStockPriceConsTaxRF";
        /// <summary>���v���z(�ԕi)</summary>
        public const string CT_StockConf_RetGdsTotalPriceRF = "RetGdsTotalPriceRF";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

        /// <summary>�d�����z(�l��)</summary>
        public const string CT_StockConf_DisStockPricTaxExcRF = "DisStockPricTaxExcRF";
        /// <summary>�����(�l��)</summary>
        public const string CT_StockConf_DisStockPriceConsTaxRF = "DisStockPriceConsTaxRF";
        /// <summary>���v���z(�l��)</summary>
        public const string CT_StockConf_DisTotalPriceRF = "DisTotalPriceRF";        
        // 2009.01.09 30413 ���� �l���̋��z��ǉ� <<<<<<END

        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
        /// <summary> ����Őŗ� </summary>
        public const String CT_Col_ConsTaxRate = "SupplierConsTaxRate";

        #region �u����Őŗ��P�v
        /// <summary>Title_�ŗ��P</summary>
        public const string CT_StockConf_TaxRate1_Title = "TaxRate1Title";
        /// <summary>�d������_�ŗ��P</summary>
        public const string CT_StockConf_TaxRate1_SalSlipCntRF = "TaxRate1SalSlipCntRF";
        /// <summary>�d�����z�v�i�Ŕ����j_�ŗ��P</summary>
        public const string CT_StockConf_TaxRate1_StockTtlPricTaxExcRF = "TaxRate1StockTtlPricTaxExcRF";

        /// <summary>Title(�ԕi)_�ŗ��P</summary>
        public const string CT_StockConf_TaxRate1_RetTitle = "TaxRate1RetTitle";
        /// <summary>�`�[����(�ԕi�l��)_�ŗ��P</summary>
        public const string CT_StockConf_TaxRate1_DisSlipCntRF = "TaxRate1DisSlipCntRF";
        /// <summary>�d�����z(�ԕi)_�ŗ��P</summary>
        public const string CT_StockConf_TaxRate1_RetGdsStockTtlPricTaxExcRF = "TaxRate1RetGdsStockTtlPricTaxExcRF";
        #endregion

        #region �u����Őŗ��Q�v
        /// <summary>Title_�ŗ�2</summary>
        public const string CT_StockConf_TaxRate2_Title = "TaxRate2Title";
        /// <summary>�d������_�ŗ��Q</summary>
        public const string CT_StockConf_TaxRate2_SalSlipCntRF = "TaxRate2SalSlipCntRF";
        /// <summary>�d�����z�v�i�Ŕ����j_�ŗ��Q</summary>
        public const string CT_StockConf_TaxRate2_StockTtlPricTaxExcRF = "TaxRate2StockTtlPricTaxExcRF";

        /// <summary>Title(�ԕi)_�ŗ��Q</summary>
        public const string CT_StockConf_TaxRate2_RetTitle = "TaxRate2RetTitle";
        /// <summary>�`�[����(�ԕi�l��)_�ŗ��Q</summary>
        public const string CT_StockConf_TaxRate2_DisSlipCntRF = "TaxRate2DisSlipCntRF";
        /// <summary>�d�����z(�ԕi)_�ŗ��Q</summary>
        public const string CT_StockConf_TaxRate2_RetGdsStockTtlPricTaxExcRF = "TaxRate2RetGdsStockTtlPricTaxExcRF";
        #endregion

        #region �u����Őŗ����̑��v
        /// <summary>Title_���̑�</summary>
        public const string CT_StockConf_Other_Title = "OtherTitle";
        /// <summary>�d������_���̑�</summary>
        public const string CT_StockConf_Other_SalSlipCntRF = "OtherSalSlipCntRF";
        /// <summary>�d�����z�v�i�Ŕ����j_���̑�</summary>
        public const string CT_StockConf_Other_StockTtlPricTaxExcRF = "OtherStockTtlPricTaxExcRF";

        /// <summary>Title_���̑�</summary>
        public const string CT_StockConf_Other_RetTitle = "OtherRetTitle";
        /// <summary>�d������(�ԕi�l��)_���̑�</summary>
        public const string CT_StockConf_Other_DisSlipCntRF = "OtherDisSlipCntRF";
        /// <summary>�d�����z(�ԕi)_���̑�</summary>
        public const string CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF = "OtherRetGdsStockTtlPricTaxExcRF";
        #endregion
        // --- ADD END 3H ���� 2020/02/27 -----<<<<<



        // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
        #region �u����Őŗ���ېŁv
        /// <summary>Title_��ې�</summary>
        public const string CT_StockConf_TaxFree_Title = "TaxFreeTitle";
        /// <summary>�d������_��ې�</summary>
        public const string CT_StockConf_TaxFree_SalSlipCntRF = "TaxFreeSalSlipCntRF";
        /// <summary>�d�����z�v�i�Ŕ����j_��ې�</summary>
        public const string CT_StockConf_TaxFree_StockTtlPricTaxExcRF = "TaxFreeStockTtlPricTaxExcRF";

        /// <summary>Title_��ې�</summary>
        public const string CT_StockConf_TaxFree_RetTitle = "TaxFreeRetTitle";
        /// <summary>�d������(�ԕi�l��)_��ې�</summary>
        public const string CT_StockConf_TaxFree_DisSlipCntRF = "TaxFreeDisSlipCntRF";
        /// <summary>�d�����z(�ԕi)_��ې�</summary>
        public const string CT_StockConf_TaxFree_RetGdsStockTtlPricTaxExcRF = "TaxFreeRetGdsStockTtlPricTaxExcRF";
        #endregion
        // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<
		// �L�[�u���C�N
		public const string COL_KEYBREAK_AR = "KEYBREAK_AR";

        // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ---------->>>>>
        // �d���摍�z�\�����@�敪
        public const string CT_StockConf_SuppTtlAmntDspWayCd = "SuppTtlAmntDspWayCd";
        // �d�������œ]�ŕ����R�[�h
        public const string CT_StockConf_SuppCTaxLayCd = "SuppCTaxLayCd";
        // �ېŋ敪
        public const string CT_StockConf_TaxationCode = "TaxationCode";
        // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ----------<<<<<

		#endregion

		#endregion

		#region Constructor
		/// <summary>
		/// �d���m�F�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d���m�F�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
		/// <br>Programmer : 22021�@�J���@�͍K</br>
		/// <br>Date       : 2006.01.27</br>
		/// </remarks>
		public MAKON02249EA()
		{
		}
		#endregion
		
		#region Public Methods
		/// <summary>
		/// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 22021 �J���@�͍K</br>
		/// <br>Date       : 2006.01.21</br>
		/// </remarks>
		public static void SettingDataSet(ref DataSet ds)
		{
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
			if ( (ds.Tables.Contains(CT_StockConfDataTable)) )
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				ds.Tables[CT_StockConfDataTable].Clear();
			}
			else
			{
                CreateStockConfTable(ref ds, 0);

			}
			
			// ����`�F�b�N���X�g�o�b�t�@�f�[�^�e�[�u��------------------------------------------
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
			if ((ds.Tables.Contains(CT_StockConfBuffDataTable)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				ds.Tables[CT_StockConfBuffDataTable].Clear();
			}
			else
			{
                CreateStockConfTable(ref ds, 1);
			}
		}

		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// �d���m�F�\(���גP��)���o���ʍ쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 22021 �J���@�͍K</br>
		/// <br>Date       : 2006.01.28</br>
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
		/// </remarks>
		private static void CreateStockConfTable(ref DataSet ds, int buffCheck)
		{
			DataTable dt = null;
			if(buffCheck == 0)
			{
				// �X�L�[�}�ݒ�
				ds.Tables.Add(CT_StockConfDataTable);
				dt = ds.Tables[CT_StockConfDataTable];
			}
			else
			{
				// �X�L�[�}�ݒ�
				ds.Tables.Add(CT_StockConfBuffDataTable);
				dt = ds.Tables[CT_StockConfBuffDataTable];
			}

                // ���_�R�[�h
                dt.Columns.Add(CT_StockConf_SectionCodeRF, typeof(string));
                dt.Columns[CT_StockConf_SectionCodeRF].DefaultValue = "";
                // ���_�K�C�h����
                dt.Columns.Add(CT_StockConf_SectionGuideNmRF, typeof(string));
                dt.Columns[CT_StockConf_SectionGuideNmRF].DefaultValue = "";
                // �d�����t
                dt.Columns.Add(CT_StockConf_StockDateRF, typeof(DateTime));
                dt.Columns[CT_StockConf_StockDateRF].DefaultValue = null;
                // ���ד��t
                dt.Columns.Add(CT_StockConf_ArrivalGoodsDayRF, typeof(DateTime));
                dt.Columns[CT_StockConf_ArrivalGoodsDayRF].DefaultValue = null;

                // --- DEL 2008/07/16 -------------------------------->>>>>
                //// ���Ӑ�R�[�h
                //dt.Columns.Add(CT_StockConf_CustomerCodeRF, typeof(Int32));
                //dt.Columns[CT_StockConf_CustomerCodeRF].DefaultValue = 0;
                //// ���Ӑ於��
                //dt.Columns.Add(CT_StockConf_CustomerNameRF, typeof(string));
                //dt.Columns[CT_StockConf_CustomerNameRF].DefaultValue = "";
                //// ���Ӑ於��2
                //dt.Columns.Add(CT_StockConf_CustomerName2RF, typeof(string));
                //dt.Columns[CT_StockConf_CustomerName2RF].DefaultValue = "";
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                // �d����R�[�h
                dt.Columns.Add(CT_StockConf_SupplierCd, typeof(Int32));
                dt.Columns[CT_StockConf_SupplierCd].DefaultValue = 0;
                // �d���旪��
                dt.Columns.Add(CT_StockConf_SupplierSnm, typeof(string));
                dt.Columns[CT_StockConf_SupplierSnm].DefaultValue = "";
                // --- ADD 2008/07/16 --------------------------------<<<<< 

                // ���i�R�[�h
                dt.Columns.Add(CT_StockConf_GoodsCodeRF, typeof(string));
                dt.Columns[CT_StockConf_GoodsCodeRF].DefaultValue = "";
                // ���i����
                dt.Columns.Add(CT_StockConf_GoodsNameRF, typeof(string));
                dt.Columns[CT_StockConf_GoodsNameRF].DefaultValue = "";
                // �d���`�[�ԍ�
                dt.Columns.Add(CT_StockConf_SupplierSlipNoRF, typeof(Int32));
                dt.Columns[CT_StockConf_SupplierSlipNoRF].DefaultValue = 0;
                // �d���s�ԍ�
                dt.Columns.Add(CT_StockConf_StockRowNoRF, typeof(Int32));
                dt.Columns[CT_StockConf_StockRowNoRF].DefaultValue = 0;
                // �d���ڍהԍ�
                dt.Columns.Add(CT_StockConf_StckSlipExpNumRF, typeof(Int32));
                dt.Columns[CT_StockConf_StckSlipExpNumRF].DefaultValue = 0;
                // �ԓ`�敪
                dt.Columns.Add(CT_StockConf_DebitNoteDivRF, typeof(Int32));
                dt.Columns[CT_StockConf_DebitNoteDivRF].DefaultValue = 0;
                // �ԓ`�敪��
                dt.Columns.Add(CT_StockConf_DebitNoteDivNmRF, typeof(string));
                dt.Columns[CT_StockConf_DebitNoteDivNmRF].DefaultValue = "";
                // ���|�敪
                dt.Columns.Add(CT_StockConf_AccPayDivCdRF, typeof(Int32));
                dt.Columns[CT_StockConf_AccPayDivCdRF].DefaultValue = 0;
                // ���|�敪��
                dt.Columns.Add(CT_StockConf_AccPayDivNmRF, typeof(string));
                dt.Columns[CT_StockConf_AccPayDivNmRF].DefaultValue = "";

                // --- DEL 2008/07/16 -------------------------------->>>>>
                //// ���i�啪�ރR�[�h
                //dt.Columns.Add(CT_StockConf_LargeGoodsGanreCodeRF, typeof(string));
                //dt.Columns[CT_StockConf_LargeGoodsGanreCodeRF].DefaultValue = 0;
                //// ���i�啪�ޖ���
                //dt.Columns.Add(CT_StockConf_LargeGoodsGanreNameRF, typeof(string));
                //dt.Columns[CT_StockConf_LargeGoodsGanreNameRF].DefaultValue = "";
                //// ���i�����ރR�[�h
                //dt.Columns.Add(CT_StockConf_MediumGoodsGanreCodeRF, typeof(string));
                //dt.Columns[CT_StockConf_MediumGoodsGanreCodeRF].DefaultValue = 0;
                //// ���i�����ޖ���
                //dt.Columns.Add(CT_StockConf_MediumGoodsGanreNameRF, typeof(string));
                //dt.Columns[CT_StockConf_MediumGoodsGanreNameRF].DefaultValue = "";
                // --- DEL 2008/07/16 --------------------------------<<<<< 

				// �d���S���҃R�[�h
                dt.Columns.Add(CT_StockConf_StockAgentCodeRF, typeof(string));
                dt.Columns[CT_StockConf_StockAgentCodeRF].DefaultValue = "";
                // �d���S���Җ���
                dt.Columns.Add(CT_StockConf_StockAgentNameRF, typeof(string));
                dt.Columns[CT_StockConf_StockAgentNameRF].DefaultValue = "";
                // �d����
                dt.Columns.Add(CT_StockConf_StockCountRF, typeof(double));
                dt.Columns[CT_StockConf_StockCountRF].DefaultValue = 0;
                // �d���P��
				dt.Columns.Add(CT_StockConf_StockUnitPriceRF, typeof(double));
                dt.Columns[CT_StockConf_StockUnitPriceRF].DefaultValue = 0;
                // �d�����z
                dt.Columns.Add(CT_StockConf_StockPriceTaxExcRF, typeof(Int64));
                dt.Columns[CT_StockConf_StockPriceTaxExcRF].DefaultValue = 0;
                // �d���`�[�敪
                dt.Columns.Add(CT_StockConf_SupplierSlipCdRF, typeof(Int32));
                dt.Columns[CT_StockConf_SupplierSlipCdRF].DefaultValue = 0;
                // �d���`�[�敪��
                dt.Columns.Add(CT_StockConf_SupplierSlipNmRF, typeof(string));
                dt.Columns[CT_StockConf_SupplierSlipNmRF].DefaultValue = "";
                // �擪�o�͏ڍ׃t���O
                dt.Columns.Add(CT_StockConf_FirstRowFlg, typeof(Int32));
                dt.Columns[CT_StockConf_FirstRowFlg].DefaultValue = 0;

                // ���͓��t
                dt.Columns.Add(CT_StockConf_InputDayRF, typeof(DateTime));
                dt.Columns[CT_StockConf_InputDayRF].DefaultValue = null;
				// �����`�[�ԍ�
				dt.Columns.Add(CT_StockConf_PartySaleSlipNumRF, typeof(string));
				dt.Columns[CT_StockConf_PartySaleSlipNumRF].DefaultValue = "";
				// ���i�敪�ڍ׃R�[�h
				dt.Columns.Add(CT_StockConf_DetailGoodsGanreCodeRF, typeof(string));
				dt.Columns[CT_StockConf_DetailGoodsGanreCodeRF].DefaultValue = "";
				// ���i�敪�ڍז���
				dt.Columns.Add(CT_StockConf_DetailGoodsGanreNameRF, typeof(string));
				dt.Columns[CT_StockConf_DetailGoodsGanreNameRF].DefaultValue = "";
				// ���Е��ރR�[�h
				dt.Columns.Add(CT_StockConf_EnterpriseGanreCodeRF, typeof(Int32));
				dt.Columns[CT_StockConf_EnterpriseGanreCodeRF].DefaultValue = 0;
				// ���Е��ޖ���
				dt.Columns.Add(CT_StockConf_EnterpriseGanreNameRF, typeof(string));
				dt.Columns[CT_StockConf_EnterpriseGanreNameRF].DefaultValue = "";
				// ���i���[�J�[�R�[�h
				dt.Columns.Add(CT_StockConf_GoodsMakerCdRF, typeof(Int32));
				dt.Columns[CT_StockConf_GoodsMakerCdRF].DefaultValue = 0;
				// ���[�J�[����
				dt.Columns.Add(CT_StockConf_MakerNameRF, typeof(string));
				dt.Columns[CT_StockConf_MakerNameRF].DefaultValue = "";
				// �d���݌Ɏ�񂹋敪
				dt.Columns.Add(CT_StockConf_StockOrderDivCdRF, typeof(Int32));
				dt.Columns[CT_StockConf_StockOrderDivCdRF].DefaultValue = 0;
				// �d���݌Ɏ�񂹖���
				dt.Columns.Add(CT_StockConf_StockOrderDivNmRF, typeof(string));
				dt.Columns[CT_StockConf_StockOrderDivNmRF].DefaultValue = "";
				// �q�ɃR�[�h
				dt.Columns.Add(CT_StockConf_WarehouseCodeRF, typeof(string));
				dt.Columns[CT_StockConf_WarehouseCodeRF].DefaultValue = "";
				// �q�ɖ���
				dt.Columns.Add(CT_StockConf_WarehouseNameRF, typeof(string));
				dt.Columns[CT_StockConf_WarehouseNameRF].DefaultValue = "";
				// BL���i�R�[�h
				dt.Columns.Add(CT_StockConf_BLGoodsCodeRF, typeof(Int32));
				dt.Columns[CT_StockConf_BLGoodsCodeRF].DefaultValue = 0;
				// �d���`�[���ה��l1
				dt.Columns.Add(CT_StockConf_StockDtiSlipNote1RF, typeof(string));
				dt.Columns[CT_StockConf_StockDtiSlipNote1RF].DefaultValue = "";
				// �P�ʃR�[�h
				dt.Columns.Add(CT_StockConf_UnitCodeRF, typeof(Int32));
				dt.Columns[CT_StockConf_UnitCodeRF].DefaultValue = 0;
				// �P�ʖ���
				dt.Columns.Add(CT_StockConf_UnitNameRF, typeof(string));
				dt.Columns[CT_StockConf_UnitNameRF].DefaultValue = "";

                // --- ADD 2008/07/16 -------------------------------->>>>>
                // �ύX�O�艿
                dt.Columns.Add(CT_StockConf_BfListPriceRF, typeof(Double));
                dt.Columns[CT_StockConf_BfListPriceRF].DefaultValue = 0.0;
                // �ύX�O�d���P�� 
                dt.Columns.Add(CT_StockConf_BfStockUnitPriceFlRF, typeof(Double));
                dt.Columns[CT_StockConf_BfStockUnitPriceFlRF].DefaultValue = 0.0;
                // ����`�[�ԍ�
                dt.Columns.Add(CT_StockConf_SalesSlipNum, typeof(string));
                dt.Columns[CT_StockConf_SalesSlipNum].DefaultValue = "";
                // ���Ӑ�R�[�h
                dt.Columns.Add(CT_StockConf_CustomerCodeRF, typeof(Int32));
                dt.Columns[CT_StockConf_CustomerCodeRF].DefaultValue = 0;
                // �e�X�g�t�n�d���}�[�N�P
                dt.Columns.Add(CT_StockConf_UoeRemark1, typeof(string));
                dt.Columns[CT_StockConf_UoeRemark1].DefaultValue = "";
                // �e�X�g�t�n�d���}�[�N�Q
                dt.Columns.Add(CT_StockConf_UoeRemark2, typeof(string));
                dt.Columns[CT_StockConf_UoeRemark2].DefaultValue = "";
                // --- ADD 2008/07/16 --------------------------------<<<<< 

				// �艿�i�����j
				dt.Columns.Add(CT_StockConf_ListPriceFlRF, typeof(Double));
				dt.Columns[CT_StockConf_ListPriceFlRF].DefaultValue = 0.0;
				// �����ԍ�
				dt.Columns.Add(CT_StockConf_OrderNumberRF, typeof(string));
				dt.Columns[CT_StockConf_OrderNumberRF].DefaultValue = "";
				// �����
                dt.Columns.Add(CT_StockConf_TaxRF, typeof(Int64));
                dt.Columns[CT_StockConf_TaxRF].DefaultValue = 0;

				// �d���`�[���l1
				dt.Columns.Add(CT_StockConf_SupplierSlipNote1RF, typeof(string));
				dt.Columns[CT_StockConf_SupplierSlipNote1RF].DefaultValue = "";

				// �d���`�[���l2
				dt.Columns.Add(CT_StockConf_SupplierSlipNote2RF, typeof(string));
				dt.Columns[CT_StockConf_SupplierSlipNote2RF].DefaultValue = "";

				// �d���旪��
				dt.Columns.Add(CT_StockConf_CustomerSnmRF, typeof(string));
				dt.Columns[CT_StockConf_CustomerSnmRF].DefaultValue = "";

				// �d���v����t
				dt.Columns.Add(CT_StockConf_StockAddUpADateRF, typeof(DateTime));
				dt.Columns[CT_StockConf_StockAddUpADateRF].DefaultValue = null;

				// ���͓��t(����p)
				dt.Columns.Add(CT_StockConf_InputDayStringRF, typeof(string));
				dt.Columns[CT_StockConf_InputDayStringRF].DefaultValue = "";
				
				// �d�����t(����p)
				dt.Columns.Add(CT_StockConf_StockDateStringRF, typeof(string));
				dt.Columns[CT_StockConf_StockDateStringRF].DefaultValue = "";
				
				// �d���v����t(����p)
				dt.Columns.Add(CT_StockConf_StockAddUpADateStringRF, typeof(string));
				dt.Columns[CT_StockConf_StockAddUpADateStringRF].DefaultValue = "";
				
				// ���ד��t(����p)
				dt.Columns.Add(CT_StockConf_ArrivalGoodsDayStringRF, typeof(string));
				dt.Columns[CT_StockConf_ArrivalGoodsDayStringRF].DefaultValue = "";

				// �d�����i�敪
				dt.Columns.Add(CT_StockConf_StockGoodsCdRF, typeof(Int32));
				dt.Columns[CT_StockConf_StockGoodsCdRF].DefaultValue = 0;

				// �d�����v�E���͓��v
				dt.Columns.Add(CT_StockConf_groupHeader1DataField, typeof(string));
				dt.Columns[CT_StockConf_groupHeader1DataField].DefaultValue = "";

				// �`�[�v
				dt.Columns.Add(CT_StockConf_groupHeader2DataField, typeof(string));
				dt.Columns[CT_StockConf_groupHeader2DataField].DefaultValue = "";

				// �d����v
				dt.Columns.Add(CT_StockConf_DailyHeaderDataField, typeof(string));
				dt.Columns[CT_StockConf_DailyHeaderDataField].DefaultValue = "";

                // --- ADD 2008/07/16 -------------------------------->>>>>
                // �d�����z�i�ō��݁j
                dt.Columns.Add(CT_StockConf_StockPriceTaxIncRF, typeof(Int64));
                dt.Columns[CT_StockConf_StockPriceTaxIncRF].DefaultValue = 0;
                //�`�[����(����)
                dt.Columns.Add(CT_StockConf_SalCntRF, typeof(Int32));
                dt.Columns[CT_StockConf_SalCntRF ].DefaultValue = 0;
                //�`�[����(�ԕi�l��)
                dt.Columns.Add(CT_StockConf_DisCntRF, typeof(Int32));
                dt.Columns[CT_StockConf_DisCntRF ].DefaultValue = 0;
                //�`�[����(���v)
                dt.Columns.Add(CT_StockConf_TotleCntRF, typeof(Int32));
                dt.Columns[CT_StockConf_TotleCntRF].DefaultValue = 0;
                //�d�����z(����)
                dt.Columns.Add(CT_StockConf_SalStockPricTaxExcRF, typeof(Int64));
                dt.Columns[CT_StockConf_SalStockPricTaxExcRF].DefaultValue = 0;
                //�����(����)
                dt.Columns.Add(CT_StockConf_SalStockPriceConsTaxRF, typeof(Int64));
                dt.Columns[CT_StockConf_SalStockPriceConsTaxRF].DefaultValue = 0;
                //���v���z(����)
                dt.Columns.Add(CT_StockConf_SalTotalPriceRF, typeof(Int64));
                dt.Columns[CT_StockConf_SalTotalPriceRF].DefaultValue = 0;

                // 2009.01.09 30413 ���� �l���̋��z��ǉ� >>>>>>START
                ////�d�����z(�ԕi�l��)
                //dt.Columns.Add(CT_StockConf_DisStockPricTaxExcRF, typeof(Int64));
                //dt.Columns[CT_StockConf_DisStockPricTaxExcRF].DefaultValue = 0;
                ////�����(�ԕi�l��)
                //dt.Columns.Add(CT_StockConf_DisStockPriceConsTaxRF, typeof(Int64));
                //dt.Columns[CT_StockConf_DisStockPriceConsTaxRF].DefaultValue = 0;
                ////���v���z(�ԕi�l��)
                //dt.Columns.Add(CT_StockConf_DisTotalPriceRF, typeof(Int64));
                //dt.Columns[CT_StockConf_DisTotalPriceRF].DefaultValue = 0;
                //�d�����z(�ԕi)
                dt.Columns.Add(CT_StockConf_RetGdsStockPricTaxExcRF, typeof(Int64));
                dt.Columns[CT_StockConf_RetGdsStockPricTaxExcRF].DefaultValue = 0;
                //�����(�ԕi)
                dt.Columns.Add(CT_StockConf_RetGdsStockPriceConsTaxRF, typeof(Int64));
                dt.Columns[CT_StockConf_RetGdsStockPriceConsTaxRF].DefaultValue = 0;
                //���v���z(�ԕi)
                dt.Columns.Add(CT_StockConf_RetGdsTotalPriceRF, typeof(Int64));
                dt.Columns[CT_StockConf_RetGdsTotalPriceRF].DefaultValue = 0;
                // --- ADD 2008/07/16 --------------------------------<<<<< 

                //�d�����z(�l��)
                dt.Columns.Add(CT_StockConf_DisStockPricTaxExcRF, typeof(Int64));
                dt.Columns[CT_StockConf_DisStockPricTaxExcRF].DefaultValue = 0;
                //�����(�l��)
                dt.Columns.Add(CT_StockConf_DisStockPriceConsTaxRF, typeof(Int64));
                dt.Columns[CT_StockConf_DisStockPriceConsTaxRF].DefaultValue = 0;
                //���v���z(�l��)
                dt.Columns.Add(CT_StockConf_DisTotalPriceRF, typeof(Int64));
                dt.Columns[CT_StockConf_DisTotalPriceRF].DefaultValue = 0;
                // 2009.01.09 30413 ���� �l���̋��z��ǉ� <<<<<<END
        
                // �L�[�u���C�N
				dt.Columns.Add(COL_KEYBREAK_AR, typeof(string));
				dt.Columns[COL_KEYBREAK_AR].DefaultValue = "";

                // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ---------->>>>>
                // �d���摍�z�\�����@�敪
                dt.Columns.Add(CT_StockConf_SuppTtlAmntDspWayCd, typeof(int));
                dt.Columns[CT_StockConf_SuppTtlAmntDspWayCd].DefaultValue = 0;

                // �d�������œ]�ŕ����R�[�h
                dt.Columns.Add(CT_StockConf_SuppCTaxLayCd, typeof(int));
                dt.Columns[CT_StockConf_SuppCTaxLayCd].DefaultValue = 0;

                // �ېŋ敪
                dt.Columns.Add(CT_StockConf_TaxationCode, typeof(int));
                dt.Columns[CT_StockConf_TaxationCode].DefaultValue = 0;
                // ADD 2008/11/04 �s��Ή�[6980] ����ł̈󎚎d�l�̕ύX ----------<<<<<

                // --- ADD START 3H ���� 2020/02/27 ---------->>>>>
                // ����Őŗ�
                dt.Columns.Add(CT_Col_ConsTaxRate, typeof(string));
                dt.Columns[CT_Col_ConsTaxRate].DefaultValue = "";
                #region �u����Őŗ��P�v
                // Title_�ŗ��P
                dt.Columns.Add(CT_StockConf_TaxRate1_Title, typeof(string));
                dt.Columns[CT_StockConf_TaxRate1_Title].DefaultValue = "";
                // �d������_�ŗ��P
                dt.Columns.Add(CT_StockConf_TaxRate1_SalSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate1_SalSlipCntRF].DefaultValue = "";
                // �d�����z�v�i�Ŕ����j_�ŗ��P
                dt.Columns.Add(CT_StockConf_TaxRate1_StockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate1_StockTtlPricTaxExcRF].DefaultValue = "";
                // Title(�ԕi�l��)_�ŗ��P
                dt.Columns.Add(CT_StockConf_TaxRate1_RetTitle, typeof(string));
                dt.Columns[CT_StockConf_TaxRate1_RetTitle].DefaultValue = "";
                // �`�[����(�ԕi�l��)_�ŗ��P
                dt.Columns.Add(CT_StockConf_TaxRate1_DisSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate1_DisSlipCntRF].DefaultValue = "";
                // �d�����z(�ԕi)_�ŗ��P
                dt.Columns.Add(CT_StockConf_TaxRate1_RetGdsStockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate1_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
                #endregion
                #region �u����Őŗ��Q�v
                // Title_�ŗ��Q
                dt.Columns.Add(CT_StockConf_TaxRate2_Title, typeof(string));
                dt.Columns[CT_StockConf_TaxRate2_Title].DefaultValue = "";
                // �d������_�ŗ��Q</summary>
                dt.Columns.Add(CT_StockConf_TaxRate2_SalSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate2_SalSlipCntRF].DefaultValue = "";
                // �d�����z�v�i�Ŕ����j_�ŗ��Q
                dt.Columns.Add(CT_StockConf_TaxRate2_StockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate2_StockTtlPricTaxExcRF].DefaultValue = "";
                // Title(�ԕi�l��)_�ŗ��Q
                dt.Columns.Add(CT_StockConf_TaxRate2_RetTitle, typeof(string));
                dt.Columns[CT_StockConf_TaxRate2_RetTitle].DefaultValue = "";
                // �`�[����(�ԕi�l��)_�ŗ��Q<
                dt.Columns.Add(CT_StockConf_TaxRate2_DisSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate2_DisSlipCntRF].DefaultValue = "";
                // �d�����z(�ԕi)_�ŗ��Q
                dt.Columns.Add(CT_StockConf_TaxRate2_RetGdsStockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate2_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
                #endregion
                #region �u����Őŗ����̑��v
                // Title_���̑�
                dt.Columns.Add(CT_StockConf_Other_Title, typeof(string));
                dt.Columns[CT_StockConf_Other_Title].DefaultValue = "";
                // �d������_���̑�
                dt.Columns.Add(CT_StockConf_Other_SalSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_Other_SalSlipCntRF].DefaultValue = "";
                // �d�����z�v�i�Ŕ����j_���̑�
                dt.Columns.Add(CT_StockConf_Other_StockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_Other_StockTtlPricTaxExcRF].DefaultValue = "";
                // Title(�ԕi�l��)_���̑�
                dt.Columns.Add(CT_StockConf_Other_RetTitle, typeof(string));
                dt.Columns[CT_StockConf_Other_RetTitle].DefaultValue = "";
                // �d������(�ԕi�l��)_���̑�
                dt.Columns.Add(CT_StockConf_Other_DisSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_Other_DisSlipCntRF].DefaultValue = "";
                // �d�����z(�ԕi)_���̑�
                dt.Columns.Add(CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
                #endregion
                // --- ADD END 3H ���� 2020/02/27 ----------<<<<<

                // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
                #region �u����Őŗ���ېŁv
                // Title_��ې�
                dt.Columns.Add(CT_StockConf_TaxFree_Title, typeof(string));
                dt.Columns[CT_StockConf_TaxFree_Title].DefaultValue = "";
                // �d������_��ې�
                dt.Columns.Add(CT_StockConf_TaxFree_SalSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_TaxFree_SalSlipCntRF].DefaultValue = "";
                // �d�����z�v�i�Ŕ����j_��ې�
                dt.Columns.Add(CT_StockConf_TaxFree_StockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_TaxFree_StockTtlPricTaxExcRF].DefaultValue = "";
                // Title(�ԕi�l��)_��ې�
                dt.Columns.Add(CT_StockConf_TaxFree_RetTitle, typeof(string));
                dt.Columns[CT_StockConf_TaxFree_RetTitle].DefaultValue = "";
                // �d������(�ԕi�l��)_��ې�
                dt.Columns.Add(CT_StockConf_TaxFree_DisSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_TaxFree_DisSlipCntRF].DefaultValue = "";
                // �d�����z(�ԕi)_��ې�
                dt.Columns.Add(CT_StockConf_TaxFree_RetGdsStockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_TaxFree_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
                #endregion
                // ----- ADD 2022/09/28 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<

		}

		#endregion
	}
}