//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ����f�[�^�e�[�u���X�L�[�}�N���X
// �v���O�����T�v   : ����f�[�^�e�[�u����`���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ����f�[�^�e�[�u���X�L�[�}�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^���o���ʃe�[�u���X�L�[�}</br>
    /// <br>Programmer : 96186�@���ԗT��</br>
    /// <br>Date       : 2008.05.26</br>
    /// </remarks>
    public class SalesSlipSchema
    {
        #region Public Members
        /// <summary>����f�[�^�e�[�u����</summary>
        public const string CT_SalesSlipDataTable = "SalesSlipDataTable";

        /// <summary>�󒍃f�[�^�e�[�u����</summary>
        public const string CT_AcptSlipDataTable = "AcptSlipDataTable";

        #region �J�����������
        public const double defValueDouble = 0;
        public const Int64 defValueInt64 = 0;
        public const Int32 defValueInt32 = 0;
        public const string defValuestring = "";
        #endregion

        #region �J�������
        /// <summary> �쐬���� </summary>
        public const string ct_Col_CreateDateTime = "CreateDateTime";
        /// <summary> �X�V���� </summary>
        public const string ct_Col_UpdateDateTime = "UpdateDateTime";
        /// <summary> ��ƃR�[�h </summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary> GUID </summary>
        public const string ct_Col_FileHeaderGuid = "FileHeaderGuid";
        /// <summary> �X�V�]�ƈ��R�[�h </summary>
        public const string ct_Col_UpdEmployeeCode = "UpdEmployeeCode";
        /// <summary> �X�V�A�Z���u��ID1 </summary>
        public const string ct_Col_UpdAssemblyId1 = "UpdAssemblyId1";
        /// <summary> �X�V�A�Z���u��ID2 </summary>
        public const string ct_Col_UpdAssemblyId2 = "UpdAssemblyId2";
        /// <summary> �_���폜�敪 </summary>
        public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary> �󒍃X�e�[�^�X </summary>
        public const string ct_Col_AcptAnOdrStatus = "AcptAnOdrStatus";
        /// <summary> ����`�[�ԍ� </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";
        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> ����R�[�h </summary>
        public const string ct_Col_SubSectionCode = "SubSectionCode";
        /// <summary> �ԓ`�敪 </summary>
        public const string ct_Col_DebitNoteDiv = "DebitNoteDiv";
        /// <summary> �ԍ��A������`�[�ԍ� </summary>
        public const string ct_Col_DebitNLnkSalesSlNum = "DebitNLnkSalesSlNum";
        /// <summary> ����`�[�敪 </summary>
        public const string ct_Col_SalesSlipCd = "SalesSlipCd";
        /// <summary> ���㏤�i�敪 </summary>
        public const string ct_Col_SalesGoodsCd = "SalesGoodsCd";
        /// <summary> ���|�敪 </summary>
        public const string ct_Col_AccRecDivCd = "AccRecDivCd";
        /// <summary> ������͋��_�R�[�h </summary>
        public const string ct_Col_SalesInpSecCd = "SalesInpSecCd";
        /// <summary> �����v�㋒�_�R�[�h </summary>
        public const string ct_Col_DemandAddUpSecCd = "DemandAddUpSecCd";
        /// <summary> ���ьv�㋒�_�R�[�h </summary>
        public const string ct_Col_ResultsAddUpSecCd = "ResultsAddUpSecCd";
        /// <summary> �X�V���_�R�[�h </summary>
        public const string ct_Col_UpdateSecCd = "UpdateSecCd";
        /// <summary> ����`�[�X�V�敪 </summary>
        public const string ct_Col_SalesSlipUpdateCd = "SalesSlipUpdateCd";
        /// <summary> �`�[�������t </summary>
        public const string ct_Col_SearchSlipDate = "SearchSlipDate";
        /// <summary> �o�ד��t </summary>
        public const string ct_Col_ShipmentDay = "ShipmentDay";
        /// <summary> ������t </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        /// <summary> �v����t </summary>
        public const string ct_Col_AddUpADate = "AddUpADate";
        /// <summary> �����敪 </summary>
        public const string ct_Col_DelayPaymentDiv = "DelayPaymentDiv";
        /// <summary> ���Ϗ��ԍ� </summary>
        public const string ct_Col_EstimateFormNo = "EstimateFormNo";
        /// <summary> ���ϋ敪 </summary>
        public const string ct_Col_EstimateDivide = "EstimateDivide";
        /// <summary> ���͒S���҃R�[�h </summary>
        public const string ct_Col_InputAgenCd = "InputAgenCd";
        /// <summary> ���͒S���Җ��� </summary>
        public const string ct_Col_InputAgenNm = "InputAgenNm";
        /// <summary> ������͎҃R�[�h </summary>
        public const string ct_Col_SalesInputCode = "SalesInputCode";
        /// <summary> ������͎Җ��� </summary>
        public const string ct_Col_SalesInputName = "SalesInputName";
        /// <summary> ��t�]�ƈ��R�[�h </summary>
        public const string ct_Col_FrontEmployeeCd = "FrontEmployeeCd";
        /// <summary> ��t�]�ƈ����� </summary>
        public const string ct_Col_FrontEmployeeNm = "FrontEmployeeNm";
        /// <summary> �̔��]�ƈ��R�[�h </summary>
        public const string ct_Col_SalesEmployeeCd = "SalesEmployeeCd";
        /// <summary> �̔��]�ƈ����� </summary>
        public const string ct_Col_SalesEmployeeNm = "SalesEmployeeNm";
        /// <summary> ���z�\�����@�敪 </summary>
        public const string ct_Col_TotalAmountDispWayCd = "TotalAmountDispWayCd";
        /// <summary> ���z�\���|���K�p�敪 </summary>
        public const string ct_Col_TtlAmntDispRateApy = "TtlAmntDispRateApy";
        /// <summary> ����`�[���v�i�ō��݁j </summary>
        public const string ct_Col_SalesTotalTaxInc = "SalesTotalTaxInc";
        /// <summary> ����`�[���v�i�Ŕ����j </summary>
        public const string ct_Col_SalesTotalTaxExc = "SalesTotalTaxExc";
        /// <summary> ���㕔�i���v�i�ō��݁j </summary>
        public const string ct_Col_SalesPrtTotalTaxInc = "SalesPrtTotalTaxInc";
        /// <summary> ���㕔�i���v�i�Ŕ����j </summary>
        public const string ct_Col_SalesPrtTotalTaxExc = "SalesPrtTotalTaxExc";
        /// <summary> �����ƍ��v�i�ō��݁j </summary>
        public const string ct_Col_SalesWorkTotalTaxInc = "SalesWorkTotalTaxInc";
        /// <summary> �����ƍ��v�i�Ŕ����j </summary>
        public const string ct_Col_SalesWorkTotalTaxExc = "SalesWorkTotalTaxExc";
        /// <summary> ���㏬�v�i�ō��݁j </summary>
        public const string ct_Col_SalesSubtotalTaxInc = "SalesSubtotalTaxInc";
        /// <summary> ���㏬�v�i�Ŕ����j </summary>
        public const string ct_Col_SalesSubtotalTaxExc = "SalesSubtotalTaxExc";
        /// <summary> ���㕔�i���v�i�ō��݁j </summary>
        public const string ct_Col_SalesPrtSubttlInc = "SalesPrtSubttlInc";
        /// <summary> ���㕔�i���v�i�Ŕ����j </summary>
        public const string ct_Col_SalesPrtSubttlExc = "SalesPrtSubttlExc";
        /// <summary> �����Ə��v�i�ō��݁j </summary>
        public const string ct_Col_SalesWorkSubttlInc = "SalesWorkSubttlInc";
        /// <summary> �����Ə��v�i�Ŕ����j </summary>
        public const string ct_Col_SalesWorkSubttlExc = "SalesWorkSubttlExc";
        /// <summary> ���㐳�����z </summary>
        public const string ct_Col_SalesNetPrice = "SalesNetPrice";
        /// <summary> ���㏬�v�i�Łj </summary>
        public const string ct_Col_SalesSubtotalTax = "SalesSubtotalTax";
        /// <summary> ����O�őΏۊz </summary>
        public const string ct_Col_ItdedSalesOutTax = "ItdedSalesOutTax";
        /// <summary> ������őΏۊz </summary>
        public const string ct_Col_ItdedSalesInTax = "ItdedSalesInTax";
        /// <summary> ���㏬�v��ېőΏۊz </summary>
        public const string ct_Col_SalSubttlSubToTaxFre = "SalSubttlSubToTaxFre";
        /// <summary> ������z����Ŋz�i�O�Łj </summary>
        public const string ct_Col_SalesOutTax = "SalesOutTax";
        /// <summary> ������z����Ŋz�i���Łj </summary>
        public const string ct_Col_SalAmntConsTaxInclu = "SalAmntConsTaxInclu";
        /// <summary> ����l�����z�v�i�Ŕ����j </summary>
        public const string ct_Col_SalesDisTtlTaxExc = "SalesDisTtlTaxExc";
        /// <summary> ����l���O�őΏۊz���v </summary>
        public const string ct_Col_ItdedSalesDisOutTax = "ItdedSalesDisOutTax";
        /// <summary> ����l�����őΏۊz���v </summary>
        public const string ct_Col_ItdedSalesDisInTax = "ItdedSalesDisInTax";
        /// <summary> ���i�l���Ώۊz���v�i�Ŕ����j </summary>
        public const string ct_Col_ItdedPartsDisOutTax = "ItdedPartsDisOutTax";
        /// <summary> ���i�l���Ώۊz���v�i�ō��݁j </summary>
        public const string ct_Col_ItdedPartsDisInTax = "ItdedPartsDisInTax";
        /// <summary> ��ƒl���Ώۊz���v�i�Ŕ����j </summary>
        public const string ct_Col_ItdedWorkDisOutTax = "ItdedWorkDisOutTax";
        /// <summary> ��ƒl���Ώۊz���v�i�ō��݁j </summary>
        public const string ct_Col_ItdedWorkDisInTax = "ItdedWorkDisInTax";
        /// <summary> ����l����ېőΏۊz���v </summary>
        public const string ct_Col_ItdedSalesDisTaxFre = "ItdedSalesDisTaxFre";
        /// <summary> ����l������Ŋz�i�O�Łj </summary>
        public const string ct_Col_SalesDisOutTax = "SalesDisOutTax";
        /// <summary> ����l������Ŋz�i���Łj </summary>
        public const string ct_Col_SalesDisTtlTaxInclu = "SalesDisTtlTaxInclu";
        /// <summary> ���i�l���� </summary>
        public const string ct_Col_PartsDiscountRate = "PartsDiscountRate";
        /// <summary> �H���l���� </summary>
        public const string ct_Col_RavorDiscountRate = "RavorDiscountRate";
        /// <summary> �������z�v </summary>
        public const string ct_Col_TotalCost = "TotalCost";
        /// <summary> ����œ]�ŕ��� </summary>
        public const string ct_Col_ConsTaxLayMethod = "ConsTaxLayMethod";
        /// <summary> ����Őŗ� </summary>
        public const string ct_Col_ConsTaxRate = "ConsTaxRate";
        /// <summary> �[�������敪 </summary>
        public const string ct_Col_FractionProcCd = "FractionProcCd";
        /// <summary> ���|����� </summary>
        public const string ct_Col_AccRecConsTax = "AccRecConsTax";
        /// <summary> ���������敪 </summary>
        public const string ct_Col_AutoDepositCd = "AutoDepositCd";
        /// <summary> ���������`�[�ԍ� </summary>
        public const string ct_Col_AutoDepositSlipNo = "AutoDepositSlipNo";
        /// <summary> �����������v�z </summary>
        public const string ct_Col_DepositAllowanceTtl = "DepositAllowanceTtl";
        /// <summary> ���������c�� </summary>
        public const string ct_Col_DepositAlwcBlnce = "DepositAlwcBlnce";
        /// <summary> ������R�[�h </summary>
        public const string ct_Col_ClaimCode = "ClaimCode";
        /// <summary> �����旪�� </summary>
        public const string ct_Col_ClaimSnm = "ClaimSnm";
        /// <summary> ���Ӑ�R�[�h </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> ���Ӑ於�� </summary>
        public const string ct_Col_CustomerName = "CustomerName";
        /// <summary> ���Ӑ於��2 </summary>
        public const string ct_Col_CustomerName2 = "CustomerName2";
        /// <summary> ���Ӑ旪�� </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> �h�� </summary>
        public const string ct_Col_HonorificTitle = "HonorificTitle";
        /// <summary> �����R�[�h </summary>
        public const string ct_Col_OutputNameCode = "OutputNameCode";
        /// <summary> �������� </summary>
        public const string ct_Col_OutputName = "OutputName";
        /// <summary> ���Ӑ�`�[�ԍ� </summary>
        public const string ct_Col_CustSlipNo = "CustSlipNo";
        /// <summary> �`�[�Z���敪 </summary>
        public const string ct_Col_SlipAddressDiv = "SlipAddressDiv";
        /// <summary> �[�i��R�[�h </summary>
        public const string ct_Col_AddresseeCode = "AddresseeCode";
        /// <summary> �[�i�於�� </summary>
        public const string ct_Col_AddresseeName = "AddresseeName";
        /// <summary> �[�i�於��2 </summary>
        public const string ct_Col_AddresseeName2 = "AddresseeName2";
        /// <summary> �[�i��X�֔ԍ� </summary>
        public const string ct_Col_AddresseePostNo = "AddresseePostNo";
        /// <summary> �[�i��Z��1(�s���{���s��S�E�����E��) </summary>
        public const string ct_Col_AddresseeAddr1 = "AddresseeAddr1";
        /// <summary> �[�i��Z��3(�Ԓn) </summary>
        public const string ct_Col_AddresseeAddr3 = "AddresseeAddr3";
        /// <summary> �[�i��Z��4(�A�p�[�g����) </summary>
        public const string ct_Col_AddresseeAddr4 = "AddresseeAddr4";
        /// <summary> �[�i��d�b�ԍ� </summary>
        public const string ct_Col_AddresseeTelNo = "AddresseeTelNo";
        /// <summary> �[�i��FAX�ԍ� </summary>
        public const string ct_Col_AddresseeFaxNo = "AddresseeFaxNo";
        /// <summary> �����`�[�ԍ� </summary>
        public const string ct_Col_PartySaleSlipNum = "PartySaleSlipNum";
        /// <summary> �`�[���l </summary>
        public const string ct_Col_SlipNote = "SlipNote";
        /// <summary> �`�[���l�Q </summary>
        public const string ct_Col_SlipNote2 = "SlipNote2";
        /// <summary> �`�[���l�R </summary>
        public const string ct_Col_SlipNote3 = "SlipNote3";
        /// <summary> �ԕi���R�R�[�h </summary>
        public const string ct_Col_RetGoodsReasonDiv = "RetGoodsReasonDiv";
        /// <summary> �ԕi���R </summary>
        public const string ct_Col_RetGoodsReason = "RetGoodsReason";
        /// <summary> ���W������ </summary>
        public const string ct_Col_RegiProcDate = "RegiProcDate";
        /// <summary> ���W�ԍ� </summary>
        public const string ct_Col_CashRegisterNo = "CashRegisterNo";
        /// <summary> POS���V�[�g�ԍ� </summary>
        public const string ct_Col_PosReceiptNo = "PosReceiptNo";
        /// <summary> ���׍s�� </summary>
        public const string ct_Col_DetailRowCount = "DetailRowCount";
        /// <summary> �d�c�h���M�� </summary>
        public const string ct_Col_EdiSendDate = "EdiSendDate";
        /// <summary> �d�c�h�捞�� </summary>
        public const string ct_Col_EdiTakeInDate = "EdiTakeInDate";
        /// <summary> �t�n�d���}�[�N�P </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        /// <summary> �t�n�d���}�[�N�Q </summary>
        public const string ct_Col_UoeRemark2 = "UoeRemark2";
        /// <summary> �`�[���s�敪 </summary>
        public const string ct_Col_SlipPrintDivCd = "SlipPrintDivCd";
        /// <summary> �`�[���s�ϋ敪 </summary>
        public const string ct_Col_SlipPrintFinishCd = "SlipPrintFinishCd";
        /// <summary> ����`�[���s�� </summary>
        public const string ct_Col_SalesSlipPrintDate = "SalesSlipPrintDate";
        /// <summary> �Ǝ�R�[�h </summary>
        public const string ct_Col_BusinessTypeCode = "BusinessTypeCode";
        /// <summary> �Ǝ햼�� </summary>
        public const string ct_Col_BusinessTypeName = "BusinessTypeName";
        /// <summary> �����ԍ� </summary>
        public const string ct_Col_OrderNumber = "OrderNumber";
        /// <summary> �[�i�敪 </summary>
        public const string ct_Col_DeliveredGoodsDiv = "DeliveredGoodsDiv";
        /// <summary> �[�i�敪���� </summary>
        public const string ct_Col_DeliveredGoodsDivNm = "DeliveredGoodsDivNm";
        /// <summary> �̔��G���A�R�[�h </summary>
        public const string ct_Col_SalesAreaCode = "SalesAreaCode";
        /// <summary> �̔��G���A���� </summary>
        public const string ct_Col_SalesAreaName = "SalesAreaName";
        /// <summary> �����t���O </summary>
        public const string ct_Col_ReconcileFlag = "ReconcileFlag";
        /// <summary> �`�[����ݒ�p���[ID </summary>
        public const string ct_Col_SlipPrtSetPaperId = "SlipPrtSetPaperId";
        /// <summary> �ꎮ�`�[�敪 </summary>
        public const string ct_Col_CompleteCd = "CompleteCd";
        /// <summary> ������z�[�������敪 </summary>
        public const string ct_Col_SalesPriceFracProcCd = "SalesPriceFracProcCd";
        /// <summary> �݌ɏ��i���v���z�i�Ŕ��j </summary>
        public const string ct_Col_StockGoodsTtlTaxExc = "StockGoodsTtlTaxExc";
        /// <summary> �������i���v���z�i�Ŕ��j </summary>
        public const string ct_Col_PureGoodsTtlTaxExc = "PureGoodsTtlTaxExc";
        /// <summary> �艿����敪 </summary>
        public const string ct_Col_ListPricePrintDiv = "ListPricePrintDiv";
        /// <summary> �����\���敪�P </summary>
        public const string ct_Col_EraNameDispCd1 = "EraNameDispCd1";
        /// <summary> ���Ϗ���ŋ敪 </summary>
        public const string ct_Col_EstimaTaxDivCd = "EstimaTaxDivCd";
        /// <summary> ���Ϗ�����敪 </summary>
        public const string ct_Col_EstimateFormPrtCd = "EstimateFormPrtCd";
        /// <summary> ���ό��� </summary>
        public const string ct_Col_EstimateSubject = "EstimateSubject";
        /// <summary> �r���P </summary>
        public const string ct_Col_Footnotes1 = "Footnotes1";
        /// <summary> �r���Q </summary>
        public const string ct_Col_Footnotes2 = "Footnotes2";
        /// <summary> ���σ^�C�g���P </summary>
        public const string ct_Col_EstimateTitle1 = "EstimateTitle1";
        /// <summary> ���σ^�C�g���Q </summary>
        public const string ct_Col_EstimateTitle2 = "EstimateTitle2";
        /// <summary> ���σ^�C�g���R </summary>
        public const string ct_Col_EstimateTitle3 = "EstimateTitle3";
        /// <summary> ���σ^�C�g���S </summary>
        public const string ct_Col_EstimateTitle4 = "EstimateTitle4";
        /// <summary> ���σ^�C�g���T </summary>
        public const string ct_Col_EstimateTitle5 = "EstimateTitle5";
        /// <summary> ���ϔ��l�P </summary>
        public const string ct_Col_EstimateNote1 = "EstimateNote1";
        /// <summary> ���ϔ��l�Q </summary>
        public const string ct_Col_EstimateNote2 = "EstimateNote2";
        /// <summary> ���ϔ��l�R </summary>
        public const string ct_Col_EstimateNote3 = "EstimateNote3";
        /// <summary> ���ϔ��l�S </summary>
        public const string ct_Col_EstimateNote4 = "EstimateNote4";
        /// <summary> ���ϔ��l�T </summary>
        public const string ct_Col_EstimateNote5 = "EstimateNote5";
        /// <summary> ���ϗL������ </summary>
        public const string ct_Col_EstimateValidityDate = "EstimateValidityDate";
        /// <summary> �i�Ԉ󎚋敪 </summary>
        public const string ct_Col_PartsNoPrtCd = "PartsNoPrtCd";
        /// <summary> �I�v�V�����󎚋敪 </summary>
        public const string ct_Col_OptionPringDivCd = "OptionPringDivCd";
        /// <summary> �|���g�p�敪 </summary>
        public const string ct_Col_RateUseCode = "RateUseCode";

        /// <summary> ����`�[�ԍ��i���j </summary>
        public const string ct_Col_TempSalesSlipNum = "TempSalesSlipNum";
        /// <summary> �o�ɐ����v </summary>
        public const string ct_Col_TotalCnt = "TotalCnt";
        /// <summary>UOE�`�[���</summary>
        public const string ct_Col_SlipCd = "SlipCd";
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// ����f�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
        /// <br>Programmer : 96186�@���ԗT��</br>
        /// <br>Date       : 2008.05.26</br>
        /// </remarks>
        public SalesSlipSchema()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2006.01.21</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds, string dataTableName)
        {
            // �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(dataTableName)))
            {
                // TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
                // �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[dataTableName].Clear();
            }
            else
            {
                CreateTable(ref ds, dataTableName);

            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// ����f�[�^�쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2008.05.26</br>
        /// </remarks>
        private static void CreateTable(ref DataSet ds, string dataTableName)
        {
            DataTable dt = null;
            // �X�L�[�}�ݒ�
            ds.Tables.Add(dataTableName);
            dt = ds.Tables[dataTableName];

            // �쐬����
            dt.Columns.Add(ct_Col_CreateDateTime, typeof(Int64));
            dt.Columns[ct_Col_CreateDateTime].DefaultValue = defValueInt64;
            // �X�V����
            dt.Columns.Add(ct_Col_UpdateDateTime, typeof(Int64));
            dt.Columns[ct_Col_UpdateDateTime].DefaultValue = defValueInt64;
            // ��ƃR�[�h
            dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
            dt.Columns[ct_Col_EnterpriseCode].DefaultValue = defValuestring;
            // GUID
            dt.Columns.Add(ct_Col_FileHeaderGuid, typeof(Guid));
            dt.Columns[ct_Col_FileHeaderGuid].DefaultValue = Guid.Empty;
            // �X�V�]�ƈ��R�[�h
            dt.Columns.Add(ct_Col_UpdEmployeeCode, typeof(string));
            dt.Columns[ct_Col_UpdEmployeeCode].DefaultValue = defValuestring;
            // �X�V�A�Z���u��ID1
            dt.Columns.Add(ct_Col_UpdAssemblyId1, typeof(string));
            dt.Columns[ct_Col_UpdAssemblyId1].DefaultValue = defValuestring;
            // �X�V�A�Z���u��ID2
            dt.Columns.Add(ct_Col_UpdAssemblyId2, typeof(string));
            dt.Columns[ct_Col_UpdAssemblyId2].DefaultValue = defValuestring;
            // �_���폜�敪
            dt.Columns.Add(ct_Col_LogicalDeleteCode, typeof(Int32));
            dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = defValueInt32;
            // �󒍃X�e�[�^�X
            dt.Columns.Add(ct_Col_AcptAnOdrStatus, typeof(Int32));
            dt.Columns[ct_Col_AcptAnOdrStatus].DefaultValue = defValueInt32;
            // ����`�[�ԍ�
            dt.Columns.Add(ct_Col_SalesSlipNum, typeof(string));
            dt.Columns[ct_Col_SalesSlipNum].DefaultValue = defValuestring;
            // ���_�R�[�h
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defValuestring;
            // ����R�[�h
            dt.Columns.Add(ct_Col_SubSectionCode, typeof(Int32));
            dt.Columns[ct_Col_SubSectionCode].DefaultValue = defValueInt32;
            // �ԓ`�敪
            dt.Columns.Add(ct_Col_DebitNoteDiv, typeof(Int32));
            dt.Columns[ct_Col_DebitNoteDiv].DefaultValue = defValueInt32;
            // �ԍ��A������`�[�ԍ�
            dt.Columns.Add(ct_Col_DebitNLnkSalesSlNum, typeof(string));
            dt.Columns[ct_Col_DebitNLnkSalesSlNum].DefaultValue = defValuestring;
            // ����`�[�敪
            dt.Columns.Add(ct_Col_SalesSlipCd, typeof(Int32));
            dt.Columns[ct_Col_SalesSlipCd].DefaultValue = defValueInt32;
            // ���㏤�i�敪
            dt.Columns.Add(ct_Col_SalesGoodsCd, typeof(Int32));
            dt.Columns[ct_Col_SalesGoodsCd].DefaultValue = defValueInt32;
            // ���|�敪
            dt.Columns.Add(ct_Col_AccRecDivCd, typeof(Int32));
            dt.Columns[ct_Col_AccRecDivCd].DefaultValue = defValueInt32;
            // ������͋��_�R�[�h
            dt.Columns.Add(ct_Col_SalesInpSecCd, typeof(string));
            dt.Columns[ct_Col_SalesInpSecCd].DefaultValue = defValuestring;
            // �����v�㋒�_�R�[�h
            dt.Columns.Add(ct_Col_DemandAddUpSecCd, typeof(string));
            dt.Columns[ct_Col_DemandAddUpSecCd].DefaultValue = defValuestring;
            // ���ьv�㋒�_�R�[�h
            dt.Columns.Add(ct_Col_ResultsAddUpSecCd, typeof(string));
            dt.Columns[ct_Col_ResultsAddUpSecCd].DefaultValue = defValuestring;
            // �X�V���_�R�[�h
            dt.Columns.Add(ct_Col_UpdateSecCd, typeof(string));
            dt.Columns[ct_Col_UpdateSecCd].DefaultValue = defValuestring;
            // ����`�[�X�V�敪
            dt.Columns.Add(ct_Col_SalesSlipUpdateCd, typeof(Int32));
            dt.Columns[ct_Col_SalesSlipUpdateCd].DefaultValue = defValueInt32;
            // �`�[�������t
            dt.Columns.Add(ct_Col_SearchSlipDate, typeof(DateTime));
            dt.Columns[ct_Col_SearchSlipDate].DefaultValue = DateTime.MinValue;
            // �o�ד��t
            dt.Columns.Add(ct_Col_ShipmentDay, typeof(DateTime));
            dt.Columns[ct_Col_ShipmentDay].DefaultValue = DateTime.MinValue;
            // ������t
            dt.Columns.Add(ct_Col_SalesDate, typeof(DateTime));
            dt.Columns[ct_Col_SalesDate].DefaultValue = DateTime.MinValue;
            // �v����t
            dt.Columns.Add(ct_Col_AddUpADate, typeof(DateTime));
            dt.Columns[ct_Col_AddUpADate].DefaultValue = DateTime.MinValue;
            // �����敪
            dt.Columns.Add(ct_Col_DelayPaymentDiv, typeof(Int32));
            dt.Columns[ct_Col_DelayPaymentDiv].DefaultValue = defValueInt32;
            // ���Ϗ��ԍ�
            dt.Columns.Add(ct_Col_EstimateFormNo, typeof(string));
            dt.Columns[ct_Col_EstimateFormNo].DefaultValue = defValuestring;
            // ���ϋ敪
            dt.Columns.Add(ct_Col_EstimateDivide, typeof(Int32));
            dt.Columns[ct_Col_EstimateDivide].DefaultValue = defValueInt32;
            // ���͒S���҃R�[�h
            dt.Columns.Add(ct_Col_InputAgenCd, typeof(string));
            dt.Columns[ct_Col_InputAgenCd].DefaultValue = defValuestring;
            // ���͒S���Җ���
            dt.Columns.Add(ct_Col_InputAgenNm, typeof(string));
            dt.Columns[ct_Col_InputAgenNm].DefaultValue = defValuestring;
            // ������͎҃R�[�h
            dt.Columns.Add(ct_Col_SalesInputCode, typeof(string));
            dt.Columns[ct_Col_SalesInputCode].DefaultValue = defValuestring;
            // ������͎Җ���
            dt.Columns.Add(ct_Col_SalesInputName, typeof(string));
            dt.Columns[ct_Col_SalesInputName].DefaultValue = defValuestring;
            // ��t�]�ƈ��R�[�h
            dt.Columns.Add(ct_Col_FrontEmployeeCd, typeof(string));
            dt.Columns[ct_Col_FrontEmployeeCd].DefaultValue = defValuestring;
            // ��t�]�ƈ�����
            dt.Columns.Add(ct_Col_FrontEmployeeNm, typeof(string));
            dt.Columns[ct_Col_FrontEmployeeNm].DefaultValue = defValuestring;
            // �̔��]�ƈ��R�[�h
            dt.Columns.Add(ct_Col_SalesEmployeeCd, typeof(string));
            dt.Columns[ct_Col_SalesEmployeeCd].DefaultValue = defValuestring;
            // �̔��]�ƈ�����
            dt.Columns.Add(ct_Col_SalesEmployeeNm, typeof(string));
            dt.Columns[ct_Col_SalesEmployeeNm].DefaultValue = defValuestring;
            // ���z�\�����@�敪
            dt.Columns.Add(ct_Col_TotalAmountDispWayCd, typeof(Int32));
            dt.Columns[ct_Col_TotalAmountDispWayCd].DefaultValue = defValueInt32;
            // ���z�\���|���K�p�敪
            dt.Columns.Add(ct_Col_TtlAmntDispRateApy, typeof(Int32));
            dt.Columns[ct_Col_TtlAmntDispRateApy].DefaultValue = defValueInt32;
            // ����`�[���v�i�ō��݁j
            dt.Columns.Add(ct_Col_SalesTotalTaxInc, typeof(Int64));
            dt.Columns[ct_Col_SalesTotalTaxInc].DefaultValue = defValueInt64;
            // ����`�[���v�i�Ŕ����j
            dt.Columns.Add(ct_Col_SalesTotalTaxExc, typeof(Int64));
            dt.Columns[ct_Col_SalesTotalTaxExc].DefaultValue = defValueInt64;
            // ���㕔�i���v�i�ō��݁j
            dt.Columns.Add(ct_Col_SalesPrtTotalTaxInc, typeof(Int64));
            dt.Columns[ct_Col_SalesPrtTotalTaxInc].DefaultValue = defValueInt64;
            // ���㕔�i���v�i�Ŕ����j
            dt.Columns.Add(ct_Col_SalesPrtTotalTaxExc, typeof(Int64));
            dt.Columns[ct_Col_SalesPrtTotalTaxExc].DefaultValue = defValueInt64;
            // �����ƍ��v�i�ō��݁j
            dt.Columns.Add(ct_Col_SalesWorkTotalTaxInc, typeof(Int64));
            dt.Columns[ct_Col_SalesWorkTotalTaxInc].DefaultValue = defValueInt64;
            // �����ƍ��v�i�Ŕ����j
            dt.Columns.Add(ct_Col_SalesWorkTotalTaxExc, typeof(Int64));
            dt.Columns[ct_Col_SalesWorkTotalTaxExc].DefaultValue = defValueInt64;
            // ���㏬�v�i�ō��݁j
            dt.Columns.Add(ct_Col_SalesSubtotalTaxInc, typeof(Int64));
            dt.Columns[ct_Col_SalesSubtotalTaxInc].DefaultValue = defValueInt64;
            // ���㏬�v�i�Ŕ����j
            dt.Columns.Add(ct_Col_SalesSubtotalTaxExc, typeof(Int64));
            dt.Columns[ct_Col_SalesSubtotalTaxExc].DefaultValue = defValueInt64;
            // ���㕔�i���v�i�ō��݁j
            dt.Columns.Add(ct_Col_SalesPrtSubttlInc, typeof(Int64));
            dt.Columns[ct_Col_SalesPrtSubttlInc].DefaultValue = defValueInt64;
            // ���㕔�i���v�i�Ŕ����j
            dt.Columns.Add(ct_Col_SalesPrtSubttlExc, typeof(Int64));
            dt.Columns[ct_Col_SalesPrtSubttlExc].DefaultValue = defValueInt64;
            // �����Ə��v�i�ō��݁j
            dt.Columns.Add(ct_Col_SalesWorkSubttlInc, typeof(Int64));
            dt.Columns[ct_Col_SalesWorkSubttlInc].DefaultValue = defValueInt64;
            // �����Ə��v�i�Ŕ����j
            dt.Columns.Add(ct_Col_SalesWorkSubttlExc, typeof(Int64));
            dt.Columns[ct_Col_SalesWorkSubttlExc].DefaultValue = defValueInt64;
            // ���㐳�����z
            dt.Columns.Add(ct_Col_SalesNetPrice, typeof(Int64));
            dt.Columns[ct_Col_SalesNetPrice].DefaultValue = defValueInt64;
            // ���㏬�v�i�Łj
            dt.Columns.Add(ct_Col_SalesSubtotalTax, typeof(Int64));
            dt.Columns[ct_Col_SalesSubtotalTax].DefaultValue = defValueInt64;
            // ����O�őΏۊz
            dt.Columns.Add(ct_Col_ItdedSalesOutTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedSalesOutTax].DefaultValue = defValueInt64;
            // ������őΏۊz
            dt.Columns.Add(ct_Col_ItdedSalesInTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedSalesInTax].DefaultValue = defValueInt64;
            // ���㏬�v��ېőΏۊz
            dt.Columns.Add(ct_Col_SalSubttlSubToTaxFre, typeof(Int64));
            dt.Columns[ct_Col_SalSubttlSubToTaxFre].DefaultValue = defValueInt64;
            // ������z����Ŋz�i�O�Łj
            dt.Columns.Add(ct_Col_SalesOutTax, typeof(Int64));
            dt.Columns[ct_Col_SalesOutTax].DefaultValue = defValueInt64;
            // ������z����Ŋz�i���Łj
            dt.Columns.Add(ct_Col_SalAmntConsTaxInclu, typeof(Int64));
            dt.Columns[ct_Col_SalAmntConsTaxInclu].DefaultValue = defValueInt64;
            // ����l�����z�v�i�Ŕ����j
            dt.Columns.Add(ct_Col_SalesDisTtlTaxExc, typeof(Int64));
            dt.Columns[ct_Col_SalesDisTtlTaxExc].DefaultValue = defValueInt64;
            // ����l���O�őΏۊz���v
            dt.Columns.Add(ct_Col_ItdedSalesDisOutTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedSalesDisOutTax].DefaultValue = defValueInt64;
            // ����l�����őΏۊz���v
            dt.Columns.Add(ct_Col_ItdedSalesDisInTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedSalesDisInTax].DefaultValue = defValueInt64;
            // ���i�l���Ώۊz���v�i�Ŕ����j
            dt.Columns.Add(ct_Col_ItdedPartsDisOutTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedPartsDisOutTax].DefaultValue = defValueInt64;
            // ���i�l���Ώۊz���v�i�ō��݁j
            dt.Columns.Add(ct_Col_ItdedPartsDisInTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedPartsDisInTax].DefaultValue = defValueInt64;
            // ��ƒl���Ώۊz���v�i�Ŕ����j
            dt.Columns.Add(ct_Col_ItdedWorkDisOutTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedWorkDisOutTax].DefaultValue = defValueInt64;
            // ��ƒl���Ώۊz���v�i�ō��݁j
            dt.Columns.Add(ct_Col_ItdedWorkDisInTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedWorkDisInTax].DefaultValue = defValueInt64;
            // ����l����ېőΏۊz���v
            dt.Columns.Add(ct_Col_ItdedSalesDisTaxFre, typeof(Int64));
            dt.Columns[ct_Col_ItdedSalesDisTaxFre].DefaultValue = defValueInt64;
            // ����l������Ŋz�i�O�Łj
            dt.Columns.Add(ct_Col_SalesDisOutTax, typeof(Int64));
            dt.Columns[ct_Col_SalesDisOutTax].DefaultValue = defValueInt64;
            // ����l������Ŋz�i���Łj
            dt.Columns.Add(ct_Col_SalesDisTtlTaxInclu, typeof(Int64));
            dt.Columns[ct_Col_SalesDisTtlTaxInclu].DefaultValue = defValueInt64;
            // ���i�l����
            dt.Columns.Add(ct_Col_PartsDiscountRate, typeof(Double));
            dt.Columns[ct_Col_PartsDiscountRate].DefaultValue = defValueDouble;
            // �H���l����
            dt.Columns.Add(ct_Col_RavorDiscountRate, typeof(Double));
            dt.Columns[ct_Col_RavorDiscountRate].DefaultValue = defValueDouble;
            // �������z�v
            dt.Columns.Add(ct_Col_TotalCost, typeof(Int64));
            dt.Columns[ct_Col_TotalCost].DefaultValue = defValueInt64;
            // ����œ]�ŕ���
            dt.Columns.Add(ct_Col_ConsTaxLayMethod, typeof(Int32));
            dt.Columns[ct_Col_ConsTaxLayMethod].DefaultValue = defValueInt32;
            // ����Őŗ�
            dt.Columns.Add(ct_Col_ConsTaxRate, typeof(Double));
            dt.Columns[ct_Col_ConsTaxRate].DefaultValue = defValueDouble;
            // �[�������敪
            dt.Columns.Add(ct_Col_FractionProcCd, typeof(Int32));
            dt.Columns[ct_Col_FractionProcCd].DefaultValue = defValueInt32;
            // ���|�����
            dt.Columns.Add(ct_Col_AccRecConsTax, typeof(Int64));
            dt.Columns[ct_Col_AccRecConsTax].DefaultValue = defValueInt64;
            // ���������敪
            dt.Columns.Add(ct_Col_AutoDepositCd, typeof(Int32));
            dt.Columns[ct_Col_AutoDepositCd].DefaultValue = defValueInt32;
            // ���������`�[�ԍ�
            dt.Columns.Add(ct_Col_AutoDepositSlipNo, typeof(Int32));
            dt.Columns[ct_Col_AutoDepositSlipNo].DefaultValue = defValueInt32;
            // �����������v�z
            dt.Columns.Add(ct_Col_DepositAllowanceTtl, typeof(Int64));
            dt.Columns[ct_Col_DepositAllowanceTtl].DefaultValue = defValueInt64;
            // ���������c��
            dt.Columns.Add(ct_Col_DepositAlwcBlnce, typeof(Int64));
            dt.Columns[ct_Col_DepositAlwcBlnce].DefaultValue = defValueInt64;
            // ������R�[�h
            dt.Columns.Add(ct_Col_ClaimCode, typeof(Int32));
            dt.Columns[ct_Col_ClaimCode].DefaultValue = defValueInt32;
            // �����旪��
            dt.Columns.Add(ct_Col_ClaimSnm, typeof(string));
            dt.Columns[ct_Col_ClaimSnm].DefaultValue = defValuestring;
            // ���Ӑ�R�[�h
            dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
            dt.Columns[ct_Col_CustomerCode].DefaultValue = defValueInt32;
            // ���Ӑ於��
            dt.Columns.Add(ct_Col_CustomerName, typeof(string));
            dt.Columns[ct_Col_CustomerName].DefaultValue = defValuestring;
            // ���Ӑ於��2
            dt.Columns.Add(ct_Col_CustomerName2, typeof(string));
            dt.Columns[ct_Col_CustomerName2].DefaultValue = defValuestring;
            // ���Ӑ旪��
            dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
            dt.Columns[ct_Col_CustomerSnm].DefaultValue = defValuestring;
            // �h��
            dt.Columns.Add(ct_Col_HonorificTitle, typeof(string));
            dt.Columns[ct_Col_HonorificTitle].DefaultValue = defValuestring;
            // �����R�[�h
            dt.Columns.Add(ct_Col_OutputNameCode, typeof(Int32));
            dt.Columns[ct_Col_OutputNameCode].DefaultValue = defValueInt32;
            // ��������
            dt.Columns.Add(ct_Col_OutputName, typeof(string));
            dt.Columns[ct_Col_OutputName].DefaultValue = defValuestring;
            // ���Ӑ�`�[�ԍ�
            dt.Columns.Add(ct_Col_CustSlipNo, typeof(Int32));
            dt.Columns[ct_Col_CustSlipNo].DefaultValue = defValueInt32;
            // �`�[�Z���敪
            dt.Columns.Add(ct_Col_SlipAddressDiv, typeof(Int32));
            dt.Columns[ct_Col_SlipAddressDiv].DefaultValue = defValueInt32;
            // �[�i��R�[�h
            dt.Columns.Add(ct_Col_AddresseeCode, typeof(Int32));
            dt.Columns[ct_Col_AddresseeCode].DefaultValue = defValueInt32;
            // �[�i�於��
            dt.Columns.Add(ct_Col_AddresseeName, typeof(string));
            dt.Columns[ct_Col_AddresseeName].DefaultValue = defValuestring;
            // �[�i�於��2
            dt.Columns.Add(ct_Col_AddresseeName2, typeof(string));
            dt.Columns[ct_Col_AddresseeName2].DefaultValue = defValuestring;
            // �[�i��X�֔ԍ�
            dt.Columns.Add(ct_Col_AddresseePostNo, typeof(string));
            dt.Columns[ct_Col_AddresseePostNo].DefaultValue = defValuestring;
            // �[�i��Z��1(�s���{���s��S�E�����E��)
            dt.Columns.Add(ct_Col_AddresseeAddr1, typeof(string));
            dt.Columns[ct_Col_AddresseeAddr1].DefaultValue = defValuestring;
            // �[�i��Z��3(�Ԓn)
            dt.Columns.Add(ct_Col_AddresseeAddr3, typeof(string));
            dt.Columns[ct_Col_AddresseeAddr3].DefaultValue = defValuestring;
            // �[�i��Z��4(�A�p�[�g����)
            dt.Columns.Add(ct_Col_AddresseeAddr4, typeof(string));
            dt.Columns[ct_Col_AddresseeAddr4].DefaultValue = defValuestring;
            // �[�i��d�b�ԍ�
            dt.Columns.Add(ct_Col_AddresseeTelNo, typeof(string));
            dt.Columns[ct_Col_AddresseeTelNo].DefaultValue = defValuestring;
            // �[�i��FAX�ԍ�
            dt.Columns.Add(ct_Col_AddresseeFaxNo, typeof(string));
            dt.Columns[ct_Col_AddresseeFaxNo].DefaultValue = defValuestring;
            // �����`�[�ԍ�
            dt.Columns.Add(ct_Col_PartySaleSlipNum, typeof(string));
            dt.Columns[ct_Col_PartySaleSlipNum].DefaultValue = defValuestring;
            // �`�[���l
            dt.Columns.Add(ct_Col_SlipNote, typeof(string));
            dt.Columns[ct_Col_SlipNote].DefaultValue = defValuestring;
            // �`�[���l�Q
            dt.Columns.Add(ct_Col_SlipNote2, typeof(string));
            dt.Columns[ct_Col_SlipNote2].DefaultValue = defValuestring;
            // �`�[���l�R
            dt.Columns.Add(ct_Col_SlipNote3, typeof(string));
            dt.Columns[ct_Col_SlipNote3].DefaultValue = defValuestring;
            // �ԕi���R�R�[�h
            dt.Columns.Add(ct_Col_RetGoodsReasonDiv, typeof(Int32));
            dt.Columns[ct_Col_RetGoodsReasonDiv].DefaultValue = defValueInt32;
            // �ԕi���R
            dt.Columns.Add(ct_Col_RetGoodsReason, typeof(string));
            dt.Columns[ct_Col_RetGoodsReason].DefaultValue = defValuestring;
            // ���W������
            dt.Columns.Add(ct_Col_RegiProcDate, typeof(DateTime));
            dt.Columns[ct_Col_RegiProcDate].DefaultValue = DateTime.MinValue;
            // ���W�ԍ�
            dt.Columns.Add(ct_Col_CashRegisterNo, typeof(Int32));
            dt.Columns[ct_Col_CashRegisterNo].DefaultValue = defValueInt32;
            // POS���V�[�g�ԍ�
            dt.Columns.Add(ct_Col_PosReceiptNo, typeof(Int32));
            dt.Columns[ct_Col_PosReceiptNo].DefaultValue = defValueInt32;
            // ���׍s��
            dt.Columns.Add(ct_Col_DetailRowCount, typeof(Int32));
            dt.Columns[ct_Col_DetailRowCount].DefaultValue = defValueInt32;
            // �d�c�h���M��
            dt.Columns.Add(ct_Col_EdiSendDate, typeof(DateTime));
            dt.Columns[ct_Col_EdiSendDate].DefaultValue = DateTime.MinValue;
            // �d�c�h�捞��
            dt.Columns.Add(ct_Col_EdiTakeInDate, typeof(DateTime));
            dt.Columns[ct_Col_EdiTakeInDate].DefaultValue = DateTime.MinValue;
            // �t�n�d���}�[�N�P
            dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
            dt.Columns[ct_Col_UoeRemark1].DefaultValue = defValuestring;
            // �t�n�d���}�[�N�Q
            dt.Columns.Add(ct_Col_UoeRemark2, typeof(string));
            dt.Columns[ct_Col_UoeRemark2].DefaultValue = defValuestring;
            // �`�[���s�敪
            dt.Columns.Add(ct_Col_SlipPrintDivCd, typeof(Int32));
            dt.Columns[ct_Col_SlipPrintDivCd].DefaultValue = defValueInt32;
            // �`�[���s�ϋ敪
            dt.Columns.Add(ct_Col_SlipPrintFinishCd, typeof(Int32));
            dt.Columns[ct_Col_SlipPrintFinishCd].DefaultValue = defValueInt32;
            // ����`�[���s��
            dt.Columns.Add(ct_Col_SalesSlipPrintDate, typeof(DateTime));
            dt.Columns[ct_Col_SalesSlipPrintDate].DefaultValue = DateTime.MinValue;
            // �Ǝ�R�[�h
            dt.Columns.Add(ct_Col_BusinessTypeCode, typeof(Int32));
            dt.Columns[ct_Col_BusinessTypeCode].DefaultValue = defValueInt32;
            // �Ǝ햼��
            dt.Columns.Add(ct_Col_BusinessTypeName, typeof(string));
            dt.Columns[ct_Col_BusinessTypeName].DefaultValue = defValuestring;
            // �����ԍ�
            dt.Columns.Add(ct_Col_OrderNumber, typeof(string));
            dt.Columns[ct_Col_OrderNumber].DefaultValue = defValuestring;
            // �[�i�敪
            dt.Columns.Add(ct_Col_DeliveredGoodsDiv, typeof(Int32));
            dt.Columns[ct_Col_DeliveredGoodsDiv].DefaultValue = defValueInt32;
            // �[�i�敪����
            dt.Columns.Add(ct_Col_DeliveredGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_DeliveredGoodsDivNm].DefaultValue = defValuestring;
            // �̔��G���A�R�[�h
            dt.Columns.Add(ct_Col_SalesAreaCode, typeof(Int32));
            dt.Columns[ct_Col_SalesAreaCode].DefaultValue = defValueInt32;
            // �̔��G���A����
            dt.Columns.Add(ct_Col_SalesAreaName, typeof(string));
            dt.Columns[ct_Col_SalesAreaName].DefaultValue = defValuestring;
            // �����t���O
            dt.Columns.Add(ct_Col_ReconcileFlag, typeof(Int32));
            dt.Columns[ct_Col_ReconcileFlag].DefaultValue = defValueInt32;
            // �`�[����ݒ�p���[ID
            dt.Columns.Add(ct_Col_SlipPrtSetPaperId, typeof(string));
            dt.Columns[ct_Col_SlipPrtSetPaperId].DefaultValue = defValuestring;
            // �ꎮ�`�[�敪
            dt.Columns.Add(ct_Col_CompleteCd, typeof(Int32));
            dt.Columns[ct_Col_CompleteCd].DefaultValue = defValueInt32;
            // ������z�[�������敪
            dt.Columns.Add(ct_Col_SalesPriceFracProcCd, typeof(Int32));
            dt.Columns[ct_Col_SalesPriceFracProcCd].DefaultValue = defValueInt32;
            // �݌ɏ��i���v���z�i�Ŕ��j
            dt.Columns.Add(ct_Col_StockGoodsTtlTaxExc, typeof(Int64));
            dt.Columns[ct_Col_StockGoodsTtlTaxExc].DefaultValue = defValueInt64;
            // �������i���v���z�i�Ŕ��j
            dt.Columns.Add(ct_Col_PureGoodsTtlTaxExc, typeof(Int64));
            dt.Columns[ct_Col_PureGoodsTtlTaxExc].DefaultValue = defValueInt64;
            // �艿����敪
            dt.Columns.Add(ct_Col_ListPricePrintDiv, typeof(Int32));
            dt.Columns[ct_Col_ListPricePrintDiv].DefaultValue = defValueInt32;
            // �����\���敪�P
            dt.Columns.Add(ct_Col_EraNameDispCd1, typeof(Int32));
            dt.Columns[ct_Col_EraNameDispCd1].DefaultValue = defValueInt32;
            // ���Ϗ���ŋ敪
            dt.Columns.Add(ct_Col_EstimaTaxDivCd, typeof(Int32));
            dt.Columns[ct_Col_EstimaTaxDivCd].DefaultValue = defValueInt32;
            // ���Ϗ�����敪
            dt.Columns.Add(ct_Col_EstimateFormPrtCd, typeof(Int32));
            dt.Columns[ct_Col_EstimateFormPrtCd].DefaultValue = defValueInt32;
            // ���ό���
            dt.Columns.Add(ct_Col_EstimateSubject, typeof(string));
            dt.Columns[ct_Col_EstimateSubject].DefaultValue = defValuestring;
            // �r���P
            dt.Columns.Add(ct_Col_Footnotes1, typeof(string));
            dt.Columns[ct_Col_Footnotes1].DefaultValue = defValuestring;
            // �r���Q
            dt.Columns.Add(ct_Col_Footnotes2, typeof(string));
            dt.Columns[ct_Col_Footnotes2].DefaultValue = defValuestring;
            // ���σ^�C�g���P
            dt.Columns.Add(ct_Col_EstimateTitle1, typeof(string));
            dt.Columns[ct_Col_EstimateTitle1].DefaultValue = defValuestring;
            // ���σ^�C�g���Q
            dt.Columns.Add(ct_Col_EstimateTitle2, typeof(string));
            dt.Columns[ct_Col_EstimateTitle2].DefaultValue = defValuestring;
            // ���σ^�C�g���R
            dt.Columns.Add(ct_Col_EstimateTitle3, typeof(string));
            dt.Columns[ct_Col_EstimateTitle3].DefaultValue = defValuestring;
            // ���σ^�C�g���S
            dt.Columns.Add(ct_Col_EstimateTitle4, typeof(string));
            dt.Columns[ct_Col_EstimateTitle4].DefaultValue = defValuestring;
            // ���σ^�C�g���T
            dt.Columns.Add(ct_Col_EstimateTitle5, typeof(string));
            dt.Columns[ct_Col_EstimateTitle5].DefaultValue = defValuestring;
            // ���ϔ��l�P
            dt.Columns.Add(ct_Col_EstimateNote1, typeof(string));
            dt.Columns[ct_Col_EstimateNote1].DefaultValue = defValuestring;
            // ���ϔ��l�Q
            dt.Columns.Add(ct_Col_EstimateNote2, typeof(string));
            dt.Columns[ct_Col_EstimateNote2].DefaultValue = defValuestring;
            // ���ϔ��l�R
            dt.Columns.Add(ct_Col_EstimateNote3, typeof(string));
            dt.Columns[ct_Col_EstimateNote3].DefaultValue = defValuestring;
            // ���ϔ��l�S
            dt.Columns.Add(ct_Col_EstimateNote4, typeof(string));
            dt.Columns[ct_Col_EstimateNote4].DefaultValue = defValuestring;
            // ���ϔ��l�T
            dt.Columns.Add(ct_Col_EstimateNote5, typeof(string));
            dt.Columns[ct_Col_EstimateNote5].DefaultValue = defValuestring;
            // ���ϗL������
            dt.Columns.Add(ct_Col_EstimateValidityDate, typeof(DateTime));
            dt.Columns[ct_Col_EstimateValidityDate].DefaultValue = DateTime.MinValue;
            // �i�Ԉ󎚋敪
            dt.Columns.Add(ct_Col_PartsNoPrtCd, typeof(Int32));
            dt.Columns[ct_Col_PartsNoPrtCd].DefaultValue = defValueInt32;
            // �I�v�V�����󎚋敪
            dt.Columns.Add(ct_Col_OptionPringDivCd, typeof(Int32));
            dt.Columns[ct_Col_OptionPringDivCd].DefaultValue = defValueInt32;
            // �|���g�p�敪
            dt.Columns.Add(ct_Col_RateUseCode, typeof(Int32));
            dt.Columns[ct_Col_RateUseCode].DefaultValue = defValueInt32;

            // ����`�[�ԍ�(��)
            dt.Columns.Add(ct_Col_TempSalesSlipNum, typeof(string));
            dt.Columns[ct_Col_TempSalesSlipNum].DefaultValue = defValuestring;
            // �o�ɐ����v
            dt.Columns.Add(ct_Col_TotalCnt, typeof(Int32));
            dt.Columns[ct_Col_TotalCnt].DefaultValue = defValueInt32;
            // UOE�`�[���
            dt.Columns.Add(ct_Col_SlipCd, typeof(Int32));
            dt.Columns[ct_Col_SlipCd].DefaultValue = defValueInt32;

            //PrimaryKey�̐ݒ�
            //����f�[�^�e�[�u��
            //�󒍃X�e�[�^�X�{����`�[�ԍ�(��)
            if (dataTableName == CT_SalesSlipDataTable)
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_AcptAnOdrStatus], dt.Columns[ct_Col_TempSalesSlipNum] };
            }
            //�󒍃f�[�^�e�[�u��
            //�󒍃X�e�[�^�X�{����`�[�ԍ�
            else
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_AcptAnOdrStatus], dt.Columns[ct_Col_SalesSlipNum] };
            }
        }
        #endregion
    }
}