using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// ����m�F�\(���גP��)���o���ʃf�[�^�e�[�u���X�L�[�}�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ����m�F�\(���גP��)�̒��o���ʃe�[�u���X�L�[�}�ł��B</br>
	/// <br>Programmer : 22021�@�J���@�͍K</br>
	/// <br>Date       : 2006.01.27</br>
    /// <br>UpdateNote : 2008/10/31 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/06/29 30517 �Ė� �x��</br>
    /// <br>             Mantis.15691�@�Ԏ햼�̈󎚂��Ԏ�S�p���̂���Ԏ피�p���̂֕ύX����B</br>
    /// <br>UpdateNote : 2010/07/14 30531 ��� �r��</br>
    /// <br>           : Mantis�y15806�z�i���ɓ`�[�Ɠ������i���J�i���Z�b�g����悤�ɏC��</br>
    /// <br>UpdateNote : 2011/07/18 �{��</br>
    /// <br>           : �����񓚂�ǉ�����</br>
    /// <br>UpdateNote : 2011/11/29 ����</br>
    /// <br>           : ��Q�� #8076����m�F�\/�����`�[�ƍ폜�`�[�̋�ʂɂ��Ă̑Ή�</br>
    /// <br>Update Note: 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : 2020/02/27 3H ����</br>
    /// <br>Update Note: 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// <br>Programmer : 2020/09/05  ���O</br>
    /// </remarks>
	public class MAHNB02349EA
	{
		#region Public Members
        /// <summary>����m�F�\(���גP��)�f�[�^�e�[�u����</summary>
        public const string CT_SalesConfDataTable = "SalesConfDataTable";

        /// <summary>����m�F�\(���גP��)�o�b�t�@�f�[�^�e�[�u����</summary>
        public const string CT_SalesConfBuffDataTable = "SalesConfBuffDataTable";

		#region ����m�F�\�i���גP�ʁj�J�������

        /// <summary> ���_�R�[�h </summary>
        public const string CT_Col_SectionCode = "SectionCode";

        /// <summary> ���_�K�C�h���� </summary>
        public const string CT_Col_SectionGuideNm = "SectionGuideNm";

        /// <summary> ����R�[�h </summary>
        public const string CT_Col_SubSectionCode = "SubSectionCode";

        /// <summary> ���喼�� </summary>
        public const string CT_Col_SubSectionName = "SubSectionName";

        /// <summary> ����`�[�ԍ� </summary>
        public const string CT_Col_SalesSlipNum = "SalesSlipNum";

        /// <summary> ������R�[�h </summary>
        public const string CT_Col_ClaimCode = "ClaimCode";

        /// <summary> �����旪�� </summary>
        public const string CT_Col_ClaimSnm = "ClaimSnm";

        /// <summary> ���Ӑ�R�[�h </summary>
        public const string CT_Col_CustomerCode = "CustomerCode";

        /// <summary> ���Ӑ旪�� </summary>
        public const string CT_Col_CustomerSnm = "CustomerSnm";

        /// <summary> �o�ד��t </summary>
        public const string CT_Col_ShipmentDay = "ShipmentDay";

        /// <summary> ������t </summary>
        public const string CT_Col_SalesDate = "SalesDate";

        /// <summary> �v����t </summary>
        public const string CT_Col_AddUpADate = "AddUpADate";

        /// <summary> ����`�[�敪 </summary>
        public const string CT_Col_SalesSlipCd = "SalesSlipCd";

        /// <summary> ���|�敪 </summary>
        public const string CT_Col_AccRecDivCd = "AccRecDivCd";

        /// <summary> ������͎҃R�[�h </summary>
        public const string CT_Col_SalesInputCode = "SalesInputCode";

        /// <summary> ������͎Җ��� </summary>
        public const string CT_Col_SalesInputName = "SalesInputName";

        /// <summary> ��t�]�ƈ��R�[�h </summary>
        public const string CT_Col_FrontEmployeeCd = "FrontEmployeeCd";

        /// <summary> ��t�]�ƈ����� </summary>
        public const string CT_Col_FrontEmployeeNm = "FrontEmployeeNm";

        /// <summary> �̔��]�ƈ��R�[�h </summary>
        public const string CT_Col_SalesEmployeeCd = "SalesEmployeeCd";

        /// <summary> �̔��]�ƈ����� </summary>
        public const string CT_Col_SalesEmployeeNm = "SalesEmployeeNm";

        /// <summary> �����`�[�ԍ� </summary>
        public const string CT_Col_PartySaleSlipNum = "PartySaleSlipNum";

        /// <summary> ����`�[���v�i�ō��݁j </summary>
        public const string CT_Col_SalesTotalTaxInc = "SalesTotalTaxInc";

        /// <summary> ����`�[���v�i�Ŕ����j </summary>
        public const string CT_Col_SalesTotalTaxExc = "SalesTotalTaxExc";

        /// <summary> �������z�v </summary>
        public const string CT_Col_TotalCost = "TotalCost";

        /// <summary> �ԕi���R�R�[�h </summary>
        public const string CT_Col_RetGoodsReasonDiv = "RetGoodsReasonDiv";

        /// <summary> �ԕi���R </summary>
        public const string CT_Col_RetGoodsReason = "RetGoodsReason";

        /// <summary> ���Ӑ�`�[�ԍ� </summary>
        public const string CT_Col_CustSlipNo = "CustSlipNo";

        /// <summary> �`�[���l </summary>
        public const string CT_Col_SlipNote = "SlipNote";

        /// <summary> �`�[���l�Q </summary>
        public const string CT_Col_SlipNote2 = "SlipNote2";

        /// <summary> �`�[���l�R </summary>
        public const string CT_Col_SlipNote3 = "SlipNote3";

        /// <summary> �Ǝ�R�[�h </summary>
        public const string CT_Col_BusinessTypeCode = "BusinessTypeCode";

        /// <summary> �Ǝ햼�� </summary>
        public const string CT_Col_BusinessTypeName = "BusinessTypeName";

        /// <summary> �̔��G���A�R�[�h </summary>
        public const string CT_Col_SalesAreaCode = "SalesAreaCode";

        /// <summary> �̔��G���A���� </summary>
        public const string CT_Col_SalesAreaName = "SalesAreaName";

        /// <summary> �t�n�d���}�[�N�P </summary>
        public const string CT_Col_UoeRemark1 = "UoeRemark1";

        /// <summary> �t�n�d���}�[�N�Q </summary>
        public const string CT_Col_UoeRemark2 = "UoeRemark2";

        /// <summary> ���i�ԍ� </summary>
        public const string CT_Col_GoodsNo = "GoodsNo";

        /// <summary> ���i���� </summary>
        public const string CT_Col_GoodsName = "GoodsName";

        /// <summary> BL���i�R�[�h </summary>
        public const string CT_Col_BLGoodsCode = "BLGoodsCode";

        /// <summary> BL���i�R�[�h���́i�S�p�j </summary>
        public const string CT_Col_BLGoodsFullName = "BLGoodsFullName";

        /// <summary> ����݌Ɏ�񂹋敪 </summary>
        public const string CT_Col_SalesOrderDivCd = "SalesOrderDivCd";

        /// <summary> �艿�i�ō��C�����j </summary>
        public const string CT_Col_ListPriceTaxIncFl = "ListPriceTaxIncFl";

        /// <summary> �艿�i�Ŕ��C�����j </summary>
        public const string CT_Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";

        /// <summary> ������ </summary>
        public const string CT_Col_SalesRate = "SalesRate";

        /// <summary> �o�א� </summary>
        public const string CT_Col_ShipmentCnt = "ShipmentCnt";

        /// <summary> �����P�� </summary>
        public const string CT_Col_SalesUnitCost = "SalesUnitCost";

        /// <summary> ����P���i�ō��C�����j </summary>
        public const string CT_Col_SalesUnPrcTaxIncFl = "SalesUnPrcTaxIncFl";

        /// <summary> ����P���i�Ŕ��C�����j </summary>
        public const string CT_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";

        /// <summary> ���� </summary>
        public const string CT_Col_Cost = "Cost";

        /// <summary> ������z�i�ō��݁j </summary>
        public const string CT_Col_SalesMoneyTaxInc = "SalesMoneyTaxInc";

        /// <summary> ������z�i�Ŕ����j </summary>
        public const string CT_Col_SalesMoneyTaxExc = "SalesMoneyTaxExc";

        /// <summary> �d����R�[�h </summary>
        public const string CT_Col_SupplierCd = "SupplierCd";

        /// <summary> �d���旪�� </summary>
        public const string CT_Col_SupplierSnm = "SupplierSnm";

        /// <summary> �d���`�[�ԍ� </summary>
        public const string CT_Col_SupplierSlipNo = "SupplierSlipNo";

        /// <summary> �q�ɃR�[�h </summary>
        public const string CT_Col_WarehouseCode = "WarehouseCode";

        /// <summary> �q�ɖ��� </summary>
        public const string CT_Col_WarehouseName = "WarehouseName";

        /// <summary> �q�ɒI�� </summary>
        public const string CT_Col_WarehouseShelfNo = "WarehouseShelfNo";

        /// <summary> �̔��敪�R�[�h </summary>
        public const string CT_Col_SalesCode = "SalesCode";

        /// <summary> �̔��敪���� </summary>
        public const string CT_Col_SalesCdNm = "SalesCdNm";

        /// <summary> �Ԏ�S�p���� </summary>
        public const string CT_Col_ModelFullName = "ModelFullName";

        /// <summary> �^���i�t���^�j </summary>
        public const string CT_Col_FullModel = "FullModel";

        /// <summary> �^���w��ԍ� </summary>
        public const string CT_Col_ModelDesignationNo = "ModelDesignationNo";

        /// <summary> �ޕʔԍ� </summary>
        public const string CT_Col_CategoryNo = "CategoryNo";

        /// <summary> ���q�Ǘ��R�[�h </summary>
        public const string CT_Col_CarMngCode = "CarMngCode";

        /// <summary> ���N�x </summary>
        public const string CT_Col_FirstEntryDate = "FirstEntryDate";

        /// <summary> ����敪��[�`�[] </summary>
        public const string CT_Col_TransactionName = "TransactionName";

        /// <summary> �e����[�`�[] </summary>
        public const string CT_Col_GrossMarginRate = "GrossMarginRate";

        /// <summary> �e���`�F�b�N�}�[�N[�`�[] </summary>
        public const string CT_Col_GrossMarginMarkSlip = "GrossMarginMarkSlip";

        /// <summary> �e����[����] </summary>
        public const string CT_Col_GrossMarginRateDtl = "GrossMarginRateDtl";

        /// <summary> �e���`�F�b�N�}�[�N[����] </summary>
        public const string CT_Col_GrossMarginMarkDtl = "GrossMarginMarkDtl";

        /// <summary> ����`�[�敪�i���ׁj </summary>
        public const string CT_Col_SalesSlipCdDtl = "SalesSlipCdDtl";

        /// <summary> ����l�����z�v�i�Ŕ����j </summary>
        public const string CT_Col_SalesDisTtlTaxExc = "SalesDisTtlTaxExc";

        /// <summary>�`�[�������t(���͓��t)</summary>
        /// <remarks>YYYYMMDD</remarks>
        public const string CT_Col_SearchSlipDate = "SearchSlipDate";


        // �����e�[�u����`���ȊO�̒ǉ�����
        /// <summary> ����`�[�敪���� </summary>
        public const string CT_Col_SalesSlipName = "SalesSlipName";

        /// <summary> �ޕ�(����) </summary>
        public const string CT_Col_CategoryDtl = "CategoryDtl";

        /// <summary> ����݌Ɏ�񂹋敪���� </summary>
        public const string CT_Col_SalesOrderDivName = "SalesOrderDivName";

        /// <summary> ����� </summary>
        public const string CT_SalesConf_Tax = "Tax";

        // --- ADD  �{��  2011/07/18 ---------->>>>>
        /// <summary> ������ </summary>
        public const string CT_AutoAnswer = "AutoAnswer";
        // --- ADD  �{��  2011/07/18 ----------<<<<<

        /// <summary> �e��(�Ŕ���)(�`�[) </summary>
        public const string CT_SalesConf_GrossProfit = "GrossProfit";

        /// <summary> �e��(�Ŕ���)(����) </summary>
        public const string CT_SalesConf_GrossProfitDtl = "GrossProfitDtl";

        /// <summary> ����s�ԍ�(����) </summary>
        public const string CT_SalesConf_SalesRowNo = "SalesRowNo";

        // 2009.01.21 30413 ���� ����łƍ��v���z�̒ǉ� >>>>>>START
        // �������v��(�`�[)�̒ǉ�����
        /// <summary>���㐔(�`�[)</summary>
        public const string CT_SalesConf_SalesCountNumber = "SalesCountNumber";

        /// <summary>���㍇�v���z</summary>
        public const string CT_SalesConf_TotalMeter = "TotalMeter";

        /// <summary>���㍇�v����(�Ŕ���)(�`�[)</summary>
        public const string CT_SalesConf_SalesCost = "SalesCost";

        /// <summary>���㍇�v�e��(�Ŕ���)(�`�[)</summary>
        public const string CT_SalesConf_SalesGrossProfit = "SalesGrossProfit";

        /// <summary>���㍇�v�����(�`�[)</summary>
        public const string CT_SalesConf_SalesTax = "SalesTax";

        /// <summary>����̏���ō����v���z(�`�[)</summary>
        public const string CT_SalesConf_SalesTotalAll = "SalesTotalAll";

        /// <summary>�ԕi��(�`�[)</summary>
        public const string CT_SalesConf_ReturnCountNumber = "ReturnCountNumber";

        /// <summary>�ԕi���v���z(�Ŕ���)(�`�[)</summary>
        public const string CT_SalesConf_ReturnSalesMoney = "ReturnSalesMoney";
        
        /// <summary>�ԕi���v����(�Ŕ���)(�`�[)</summary>
        public const string CT_SalesConf_SalesReturnCost = "SalesReturnCost";

        /// <summary>�ԕi���v�e��(�Ŕ���)(�`�[)</summary>
        public const string CT_SalesConf_ReturnGrossProfit = "ReturnGrossProfit";

        /// <summary>�ԕi���v�����(�`�[)</summary>
        public const string CT_SalesConf_ReturnTax = "ReturnTax";

        /// <summary>�ԕi�̏���ō����v���z(�`�[)</summary>
        public const string CT_SalesConf_ReturnTotalAll = "ReturnTotalAll";

        /// <summary>�l�������v���z(�Ŕ���)(�`�[)</summary>
        public const string CT_SalesConf_DistSalesMoney = "DistSalesMoney";

        /// <summary>�l�������v����(�Ŕ���)(�`�[)</summary>
        public const string CT_SalesConf_DistCost = "DistCost";

        /// <summary>�l�������v�e��(�Ŕ���)(�`�[)</summary>
        public const string CT_SalesConf_DistGrossProfit = "DistGrossProfit";

        /// <summary>�l�������v�����(�`�[)</summary>
        public const string CT_SalesConf_DistTax = "DistTax";

        /// <summary>�l�����̏���ō����v���z(�`�[)</summary>
        public const string CT_SalesConf_DistTotalAll = "DistTotalAll";


        // �������v��(����)�̒ǉ�����
        /// <summary>���㐔(����)</summary>
        public const string CT_SalesConf_SalesCountnumberDtl = "SalesCountnumberDtl";
        
        /// <summary>���㍇�v���z(����)</summary>
        public const string CT_SalesConf_SalesDtl = "SalesDtl";

        /// <summary>���㍇�v����(�Ŕ���)(����)</summary>
        public const string CT_SalesConf_SalesCostDtl = "SalesCostDtl";

        /// <summary>���㍇�v�e��(�Ŕ���)(����)</summary>
        public const string CT_SalesConf_SalesGrossProfitDtl = "SalesGrossProfitDtl";

        /// <summary>���㍇�v�����(����)</summary>
        public const string CT_SalesConf_SalesDtlTax = "SalesDtlTax";

        /// <summary>�ԕi��(����)</summary>
        public const string CT_SalesConf_ReturnSalesCountDtl = "ReturnSalesCountDtl";

        /// <summary>�ԕi���v���z(����)</summary>
        public const string CT_SalesConf_ReturnDtl = "ReturnDtl";

        /// <summary>�ԕi���v����(�Ŕ���)(����)</summary>
        public const string CT_SalesConf_SalesReturnCostDtl = "SalesReturnCostDtl";

        /// <summary>�ԕi���v�e��(�Ŕ���)(����)</summary>
        public const string CT_SalesConf_ReturnGrossProfitDtl = "ReturnGrossProfitDtl";

        /// <summary>�ԕi���v�����(����)</summary>
        public const string CT_SalesConf_ReturnDtlTax = "ReturnDtlTax";

        /// <summary>�l�������v���z(����)</summary>
        public const string CT_SalesConf_DistDtl = "DistDtl";

        /// <summary>�l�������v�������z(�Ŕ���)(����)</summary>
        public const string CT_SalesConf_DistDtlCost = "DistDtlCost";

        /// <summary>�l�������v�e��(�Ŕ���)(����)</summary>
        public const string CT_SalesConf_DistGrossProfitDtl = "DistGrossProfitDtl";

        /// <summary>�l�������v�����(����)</summary>
        public const string CT_SalesConf_DistDtlTax = "DistDtlTax";
        // 2009.01.21 30413 ���� ����łƍ��v���z�̒ǉ� <<<<<<END

        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
        /// <summary> ����Őŗ� </summary>
        public const String CT_Col_ConsTaxRate = "ConsTaxRate";

        #region �u����Őŗ�1�v
        /// <summary>Title_�ŗ�1</summary>
        public const string CT_SalesConf_TaxRate1_Title = "TaxRate1Title";

        /// <summary>���㐔_�ŗ�1</summary>
        public const string CT_SalesConf_TaxRate1_SalesCountnumberDtl = "TaxRate1SalesCountnumberDtl";

        /// <summary>������z_�ŗ�1</summary>
        public const string CT_SalesConf_TaxRate1_SalesDtl = "TaxRate1SalesDtl";

        /// <summary>����̏���ō����v���z_�ŗ�1</summary>
        public const string CT_SalesConf_TaxRate1_SalesTotalAll = "TaxRate1SalesTotalAll";

        /// <summary>��������_�ŗ�1</summary>
        public const string CT_SalesConf_TaxRate1_SalesDtlTax = "TaxRate1SalesDtlTax";

        /// <summary>���㌴��(�Ŕ���)_�ŗ�1</summary>
        public const string CT_SalesConf_TaxRate1_SalesCostDtl = "TaxRate1SalesCostDtl";

        /// <summary>Title_�ŗ�1</summary>
        public const string CT_SalesConf_TaxRate1_ReturnTitle = "TaxRate1ReturnTitle";

        /// <summary>�ԕi��_�ŗ�1</summary>
        public const string CT_SalesConf_TaxRate1_ReturnSalesCountDtl = "TaxRate1ReturnSalesCountDtl";

        /// <summary>�ԕi���z_�ŗ�1</summary>
        public const string CT_SalesConf_TaxRate1_ReturnDtl = "TaxRate1ReturnDtl";

        /// <summary>�ԕi�����_�ŗ�1</summary>
        public const string CT_SalesConf_TaxRate1_ReturnDtlTax = "TaxRate1ReturnDtlTax";

        /// <summary>�ԕi�̏���ō����v���z_�ŗ�1</summary>
        public const string CT_SalesConf_TaxRate1_ReturnTotalAll = "TaxRate1ReturnTotalAll";

        /// <summary>�ԕi����(�Ŕ���)_�ŗ�1</summary>
        public const string CT_SalesConf_TaxRate1_ReturnCostDtl = "TaxRate1ReturnCostDtl";
        #endregion

        #region �u����Őŗ�2�v
        /// <summary>Title_�ŗ�2</summary>
        public const string CT_SalesConf_TaxRate2_Title = "TaxRate2Title";

        /// <summary>���㐔_�ŗ��Q</summary>
        public const string CT_SalesConf_TaxRate2_SalesCountnumberDtl = "TaxRate2SalesCountnumberDtl";

        /// <summary>������z_�ŗ��Q</summary>
        public const string CT_SalesConf_TaxRate2_SalesDtl = "TaxRate2SalesDtl";

        /// <summary>��������_�ŗ��Q</summary>
        public const string CT_SalesConf_TaxRate2_SalesDtlTax = "TaxRate2SalesDtlTax";

        /// <summary>����̏���ō����v���z_�ŗ��Q</summary>
        public const string CT_SalesConf_TaxRate2_SalesTotalAll = "TaxRate2SalesTotalAll";

        /// <summary>���㌴��(�Ŕ���)_�ŗ��Q</summary>
        public const string CT_SalesConf_TaxRate2_SalesCostDtl = "TaxRate2SalesCostDtl";

        /// <summary>Title_�ŗ��Q</summary>
        public const string CT_SalesConf_TaxRate2_ReturnTitle = "TaxRate2ReturnTitle";

        /// <summary>�ԕi��_�ŗ��Q</summary>
        public const string CT_SalesConf_TaxRate2_ReturnSalesCountDtl = "TaxRate2ReturnSalesCountDtl";

        /// <summary>�ԕi���z_�ŗ��Q</summary>
        public const string CT_SalesConf_TaxRate2_ReturnDtl = "TaxRate2ReturnDtl";

        /// <summary>�ԕi�����_�ŗ��Q</summary>
        public const string CT_SalesConf_TaxRate2_ReturnDtlTax = "TaxRate2ReturnDtlTax";

        /// <summary>�ԕi�̏���ō����v���z_�ŗ��Q</summary>
        public const string CT_SalesConf_TaxRate2_ReturnTotalAll = "TaxRate2ReturnTotalAll";

        /// <summary>�ԕi����(�Ŕ���)_�ŗ��Q</summary>
        public const string CT_SalesConf_TaxRate2_ReturnCostDtl = "TaxRate2ReturnCostDtl";
        #endregion

        #region �u����Őŗ� ���̑��v
        /// <summary>Title_���̑�</summary>
        public const string CT_SalesConf_Other_Title = "OtherTitle";

        /// <summary>���㐔_���̑�</summary>
        public const string CT_SalesConf_Other_SalesCountnumberDtl = "OtherSalesCountnumberDtl";

        /// <summary>������z_���̑�</summary>
        public const string CT_SalesConf_Other_SalesDtl = "OtherSalesDtl";

        /// <summary>��������_���̑�</summary>
        public const string CT_SalesConf_Other_SalesDtlTax = "OtherSalesDtlTax";

        /// <summary>����̏���ō����v���z_���̑�</summary>
        public const string CT_SalesConf_Other_SalesTotalAll = "OtherSalesTotalAll";

        /// <summary>���㌴��(�Ŕ���)_���̑�</summary>
        public const string CT_SalesConf_Other_SalesCostDtl = "OtherSalesCostDtl";

        /// <summary>Title_���̑�</summary>
        public const string CT_SalesConf_Other_ReturnTitle = "OtherReturnTitle";

        /// <summary>�ԕi��_���̑�</summary>
        public const string CT_SalesConf_Other_ReturnSalesCountDtl = "OtherReturnSalesCountDtl";

        /// <summary>�ԕi���v���z_���̑�</summary>
        public const string CT_SalesConf_Other_ReturnDtl = "OtherReturnDtl";

        /// <summary>�ԕi���v�����_���̑�</summary>
        public const string CT_SalesConf_Other_ReturnDtlTax = "OtherReturnDtlTax";

        /// <summary>�ԕi�̏���ō����v���z_���̑�</summary>
        public const string CT_SalesConf_Other_ReturnTotalAll = "OtherReturnTotalAll";

        /// <summary>�ԕi����(�Ŕ���)_���̑�</summary>
        public const string CT_SalesConf_Other_ReturnCostDtl = "OtherReturnCostDtl";

        #endregion
        // --- ADD END 3H ���� 2020/02/27 -----<<<<<

        // ----- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
        #region �u����Őŗ� ��ېŁv
        /// <summary>Title_��ې�</summary>
        public const string CT_SalesConf_TaxFree_Title = "TaxFreeTitle";

        /// <summary>���㐔_��ې�</summary>
        public const string CT_SalesConf_TaxFree_SalesCountnumberDtl = "TaxFreeSalesCountnumberDtl";

        /// <summary>������z_��ې�</summary>
        public const string CT_SalesConf_TaxFree_SalesDtl = "TaxFreeSalesDtl";

        /// <summary>��������_��ې�</summary>
        public const string CT_SalesConf_TaxFree_SalesDtlTax = "TaxFreeSalesDtlTax";

        /// <summary>����̏���ō����v���z_��ې�</summary>
        public const string CT_SalesConf_TaxFree_SalesTotalAll = "TaxFreeSalesTotalAll";

        /// <summary>���㌴��(�Ŕ���)_��ې�</summary>
        public const string CT_SalesConf_TaxFree_SalesCostDtl = "TaxFreeSalesCostDtl";

        /// <summary>Title_��ې�</summary>
        public const string CT_SalesConf_TaxFree_ReturnTitle = "TaxFreeReturnTitle";

        /// <summary>�ԕi��_��ې�</summary>
        public const string CT_SalesConf_TaxFree_ReturnSalesCountDtl = "TaxFreeReturnSalesCountDtl";

        /// <summary>�ԕi���v���z_��ې�</summary>
        public const string CT_SalesConf_TaxFree_ReturnDtl = "TaxFreeReturnDtl";

        /// <summary>�ԕi���v�����_��ې�</summary>
        public const string CT_SalesConf_TaxFree_ReturnDtlTax = "TaxFreeReturnDtlTax";

        /// <summary>�ԕi�̏���ō����v���z_��ې�</summary>
        public const string CT_SalesConf_TaxFree_ReturnTotalAll = "TaxFreeReturnTotalAll";

        /// <summary>�ԕi����(�Ŕ���)_��ې�</summary>
        public const string CT_SalesConf_TaxFree_ReturnCostDtl = "TaxFreeReturnCostDtl";

        #endregion
        // ----- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<

        // �`�[�^�C�v�̈󎚗p���t
        /// <summary> ������t(�`�[�^�C�v�󎚗p) </summary>
        /// <remarks>YY/MM/DD</remarks>
        public const string CT_Col_SalesDateY2 = "SalesDateY2";

        /// <summary> �v����t(�`�[�^�C�v�󎚗p) </summary>
        /// <remarks>YY/MM/DD</remarks>
        public const string CT_Col_AddUpADateY2 = "AddUpADateY2";

        /// <summary> �`�[�������t(���͓��t)(�`�[�^�C�v�󎚗p) </summary>
        /// <remarks>YY/MM/DD</remarks>
        public const string CT_Col_SearchSlipDateY2 = "SearchSlipDateY2";

        // --- ADD 2008/10/31 --------------------------------------------------------->>>>>
        /// <summary>����œ]�ŕ���[�`�[]</summary>
        public const string CT_Col_ConsTaxLayMethod = "ConsTaxLayMethod";		
        /// <summary>�ېŋ敪[����]</summary>
        public const string CT_Col_TaxationDivCd = "TaxationDivCd";
        /// <summary>���v���z(���z�{�����)</summary>
        public const string CT_Col_SalesTotalTaxExcPlusTax = "SalesTotalTaxExcPlusTax";
        // --- ADD 2008/10/31 ---------------------------------------------------------<<<<<

        // 2010/06/29 Add >>>
        /// <summary> �Ԏ피�p���� </summary>
        public const string CT_Col_ModelHalfName = "ModelHalfName";
        // 2010/06/29 Add <<<

        // --- ADD  ���r��  2010/07/14 ---------->>>>>
        /// <summary> ���i���̃J�i</summary>
        public const string CT_Col_GoodsNameKana = "GoodsNameKana";
        // --- ADD  ���r��  2010/07/14 ----------<<<<<
        
        /// <summary>�L�[�u���C�N</summary>
        public const string COL_KEYBREAK_AR = "KEYBREAK_AR";

        public const string CT_COL_LOGICALDELETECODE = "LogicalDeleteCode";// --- ADD  ����  2010/11/29 
        #endregion

        #endregion

        #region Constructor
        /// <summary>
		/// ����m�F�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����m�F�\���o���ʃf�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
		/// <br>Programmer : 22021�@�J���@�͍K</br>
		/// <br>Date       : 2006.01.27</br>
		/// </remarks>
		public MAHNB02349EA()
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
			if ( (ds.Tables.Contains(CT_SalesConfDataTable)) )
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				ds.Tables[CT_SalesConfDataTable].Clear();
			}
			else
			{
                CreateSaleConfTable(ref ds, 0);

			}
			
			// ����`�F�b�N���X�g�o�b�t�@�f�[�^�e�[�u��------------------------------------------
			// �e�[�u�������݂��邩�ǂ������`�F�b�N
			if ((ds.Tables.Contains(CT_SalesConfBuffDataTable)))
			{
				// TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
				// �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
				ds.Tables[CT_SalesConfBuffDataTable].Clear();
			}
			else
			{
                CreateSaleConfTable(ref ds, 1);
			}
		}

		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// ����m�F�\(���גP��)���o���ʍ쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 22021 �J���@�͍K</br>
		/// <br>Date       : 2006.01.28</br>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
		/// <br>Programmer : 3H ����</br>
		/// </remarks>
		private static void CreateSaleConfTable(ref DataSet ds, int buffCheck)
		{
			DataTable dt = null;
			if(buffCheck == 0)
			{
				// �X�L�[�}�ݒ�
				ds.Tables.Add(CT_SalesConfDataTable);
				dt = ds.Tables[CT_SalesConfDataTable];
			}
			else
			{
				// �X�L�[�}�ݒ�
				ds.Tables.Add(CT_SalesConfBuffDataTable);
				dt = ds.Tables[CT_SalesConfBuffDataTable];
			}

            string defValueString = "";
            Int32 defValueInt32 = 0;
            Int64 defValueInt64 = 0;
            Double defValueDouble = 0.0;

            // ���_�R�[�h
            dt.Columns.Add(CT_Col_SectionCode, typeof(string));
            dt.Columns[CT_Col_SectionCode].DefaultValue = defValueString;

            // ���_�K�C�h����
            dt.Columns.Add(CT_Col_SectionGuideNm, typeof(string));
            dt.Columns[CT_Col_SectionGuideNm].DefaultValue = defValueString;

            // ����R�[�h
            dt.Columns.Add(CT_Col_SubSectionCode, typeof(Int32));
            dt.Columns[CT_Col_SubSectionCode].DefaultValue = defValueInt32;

            // ���喼��
            dt.Columns.Add(CT_Col_SubSectionName, typeof(string));
            dt.Columns[CT_Col_SubSectionName].DefaultValue = defValueString;

            // ����`�[�ԍ�
            dt.Columns.Add(CT_Col_SalesSlipNum, typeof(string));
            dt.Columns[CT_Col_SalesSlipNum].DefaultValue = defValueString;

            // ������R�[�h
            dt.Columns.Add(CT_Col_ClaimCode, typeof(Int32));
            dt.Columns[CT_Col_ClaimCode].DefaultValue = defValueInt32;

            // �����旪��
            dt.Columns.Add(CT_Col_ClaimSnm, typeof(string));
            dt.Columns[CT_Col_ClaimSnm].DefaultValue = defValueString;

            // ���Ӑ�R�[�h
            dt.Columns.Add(CT_Col_CustomerCode, typeof(Int32));
            dt.Columns[CT_Col_CustomerCode].DefaultValue = defValueInt32;

            // ���Ӑ旪��
            dt.Columns.Add(CT_Col_CustomerSnm, typeof(string));
            dt.Columns[CT_Col_CustomerSnm].DefaultValue = defValueString;

            // �o�ד��t
            dt.Columns.Add(CT_Col_ShipmentDay, typeof(string));
            dt.Columns[CT_Col_ShipmentDay].DefaultValue = defValueString;

            // ������t
            dt.Columns.Add(CT_Col_SalesDate, typeof(string));
            dt.Columns[CT_Col_SalesDate].DefaultValue = defValueString;

            // �v����t
            dt.Columns.Add(CT_Col_AddUpADate, typeof(string));
            dt.Columns[CT_Col_AddUpADate].DefaultValue = defValueString;

            // ����`�[�敪
            dt.Columns.Add(CT_Col_SalesSlipCd, typeof(Int32));
            dt.Columns[CT_Col_SalesSlipCd].DefaultValue = defValueInt32;

            // ���|�敪
            dt.Columns.Add(CT_Col_AccRecDivCd, typeof(Int32));
            dt.Columns[CT_Col_AccRecDivCd].DefaultValue = defValueInt32;

            // ������͎҃R�[�h
            dt.Columns.Add(CT_Col_SalesInputCode, typeof(string));
            dt.Columns[CT_Col_SalesInputCode].DefaultValue = defValueString;

            // ������͎Җ���
            dt.Columns.Add(CT_Col_SalesInputName, typeof(string));
            dt.Columns[CT_Col_SalesInputName].DefaultValue = defValueString;

            // ��t�]�ƈ��R�[�h
            dt.Columns.Add(CT_Col_FrontEmployeeCd, typeof(string));
            dt.Columns[CT_Col_FrontEmployeeCd].DefaultValue = defValueString;

            // ��t�]�ƈ�����
            dt.Columns.Add(CT_Col_FrontEmployeeNm, typeof(string));
            dt.Columns[CT_Col_FrontEmployeeNm].DefaultValue = defValueString;

            // �̔��]�ƈ��R�[�h
            dt.Columns.Add(CT_Col_SalesEmployeeCd, typeof(string));
            dt.Columns[CT_Col_SalesEmployeeCd].DefaultValue = defValueString;

            // �̔��]�ƈ�����
            dt.Columns.Add(CT_Col_SalesEmployeeNm, typeof(string));
            dt.Columns[CT_Col_SalesEmployeeNm].DefaultValue = defValueString;

            // �����`�[�ԍ�
            dt.Columns.Add(CT_Col_PartySaleSlipNum, typeof(string));
            dt.Columns[CT_Col_PartySaleSlipNum].DefaultValue = defValueString;

            // ����`�[���v�i�ō��݁j
            dt.Columns.Add(CT_Col_SalesTotalTaxInc, typeof(Int64));
            dt.Columns[CT_Col_SalesTotalTaxInc].DefaultValue = defValueInt64;

            // ����`�[���v�i�Ŕ����j
            dt.Columns.Add(CT_Col_SalesTotalTaxExc, typeof(Int64));
            dt.Columns[CT_Col_SalesTotalTaxExc].DefaultValue = defValueInt64;

            // �������z�v
            dt.Columns.Add(CT_Col_TotalCost, typeof(Int64));
            dt.Columns[CT_Col_TotalCost].DefaultValue = defValueInt64;

            // �ԕi���R�R�[�h
            dt.Columns.Add(CT_Col_RetGoodsReasonDiv, typeof(string));
            dt.Columns[CT_Col_RetGoodsReasonDiv].DefaultValue = defValueString;

            // �ԕi���R
            dt.Columns.Add(CT_Col_RetGoodsReason, typeof(string));
            dt.Columns[CT_Col_RetGoodsReason].DefaultValue = defValueString;

            // ���Ӑ�`�[�ԍ�
            dt.Columns.Add(CT_Col_CustSlipNo, typeof(string));
            dt.Columns[CT_Col_CustSlipNo].DefaultValue = defValueString;

            // �`�[���l
            dt.Columns.Add(CT_Col_SlipNote, typeof(string));
            dt.Columns[CT_Col_SlipNote].DefaultValue = defValueString;

            // �`�[���l�Q
            dt.Columns.Add(CT_Col_SlipNote2, typeof(string));
            dt.Columns[CT_Col_SlipNote2].DefaultValue = defValueString;

            // �`�[���l�R
            dt.Columns.Add(CT_Col_SlipNote3, typeof(string));
            dt.Columns[CT_Col_SlipNote3].DefaultValue = defValueString;

            // �Ǝ�R�[�h
            dt.Columns.Add(CT_Col_BusinessTypeCode, typeof(Int32));
            dt.Columns[CT_Col_BusinessTypeCode].DefaultValue = defValueInt32;

            // �Ǝ햼��
            dt.Columns.Add(CT_Col_BusinessTypeName, typeof(string));
            dt.Columns[CT_Col_BusinessTypeName].DefaultValue = defValueString;

            // �̔��G���A�R�[�h
            dt.Columns.Add(CT_Col_SalesAreaCode, typeof(Int32));
            dt.Columns[CT_Col_SalesAreaCode].DefaultValue = defValueInt32;

            // �̔��G���A����
            dt.Columns.Add(CT_Col_SalesAreaName, typeof(string));
            dt.Columns[CT_Col_SalesAreaName].DefaultValue = defValueString;

            // �t�n�d���}�[�N�P
            dt.Columns.Add(CT_Col_UoeRemark1, typeof(string));
            dt.Columns[CT_Col_UoeRemark1].DefaultValue = defValueString;

            // �t�n�d���}�[�N�Q
            dt.Columns.Add(CT_Col_UoeRemark2, typeof(string));
            dt.Columns[CT_Col_UoeRemark2].DefaultValue = defValueString;

            // ���i�ԍ�
            dt.Columns.Add(CT_Col_GoodsNo, typeof(string));
            dt.Columns[CT_Col_GoodsNo].DefaultValue = defValueString;

            // ���i����
            dt.Columns.Add(CT_Col_GoodsName, typeof(string));
            dt.Columns[CT_Col_GoodsName].DefaultValue = defValueString;

            // BL���i�R�[�h
            dt.Columns.Add(CT_Col_BLGoodsCode, typeof(string));
            dt.Columns[CT_Col_BLGoodsCode].DefaultValue = defValueString;

            // BL���i�R�[�h���́i�S�p�j
            dt.Columns.Add(CT_Col_BLGoodsFullName, typeof(string));
            dt.Columns[CT_Col_BLGoodsFullName].DefaultValue = defValueString;

            // ����݌Ɏ�񂹋敪
            dt.Columns.Add(CT_Col_SalesOrderDivCd, typeof(Int32));
            dt.Columns[CT_Col_SalesOrderDivCd].DefaultValue = defValueInt32;

            // �艿�i�ō��C�����j
            dt.Columns.Add(CT_Col_ListPriceTaxIncFl, typeof(Double));
            dt.Columns[CT_Col_ListPriceTaxIncFl].DefaultValue = defValueDouble;

            // �艿�i�Ŕ��C�����j
            dt.Columns.Add(CT_Col_ListPriceTaxExcFl, typeof(Double));
            dt.Columns[CT_Col_ListPriceTaxExcFl].DefaultValue = defValueDouble;

            // ������
            dt.Columns.Add(CT_Col_SalesRate, typeof(Double));
            dt.Columns[CT_Col_SalesRate].DefaultValue = defValueDouble;

            // �o�א�
            dt.Columns.Add(CT_Col_ShipmentCnt, typeof(Double));
            dt.Columns[CT_Col_ShipmentCnt].DefaultValue = defValueDouble;

            // �����P��
            dt.Columns.Add(CT_Col_SalesUnitCost, typeof(Double));
            dt.Columns[CT_Col_SalesUnitCost].DefaultValue = defValueDouble;

            // ����P���i�ō��C�����j
            dt.Columns.Add(CT_Col_SalesUnPrcTaxIncFl, typeof(Double));
            dt.Columns[CT_Col_SalesUnPrcTaxIncFl].DefaultValue = defValueDouble;

            // ����P���i�Ŕ��C�����j
            dt.Columns.Add(CT_Col_SalesUnPrcTaxExcFl, typeof(Double));
            dt.Columns[CT_Col_SalesUnPrcTaxExcFl].DefaultValue = defValueDouble;

            // ����
            dt.Columns.Add(CT_Col_Cost, typeof(Int64));
            dt.Columns[CT_Col_Cost].DefaultValue = defValueInt64;

            // ������z�i�ō��݁j
            dt.Columns.Add(CT_Col_SalesMoneyTaxInc, typeof(Int64));
            dt.Columns[CT_Col_SalesMoneyTaxInc].DefaultValue = defValueInt64;

            // ������z�i�Ŕ����j
            dt.Columns.Add(CT_Col_SalesMoneyTaxExc, typeof(Int64));
            dt.Columns[CT_Col_SalesMoneyTaxExc].DefaultValue = defValueInt64;

            // �d����R�[�h
            dt.Columns.Add(CT_Col_SupplierCd, typeof(string));
            dt.Columns[CT_Col_SupplierCd].DefaultValue = defValueString;

            // �d���旪��
            dt.Columns.Add(CT_Col_SupplierSnm, typeof(string));
            dt.Columns[CT_Col_SupplierSnm].DefaultValue = defValueString;

            // �d���`�[�ԍ�
            dt.Columns.Add(CT_Col_SupplierSlipNo, typeof(string));
            dt.Columns[CT_Col_SupplierSlipNo].DefaultValue = defValueString;

            // �q�ɃR�[�h
            dt.Columns.Add(CT_Col_WarehouseCode, typeof(string));
            dt.Columns[CT_Col_WarehouseCode].DefaultValue = defValueString;

            // �q�ɖ���
            dt.Columns.Add(CT_Col_WarehouseName, typeof(string));
            dt.Columns[CT_Col_WarehouseName].DefaultValue = defValueString;

            // �q�ɒI��
            dt.Columns.Add(CT_Col_WarehouseShelfNo, typeof(string));
            dt.Columns[CT_Col_WarehouseShelfNo].DefaultValue = defValueString;

            // �̔��敪�R�[�h
            dt.Columns.Add(CT_Col_SalesCode, typeof(string));
            dt.Columns[CT_Col_SalesCode].DefaultValue = defValueString;

            // �̔��敪����
            dt.Columns.Add(CT_Col_SalesCdNm, typeof(string));
            dt.Columns[CT_Col_SalesCdNm].DefaultValue = defValueString;

            // �Ԏ�S�p����
            dt.Columns.Add(CT_Col_ModelFullName, typeof(string));
            dt.Columns[CT_Col_ModelFullName].DefaultValue = defValueString;

            // �^���i�t���^�j
            dt.Columns.Add(CT_Col_FullModel, typeof(string));
            dt.Columns[CT_Col_FullModel].DefaultValue = defValueString;

            // �^���w��ԍ�
            dt.Columns.Add(CT_Col_ModelDesignationNo, typeof(Int32));
            dt.Columns[CT_Col_ModelDesignationNo].DefaultValue = defValueInt32;

            // �ޕʔԍ�
            dt.Columns.Add(CT_Col_CategoryNo, typeof(Int32));
            dt.Columns[CT_Col_CategoryNo].DefaultValue = defValueInt32;

            // ���q�Ǘ��R�[�h
            dt.Columns.Add(CT_Col_CarMngCode, typeof(string));
            dt.Columns[CT_Col_CarMngCode].DefaultValue = defValueString;

            // ���N�x
            dt.Columns.Add(CT_Col_FirstEntryDate, typeof(string));
            dt.Columns[CT_Col_FirstEntryDate].DefaultValue = defValueString;

            // ����敪��[�`�[]
            dt.Columns.Add(CT_Col_TransactionName, typeof(string));
            dt.Columns[CT_Col_TransactionName].DefaultValue = defValueString;

            // �e����[�`�[]
            dt.Columns.Add(CT_Col_GrossMarginRate, typeof(Double));
            dt.Columns[CT_Col_GrossMarginRate].DefaultValue = defValueDouble;

            // �e���`�F�b�N�}�[�N[�`�[]
            dt.Columns.Add(CT_Col_GrossMarginMarkSlip, typeof(string));
            dt.Columns[CT_Col_GrossMarginMarkSlip].DefaultValue = defValueString;

            // �e����[����]
            dt.Columns.Add(CT_Col_GrossMarginRateDtl, typeof(Double));
            dt.Columns[CT_Col_GrossMarginRateDtl].DefaultValue = defValueDouble;

            // �e���`�F�b�N�}�[�N[����]
            dt.Columns.Add(CT_Col_GrossMarginMarkDtl, typeof(string));
            dt.Columns[CT_Col_GrossMarginMarkDtl].DefaultValue = defValueString;

            // ����`�[�敪�i���ׁj
            dt.Columns.Add(CT_Col_SalesSlipCdDtl, typeof(Int32));
            dt.Columns[CT_Col_SalesSlipCdDtl].DefaultValue = defValueInt32;

            // ����l�����z�v�i�Ŕ����j
            dt.Columns.Add(CT_Col_SalesDisTtlTaxExc, typeof(Int64));
            dt.Columns[CT_Col_SalesDisTtlTaxExc].DefaultValue = defValueInt64;

            // �`�[�������t(���͓��t)
            dt.Columns.Add(CT_Col_SearchSlipDate, typeof(string));
            dt.Columns[CT_Col_SearchSlipDate].DefaultValue = defValueString;


            // �����e�[�u����`���ȊO�̒ǉ�����
            // ����`�[�敪����
            dt.Columns.Add(CT_Col_SalesSlipName, typeof(string));
            dt.Columns[CT_Col_SalesSlipName].DefaultValue = defValueString;

            // �ޕ�(����)
            dt.Columns.Add(CT_Col_CategoryDtl, typeof(string));
            dt.Columns[CT_Col_CategoryDtl].DefaultValue = defValueString;

            // ����݌Ɏ�񂹋敪����
            dt.Columns.Add(CT_Col_SalesOrderDivName, typeof(string));
            dt.Columns[CT_Col_SalesOrderDivName].DefaultValue = defValueString;

            // �����
            dt.Columns.Add(CT_SalesConf_Tax, typeof(Int64));
            dt.Columns[CT_SalesConf_Tax].DefaultValue = defValueInt64;

            // --- ADD  �{��  2011/07/18 ---------->>>>>
            // ������
            dt.Columns.Add(CT_AutoAnswer, typeof(string));
            dt.Columns[CT_AutoAnswer].DefaultValue = defValueString;
            // --- ADD  �{��  2011/07/18 ----------<<<<<

            // �e��(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_SalesConf_GrossProfit, typeof(Int64));
            dt.Columns[CT_SalesConf_GrossProfit].DefaultValue = defValueInt64;

            // �e��(�Ŕ���)(����)
            dt.Columns.Add(CT_SalesConf_GrossProfitDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_GrossProfitDtl].DefaultValue = defValueInt64;

            // ����s�ԍ�(����)
            dt.Columns.Add(CT_SalesConf_SalesRowNo, typeof(Int32));
            dt.Columns[CT_SalesConf_SalesRowNo].DefaultValue = defValueInt32;


            // 2009.01.21 30413 ���� ����łƍ��v���z�̒ǉ� >>>>>>START
            // �������v���̒ǉ�����
            // ���㐔(�`�[)
            dt.Columns.Add(CT_SalesConf_SalesCountNumber, typeof(Int32));
            dt.Columns[CT_SalesConf_SalesCountNumber].DefaultValue = defValueInt32;

            // ���㍇�v���z
            dt.Columns.Add(CT_SalesConf_TotalMeter, typeof(Int64));
            dt.Columns[CT_SalesConf_TotalMeter].DefaultValue = defValueInt64;

            // ���㍇�v����(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_SalesConf_SalesCost, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesCost].DefaultValue = defValueInt64;

            // ���㍇�v�e��(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_SalesConf_SalesGrossProfit, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesGrossProfit].DefaultValue = defValueInt64;

            // ���㍇�v�����(�`�[)
            dt.Columns.Add(CT_SalesConf_SalesTax, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesTax].DefaultValue = defValueInt64;

            // ����̏���ō����v���z(�`�[)
            dt.Columns.Add(CT_SalesConf_SalesTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesTotalAll].DefaultValue = defValueInt64;

            // �ԕi��(�`�[)
            dt.Columns.Add(CT_SalesConf_ReturnCountNumber, typeof(Int32));
            dt.Columns[CT_SalesConf_ReturnCountNumber].DefaultValue = defValueInt32;

            // �ԕi���v���z(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_SalesConf_ReturnSalesMoney, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnSalesMoney].DefaultValue = defValueInt64;

            // �ԕi���v����(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_SalesConf_SalesReturnCost, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesReturnCost].DefaultValue = defValueInt64;

            // �ԕi���v�e��(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_SalesConf_ReturnGrossProfit, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnGrossProfit].DefaultValue = defValueInt64;

            // �ԕi���v�����(�`�[)
            dt.Columns.Add(CT_SalesConf_ReturnTax, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnTax].DefaultValue = defValueInt64;

            // �ԕi�̏���ō����v���z(�`�[)
            dt.Columns.Add(CT_SalesConf_ReturnTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnTotalAll].DefaultValue = defValueInt64;

            // �l�������v���z(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_SalesConf_DistSalesMoney, typeof(Int64));
            dt.Columns[CT_SalesConf_DistSalesMoney].DefaultValue = defValueInt64;

            // �l�������v����(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_SalesConf_DistCost, typeof(Int64));
            dt.Columns[CT_SalesConf_DistCost].DefaultValue = defValueInt64;

            // �l�������v�e��(�Ŕ���)(�`�[)
            dt.Columns.Add(CT_SalesConf_DistGrossProfit, typeof(Int64));
            dt.Columns[CT_SalesConf_DistGrossProfit].DefaultValue = defValueInt64;

            // �l�������v�����(�`�[)
            dt.Columns.Add(CT_SalesConf_DistTax, typeof(Int64));
            dt.Columns[CT_SalesConf_DistTax].DefaultValue = defValueInt64;

            // �l�����̏���ō����v���z(�`�[)
            dt.Columns.Add(CT_SalesConf_DistTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_DistTotalAll].DefaultValue = defValueInt64;


            // �������v��(����)�̒ǉ�����
            // ���㐔(����)
            dt.Columns.Add(CT_SalesConf_SalesCountnumberDtl, typeof(Int32));
            dt.Columns[CT_SalesConf_SalesCountnumberDtl].DefaultValue = defValueInt32;

            // ���㍇�v���z(����)
            dt.Columns.Add(CT_SalesConf_SalesDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesDtl].DefaultValue = defValueInt64;

            // ���㍇�v����(�Ŕ���)(����)
            dt.Columns.Add(CT_SalesConf_SalesCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesCostDtl].DefaultValue = defValueInt64;

            // ���㍇�v�e��(�Ŕ���)(����)
            dt.Columns.Add(CT_SalesConf_SalesGrossProfitDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesGrossProfitDtl].DefaultValue = defValueInt64;

            // ���㍇�v�����(����)
            dt.Columns.Add(CT_SalesConf_SalesDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesDtlTax].DefaultValue = defValueInt64;

            // �ԕi��(����)
            dt.Columns.Add(CT_SalesConf_ReturnSalesCountDtl, typeof(Int32));
            dt.Columns[CT_SalesConf_ReturnSalesCountDtl].DefaultValue = defValueInt32;

            // �ԕi���v���z(����)
            dt.Columns.Add(CT_SalesConf_ReturnDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnDtl].DefaultValue = defValueInt64;

            // �ԕi���v����(�Ŕ���)(����)
            dt.Columns.Add(CT_SalesConf_SalesReturnCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesReturnCostDtl].DefaultValue = defValueInt64;

            // �ԕi���v�e��(�Ŕ���)(����)
            dt.Columns.Add(CT_SalesConf_ReturnGrossProfitDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnGrossProfitDtl].DefaultValue = defValueInt64;

            // �ԕi���v�����(����)
            dt.Columns.Add(CT_SalesConf_ReturnDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnDtlTax].DefaultValue = defValueInt64;

            // �l�������v���z(����)
            dt.Columns.Add(CT_SalesConf_DistDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_DistDtl].DefaultValue = defValueInt64;

            // �l�������v�������z(�Ŕ���)(����)
            dt.Columns.Add(CT_SalesConf_DistDtlCost, typeof(Int64));
            dt.Columns[CT_SalesConf_DistDtlCost].DefaultValue = defValueInt64;

            // �l�������v�e��(�Ŕ���)(����)
            dt.Columns.Add(CT_SalesConf_DistGrossProfitDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_DistGrossProfitDtl].DefaultValue = defValueInt64;

            // �l�������v�����(����)
            dt.Columns.Add(CT_SalesConf_DistDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_DistDtlTax].DefaultValue = defValueInt64;
            // 2009.01.21 30413 ���� ����łƍ��v���z�̒ǉ� <<<<<<END

            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            dt.Columns.Add(CT_Col_ConsTaxRate, typeof(String));
            dt.Columns[CT_Col_ConsTaxRate].DefaultValue = defValueString;

            #region �u����Őŗ��ŗ�1�v
            // Title_�ŗ�1
            dt.Columns.Add(CT_SalesConf_TaxRate1_Title, typeof(String));
            dt.Columns[CT_SalesConf_TaxRate1_Title].DefaultValue = defValueString;

            // ���㐔_�ŗ�1
            dt.Columns.Add(CT_SalesConf_TaxRate1_SalesCountnumberDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_SalesCountnumberDtl].DefaultValue = defValueInt64;

            // ������z_�ŗ�1
            dt.Columns.Add(CT_SalesConf_TaxRate1_SalesDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_SalesDtl].DefaultValue = defValueInt64;

            // ��������_�ŗ�1
            dt.Columns.Add(CT_SalesConf_TaxRate1_SalesDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_SalesDtlTax].DefaultValue = defValueInt64;

            // ����̏���ō����v���z_�ŗ�1
            dt.Columns.Add(CT_SalesConf_TaxRate1_SalesTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_SalesTotalAll].DefaultValue = defValueInt64;

            // ���㌴��(�Ŕ���)_�ŗ�1
            dt.Columns.Add(CT_SalesConf_TaxRate1_SalesCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_SalesCostDtl].DefaultValue = defValueInt64;

            // �ԕiTitle_�ŗ�1
            dt.Columns.Add(CT_SalesConf_TaxRate1_ReturnTitle, typeof(String));
            dt.Columns[CT_SalesConf_TaxRate1_ReturnTitle].DefaultValue = defValueString;

            // �ԕi��_�ŗ�1
            dt.Columns.Add(CT_SalesConf_TaxRate1_ReturnSalesCountDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_ReturnSalesCountDtl].DefaultValue = defValueInt64;

            // �ԕi���z_�ŗ�1
            dt.Columns.Add(CT_SalesConf_TaxRate1_ReturnDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_ReturnDtl].DefaultValue = defValueInt64;

            // �ԕi�����_�ŗ�1
            dt.Columns.Add(CT_SalesConf_TaxRate1_ReturnDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_ReturnDtlTax].DefaultValue = defValueInt64;

            // �ԕi�̏���ō����v���z_�ŗ�1
            dt.Columns.Add(CT_SalesConf_TaxRate1_ReturnTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_ReturnTotalAll].DefaultValue = defValueInt64;

            // �ԕi����(�Ŕ���)_�ŗ�1
            dt.Columns.Add(CT_SalesConf_TaxRate1_ReturnCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_ReturnCostDtl].DefaultValue = defValueInt64;
            #endregion

            #region �u����Őŗ��ŗ��Q�v
            // Title_�ŗ�2
            dt.Columns.Add(CT_SalesConf_TaxRate2_Title, typeof(String));
            dt.Columns[CT_SalesConf_TaxRate2_Title].DefaultValue = defValueString;

            // ���㐔_�ŗ��Q
            dt.Columns.Add(CT_SalesConf_TaxRate2_SalesCountnumberDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_SalesCountnumberDtl].DefaultValue = defValueInt64;

            // ������z_�ŗ��Q
            dt.Columns.Add(CT_SalesConf_TaxRate2_SalesDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_SalesDtl].DefaultValue = defValueInt64;

            // ��������_�ŗ��Q
            dt.Columns.Add(CT_SalesConf_TaxRate2_SalesDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_SalesDtlTax].DefaultValue = defValueInt64;

            // ����̏���ō����v���z_�ŗ��Q
            dt.Columns.Add(CT_SalesConf_TaxRate2_SalesTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_SalesTotalAll].DefaultValue = defValueInt64;

            // ���㌴��(�Ŕ���)_�ŗ��Q
            dt.Columns.Add(CT_SalesConf_TaxRate2_SalesCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_SalesCostDtl].DefaultValue = defValueInt64;

            // �ԕiTitle_�ŗ�2
            dt.Columns.Add(CT_SalesConf_TaxRate2_ReturnTitle, typeof(String));
            dt.Columns[CT_SalesConf_TaxRate2_ReturnTitle].DefaultValue = defValueString;

            // �ԕi��_�ŗ��Q
            dt.Columns.Add(CT_SalesConf_TaxRate2_ReturnSalesCountDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_ReturnSalesCountDtl].DefaultValue = defValueInt64;

            // �ԕi���z_�ŗ��Q
            dt.Columns.Add(CT_SalesConf_TaxRate2_ReturnDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_ReturnDtl].DefaultValue = defValueInt64;

            // �ԕi�����_�ŗ��Q
            dt.Columns.Add(CT_SalesConf_TaxRate2_ReturnDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_ReturnDtlTax].DefaultValue = defValueInt64;

            // �ԕi�̏���ō����v���z_�ŗ��Q
            dt.Columns.Add(CT_SalesConf_TaxRate2_ReturnTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_ReturnTotalAll].DefaultValue = defValueInt64;

            // �ԕi����(�Ŕ���)_�ŗ��Q
            dt.Columns.Add(CT_SalesConf_TaxRate2_ReturnCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_ReturnCostDtl].DefaultValue = defValueInt64;
            #endregion

            #region �u����Őŗ����̑��v
            // Title__���̑�
            dt.Columns.Add(CT_SalesConf_Other_Title, typeof(String));
            dt.Columns[CT_SalesConf_Other_Title].DefaultValue = defValueString;

            // ���㐔_���̑�
            dt.Columns.Add(CT_SalesConf_Other_SalesCountnumberDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_SalesCountnumberDtl].DefaultValue = defValueInt64;

            // ������z_���̑�
            dt.Columns.Add(CT_SalesConf_Other_SalesDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_SalesDtl].DefaultValue = defValueInt64;

            // ��������_���̑�
            dt.Columns.Add(CT_SalesConf_Other_SalesDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_SalesDtlTax].DefaultValue = defValueInt64;

            // ����̏���ō����v���z_���̑�
            dt.Columns.Add(CT_SalesConf_Other_SalesTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_SalesTotalAll].DefaultValue = defValueInt64;

            // ���㌴��(�Ŕ���)_���̑�
            dt.Columns.Add(CT_SalesConf_Other_SalesCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_SalesCostDtl].DefaultValue = defValueInt64;

            // Title__���̑�
            dt.Columns.Add(CT_SalesConf_Other_ReturnTitle, typeof(String));
            dt.Columns[CT_SalesConf_Other_ReturnTitle].DefaultValue = defValueString;

            // �ԕi��_���̑�
            dt.Columns.Add(CT_SalesConf_Other_ReturnSalesCountDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_ReturnSalesCountDtl].DefaultValue = defValueInt64;

            // �ԕi���z_���̑�
            dt.Columns.Add(CT_SalesConf_Other_ReturnDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_ReturnDtl].DefaultValue = defValueInt64;

            // �ԕi�����_���̑�
            dt.Columns.Add(CT_SalesConf_Other_ReturnDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_ReturnDtlTax].DefaultValue = defValueInt64;

            // �ԕi�̏���ō����v���z_���̑�
            dt.Columns.Add(CT_SalesConf_Other_ReturnTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_ReturnTotalAll].DefaultValue = defValueInt64;

            // �ԕi����(�Ŕ���)_���̑�
            dt.Columns.Add(CT_SalesConf_Other_ReturnCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_ReturnCostDtl].DefaultValue = defValueInt64;
            #endregion
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<       

            // ----- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- >>>>>
            #region �u����Őŗ���ېŁv
            // Title__��ې�
            dt.Columns.Add(CT_SalesConf_TaxFree_Title, typeof(String));
            dt.Columns[CT_SalesConf_TaxFree_Title].DefaultValue = defValueString;

            // ���㐔_��ې�
            dt.Columns.Add(CT_SalesConf_TaxFree_SalesCountnumberDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_SalesCountnumberDtl].DefaultValue = defValueInt64;

            // ������z_��ې�
            dt.Columns.Add(CT_SalesConf_TaxFree_SalesDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_SalesDtl].DefaultValue = defValueInt64;

            // ��������_��ې�
            dt.Columns.Add(CT_SalesConf_TaxFree_SalesDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_SalesDtlTax].DefaultValue = defValueInt64;

            // ����̏���ō����v���z_��ې�
            dt.Columns.Add(CT_SalesConf_TaxFree_SalesTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_SalesTotalAll].DefaultValue = defValueInt64;

            // ���㌴��(�Ŕ���)_��ې�
            dt.Columns.Add(CT_SalesConf_TaxFree_SalesCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_SalesCostDtl].DefaultValue = defValueInt64;

            // Title__��ې�
            dt.Columns.Add(CT_SalesConf_TaxFree_ReturnTitle, typeof(String));
            dt.Columns[CT_SalesConf_TaxFree_ReturnTitle].DefaultValue = defValueString;

            // �ԕi��_��ې�
            dt.Columns.Add(CT_SalesConf_TaxFree_ReturnSalesCountDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_ReturnSalesCountDtl].DefaultValue = defValueInt64;

            // �ԕi���z_��ې�
            dt.Columns.Add(CT_SalesConf_TaxFree_ReturnDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_ReturnDtl].DefaultValue = defValueInt64;

            // �ԕi�����_��ې�
            dt.Columns.Add(CT_SalesConf_TaxFree_ReturnDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_ReturnDtlTax].DefaultValue = defValueInt64;

            // �ԕi�̏���ō����v���z_��ې�
            dt.Columns.Add(CT_SalesConf_TaxFree_ReturnTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_ReturnTotalAll].DefaultValue = defValueInt64;

            // �ԕi����(�Ŕ���)_��ې�
            dt.Columns.Add(CT_SalesConf_TaxFree_ReturnCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_ReturnCostDtl].DefaultValue = defValueInt64;
            #endregion
            // ----- ADD 2022/09/05 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j----- <<<<<

            // �`�[�^�C�v�̈󎚗p���t
            // ������t
            dt.Columns.Add(CT_Col_SalesDateY2, typeof(string));
            dt.Columns[CT_Col_SalesDateY2].DefaultValue = defValueString;

            // �v����t
            dt.Columns.Add(CT_Col_AddUpADateY2, typeof(string));
            dt.Columns[CT_Col_AddUpADateY2].DefaultValue = defValueString;

            // �`�[�������t(���͓��t)
            dt.Columns.Add(CT_Col_SearchSlipDateY2, typeof(string));
            dt.Columns[CT_Col_SearchSlipDateY2].DefaultValue = defValueString;

            // --- ADD 2008/10/31 --------------------------------------------------------->>>>>
            // ����œ]�ŕ���[�`�[]
            dt.Columns.Add(CT_Col_ConsTaxLayMethod, typeof(Int32));
            dt.Columns[CT_Col_ConsTaxLayMethod].DefaultValue = defValueInt32;
            // �ېŋ敪[����]
            dt.Columns.Add(CT_Col_TaxationDivCd, typeof(Int32));
            dt.Columns[CT_Col_TaxationDivCd].DefaultValue = defValueInt32;
            // ���v���z(���z�{�����)
            dt.Columns.Add(CT_Col_SalesTotalTaxExcPlusTax, typeof(Double));
            dt.Columns[CT_Col_SalesTotalTaxExcPlusTax].DefaultValue = defValueDouble;
            // --- ADD 2008/10/31 ---------------------------------------------------------<<<<<

            // 2010/06/29 Add >>>
            // �Ԏ피�p����
            dt.Columns.Add(CT_Col_ModelHalfName, typeof(string));
            dt.Columns[CT_Col_ModelHalfName].DefaultValue = defValueString;
            // 2010/06/29 Add <<<

            // --- ADD  ���r��  2010/07/14 ---------->>>>>
            //���i���̃J�i
            dt.Columns.Add(CT_Col_GoodsNameKana, typeof(string));
            dt.Columns[CT_Col_GoodsNameKana].DefaultValue = defValueString;
            // --- ADD  ���r��  2010/07/14 ----------<<<<<

            // �L�[�u���C�N
			dt.Columns.Add(COL_KEYBREAK_AR, typeof(string));
			dt.Columns[COL_KEYBREAK_AR].DefaultValue = "";
		    
            // --- ADD  ����  2010/11/29 ---------->>>>>
            dt.Columns.Add(CT_COL_LOGICALDELETECODE, typeof(string));
            dt.Columns[CT_COL_LOGICALDELETECODE].DefaultValue = "";
            // --- ADD  ����  2010/11/29 ----------<<<<<
		}

		#endregion
	}
}