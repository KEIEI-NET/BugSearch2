using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   DCHNB02014EA
	/// <summary>
	/// �󒍏o�׊m�F�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X
	/// </summary>
	/// <remarks>
	/// <br>�󒍏o�׊m�F�\�̒��o���ʃe�[�u���X�L�[�}�ł��B</br>
    /// <br>UpdateNote : 2008/10/31 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>UpdateNote : 2009/01/30 ��� �r���@�󒍐��A�󒍎c���ǉ�</br>
    /// </remarks>
	public class DCHNB02014EA
	{
		#region Public Members
		
		/// <summary>�󒍏o�׊m�F�\�f�[�^�e�[�u����</summary>
		public const string CT_OrderConfDataTable = "SalesConfDataTable";
		/// <summary>�󒍏o�׊m�F�\�o�b�t�@�f�[�^�e�[�u����</summary>
		public const string CT_OrderConfBuffDataTable = "SalesConfBuffDataTable";

		#region �󒍏o�׊m�F�\�i�`�[�`���j�J�������

		/// <summary>���_�R�[�h[����]</summary>
		public const string CT_OrderConf_SectionCode = "SectionCode";

		/// <summary>���_�K�C�h���́i���_���́j[����]</summary>
		/// <remarks>���_���ݒ�}�X�^���擾</remarks>
		public const string CT_OrderConf_SectionGuideNm = "SectionGuideNm";
		
		/// <summary>���Ӑ�R�[�h[����]</summary>
		public const string CT_OrderConf_CustomerCodeRF = "CustomerCode";

		/// <summary>���Ӑ旪��[����]</summary>
		public const string CT_OrderConf_CustomerSnmRF = "CustomerSnm";

		/// <summary>������͎҃R�[�h[����]</summary>
		public const string CT_OrderConf_SalesInputCodeRF = "SalesInputCode";

		/// <summary>������͎Җ���[����]</summary>
		public const string CT_OrderConf_SalesInputNameRF = "SalesInputName";

		/// <summary>�̔��]�ƈ��i�S���ҁj�R�[�h[����]</summary>
		public const string CT_OrderConf_SalesEmployeeCdRF = "SalesEmployeeCd";

		/// <summary>�̔��]�ƈ��i�S���ҁj����[����]</summary>
		public const string CT_OrderConf_SalesEmployeeNmRF = "SalesEmployeeNm";

		/// <summary>�󒍃X�e�[�^�X[����]</summary>
		/// <remarks>20:�� 40:�o��</remarks>
		public const string CT_OrderConf_AcptAnOdrStatusRF = "AcptAnOdrStatus";

		/// <summary>����`�[�ԍ�[�`�[]</summary>
		public const string CT_OrderConf_SalesSlipNumRF = "SalesSlipNum";

		/// <summary>����`�[�敪[�`�[]</summary>
		/// <remarks>0:����,1:�ԕi</remarks>
		public const string CT_OrderConf_SalesSlipCdRF = "SalesSlipCd";

		/// <summary>���|�敪[����]</summary>
		/// <remarks>0:���|�Ȃ�,1:���|</remarks>
		public const string CT_OrderConf_AccRecDivCd = "AccRecDivCd";

		/// <summary>����敪��[�`�[]</summary>
		/// <remarks>�����[�g���ŎZ�o(����`�[�敪�E���|�敪���g�p)</remarks>
		public const string CT_OrderConf_TransactionNameRF = "TransactionName";

		/// <summary>�`�[�������t(���͓��t)[����]</summary>
		/// <remarks>YYYYMMDD</remarks>
		public const string CT_OrderConf_SearchSlipDateRF = "SearchSlipDate";

		/// <summary>�o�ד��t[����]</summary>
		/// <remarks>YYYYMMDD</remarks>
		public const string CT_OrderConf_ShipmentDayRF = "ShipmentDay";

		/// <summary>����i�󒍁j���t[����]</summary>
		public const string CT_OrderConf_SalesDateRF = "SalesDate";

		/// <summary>�v����t(������)[����]</summary>
		/// <remarks>YYYYMMDD</remarks>
		public const string CT_OrderConf_AddUpADateRF = "AddUpADate";

		/// <summary>�����`�[�ԍ�[����]</summary>
		public const string CT_OrderConf_PartySaleSlipNumRF = "PartySaleSlipNum";

        // 2008.07.25 30413 ���� [����]�̍��ڒǉ� >>>>>>START
        /// <summary> ��t�]�ƈ��R�[�h[����] </summary>
        public const string CT_OrderConf_FrontEmployeeCd = "FrontEmployeeCd";
        /// <summary> ��t�]�ƈ�����[����] </summary>
        public const string CT_OrderConf_FrontEmployeeNm = "FrontEmployeeNm";
        // 2008.07.25 30413 ���� [����]�̍��ڒǉ� <<<<<<END
        // --- ADD 2009/01/30 -------------------------------->>>>>
        /// <summary> �󒍎c�� </summary>
        public const string CT_OrderConf_AcptAnOdrRemainCnt = "AcptAnOdrRemainCnt";
        /// <summary> �󒍐��� </summary>
        public const string CT_OrderConf_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> �󒍒����� </summary>
        public const string CT_OrderConf_AcptAnOdrAdjustCnt = "AcptAnOdrAdjustCnt";
        /// <summary> �󒍐� </summary>
        public const string CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt = "AcceptAnOrderCntPlusAdjustCnt";
        // --- ADD 2009/01/30 --------------------------------<<<<<

        /// <summary>����i�󒍁j�`�[���v(�Ŕ�)[�`�[]</summary>
		/// <remarks>(�l�����܂�)</remarks>
		public const string CT_OrderConf_SalesTotalTaxExcRF = "SalesTotalTaxExc";

		/// <summary>����i�󒍁j�`�[���v(�ō�)[�`�[]</summary>
		/// <remarks>(�l�����܂�)</remarks>
		public const string CT_OrderConf_SalesTotalTaxIncRF = "SalesTotalTaxInc";

		/// <summary>����i�󒍁j�l�����z�v(�Ŕ�)[�`�[]</summary>
		public const string CT_OrderConf_SalesDisTtlTaxExcRF = "SalesDisTtlTaxExc";

		/// <summary>����i�󒍁j�l�����z�v(�ō�)[�`�[]</summary>
		public const string CT_OrderConf_SalesDisTtlTaxIncluRF = "SalesDisTtlTaxInclu";

		/// <summary>�������z�v[�`�[]</summary>
		public const string CT_OrderConf_TotalCostRF = "TotalCost";

		/// <summary>�e����[�`�[]</summary>
		/// <remarks>�����[�g���ŎZ�o</remarks>
		public const string CT_OrderConf_GrossMarginRate = "GrossMarginRate";

		/// <summary>�e���`�F�b�N�}�[�N[�`�[]</summary>
		/// <remarks>�����[�g���ŎZ�o</remarks>
		public const string CT_OrderConf_GrossMarginMarkSlip = "GrossMarginMarkSlip";

        // 2008.07.25 30413 ���� [�`�[]�̍��ڒǉ� >>>>>>START
        /// <summary> �`�[���l[�`�[] </summary>
        public const string CT_OrderConf_SlipNote = "SlipNote";
        // 2008.07.25 30413 ���� [�`�[]�̍��ڒǉ� <<<<<<END
        

		/// <summary>����s�ԍ�[����]</summary>
		public const string CT_OrderConf_SalesRowNoRF = "SalesRowNo";

		/// <summary>����`�[�敪[����]</summary>
		/// <remarks>0:����,1:�ԕi,2:�l��,9:�ꎮ</remarks>
		public const string CT_OrderConf_SalesSlipCdDtlRF = "SalesSlipCdDtl";

		/// <summary>����`�[�敪��[����]</summary>
		/// <remarks>0:����,1:�ԕi,2:�l��,9:�ꎮ</remarks>
		public const string CT_OrderConf_SalesSlipNmDtl = "SalesSlipNmDtl";

		///// <summary>���i���[�J�[�R�[�h[����]</summary>
		//public const string CT_OrderConf_GoodsMakerCdRF = "GoodsMakerCd";

		/// <summary>���[�J�[����[����]</summary>
		public const string CT_OrderConf_MakerNameRF = "MakerName";

		/// <summary>���i�ԍ�[����]</summary>
		public const string CT_OrderConf_GoodsNoRF = "GoodsNo";

		/// <summary>���i����[����]</summary>
		public const string CT_OrderConf_GoodsNameRF = "GoodsName";

		///// <summary>�P�ʃR�[�h[����]</summary>
		//public const string CT_OrderConf_UnitCodeRF = "UnitCode";

		/// <summary>�P�ʖ���[����]</summary>
		public const string CT_OrderConf_UnitNameRF = "UnitName";

		/// <summary>�o�א��i���ʁj[����]</summary>
		public const string CT_OrderConf_ShipmentCntRF = "ShipmentCnt";

		///// <summary>����P��(�ō�)[����]</summary>
		//public const string CT_OrderConf_SalesUnPrcTaxIncFlRF = "SalesUnPrcTaxIncFl";

		/// <summary>����P��(�Ŕ�)[����]</summary>
		public const string CT_OrderConf_SalesUnPrcTaxExcFlRF = "SalesUnPrcTaxExcFl";

		///// <summary>������z(�ō�)[����]</summary>
		//public const string CT_OrderConf_SalesMoneyTaxIncRF = "SalesMoneyTaxInc";

		/// <summary>������z(�Ŕ�)[����]</summary>
		public const string CT_OrderConf_SalesMoneyTaxExcRF = "SalesMoneyTaxExc";

		/// <summary>�����P��[����]</summary>
		public const string CT_OrderConf_SalesUnitCostRF = "SalesUnitCost";

		/// <summary>�������z[����]</summary>
		public const string CT_OrderConf_CostRF = "Cost";

		/// <summary>�e����[����]</summary>
		/// <remarks>�����[�g���ŎZ�o</remarks>
		public const string CT_OrderConf_GrossMarginRateDtl = "GrossMarginRateDtl";

		/// <summary>�e���`�F�b�N�}�[�N[����]</summary>
		/// <remarks>�����[�g���ŎZ�o</remarks>
		public const string CT_OrderConf_GrossMarginMarkDtl = "GrossMarginMarkDtl";

		///// <summary>�����`�[�ԍ��i���Ӑ撍���ԍ��j[����]</summary>
		//public const string CT_OrderConf_PartySlipNumDtlRF = "PpartySlipNumDtl";

        // 2008.07.25 30413 ���� [����]�̍��ڒǉ� >>>>>>START
        /// <summary> �d����R�[�h[����] </summary>
        public const string CT_OrderConf_SupplierCd = "SupplierCd";
        /// <summary> �d���旪��[����] </summary>
        public const string CT_OrderConf_SupplierSnm = "SupplierSnm";
        /// <summary> �d���`�[�ԍ�[����] </summary>
        public const string CT_OrderConf_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> �q�ɃR�[�h[����]  </summary>
        public const string CT_OrderConf_WarehouseCode = "WarehouseCode";
        /// <summary> �q�ɖ���[����] </summary>
        public const string CT_OrderConf_WarehouseName = "WarehouseName";
        /// <summary> �Ǝ�R�[�h[����] </summary>
        public const string CT_OrderConf_BusinessTypeCode = "BusinessTypeCode";
        /// <summary> �Ǝ햼��[����] </summary>
        public const string CT_OrderConf_BusinessTypeName = "BusinessTypeName";
        /// <summary> �̔��敪�R�[�h[����] </summary>
        public const string CT_OrderConf_SalesCode = "SalesCode";
        /// <summary> �̔��敪����[����] </summary>
        public const string CT_OrderConf_SalesCdNm = "SalesCdNm";
        /// <summary> �Ԏ�S�p����[����] </summary>
        public const string CT_OrderConf_ModelFullName = "ModelFullName";
        /// <summary> �^���i�t���^�j[����] </summary>
        public const string CT_OrderConf_FullModel = "FullModel";
        /// <summary> �^���w��ԍ�[����] </summary>
        public const string CT_OrderConf_ModelDesignationNo = "ModelDesignationNo";
        /// <summary> �ޕʔԍ�[����] </summary>
        public const string CT_OrderConf_CategoryNo = "CategoryNo";
        /// <summary> ���q�Ǘ��R�[�h[����] </summary>
        public const string CT_OrderConf_CarMngCode = "CarMngCode";
        /// <summary> ���N�x[����] </summary>
        public const string CT_OrderConf_FirstEntryDate = "FirstEntryDate";
        /// <summary> �`�[���l�Q[����] </summary>
        public const string CT_OrderConf_SlipNote2 = "SlipNote2";
        /// <summary> �`�[���l�R[����] </summary>
        public const string CT_OrderConf_SlipNote3 = "SlipNote3";
        /// <summary> BL���i�R�[�h[����] </summary>
        public const string CT_OrderConf_BLGoodsCode = "BLGoodsCode";
        /// <summary> BL���i�R�[�h���́i�S�p�j[����] </summary>
        public const string CT_OrderConf_BLGoodsFullName = "BLGoodsFullName";
        /// <summary> ����݌Ɏ�񂹋敪 </summary>
        public const string CT_OrderConf_SalesOrderDivCd = "SalesOrderDivCd";
        // 2008.07.25 30413 ���� [����]�̍��ڒǉ� <<<<<<END

        // �����e�[�u����`���ȊO�̒ǉ�����
        /// <summary> ����`�[�敪���� </summary>
        public const string CT_OrderConf_SalesSlipName = "SalesSlipName";

        /// <summary> �ޕ�(����) </summary>
        public const string CT_OrderConf_CategoryDtl = "CategoryDtl";

        /// <summary> ����݌Ɏ�񂹋敪���� </summary>
        public const string CT_OrderConf_SalesOrderDivName = "SalesOrderDivName";

        /// <summary> ����� </summary>
        public const string CT_OrderConf_Tax = "Tax";

        /// <summary> �e��(�Ŕ���)(�`�[) </summary>
        public const string CT_OrderConf_GrossProfit = "GrossProfit";

        /// <summary> �e��(�Ŕ���)(����) </summary>
        public const string CT_OrderConf_GrossProfitDtl = "GrossProfitDtl";





		/// <summary>�e���`�F�b�N����</summary>
		public const string CT_OrderConf_GrsProfitCheckLower = "GrsProfitCheckLower";

		/// <summary>�e���`�F�b�N�K��</summary>
		public const string CT_OrderConf_GrsProfitCheckBest = "GrsProfitCheckBest";

		/// <summary>�e���`�F�b�N���</summary>
		public const string CT_OrderConf_GrsProfitCheckUpper = "GrsProfitCheckUpper";

		/// <summary>�����[�`�[] </summary>
		public const string CT_OrderConf_ConsTaxSlip = "ConsTaxSlip";

		/// <summary>�����[����] </summary>
		public const string CT_OrderConf_ConsTaxDtl = "ConsTaxDtl";

		/// <summary>����Łi����j[�`�[] </summary>
		public const string CT_OrderConf_ConsTaxSlSlip = "ConsTaxSlSlip";

		/// <summary>����Łi����j[����] </summary>
		public const string CT_OrderConf_ConsTaxSlDtl = "ConsTaxSlDtl";

		/// <summary>����Łi�ԕi�j[�`�[] </summary>
		public const string CT_OrderConf_ConsTaxRtnSlip = "ConsTaxRtnSlip";

		/// <summary>����Łi�ԕi�j[����] </summary>
		public const string CT_OrderConf_ConsTaxRtnDtl = "ConsTaxRtnDtl";

		/// <summary>����Łi�l�����j[�`�[] </summary>
		public const string CT_OrderConf_ConsTaxDisSlip = "ConsTaxDisSlip";

		/// <summary>����Łi�l�����j[����] </summary>
		public const string CT_OrderConf_ConsTaxDisDtl = "ConsTaxDisDtl";


        // 2009.01.27 30413 ���� ����łƍ��v���z�̒ǉ� >>>>>>START
        // �������v��[�`�[]�̒�`
        /// <summary>���㐔[�`�[] </summary>
        public const string CT_OrderConf_CntSales = "CntSales";
        
        /// <summary>����z[�`�[] </summary>
		public const string CT_OrderConf_SalesMoney = "SalesMoney";

        /// <summary>�������z�v�i����j[�`�[]</summary>
        public const string CT_OrderConf_TotalCostSl = "TotalCostSl";

        /// <summary>���㍇�v�e��(�Ŕ���)(�`�[)</summary>
        public const string CT_OrderConf_SalesGrossProfit = "SalesGrossProfit";

        /// <summary>���㍇�v�����(�`�[)</summary>
        public const string CT_OrderConf_SalesTax = "SalesTax";

        /// <summary>����̏���ō����v���z(�`�[)</summary>
        public const string CT_OrderConf_SalesTotalAll = "SalesTotalAll";

        /// <summary>�ԕi��[�`�[] </summary>
        public const string CT_OrderConf_CntReturn = "CntReturn";

		/// <summary>�ԕi�z[�`�[] </summary>
		public const string CT_OrderConf_ReturnSalesMoney = "ReturnSalesMoney";
        
        /// <summary>�������z�v�i�ԕi�j[�`�[]</summary>
        public const string CT_OrderConf_TotalCostRtn = "TotalCostRtn";

        /// <summary>�ԕi���v�e��(�Ŕ���)(�`�[)</summary>
        public const string CT_OrderConf_ReturnGrossProfit = "ReturnGrossProfit";

        /// <summary>�ԕi���v�����(�`�[)</summary>
        public const string CT_OrderConf_ReturnTax = "ReturnTax";

        /// <summary>�ԕi�̏���ō����v���z(�`�[)</summary>
        public const string CT_OrderConf_ReturnTotalAll = "ReturnTotalAll";

        /// <summary>�l�������v����(�Ŕ���)(�`�[)</summary>
        public const string CT_OrderConf_DistCost = "DistCost";

        /// <summary>�l�������v�e��(�Ŕ���)(�`�[)</summary>
        public const string CT_OrderConf_DistGrossProfit = "DistGrossProfit";

        /// <summary>�l�������v�����(�`�[)</summary>
        public const string CT_OrderConf_DistTax = "DistTax";

        /// <summary>�l�����̏���ō����v���z(�`�[)</summary>
        public const string CT_OrderConf_DistTotalAll = "DistTotalAll";


        // �������v��[����]�̒ǉ�����
        /// <summary>���㐔[����] </summary>
        public const string CT_OrderConf_CntSalesDtl = "CntSalesDtl";

        /// <summary>�w����x�z[����] </summary>
        public const string CT_OrderConf_SalesMoneyDtl = "SalesMoneyDtl";

        /// <summary>�������z�v�i����j[����]</summary>
        public const string CT_OrderConf_TotalCostDtl = "TotalCostDtl";

        /// <summary>���㍇�v�e��(�Ŕ���)(����)</summary>
        public const string CT_OrderConf_SalesGrossProfitDtl = "SalesGrossProfitDtl";

        /// <summary>���㍇�v�����(����)</summary>
        public const string CT_OrderConf_SalesDtlTax = "SalesDtlTax";

        /// <summary>�ԕi��[����] </summary>
        public const string CT_OrderConf_CntReturnDtl = "CntReturnDtl";

        /// <summary>�ԕi�z[����] </summary>
        public const string CT_OrderConf_SalesMoneyRtnDtl = "SalesMoneyRtnDtl";

        /// <summary>�������z�i�ԕi�j[����]</summary>
        public const string CT_OrderConf_TotalCostRtnDtl = "TotalCostRtnDtl";

        /// <summary>�ԕi���v�e��(�Ŕ���)(����)</summary>
        public const string CT_OrderConf_ReturnGrossProfitDtl = "ReturnGrossProfitDtl";

        /// <summary>�ԕi���v�����(����)</summary>
        public const string CT_OrderConf_ReturnDtlTax = "ReturnDtlTax";

        /// <summary>�w�l���x���z[����]</summary>
        public const string CT_OrderConf_SalesDisTtlTaxExcDtl = "SalesDisTtlTaxExcDtl";

        /// <summary>�l�������v�������z(�Ŕ���)(����)</summary>
        public const string CT_OrderConf_DistDtlCost = "DistDtlCost";

        /// <summary>�l�������v�e��(�Ŕ���)(����)</summary>
        public const string CT_OrderConf_DistGrossProfitDtl = "DistGrossProfitDtl";

        /// <summary>�l�������v�����(����)</summary>
        public const string CT_OrderConf_DistDtlTax = "DistDtlTax";
        // 2009.01.27 30413 ���� ����łƍ��v���z�̒ǉ� <<<<<<END
        


		/// <summary>������i�������z�j[�`�[]</summary>
		public const string CT_OrderConf_PureTotalCost = "PureTotalCost";
		
		/// <summary>������i�������z�j[����]</summary>
		public const string CT_OrderConf_PureTotalCostDtl = "PureTotalCostDtl";

		///// <summary>�w�l���x�������z[����]</summary>
		//public const string CT_OrderConf_TotalDisCostRtnDtl = "TotalDisCostRtnDtl";

        // --- ADD 2008/10/31 ------------------------------------------------------------>>>>>
        /// <summary>����œ]�ŕ���[�`�[]</summary>
        public const string CT_OrderConf_ConsTaxLayMethod = "ConsTaxLayMethod";
        /// <summary>�ېŋ敪[����]</summary>
        public const string CT_OrderConf_TaxationDivCd = "TaxationDivCd";
        /// <summary>���v���z(���z�{�����)</summary>
        public const string CT_OrderConf_SalesTotalTaxExcPlusTax = "SalesTotalTaxExcPlusTax";
        // --- ADD 2008/10/31 ------------------------------------------------------------<<<<<

        // 2008.11.27 30413 ���� ������ڂ̒ǉ� >>>>>>START
        /// <summary> �艿�i�Ŕ��C�����j </summary>
        public const string CT_OrderConf_ListPriceTaxExcFl = "ListPriceTaxExcFl";
        // 2008.11.27 30413 ���� ������ڂ̒ǉ� <<<<<<END
        
		public const string COL_KEYBREAK_AR = "KEYBREAK_AR";				// �L�[�u���C�N

		#endregion

		#endregion

		#region Constructor
		/// <summary>
		/// �󒍏o�׊m�F�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br> �󒍏o�׊m�F�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
		/// </remarks>
		public DCHNB02014EA()
		{
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
		/// </summary>
		public static void SettingDataSet(ref DataSet ds)
		{
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
			if ((ds.Tables.Contains(CT_OrderConfDataTable)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				ds.Tables[CT_OrderConfDataTable].Clear();
			}
			else
			{
				CreateSaleConfTable(ref ds, 0);

			}

			// ����`�F�b�N���X�g�o�b�t�@�f�[�^�e�[�u��------------------------------------------
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
			if ((ds.Tables.Contains(CT_OrderConfBuffDataTable)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				ds.Tables[CT_OrderConfBuffDataTable].Clear();
			}
			else
			{
				CreateSaleConfTable(ref ds, 1);
			}
		}

		#endregion

		#region Private Methods
		
		/// <summary>
		/// �󒍏o�׊m�F�\(�`�[�`��)���o���ʍ쐬����
		/// </summary>
		/// <remarks>
        private static void CreateSaleConfTable(ref DataSet ds, int buffCheck)
        {
            DataTable dt = null;
            if (buffCheck == 0)
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(CT_OrderConfDataTable);
                dt = ds.Tables[CT_OrderConfDataTable];
            }
            else
            {
                // �X�L�[�}�ݒ�
                ds.Tables.Add(CT_OrderConfBuffDataTable);
                dt = ds.Tables[CT_OrderConfBuffDataTable];
            }

            // ���_�R�[�h
            dt.Columns.Add(CT_OrderConf_SectionCode, typeof(string));
            dt.Columns[CT_OrderConf_SectionCode].DefaultValue = "";
            // ���_�K�C�h���́i���_���́j
            dt.Columns.Add(CT_OrderConf_SectionGuideNm, typeof(string));
            dt.Columns[CT_OrderConf_SectionGuideNm].DefaultValue = "";
            // ���Ӑ�R�[�h
            dt.Columns.Add(CT_OrderConf_CustomerCodeRF, typeof(Int32));
            dt.Columns[CT_OrderConf_CustomerCodeRF].DefaultValue = 0;
            // ���Ӑ於��
            dt.Columns.Add(CT_OrderConf_CustomerSnmRF, typeof(string));
            dt.Columns[CT_OrderConf_CustomerSnmRF].DefaultValue = "";
            //������͎҃R�[�h[����]
            dt.Columns.Add(CT_OrderConf_SalesInputCodeRF, typeof(string));
            dt.Columns[CT_OrderConf_SalesInputCodeRF].DefaultValue = "";
            //������͎Җ���[����]
            dt.Columns.Add(CT_OrderConf_SalesInputNameRF, typeof(string));
            dt.Columns[CT_OrderConf_SalesInputNameRF].DefaultValue = "";
            //�̔��]�ƈ��i�S���ҁj�R�[�h[����]
            dt.Columns.Add(CT_OrderConf_SalesEmployeeCdRF, typeof(string));
            dt.Columns[CT_OrderConf_SalesEmployeeCdRF].DefaultValue = "";
            //�̔��]�ƈ��i�S���ҁj����[����]
            dt.Columns.Add(CT_OrderConf_SalesEmployeeNmRF, typeof(string));
            dt.Columns[CT_OrderConf_SalesEmployeeNmRF].DefaultValue = "";
            //�󒍃X�e�[�^�X[����]
            dt.Columns.Add(CT_OrderConf_AcptAnOdrStatusRF, typeof(Int32));
            dt.Columns[CT_OrderConf_AcptAnOdrStatusRF].DefaultValue = 0;
            //����`�[�ԍ�[�`�[]
            dt.Columns.Add(CT_OrderConf_SalesSlipNumRF, typeof(string));
            dt.Columns[CT_OrderConf_SalesSlipNumRF].DefaultValue = "";
            //����`�[�敪[�`�[]	0:����,1:�ԕi
            dt.Columns.Add(CT_OrderConf_SalesSlipCdRF, typeof(Int32));
            dt.Columns[CT_OrderConf_SalesSlipCdRF].DefaultValue = 0;
            //���|�敪[����]		0:���|�Ȃ�,1:���|
            dt.Columns.Add(CT_OrderConf_AccRecDivCd, typeof(Int32));
            dt.Columns[CT_OrderConf_AccRecDivCd].DefaultValue = 0;
            //����敪��[�`�[]
            dt.Columns.Add(CT_OrderConf_TransactionNameRF, typeof(string));
            dt.Columns[CT_OrderConf_TransactionNameRF].DefaultValue = "";
            //�`�[�������t(���͓��t)[����]
            dt.Columns.Add(CT_OrderConf_SearchSlipDateRF, typeof(DateTime));
            dt.Columns[CT_OrderConf_SearchSlipDateRF].DefaultValue = null;
            // �o�ד��t[����]
            dt.Columns.Add(CT_OrderConf_ShipmentDayRF, typeof(DateTime));
            dt.Columns[CT_OrderConf_ShipmentDayRF].DefaultValue = null;
            // ����i�󒍁j���t[����] 
            dt.Columns.Add(CT_OrderConf_SalesDateRF, typeof(DateTime));
            dt.Columns[CT_OrderConf_SalesDateRF].DefaultValue = null;
            //�v����t(������)[����]
            dt.Columns.Add(CT_OrderConf_AddUpADateRF, typeof(DateTime));
            dt.Columns[CT_OrderConf_AddUpADateRF].DefaultValue = null;
            //�����`�[�ԍ�[����]
            dt.Columns.Add(CT_OrderConf_PartySaleSlipNumRF, typeof(string));
            dt.Columns[CT_OrderConf_PartySaleSlipNumRF].DefaultValue = "";

            // 2008.07.25 30413 ���� [����]�̍��ڒǉ� >>>>>>START
            // ��t�]�ƈ��R�[�h[����]
            dt.Columns.Add(CT_OrderConf_FrontEmployeeCd, typeof(string));
            dt.Columns[CT_OrderConf_FrontEmployeeCd].DefaultValue = "";
            // ��t�]�ƈ�����[����]
            dt.Columns.Add(CT_OrderConf_FrontEmployeeNm, typeof(string));
            dt.Columns[CT_OrderConf_FrontEmployeeNm].DefaultValue = "";
            // 2008.07.25 30413 ���� [����]�̍��ڒǉ� <<<<<<END


            //����i�󒍁j�`�[���v(�Ŕ�)[�`�[]
            dt.Columns.Add(CT_OrderConf_SalesTotalTaxIncRF, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesTotalTaxIncRF].DefaultValue = 0;
            //����i�󒍁j�`�[���v(�ō�)[�`�[]
            dt.Columns.Add(CT_OrderConf_SalesTotalTaxExcRF, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesTotalTaxExcRF].DefaultValue = 0;
            //����i�󒍁j�l�����z�v(�Ŕ�)[�`�[]
            dt.Columns.Add(CT_OrderConf_SalesDisTtlTaxExcRF, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesDisTtlTaxExcRF].DefaultValue = 0;
            //����i�󒍁j�l�����z�v(�ō�)[�`�[]
            dt.Columns.Add(CT_OrderConf_SalesDisTtlTaxIncluRF, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesDisTtlTaxIncluRF].DefaultValue = 0;
            //�������z�v[�`�[]
            dt.Columns.Add(CT_OrderConf_TotalCostRF, typeof(Int64));
            dt.Columns[CT_OrderConf_TotalCostRF].DefaultValue = 0;
            //�e����[�`�[]
            dt.Columns.Add(CT_OrderConf_GrossMarginRate, typeof(Double));
            dt.Columns[CT_OrderConf_GrossMarginRate].DefaultValue = 0.0;
            //�e���`�F�b�N�}�[�N[�`�[]
            dt.Columns.Add(CT_OrderConf_GrossMarginMarkSlip, typeof(string));
            dt.Columns[CT_OrderConf_GrossMarginMarkSlip].DefaultValue = "";

            // 2008.07.25 30413 ���� [�`�[]�̍��ڒǉ� >>>>>>START
            // �`�[���l[�`�[]
            dt.Columns.Add(CT_OrderConf_SlipNote, typeof(string));
            dt.Columns[CT_OrderConf_SlipNote].DefaultValue = "";
            // 2008.07.25 30413 ���� [�`�[]�̍��ڒǉ� <<<<<<END


            //����s�ԍ�[����]
            dt.Columns.Add(CT_OrderConf_SalesRowNoRF, typeof(Int32));
            dt.Columns[CT_OrderConf_SalesRowNoRF].DefaultValue = 0;
            //����`�[�敪[����]
            dt.Columns.Add(CT_OrderConf_SalesSlipCdDtlRF, typeof(Int32));
            dt.Columns[CT_OrderConf_SalesSlipCdDtlRF].DefaultValue = 0;
            //����`�[�敪��[����]
            dt.Columns.Add(CT_OrderConf_SalesSlipNmDtl, typeof(string));
            dt.Columns[CT_OrderConf_SalesSlipNmDtl].DefaultValue = "";
            ////���i���[�J�[�R�[�h[����]
            //dt.Columns.Add(CT_OrderConf_GoodsMakerCdRF, typeof(Int32));
            //dt.Columns[CT_OrderConf_GoodsMakerCdRF].DefaultValue = 0;
            //���[�J�[����[����]
            dt.Columns.Add(CT_OrderConf_MakerNameRF, typeof(string));
            dt.Columns[CT_OrderConf_MakerNameRF].DefaultValue = "";
            // ���i�ԍ�[����]
            dt.Columns.Add(CT_OrderConf_GoodsNoRF, typeof(string));
            dt.Columns[CT_OrderConf_GoodsNoRF].DefaultValue = "";
            // ���i����[����]
            dt.Columns.Add(CT_OrderConf_GoodsNameRF, typeof(string));
            dt.Columns[CT_OrderConf_GoodsNameRF].DefaultValue = "";
            //�P�ʃR�[�h[����]
            //dt.Columns.Add(CT_OrderConf_UnitCodeRF, typeof(Int32));
            //dt.Columns[CT_OrderConf_UnitCodeRF].DefaultValue = 0;
            //�P�ʖ���[����]
            dt.Columns.Add(CT_OrderConf_UnitNameRF, typeof(string));
            dt.Columns[CT_OrderConf_UnitNameRF].DefaultValue = "";
            //�o�א��i���ʁj[����]
            dt.Columns.Add(CT_OrderConf_ShipmentCntRF, typeof(Double));
            dt.Columns[CT_OrderConf_ShipmentCntRF].DefaultValue = 0;
            ////����P��(�ō�)[����]
            //dt.Columns.Add(CT_OrderConf_SalesUnPrcTaxIncFlRF, typeof(Int64));
            //dt.Columns[CT_OrderConf_SalesUnPrcTaxIncFlRF].DefaultValue = 0;
            //����P��(�Ŕ�)[����]
            dt.Columns.Add(CT_OrderConf_SalesUnPrcTaxExcFlRF, typeof(Double));
            dt.Columns[CT_OrderConf_SalesUnPrcTaxExcFlRF].DefaultValue = 0;
            ////������z(�ō�)[����]
            //dt.Columns.Add(CT_OrderConf_SalesMoneyTaxIncRF, typeof(Int64));
            //dt.Columns[CT_OrderConf_SalesMoneyTaxIncRF].DefaultValue = 0;
            //������z(�Ŕ�)[����]
            dt.Columns.Add(CT_OrderConf_SalesMoneyTaxExcRF, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesMoneyTaxExcRF].DefaultValue = 0;
            //�����P��[����]
            dt.Columns.Add(CT_OrderConf_SalesUnitCostRF, typeof(Double));
            dt.Columns[CT_OrderConf_SalesUnitCostRF].DefaultValue = 0;
            //�������z[����]
            dt.Columns.Add(CT_OrderConf_CostRF, typeof(Int64));
            dt.Columns[CT_OrderConf_CostRF].DefaultValue = 0;
            //�e����[����]
            dt.Columns.Add(CT_OrderConf_GrossMarginRateDtl, typeof(Double));
            dt.Columns[CT_OrderConf_GrossMarginRateDtl].DefaultValue = 0;
            //�e���`�F�b�N�}�[�N[����]
            dt.Columns.Add(CT_OrderConf_GrossMarginMarkDtl, typeof(string));
            dt.Columns[CT_OrderConf_GrossMarginMarkDtl].DefaultValue = "";
            ////�����`�[�ԍ�[����]
            //dt.Columns.Add(CT_OrderConf_PartySlipNumDtlRF, typeof(string));
            //dt.Columns[CT_OrderConf_PartySlipNumDtlRF].DefaultValue = "";

            // 2008.07.25 30413 ���� [����]�̍��ڒǉ� >>>>>>START
            // �d����R�[�h[����]
            dt.Columns.Add(CT_OrderConf_SupplierCd, typeof(string));
            dt.Columns[CT_OrderConf_SupplierCd].DefaultValue = "";
            // �d���旪��[����]
            dt.Columns.Add(CT_OrderConf_SupplierSnm, typeof(string));
            dt.Columns[CT_OrderConf_SupplierSnm].DefaultValue = "";
            // �d���`�[�ԍ�[����]
            dt.Columns.Add(CT_OrderConf_SupplierSlipNo, typeof(string));
            dt.Columns[CT_OrderConf_SupplierSlipNo].DefaultValue = "";
            // �q�ɃR�[�h[����]
            dt.Columns.Add(CT_OrderConf_WarehouseCode, typeof(string));
            dt.Columns[CT_OrderConf_WarehouseCode].DefaultValue = "";
            // �q�ɖ���[����]
            dt.Columns.Add(CT_OrderConf_WarehouseName, typeof(string));
            dt.Columns[CT_OrderConf_WarehouseName].DefaultValue = "";
            // �Ǝ�R�[�h[����]
            dt.Columns.Add(CT_OrderConf_BusinessTypeCode, typeof(Int32));
            dt.Columns[CT_OrderConf_BusinessTypeCode].DefaultValue = 0;
            // �Ǝ햼��[����]
            dt.Columns.Add(CT_OrderConf_BusinessTypeName, typeof(string));
            dt.Columns[CT_OrderConf_BusinessTypeName].DefaultValue = "";
            // �̔��敪�R�[�h[����]
            dt.Columns.Add(CT_OrderConf_SalesCode, typeof(string));
            dt.Columns[CT_OrderConf_SalesCode].DefaultValue = "";
            // �̔��敪����[����]
            dt.Columns.Add(CT_OrderConf_SalesCdNm, typeof(string));
            dt.Columns[CT_OrderConf_SalesCdNm].DefaultValue = "";
            // �Ԏ�S�p����[����]
            dt.Columns.Add(CT_OrderConf_ModelFullName, typeof(string));
            dt.Columns[CT_OrderConf_ModelFullName].DefaultValue = "";
            // �^���i�t���^�j[����]
            dt.Columns.Add(CT_OrderConf_FullModel, typeof(string));
            dt.Columns[CT_OrderConf_FullModel].DefaultValue = "";
            // �^���w��ԍ�[����]
            dt.Columns.Add(CT_OrderConf_ModelDesignationNo, typeof(Int32));
            dt.Columns[CT_OrderConf_ModelDesignationNo].DefaultValue = 0;
            // �ޕʔԍ�[����]
            dt.Columns.Add(CT_OrderConf_CategoryNo, typeof(Int32));
            dt.Columns[CT_OrderConf_CategoryNo].DefaultValue = 0;
            // ���q�Ǘ��R�[�h[����]
            dt.Columns.Add(CT_OrderConf_CarMngCode, typeof(string));
            dt.Columns[CT_OrderConf_CarMngCode].DefaultValue = "";
            // ���N�x[����]
            dt.Columns.Add(CT_OrderConf_FirstEntryDate, typeof(string));
            dt.Columns[CT_OrderConf_FirstEntryDate].DefaultValue = "";
            // �`�[���l�Q[����]
            dt.Columns.Add(CT_OrderConf_SlipNote2, typeof(string));
            dt.Columns[CT_OrderConf_SlipNote2].DefaultValue = "";
            // �`�[���l�R[����]
            dt.Columns.Add(CT_OrderConf_SlipNote3, typeof(string));
            dt.Columns[CT_OrderConf_SlipNote3].DefaultValue = "";
            // BL���i�R�[�h[����]
            dt.Columns.Add(CT_OrderConf_BLGoodsCode, typeof(string));
            dt.Columns[CT_OrderConf_BLGoodsCode].DefaultValue = "";
            // ����݌Ɏ�񂹋敪
            dt.Columns.Add(CT_OrderConf_SalesOrderDivCd, typeof(Int32));
            dt.Columns[CT_OrderConf_SalesOrderDivCd].DefaultValue = 0;
            // 2008.07.25 30413 ���� [����]�̍��ڒǉ� <<<<<<END
            // --- ADD 2009/01/30 -------------------------------->>>>>
            // �󒍎c��
            dt.Columns.Add(CT_OrderConf_AcptAnOdrRemainCnt, typeof(double));
            dt.Columns[CT_OrderConf_AcptAnOdrRemainCnt].DefaultValue = 0;

            // �󒍐���
            dt.Columns.Add(CT_OrderConf_AcceptAnOrderCnt, typeof(double));
            dt.Columns[CT_OrderConf_AcceptAnOrderCnt].DefaultValue = 0;

            // �󒍒�����
            dt.Columns.Add(CT_OrderConf_AcptAnOdrAdjustCnt, typeof(double));
            dt.Columns[CT_OrderConf_AcptAnOdrAdjustCnt].DefaultValue = 0;

            // �󒍐�
            dt.Columns.Add(CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt, typeof(double));
            dt.Columns[CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt].DefaultValue = 0;
            // --- ADD 2009/01/30 --------------------------------<<<<<

            // �����e�[�u����`���ȊO�̒ǉ�����
            // ����`�[�敪����
            dt.Columns.Add(CT_OrderConf_SalesSlipName, typeof(string));
            dt.Columns[CT_OrderConf_SalesSlipName].DefaultValue = "";

            // �ޕ�(����)
            dt.Columns.Add(CT_OrderConf_CategoryDtl, typeof(string));
            dt.Columns[CT_OrderConf_CategoryDtl].DefaultValue = "";

            // ����݌Ɏ�񂹋敪����
            dt.Columns.Add(CT_OrderConf_SalesOrderDivName, typeof(string));
            dt.Columns[CT_OrderConf_SalesOrderDivName].DefaultValue = "";

            // �����
            dt.Columns.Add(CT_OrderConf_Tax, typeof(Int64));
            dt.Columns[CT_OrderConf_Tax].DefaultValue = 0;

            // �e��(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_OrderConf_GrossProfit, typeof(Int64));
            dt.Columns[CT_OrderConf_GrossProfit].DefaultValue = 0;

            // �e��(�Ŕ���)(����)
            dt.Columns.Add(CT_OrderConf_GrossProfitDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_GrossProfitDtl].DefaultValue = 0;




            //�e���`�F�b�N����
            dt.Columns.Add(CT_OrderConf_GrsProfitCheckLower, typeof(Double));
            dt.Columns[CT_OrderConf_GrsProfitCheckLower].DefaultValue = 0;
            //�e���`�F�b�N�K��
            dt.Columns.Add(CT_OrderConf_GrsProfitCheckBest, typeof(Double));
            dt.Columns[CT_OrderConf_GrsProfitCheckBest].DefaultValue = 0;
            //�e���`�F�b�N���
            dt.Columns.Add(CT_OrderConf_GrsProfitCheckUpper, typeof(Double));
            dt.Columns[CT_OrderConf_GrsProfitCheckUpper].DefaultValue = 0;
            //�����[�`�[]
            dt.Columns.Add(CT_OrderConf_ConsTaxSlip, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxSlip].DefaultValue = 0;
            //�����[����]
            dt.Columns.Add(CT_OrderConf_ConsTaxDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxDtl].DefaultValue = 0;
            //����Łi����j[�`�[]
            dt.Columns.Add(CT_OrderConf_ConsTaxSlSlip, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxSlSlip].DefaultValue = 0;
            //����Łi����j[����]
            dt.Columns.Add(CT_OrderConf_ConsTaxSlDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxSlDtl].DefaultValue = 0;
            //����Łi�ԕi�j[�`�[]
            dt.Columns.Add(CT_OrderConf_ConsTaxRtnSlip, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxRtnSlip].DefaultValue = 0;
            //����Łi�ԕi�j[����]
            dt.Columns.Add(CT_OrderConf_ConsTaxRtnDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxRtnDtl].DefaultValue = 0;
            //����Łi�l���j[�`�[]
            dt.Columns.Add(CT_OrderConf_ConsTaxDisSlip, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxDisSlip].DefaultValue = 0;
            //����Łi�l���j[����]
            dt.Columns.Add(CT_OrderConf_ConsTaxDisDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxDisDtl].DefaultValue = 0;


            // 2009.01.27 30413 ���� ����łƍ��v���z�̒ǉ� >>>>>>START
            // �������v��[�`�[]�̐ݒ�
            //���㐔[�`�[]
            dt.Columns.Add(CT_OrderConf_CntSales, typeof(Int32));
            dt.Columns[CT_OrderConf_CntSales].DefaultValue = 0;
            //����z[�`�[]
            dt.Columns.Add(CT_OrderConf_SalesMoney, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesMoney].DefaultValue = 0;
            //�������z�v�i����j[�`�[]
            dt.Columns.Add(CT_OrderConf_TotalCostSl, typeof(Int64));
            dt.Columns[CT_OrderConf_TotalCostSl].DefaultValue = 0;
            //���㍇�v�e��(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_OrderConf_SalesGrossProfit, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesGrossProfit].DefaultValue = 0;
            // ���㍇�v�����(�`�[)
            dt.Columns.Add(CT_OrderConf_SalesTax, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesTax].DefaultValue = 0;
            // ����̏���ō����v���z(�`�[)
            dt.Columns.Add(CT_OrderConf_SalesTotalAll, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesTotalAll].DefaultValue = 0;

            //�ԕi��[�`�[]
            dt.Columns.Add(CT_OrderConf_CntReturn, typeof(Int32));
            dt.Columns[CT_OrderConf_CntReturn].DefaultValue = 0;
            //�ԕi�z[�`�[]
            dt.Columns.Add(CT_OrderConf_ReturnSalesMoney, typeof(Int64));
            dt.Columns[CT_OrderConf_ReturnSalesMoney].DefaultValue = 0;
            //�������z�v�i�ԕi�j[�`�[]
            dt.Columns.Add(CT_OrderConf_TotalCostRtn, typeof(Int64));
            dt.Columns[CT_OrderConf_TotalCostRtn].DefaultValue = 0;
            //�ԕi���v�e��(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_OrderConf_ReturnGrossProfit, typeof(Int64));
            dt.Columns[CT_OrderConf_ReturnGrossProfit].DefaultValue = 0;
            // �ԕi���v�����(�`�[)
            dt.Columns.Add(CT_OrderConf_ReturnTax, typeof(Int64));
            dt.Columns[CT_OrderConf_ReturnTax].DefaultValue = 0;
            // �ԕi�̏���ō����v���z(�`�[)
            dt.Columns.Add(CT_OrderConf_ReturnTotalAll, typeof(Int64));
            dt.Columns[CT_OrderConf_ReturnTotalAll].DefaultValue = 0;

            //�l�������v����(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_OrderConf_DistCost, typeof(Int64));
            dt.Columns[CT_OrderConf_DistCost].DefaultValue = 0;
            //�l�������v�e��(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_OrderConf_DistGrossProfit, typeof(Int64));
            dt.Columns[CT_OrderConf_DistGrossProfit].DefaultValue = 0;
            // �l�������v�����(�`�[)
            dt.Columns.Add(CT_OrderConf_DistTax, typeof(Int64));
            dt.Columns[CT_OrderConf_DistTax].DefaultValue = 0;
            // �l�����̏���ō����v���z(�`�[)
            dt.Columns.Add(CT_OrderConf_DistTotalAll, typeof(Int64));
            dt.Columns[CT_OrderConf_DistTotalAll].DefaultValue = 0;

            // �������v��[����]�̐ݒ�
            //���㐔[����]
            dt.Columns.Add(CT_OrderConf_CntSalesDtl, typeof(Int32));
            dt.Columns[CT_OrderConf_CntSalesDtl].DefaultValue = 0;
            //����z[����]
            dt.Columns.Add(CT_OrderConf_SalesMoneyDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesMoneyDtl].DefaultValue = 0;
            //�������z�v�i����j[����]
            dt.Columns.Add(CT_OrderConf_TotalCostDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_TotalCostDtl].DefaultValue = 0;
            //���㍇�v�e��(�Ŕ���)(����)
            dt.Columns.Add(CT_OrderConf_SalesGrossProfitDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesGrossProfitDtl].DefaultValue = 0;
            // ���㍇�v�����(����)
            dt.Columns.Add(CT_OrderConf_SalesDtlTax, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesDtlTax].DefaultValue = 0;

            //�ԕi��[����]
            dt.Columns.Add(CT_OrderConf_CntReturnDtl, typeof(Int32));
            dt.Columns[CT_OrderConf_CntReturnDtl].DefaultValue = 0;
            //�ԕi�z[����]
            dt.Columns.Add(CT_OrderConf_SalesMoneyRtnDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesMoneyRtnDtl].DefaultValue = 0;
            //�������z�v�i�ԕi�j[����]
            dt.Columns.Add(CT_OrderConf_TotalCostRtnDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_TotalCostRtnDtl].DefaultValue = 0;
            //�ԕi���v�e��(�Ŕ���)(����)
            dt.Columns.Add(CT_OrderConf_ReturnGrossProfitDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_ReturnGrossProfitDtl].DefaultValue = 0;
            // �ԕi���v�����(����)
            dt.Columns.Add(CT_OrderConf_ReturnDtlTax, typeof(Int64));
            dt.Columns[CT_OrderConf_ReturnDtlTax].DefaultValue = 0;

            //�w�l���x���z[����]
            dt.Columns.Add(CT_OrderConf_SalesDisTtlTaxExcDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesDisTtlTaxExcDtl].DefaultValue = 0;
            // �l�������v�������z(�Ŕ���)(����)
            dt.Columns.Add(CT_OrderConf_DistDtlCost, typeof(Int64));
            dt.Columns[CT_OrderConf_DistDtlCost].DefaultValue = 0;
            // �l�������v�e��(�Ŕ���)(����)
            dt.Columns.Add(CT_OrderConf_DistGrossProfitDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_DistGrossProfitDtl].DefaultValue = 0;
            // �l�������v�����(����)
            dt.Columns.Add(CT_OrderConf_DistDtlTax, typeof(Int64));
            dt.Columns[CT_OrderConf_DistDtlTax].DefaultValue = 0;
            // 2009.01.27 30413 ���� ����łƍ��v���z�̒ǉ� <<<<<<END


            //������[�`�[]
            dt.Columns.Add(CT_OrderConf_PureTotalCost, typeof(Int64));
            dt.Columns[CT_OrderConf_PureTotalCost].DefaultValue = 0;
            //������[����]
            dt.Columns.Add(CT_OrderConf_PureTotalCostDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_PureTotalCostDtl].DefaultValue = 0;
            ////�w�l���x�������z[����]
            //dt.Columns.Add(CT_OrderConf_TotalDisCostRtnDtl, typeof(Int64));
            //dt.Columns[CT_OrderConf_TotalDisCostRtnDtl].DefaultValue = 0;

            // --- ADD 2008/10/31 ------------------------------------------------------------>>>>>
            // ����œ]�ŕ���[�`�[]
            dt.Columns.Add(CT_OrderConf_ConsTaxLayMethod, typeof(Int32));
            dt.Columns[CT_OrderConf_ConsTaxLayMethod].DefaultValue = 0;
            // �ېŋ敪[����]
            dt.Columns.Add(CT_OrderConf_TaxationDivCd, typeof(Int32));
            dt.Columns[CT_OrderConf_TaxationDivCd].DefaultValue = 0;
            // ������z����Ŋz�i���Łj[�`�[]
            dt.Columns.Add(CT_OrderConf_SalesTotalTaxExcPlusTax, typeof(Double));
            dt.Columns[CT_OrderConf_SalesTotalTaxExcPlusTax].DefaultValue = 0;
            // --- ADD 2008/10/31 ------------------------------------------------------------<<<<<

            // 2008.11.27 30413 ���� ������ڂ̒ǉ� >>>>>>START
            // �艿�i�Ŕ��C�����j
            dt.Columns.Add(CT_OrderConf_ListPriceTaxExcFl, typeof(Double));
            dt.Columns[CT_OrderConf_ListPriceTaxExcFl].DefaultValue = 0;
            // 2008.11.27 30413 ���� ������ڂ̒ǉ� <<<<<<END

#if false
				//
				dt.Columns.Add(,typeof());
				dt.Columns[].DefaultValue = ;
#endif


            // �L�[�u���C�N
            dt.Columns.Add(COL_KEYBREAK_AR, typeof(string));
            dt.Columns[COL_KEYBREAK_AR].DefaultValue = "";
        }

		#endregion

		}
	}
