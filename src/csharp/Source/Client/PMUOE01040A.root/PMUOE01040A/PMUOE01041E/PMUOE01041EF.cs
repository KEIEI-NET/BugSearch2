//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���f�[�^�e�[�u���X�L�[�}�N���X
// �v���O�����T�v   : �d���f�[�^�e�[�u����`���s��
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
    /// �d���f�[�^�e�[�u���X�L�[�}�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���f�[�^���o���ʃe�[�u���X�L�[�}</br>
    /// <br>Programmer : 96186�@���ԗT��</br>
    /// <br>Date       : 2008.05.26</br>
    /// </remarks>
    public class StockSlipSchema
    {
        #region Public Members
        /// <summary>�d���f�[�^�e�[�u����</summary>
        public const string CT_StockSlipDataTable = "StockSlipDataTable";

        /// <summary>Uoe�d���f�[�^�e�[�u����</summary>
        public const string CT_UoeStockSlipDataTable = "UoeStockSlipDataTable";

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
        /// <summary> �d���`�� </summary>
        public const string ct_Col_SupplierFormal = "SupplierFormal";
        /// <summary> �d���`�[�ԍ� </summary>
        public const string ct_Col_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> ����R�[�h </summary>
        public const string ct_Col_SubSectionCode = "SubSectionCode";
        /// <summary> �ԓ`�敪 </summary>
        public const string ct_Col_DebitNoteDiv = "DebitNoteDiv";
        /// <summary> �ԍ��A���d���`�[�ԍ� </summary>
        public const string ct_Col_DebitNLnkSuppSlipNo = "DebitNLnkSuppSlipNo";
        /// <summary> �d���`�[�敪 </summary>
        public const string ct_Col_SupplierSlipCd = "SupplierSlipCd";
        /// <summary> �d�����i�敪 </summary>
        public const string ct_Col_StockGoodsCd = "StockGoodsCd";
        /// <summary> ���|�敪 </summary>
        public const string ct_Col_AccPayDivCd = "AccPayDivCd";
        /// <summary> �d�����_�R�[�h </summary>
        public const string ct_Col_StockSectionCd = "StockSectionCd";
        /// <summary> �d���v�㋒�_�R�[�h </summary>
        public const string ct_Col_StockAddUpSectionCd = "StockAddUpSectionCd";
        /// <summary> �d���`�[�X�V�敪 </summary>
        public const string ct_Col_StockSlipUpdateCd = "StockSlipUpdateCd";
        /// <summary> ���͓� </summary>
        public const string ct_Col_InputDay = "InputDay";
        /// <summary> ���ד� </summary>
        public const string ct_Col_ArrivalGoodsDay = "ArrivalGoodsDay";
        /// <summary> �d���� </summary>
        public const string ct_Col_StockDate = "StockDate";
        /// <summary> �d���v����t </summary>
        public const string ct_Col_StockAddUpADate = "StockAddUpADate";
        /// <summary> �����敪 </summary>
        public const string ct_Col_DelayPaymentDiv = "DelayPaymentDiv";
        /// <summary> �x����R�[�h </summary>
        public const string ct_Col_PayeeCode = "PayeeCode";
        /// <summary> �x���旪�� </summary>
        public const string ct_Col_PayeeSnm = "PayeeSnm";
        /// <summary> �d����R�[�h </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> �d���於1 </summary>
        public const string ct_Col_SupplierNm1 = "SupplierNm1";
        /// <summary> �d���於2 </summary>
        public const string ct_Col_SupplierNm2 = "SupplierNm2";
        /// <summary> �d���旪�� </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> �Ǝ�R�[�h </summary>
        public const string ct_Col_BusinessTypeCode = "BusinessTypeCode";
        /// <summary> �Ǝ햼�� </summary>
        public const string ct_Col_BusinessTypeName = "BusinessTypeName";
        /// <summary> �̔��G���A�R�[�h </summary>
        public const string ct_Col_SalesAreaCode = "SalesAreaCode";
        /// <summary> �̔��G���A���� </summary>
        public const string ct_Col_SalesAreaName = "SalesAreaName";
        /// <summary> �d�����͎҃R�[�h </summary>
        public const string ct_Col_StockInputCode = "StockInputCode";
        /// <summary> �d�����͎Җ��� </summary>
        public const string ct_Col_StockInputName = "StockInputName";
        /// <summary> �d���S���҃R�[�h </summary>
        public const string ct_Col_StockAgentCode = "StockAgentCode";
        /// <summary> �d���S���Җ��� </summary>
        public const string ct_Col_StockAgentName = "StockAgentName";
        /// <summary> �d���摍�z�\�����@�敪 </summary>
        public const string ct_Col_SuppTtlAmntDspWayCd = "SuppTtlAmntDspWayCd";
        /// <summary> ���z�\���|���K�p�敪 </summary>
        public const string ct_Col_TtlAmntDispRateApy = "TtlAmntDispRateApy";
        /// <summary> �d�����z���v </summary>
        public const string ct_Col_StockTotalPrice = "StockTotalPrice";
        /// <summary> �d�����z���v </summary>
        public const string ct_Col_StockSubttlPrice = "StockSubttlPrice";
        /// <summary> �d�����z�v�i�ō��݁j </summary>
        public const string ct_Col_StockTtlPricTaxInc = "StockTtlPricTaxInc";
        /// <summary> �d�����z�v�i�Ŕ����j </summary>
        public const string ct_Col_StockTtlPricTaxExc = "StockTtlPricTaxExc";
        /// <summary> �d���������z </summary>
        public const string ct_Col_StockNetPrice = "StockNetPrice";
        /// <summary> �d�����z����Ŋz </summary>
        public const string ct_Col_StockPriceConsTax = "StockPriceConsTax";
        /// <summary> �d���O�őΏۊz���v </summary>
        public const string ct_Col_TtlItdedStcOutTax = "TtlItdedStcOutTax";
        /// <summary> �d�����őΏۊz���v </summary>
        public const string ct_Col_TtlItdedStcInTax = "TtlItdedStcInTax";
        /// <summary> �d����ېőΏۊz���v </summary>
        public const string ct_Col_TtlItdedStcTaxFree = "TtlItdedStcTaxFree";
        /// <summary> �d�����z����Ŋz�i�O�Łj </summary>
        public const string ct_Col_StockOutTax = "StockOutTax";
        /// <summary> �d�����z����Ŋz�i���Łj </summary>
        public const string ct_Col_StckPrcConsTaxInclu = "StckPrcConsTaxInclu";
        /// <summary> �d���l�����z�v�i�Ŕ����j </summary>
        public const string ct_Col_StckDisTtlTaxExc = "StckDisTtlTaxExc";
        /// <summary> �d���l���O�őΏۊz���v </summary>
        public const string ct_Col_ItdedStockDisOutTax = "ItdedStockDisOutTax";
        /// <summary> �d���l�����őΏۊz���v </summary>
        public const string ct_Col_ItdedStockDisInTax = "ItdedStockDisInTax";
        /// <summary> �d���l����ېőΏۊz���v </summary>
        public const string ct_Col_ItdedStockDisTaxFre = "ItdedStockDisTaxFre";
        /// <summary> �d���l������Ŋz�i�O�Łj </summary>
        public const string ct_Col_StockDisOutTax = "StockDisOutTax";
        /// <summary> �d���l������Ŋz�i���Łj </summary>
        public const string ct_Col_StckDisTtlTaxInclu = "StckDisTtlTaxInclu";
        /// <summary> ����Œ����z </summary>
        public const string ct_Col_TaxAdjust = "TaxAdjust";
        /// <summary> �c�������z </summary>
        public const string ct_Col_BalanceAdjust = "BalanceAdjust";
        /// <summary> �d�������œ]�ŕ����R�[�h </summary>
        public const string ct_Col_SuppCTaxLayCd = "SuppCTaxLayCd";
        /// <summary> �d�������Őŗ� </summary>
        public const string ct_Col_SupplierConsTaxRate = "SupplierConsTaxRate";
        /// <summary> ���|����� </summary>
        public const string ct_Col_AccPayConsTax = "AccPayConsTax";
        /// <summary> �d���[�������敪 </summary>
        public const string ct_Col_StockFractionProcCd = "StockFractionProcCd";
        /// <summary> �����x���敪 </summary>
        public const string ct_Col_AutoPayment = "AutoPayment";
        /// <summary> �����x���`�[�ԍ� </summary>
        public const string ct_Col_AutoPaySlipNum = "AutoPaySlipNum";
        /// <summary> �ԕi���R�R�[�h </summary>
        public const string ct_Col_RetGoodsReasonDiv = "RetGoodsReasonDiv";
        /// <summary> �ԕi���R </summary>
        public const string ct_Col_RetGoodsReason = "RetGoodsReason";
        /// <summary> �����`�[�ԍ� </summary>
        public const string ct_Col_PartySaleSlipNum = "PartySaleSlipNum";
        /// <summary> �d���`�[���l1 </summary>
        public const string ct_Col_SupplierSlipNote1 = "SupplierSlipNote1";
        /// <summary> �d���`�[���l2 </summary>
        public const string ct_Col_SupplierSlipNote2 = "SupplierSlipNote2";
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
        /// <summary> �d���`�[���s�� </summary>
        public const string ct_Col_StockSlipPrintDate = "StockSlipPrintDate";
        /// <summary> �`�[����ݒ�p���[ID </summary>
        public const string ct_Col_SlipPrtSetPaperId = "SlipPrtSetPaperId";
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
        /// <summary> �����敪 </summary>
        public const string ct_Col_DirectSendingCd = "DirectSendingCd";

        /// <summary> ���ʓ`�[�ԍ� </summary>
        public const string ct_Col_CommonSlipNo = "CommonSlipNo";
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// �d���f�[�^�e�[�u���X�L�[�}�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���f�[�^�e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
        /// <br>Programmer : 96186�@���ԗT��</br>
        /// <br>Date       : 2008.05.26</br>
        /// </remarks>
        public StockSlipSchema()
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
        /// �d���f�[�^�쐬����
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
            dt.Columns.Add(ct_Col_CreateDateTime, typeof(DateTime));
            dt.Columns[ct_Col_CreateDateTime].DefaultValue = DateTime.MinValue;
            // �X�V����
            dt.Columns.Add(ct_Col_UpdateDateTime, typeof(DateTime));
            dt.Columns[ct_Col_UpdateDateTime].DefaultValue = DateTime.MinValue;
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
            // �d���`��
            dt.Columns.Add(ct_Col_SupplierFormal, typeof(Int32));
            dt.Columns[ct_Col_SupplierFormal].DefaultValue = defValueInt32;
            // �d���`�[�ԍ�
            dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(Int32));
            dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = defValueInt32;
            // ���_�R�[�h
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defValuestring;
            // ����R�[�h
            dt.Columns.Add(ct_Col_SubSectionCode, typeof(Int32));
            dt.Columns[ct_Col_SubSectionCode].DefaultValue = defValueInt32;
            // �ԓ`�敪
            dt.Columns.Add(ct_Col_DebitNoteDiv, typeof(Int32));
            dt.Columns[ct_Col_DebitNoteDiv].DefaultValue = defValueInt32;
            // �ԍ��A���d���`�[�ԍ�
            dt.Columns.Add(ct_Col_DebitNLnkSuppSlipNo, typeof(Int32));
            dt.Columns[ct_Col_DebitNLnkSuppSlipNo].DefaultValue = defValueInt32;
            // �d���`�[�敪
            dt.Columns.Add(ct_Col_SupplierSlipCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierSlipCd].DefaultValue = defValueInt32;
            // �d�����i�敪
            dt.Columns.Add(ct_Col_StockGoodsCd, typeof(Int32));
            dt.Columns[ct_Col_StockGoodsCd].DefaultValue = defValueInt32;
            // ���|�敪
            dt.Columns.Add(ct_Col_AccPayDivCd, typeof(Int32));
            dt.Columns[ct_Col_AccPayDivCd].DefaultValue = defValueInt32;
            // �d�����_�R�[�h
            dt.Columns.Add(ct_Col_StockSectionCd, typeof(string));
            dt.Columns[ct_Col_StockSectionCd].DefaultValue = defValuestring;
            // �d���v�㋒�_�R�[�h
            dt.Columns.Add(ct_Col_StockAddUpSectionCd, typeof(string));
            dt.Columns[ct_Col_StockAddUpSectionCd].DefaultValue = defValuestring;
            // �d���`�[�X�V�敪
            dt.Columns.Add(ct_Col_StockSlipUpdateCd, typeof(Int32));
            dt.Columns[ct_Col_StockSlipUpdateCd].DefaultValue = defValueInt32;
            // ���͓�
            dt.Columns.Add(ct_Col_InputDay, typeof(DateTime));
            dt.Columns[ct_Col_InputDay].DefaultValue = DateTime.MinValue;
            // ���ד�
            dt.Columns.Add(ct_Col_ArrivalGoodsDay, typeof(DateTime));
            dt.Columns[ct_Col_ArrivalGoodsDay].DefaultValue = DateTime.MinValue;
            // �d����
            dt.Columns.Add(ct_Col_StockDate, typeof(DateTime));
            dt.Columns[ct_Col_StockDate].DefaultValue = DateTime.MinValue;
            // �d���v����t
            dt.Columns.Add(ct_Col_StockAddUpADate, typeof(DateTime));
            dt.Columns[ct_Col_StockAddUpADate].DefaultValue = DateTime.MinValue;
            // �����敪
            dt.Columns.Add(ct_Col_DelayPaymentDiv, typeof(Int32));
            dt.Columns[ct_Col_DelayPaymentDiv].DefaultValue = defValueInt32;
            // �x����R�[�h
            dt.Columns.Add(ct_Col_PayeeCode, typeof(Int32));
            dt.Columns[ct_Col_PayeeCode].DefaultValue = defValueInt32;
            // �x���旪��
            dt.Columns.Add(ct_Col_PayeeSnm, typeof(string));
            dt.Columns[ct_Col_PayeeSnm].DefaultValue = defValuestring;
            // �d����R�[�h
            dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierCd].DefaultValue = defValueInt32;
            // �d���於1
            dt.Columns.Add(ct_Col_SupplierNm1, typeof(string));
            dt.Columns[ct_Col_SupplierNm1].DefaultValue = defValuestring;
            // �d���於2
            dt.Columns.Add(ct_Col_SupplierNm2, typeof(string));
            dt.Columns[ct_Col_SupplierNm2].DefaultValue = defValuestring;
            // �d���旪��
            dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
            dt.Columns[ct_Col_SupplierSnm].DefaultValue = defValuestring;
            // �Ǝ�R�[�h
            dt.Columns.Add(ct_Col_BusinessTypeCode, typeof(Int32));
            dt.Columns[ct_Col_BusinessTypeCode].DefaultValue = defValueInt32;
            // �Ǝ햼��
            dt.Columns.Add(ct_Col_BusinessTypeName, typeof(string));
            dt.Columns[ct_Col_BusinessTypeName].DefaultValue = defValuestring;
            // �̔��G���A�R�[�h
            dt.Columns.Add(ct_Col_SalesAreaCode, typeof(Int32));
            dt.Columns[ct_Col_SalesAreaCode].DefaultValue = defValueInt32;
            // �̔��G���A����
            dt.Columns.Add(ct_Col_SalesAreaName, typeof(string));
            dt.Columns[ct_Col_SalesAreaName].DefaultValue = defValuestring;
            // �d�����͎҃R�[�h
            dt.Columns.Add(ct_Col_StockInputCode, typeof(string));
            dt.Columns[ct_Col_StockInputCode].DefaultValue = defValuestring;
            // �d�����͎Җ���
            dt.Columns.Add(ct_Col_StockInputName, typeof(string));
            dt.Columns[ct_Col_StockInputName].DefaultValue = defValuestring;
            // �d���S���҃R�[�h
            dt.Columns.Add(ct_Col_StockAgentCode, typeof(string));
            dt.Columns[ct_Col_StockAgentCode].DefaultValue = defValuestring;
            // �d���S���Җ���
            dt.Columns.Add(ct_Col_StockAgentName, typeof(string));
            dt.Columns[ct_Col_StockAgentName].DefaultValue = defValuestring;
            // �d���摍�z�\�����@�敪
            dt.Columns.Add(ct_Col_SuppTtlAmntDspWayCd, typeof(Int32));
            dt.Columns[ct_Col_SuppTtlAmntDspWayCd].DefaultValue = defValueInt32;
            // ���z�\���|���K�p�敪
            dt.Columns.Add(ct_Col_TtlAmntDispRateApy, typeof(Int32));
            dt.Columns[ct_Col_TtlAmntDispRateApy].DefaultValue = defValueInt32;
            // �d�����z���v
            dt.Columns.Add(ct_Col_StockTotalPrice, typeof(Int64));
            dt.Columns[ct_Col_StockTotalPrice].DefaultValue = defValueInt64;
            // �d�����z���v
            dt.Columns.Add(ct_Col_StockSubttlPrice, typeof(Int64));
            dt.Columns[ct_Col_StockSubttlPrice].DefaultValue = defValueInt64;
            // �d�����z�v�i�ō��݁j
            dt.Columns.Add(ct_Col_StockTtlPricTaxInc, typeof(Int64));
            dt.Columns[ct_Col_StockTtlPricTaxInc].DefaultValue = defValueInt64;
            // �d�����z�v�i�Ŕ����j
            dt.Columns.Add(ct_Col_StockTtlPricTaxExc, typeof(Int64));
            dt.Columns[ct_Col_StockTtlPricTaxExc].DefaultValue = defValueInt64;
            // �d���������z
            dt.Columns.Add(ct_Col_StockNetPrice, typeof(Int64));
            dt.Columns[ct_Col_StockNetPrice].DefaultValue = defValueInt64;
            // �d�����z����Ŋz
            dt.Columns.Add(ct_Col_StockPriceConsTax, typeof(Int64));
            dt.Columns[ct_Col_StockPriceConsTax].DefaultValue = defValueInt64;
            // �d���O�őΏۊz���v
            dt.Columns.Add(ct_Col_TtlItdedStcOutTax, typeof(Int64));
            dt.Columns[ct_Col_TtlItdedStcOutTax].DefaultValue = defValueInt64;
            // �d�����őΏۊz���v
            dt.Columns.Add(ct_Col_TtlItdedStcInTax, typeof(Int64));
            dt.Columns[ct_Col_TtlItdedStcInTax].DefaultValue = defValueInt64;
            // �d����ېőΏۊz���v
            dt.Columns.Add(ct_Col_TtlItdedStcTaxFree, typeof(Int64));
            dt.Columns[ct_Col_TtlItdedStcTaxFree].DefaultValue = defValueInt64;
            // �d�����z����Ŋz�i�O�Łj
            dt.Columns.Add(ct_Col_StockOutTax, typeof(Int64));
            dt.Columns[ct_Col_StockOutTax].DefaultValue = defValueInt64;
            // �d�����z����Ŋz�i���Łj
            dt.Columns.Add(ct_Col_StckPrcConsTaxInclu, typeof(Int64));
            dt.Columns[ct_Col_StckPrcConsTaxInclu].DefaultValue = defValueInt64;
            // �d���l�����z�v�i�Ŕ����j
            dt.Columns.Add(ct_Col_StckDisTtlTaxExc, typeof(Int64));
            dt.Columns[ct_Col_StckDisTtlTaxExc].DefaultValue = defValueInt64;
            // �d���l���O�őΏۊz���v
            dt.Columns.Add(ct_Col_ItdedStockDisOutTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedStockDisOutTax].DefaultValue = defValueInt64;
            // �d���l�����őΏۊz���v
            dt.Columns.Add(ct_Col_ItdedStockDisInTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedStockDisInTax].DefaultValue = defValueInt64;
            // �d���l����ېőΏۊz���v
            dt.Columns.Add(ct_Col_ItdedStockDisTaxFre, typeof(Int64));
            dt.Columns[ct_Col_ItdedStockDisTaxFre].DefaultValue = defValueInt64;
            // �d���l������Ŋz�i�O�Łj
            dt.Columns.Add(ct_Col_StockDisOutTax, typeof(Int64));
            dt.Columns[ct_Col_StockDisOutTax].DefaultValue = defValueInt64;
            // �d���l������Ŋz�i���Łj
            dt.Columns.Add(ct_Col_StckDisTtlTaxInclu, typeof(Int64));
            dt.Columns[ct_Col_StckDisTtlTaxInclu].DefaultValue = defValueInt64;
            // ����Œ����z
            dt.Columns.Add(ct_Col_TaxAdjust, typeof(Int64));
            dt.Columns[ct_Col_TaxAdjust].DefaultValue = defValueInt64;
            // �c�������z
            dt.Columns.Add(ct_Col_BalanceAdjust, typeof(Int64));
            dt.Columns[ct_Col_BalanceAdjust].DefaultValue = defValueInt64;
            // �d�������œ]�ŕ����R�[�h
            dt.Columns.Add(ct_Col_SuppCTaxLayCd, typeof(Int32));
            dt.Columns[ct_Col_SuppCTaxLayCd].DefaultValue = defValueInt32;
            // �d�������Őŗ�
            dt.Columns.Add(ct_Col_SupplierConsTaxRate, typeof(Double));
            dt.Columns[ct_Col_SupplierConsTaxRate].DefaultValue = defValueDouble;
            // ���|�����
            dt.Columns.Add(ct_Col_AccPayConsTax, typeof(Int64));
            dt.Columns[ct_Col_AccPayConsTax].DefaultValue = defValueInt64;
            // �d���[�������敪
            dt.Columns.Add(ct_Col_StockFractionProcCd, typeof(Int32));
            dt.Columns[ct_Col_StockFractionProcCd].DefaultValue = defValueInt32;
            // �����x���敪
            dt.Columns.Add(ct_Col_AutoPayment, typeof(Int32));
            dt.Columns[ct_Col_AutoPayment].DefaultValue = defValueInt32;
            // �����x���`�[�ԍ�
            dt.Columns.Add(ct_Col_AutoPaySlipNum, typeof(Int32));
            dt.Columns[ct_Col_AutoPaySlipNum].DefaultValue = defValueInt32;
            // �ԕi���R�R�[�h
            dt.Columns.Add(ct_Col_RetGoodsReasonDiv, typeof(Int32));
            dt.Columns[ct_Col_RetGoodsReasonDiv].DefaultValue = defValueInt32;
            // �ԕi���R
            dt.Columns.Add(ct_Col_RetGoodsReason, typeof(string));
            dt.Columns[ct_Col_RetGoodsReason].DefaultValue = defValuestring;
            // �����`�[�ԍ�
            dt.Columns.Add(ct_Col_PartySaleSlipNum, typeof(string));
            dt.Columns[ct_Col_PartySaleSlipNum].DefaultValue = defValuestring;
            // �d���`�[���l1
            dt.Columns.Add(ct_Col_SupplierSlipNote1, typeof(string));
            dt.Columns[ct_Col_SupplierSlipNote1].DefaultValue = defValuestring;
            // �d���`�[���l2
            dt.Columns.Add(ct_Col_SupplierSlipNote2, typeof(string));
            dt.Columns[ct_Col_SupplierSlipNote2].DefaultValue = defValuestring;
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
            // �d���`�[���s��
            dt.Columns.Add(ct_Col_StockSlipPrintDate, typeof(DateTime));
            dt.Columns[ct_Col_StockSlipPrintDate].DefaultValue = DateTime.MinValue;
            // �`�[����ݒ�p���[ID
            dt.Columns.Add(ct_Col_SlipPrtSetPaperId, typeof(string));
            dt.Columns[ct_Col_SlipPrtSetPaperId].DefaultValue = defValuestring;
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
            // �����敪
            dt.Columns.Add(ct_Col_DirectSendingCd, typeof(Int32));
            dt.Columns[ct_Col_DirectSendingCd].DefaultValue = defValueInt32;

            // ���ʓ`�[�ԍ�
            dt.Columns.Add(ct_Col_CommonSlipNo, typeof(string));
            dt.Columns[ct_Col_CommonSlipNo].DefaultValue = defValuestring;

            //PrimaryKey�̐ݒ�
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SupplierFormal], dt.Columns[ct_Col_CommonSlipNo] };
        }
        #endregion
    }
}