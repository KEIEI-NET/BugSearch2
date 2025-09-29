//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���������s(����)
// �v���O�����T�v   : ���������s(����)�̈󎚂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30531 ���@�r��
// �� �� ��  2010/02/01  �C�����e : Mantis�y14929�z�������^�C�v���Ɉ�����䂪�ł���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30531 ���@�r��
// �� �� ��  2010/02/24  �C�����e : Mantis�y15037�z���z�v���X�Ȃǂ̍i�荞�ݏ������L���ɂȂ�悤�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2010/03/12  �C�����e : Mantis�y15092�z�|���敪�w���|�x�̎��������Ӑ悪����Ƃ���ȍ~�̓��Ӑ悪�󎚂���Ȃ����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570208-00    �쐬�S���F���O
// �C����    2020/04/13     �C�����e�FPMKOBETSU-2912 �y���ŗ��̑Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  11800255-00    �쐬�S���F���O
// �C����    2022/08/30     �C�����e�FPMKOBETSU-4225 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
// ---------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Collections;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Windows.Forms;
// --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----->>>>>
using System.Reflection;
using Broadleaf.Windows.Forms;
// --- ADD 2020/04/13 ���O �y���ŗ��Ή� -----<<<<<
namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// ���������s(����)�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������s(����)�̏����擾����A�N�Z�X�N���X�ł��B</br>
    /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/04/13</br>
    /// </remarks>
    public class SumDemandPrintAcs
    {
        //================================================================================
        //  �O���񋟒萔�Q
        //================================================================================
        #region public constant
        
        /// <summary>�������[�f�[�^�Z�b�g��</summary>
        public const string CT_DemandDataSet = "DemandDataSet";
        /// <summary>���Ӑ搿�����z�f�[�^�e�[�u����</summary>
        public const string CT_CustDmdPrcDataTable = "CustDmdPrcDataTable";
        
        /// <summary>�S���_�R�[�h</summary>
        public const string CT_AllSectionCode = "00";

        //--------------------------------------------------
        //  ���Ӑ搿�����z�J�������
        //--------------------------------------------------
        #region ���Ӑ搿�����z�J�������
        /// <summary>���j�[�NID</summary>
        public const string CT_CsDmd_UniqueID = "UniqueID";

        /// <summary>���R�[�h�^�C�v</summary>
        public const string CT_CsDmd_DataType = "DataType";

        /// <summary>���R�[�h��</summary>
        public const string CT_CsDmd_RecordName = "RecordName";
        
        /// <summary>����t���O</summary>
        public const string CT_CsDmd_PrintFlag = "PrintFlag";

        /// <summary>����p�C���f�b�N�X</summary>
        public const string CT_CsDmd_PrintIndex = "PrintIndex";

        /// <summary>�v�㋒�_�R�[�h</summary>
        public const string CT_CsDmd_AddUpSecCode = "AddUpSecCode";

        /// <summary>�v�㋒�_����</summary>
        public const string CT_CsDmd_AddUpSecName = "AddUpSecName";

        /// <summary>�������_�R�[�h</summary>
        public const string CT_CsDmd_ClaimSectionCode = "ClaimSectionCode";

        /// <summary>�������_����</summary>
        public const string CT_CsDmd_ClaimSectionName = "ClaimSectionName";
        
        /// <summary>���ы��_�R�[�h</summary>
        public const string CT_CsDmd_ResultsSectCd = "ResultsSectCd";
        
        /// <summary>�������Ӑ�R�[�h</summary>
        public const string CT_CsDmd_SumClaimCustCode = "SumClaimCustCode";

        /// <summary>�������Ӑ�R�[�h(���o���ʕ\���p)</summary>
        public const string CT_CsDmd_SumClaimCustCodeDisp = "SumClaimCustCodeDisp";

        /// <summary>�������Ӑ旪��</summary>
        public const string CT_CsDmd_SumClaimCustSnm = "SumClaimCustSnm";

        /// <summary>������R�[�h</summary>
        public const string CT_CsDmd_ClaimCode = "ClaimCode";

        /// <summary>������R�[�h(���o���ʕ\���p)</summary>
        public const string CT_CsDmd_ClaimCodeDisp = "ClaimCodeDisp";
        
        /// <summary>�����於��</summary>
        public const string CT_CsDmd_ClaimName = "ClaimName";

        /// <summary>�����於��2</summary>
        public const string CT_CsDmd_ClaimName2 = "ClaimName2";

        /// <summary>�����旪��</summary>
        public const string CT_CsDmd_ClaimSnm = "ClaimSnm";

        /// <summary>���Ӑ�R�[�h</summary>
        public const string CT_CsDmd_CustomerCode = "CustomerCode";

        /// <summary>���Ӑ於��</summary>
        public const string CT_CsDmd_CustomerName = "CustomerName";

        /// <summary>���Ӑ於��2</summary>
        public const string CT_CsDmd_CustomerName2 = "CustomerName2";

        /// <summary>���Ӑ旪��</summary>
        public const string CT_CsDmd_CustomerSnm = "CustomerSnm";

        /// <summary>�v��N����</summary>
        public const string CT_CsDmd_AddUpDate = "AddUpDate";

        /// <summary>�v��N����(���l�^)</summary>
        public const string CT_CsDmd_AddUpDateInt = "AddUpDateInt";

        /// <summary>�v��N��</summary>
        public const string CT_CsDmd_AddUpYearMonth = "AddUpYearMonth";

        /// <summary>�O�񐿋��z</summary>
        public const string CT_CsDmd_LastTimeDemand = "LastTimeDemand";

        /// <summary>����������z�i�ʏ�����j</summary>
        public const string CT_CsDmd_ThisTimeDmdNrml = "ThisTimeDmdNrml";

        /// <summary>����萔���z�i�ʏ�����j</summary>
        public const string CT_CsDmd_ThisTimeFeeDmdNrml = "ThisTimeFeeDmdNrml";

        /// <summary>����l���z(�ʏ����)</summary>
        public const string CT_CsDmd_ThisTimeDisDmdNrml = "ThisTimeDisDmdNrml";

        /// <summary>����J�z�c���i�����v�j[����J�z�c�����O�񐿋��z�|�����z�i�����v�j]</summary>
        public const string CT_CsDmd_ThisTimeTtlBlcDmd = "ThisTimeTtlBlcDmd";

        /// <summary>���E�㍡�񔄏���z</summary>
        public const string CT_CsDmd_OfsThisTimeSales = "OfsThisTimeSales";

        /// <summary>���E�㍡�񔄏�����</summary>
        public const string CT_CsDmd_OfsThisSalesTax = "OfsThisSalesTax";

        /// <summary>���E�㍡�񍇌v������z</summary>
        public const string CT_CsDmd_OfsThisSalesSum = "OfsThisSalesSum";

        /// <summary>���񔄏���z</summary>
        public const string CT_CsDmd_ThisTimeSales = "ThisTimeSales";

        /// <summary>���񔄏�ԕi���z</summary>
        public const string CT_CsDmd_ThisSalesPricRgds = "ThisSalesPricRgds";

        /// <summary>���񔄏�l�����z</summary>
        public const string CT_CsDmd_ThisSalesPricDis = "ThisSalesPricDis";

        /// <summary>���񔄏�ԕi�E�l�����z</summary>
        public const string CT_CsDmd_ThisSalesPricRgdsDis = "ThisSalesPricRgdsDis";

        /// <summary>�c�������z</summary>
        public const string CT_CsDmd_BalanceAdjust = "BalanceAdjust";

        /// <summary>�v�Z�㐿�����z</summary>
        public const string CT_CsDmd_AfCalDemandPrice = "AfCalDemandPrice";

        /// <summary>�v�Z�㐿�����z(�t�B���^�[�p)</summary>
        public const string CT_CsDmd_AfCalDemandPriceFilter = "AfCalDemandPriceFilter";
            
        /// <summary>����`�[����</summary>
        public const string CT_CsDmd_SaleslSlipCount = "SaleslSlipCount";

        /// <summary>�[�������敪</summary>
        public const string CT_CsDmd_FractionProcCd = "FractionProcCd";

        #endregion

        //--------------------------------------------------
        //  ���Ӑ�֘A���
        //--------------------------------------------------
        #region ���Ӑ�֘A���
        /// <summary>����</summary>
        public const string CT_CsDmd_TotalDay = "TotalDay";

        /// <summary>����(����p)</summary>
        public const string CT_CsDmd_PrintTotalDay = "PrintTotalDay";

        /// <summary>�W�����敪����</summary>
        public const string CT_CsDmd_CollectMoneyName = "CollectMoneyName";

        /// <summary>�W����</summary>
        public const string CT_CsDmd_CollectMoneyDay = "CollectMoneyDay";

        /// <summary>�W����(����p)</summary>
        public const string CT_CsDmd_CollectMoneyDayNm = "CollectMoneyDayNm";

        /// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
        public const string CT_CsDmd_CustomerAgentCd = "CustomerAgentCd";

        /// <summary>�ڋq�S���]�ƈ�����</summary>
        public const string CT_CsDmd_CustomerAgentNm = "CustomerAgentNm";

        /// <summary>�W���S���]�ƈ��R�[�h</summary>
        public const string CT_CsDmd_BillCollecterCd = "BillCollecterCd";

        /// <summary>�W���S���]�ƈ�����</summary>
        public const string CT_CsDmd_BillCollecterNm = "BillCollecterNm";

        /// <summary>����p�]�ƈ��R�[�h</summary>
        public const string CT_CsDmd_EmployeeCd = "EmployeeCd";

        /// <summary>����p�]�ƈ�����</summary>
        public const string CT_CsDmd_EmployeeNm = "EmployeeNm";

        /// <summary>���z�\���敪</summary>
        public const string CT_CsDmd_TotalAmountDispWayCd = "TotalAmountDispWayCd";

        #endregion
        
        //--------------------------------------------------
        //  ���̑�����(����p)
        //--------------------------------------------------
        #region ���̑�����(����p)
        /// <summary>�������z</summary>
        public const string CT_CsDmd_PrintAfCalDemandPrice = "PrintAfCalDemandPrice";

        /// <summary>��������</summary>
        public const string CT_CsDmd_PrintTtlConsTaxDmd = "PrintTtlConsTaxDmd";

        #endregion
        
        /// <summary>�����c��</summary>
        public const string CT_CsDmd_DemandBalance = "DemandBalance";

        /// <summary>������z</summary>
        public const string CT_CsDmd_NetSales = "NetSales";

        /// <summary>�����</summary>
        public const string CT_CsDmd_CollectRate = "CollectRate";

        /// <summary>����c��(���v���v�Z�p)</summary>
        public const string CT_CsDmd_CollectDemand = "CollectDemand";

        /// <summary>�̔��G���A�R�[�h</summary>
        public const string CT_CsDmd_SalesAreaCode = "SalesAreaCode";

        /// <summary>�̔��G���A����</summary>
        public const string CT_CsDmd_SalesAreaName = "SalesAreaName";

        //--------------------------------------------------
        //  �c����������
        //--------------------------------------------------
        /// <summary>�󒍂R��O�c��(�O�X�X��)</summary>
        public const string CT_Blnce_AcpOdrTtl3TmBfBlDmd = "AcpOdrTtl3TmBfBlDmd";

        /// <summary>�󒍂Q��O�c��(�O�X��)</summary>
        public const string CT_Blnce_AcpOdrTtl2TmBfBlDmd = "AcpOdrTtl2TmBfBlDmd";

        /// <summary>����(����敪)</summary>
        public const string CT_Blnce_MoneyKindDiv101 = "MoneyKindDiv101";

        /// <summary>�U��(����敪)</summary>
        public const string CT_Blnce_MoneyKindDiv102 = "MoneyKindDiv102";

        /// <summary>���؎�(����敪)</summary>
        public const string CT_Blnce_MoneyKindDiv107 = "MoneyKindDiv107";

        /// <summary>��`(����敪)</summary>
        public const string CT_Blnce_MoneyKindDiv105 = "MoneyKindDiv105";

        /// <summary>���E(����敪)</summary>
        public const string CT_Blnce_MoneyKindDiv106 = "MoneyKindDiv106";

        /// <summary>���̑�(����敪)</summary>
        public const string CT_Blnce_MoneyKindDiv109 = "MoneyKindDiv109";

        /// <summary>�����U��(����敪)</summary>
        public const string CT_Blnce_MoneyKindDiv112 = "MoneyKindDiv112";
        
        /// <summary>�������o�͋敪�R�[�h</summary>
        public const string CT_Blnce_BillOutputCode = "BillOutputCode";
        
        /// <summary>�̎����o�͋敪�R�[�h</summary>
        public const string CT_Blnce_ReceiptOutputCode = "ReceiptOutputCode";

        // --- ADD  ���r��  2010/02/01 ---------->>>>>
        /// <summary>�������o�͋敪�R�[�h</summary>
        public const string CT_Blnce_TotalBillOutputDiv = "TotalBillOutputDiv";

        /// <summary>�������o�͋敪�R�[�h</summary>
        public const string CT_Blnce_DetailBillOutputCode = "DetailBillOutputCode";

        /// <summary>�������o�͋敪�R�[�h</summary>
        public const string CT_Blnce_SlipTtlBillOutputDiv = "SlipTtlBillOutputDiv";

        // --- ADD  ���r��  2010/02/01 ----------<<<<<
            
        //--------------------------------------------------
        //  ���̑�����(����p)
        //--------------------------------------------------
        /// <summary>�v����t(����p)</summary>
        public const string CT_SaleDepo_AddUpADatePrint = "AddUpADatePrint";

        /// <summary>����p����(0:�v���[�g�ԍ��w�b�_�[�p,1:����ȊO)</summary>
        public const string CT_SaleDepo_PrintDetailHeaderOder = "PrintDetailHeaderOder";

        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
        /// <summary> ����z(�v�ŗ�1) </summary>
        public const string Col_TotalThisTimeSalesTaxRate1 = "TotalThisTimeSalesTaxRate1";

        /// <summary> ����z(�v�ŗ�2) </summary>
        public const string Col_TotalThisTimeSalesTaxRate2 = "TotalThisTimeSalesTaxRate2";

        /// <summary> ����z(�v���̑�) </summary>
        public const string Col_TotalThisTimeSalesOther = "TotalThisTimeSalesOther";

        /// <summary> �ԕi�l��(�v�ŗ�1) </summary>
        public const string Col_TotalThisRgdsDisPricTaxRate1 = "TotalThisRgdsDisPricTaxRate1";

        /// <summary> �ԕi�l��(�v�ŗ�2) </summary>
        public const string Col_TotalThisRgdsDisPricTaxRate2 = "TotalThisRgdsDisPricTaxRate2";

        /// <summary> �ԕi�l��(�v���̑�) </summary>
        public const string Col_TotalThisRgdsDisPricOther = "TotalThisRgdsDisPricOther";

        /// <summary> ������z(�v�ŗ�1) </summary>
        public const string Col_TotalPureSalesTaxRate1 = "TotalPureSalesTaxRate1";

        /// <summary> ������z(�v�ŗ�2) </summary>
        public const string Col_TotalPureSalesTaxRate2 = "TotalPureSalesTaxRate2";

        /// <summary> ������z(�v���̑�) </summary>
        public const string Col_TotalPureSalesOther = "TotalPureSalesOther";

        /// <summary> �����(�v�ŗ�1) </summary>
        public const string Col_TotalSalesPricTaxTaxRate1 = "TotalSalesPricTaxTaxRate1";

        /// <summary> �����(�v�ŗ�2) </summary>
        public const string Col_TotalSalesPricTaxTaxRate2 = "TotalSalesPricTaxTaxRate2";

        /// <summary> �����(�v���̑�) </summary>
        public const string Col_TotalSalesPricTaxOther = "TotalSalesPricTaxOther";

        /// <summary> ���񍇌v(�v�ŗ�1) </summary>
        public const string Col_TotalThisSalesSumTaxRate1 = "TotalThisSalesSumTaxRate1";

        /// <summary> ���񍇌v(�v�ŗ�2) </summary>
        public const string Col_TotalThisSalesSumTaxRate2 = "TotalThisSalesSumTaxRate2";

        /// <summary> ���񍇌v(�v���̑�) </summary>
        public const string Col_TotalThisSalesSumTaxOther = "TotalThisSalesSumTaxOther";

        /// <summary> ����(�v�ŗ�1) </summary>
        public const string Col_TotalSalesSlipCountTaxRate1 = "TotalSalesSlipCountTaxRate1";

        /// <summary> ����(�v�ŗ�2) </summary>
        public const string Col_TotalSalesSlipCountTaxRate2 = "TotalSalesSlipCountTaxRate2";

        /// <summary> ����(�v���̑�) </summary>
        public const string Col_TotalSalesSlipCountOther = "TotalSalesSlipCountOther";

        /// <summary> �ŗ�1�^�C�g�� </summary>
        public const string Col_TitleTaxRate1 = "TitleTaxRate1";

        /// <summary> �ŗ�2�^�C�g�� </summary>
        public const string Col_TitleTaxRate2 = "TitleTaxRate2";

        /// <summary> �y���ŗ���Ή����邩���f��p(���ӁF��PG(P�N���X)�ŏ������f�Ɏg�p) </summary>
        public const bool TaxReductionAccessDone = true;
        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
        //--- ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
        /// <summary> ����z(�v��ې�) </summary>
        public const string Col_TotalThisTimeSalesTaxFree = "TotalThisTimeSalesTaxFree";

        /// <summary> �ԕi�l��(�v��ې�) </summary>
        public const string Col_TotalThisRgdsDisPricTaxFree = "TotalThisRgdsDisPricTaxFree";

        /// <summary> ������z(�v��ې�) </summary>
        public const string Col_TotalPureSalesTaxFree = "TotalPureSalesTaxFree";

        /// <summary> �����(�v��ې�) </summary>
        public const string Col_TotalSalesPricTaxTaxFree = "TotalSalesPricTaxTaxFree";

        /// <summary> ���񍇌v(�v��ې�) </summary>
        public const string Col_TotalThisSalesSumTaxFree = "TotalThisSalesSumTaxFree";

        /// <summary> ����(�v��ې�) </summary>
        public const string Col_TotalSalesSlipCountTaxFree = "TotalSalesSlipCountTaxFree";
        //--- ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
        #endregion

        //================================================================================
        //  �v���C�x�[�g�ϐ�
        //================================================================================
        #region private member
        
        /// <summary>�����ꗗ�i�����j�f�[�^�����[�g�I�u�W�F�N�g</summary>
        private static ISumBillTableDB _iSumBillTableDB = null;

        /// <summary>���_��񕔕i�A�N�Z�X�N���X</summary>
        private static SecInfoAcs mSecInfoAcs = null;

        /// <summary>�S�̏����l�ݒ�A�N�Z�X�N���X</summary>
        private static AllDefSetAcs mAllDefSetAcs = null;

        /// <summary>��������ݒ�A�N�Z�X�N���X</summary>
        private static BillPrtStAcs mBillPrtStAcs = null;

        /// <summary>�ŗ��ݒ�A�N�Z�X�N���X</summary>
        private static TaxRateSetAcs mTaxRateSetAcs = null;

        /// <summary>���[�o�͐ݒ�A�N�Z�X�N���X</summary>
        private static PrtOutSetAcs mPrtOutSetAcs = null;

        /// <summary>����������p�^�[���}�X�^�A�N�Z�X�N���X</summary>
        private static DmdPrtPtnAcs _dmdPrtPtnAcs = null;

        /// <summary>�S�̍��ڕ\���ݒ�̃A�N�Z�X�N���X</summary>
        private static AlItmDspNmAcs mAlItmDspNmAcs = null;
        private static AlItmDspNm _alItmDspNm = null;

        /// <summary>���Ӑ�}�X�^�̃A�N�Z�X�N���X</summary>
        private static CustomerInfoAcs _customerInfoAcs = null;
        
        /// <summary>�������[�f�[�^�Z�b�g</summary>
        private DataSet _demandDataSet = null;

        /// <summary>�������z�f�[�^�e�[�u��</summary>
        private DataTable _custDmdPrcDataTable = null;

        /// <summary>�������z�f�[�^�r���[(��ʗp)</summary>
        private DataView _custDmdPrcDataView = null;

        /// <summary>�������z�f�[�^�e�[�u��(����p)</summary>
        private DataTable _custDmdPrcPrintDataTable = null;

        /// <summary>�������z�f�[�^�r���[(����p)</summary>
        private DataView _custDmdPrcDataViewPrint = null;

        /// <summary>���_�e�[�u���擾�p</summary>
        private static Hashtable sectionTable = null;
        private static ArrayList secCodeList = null;

        /// <summary>��������ݒ�</summary>
        private static BillPrtSt _billPrtSt = null;

        /// <summary>�����_�R�[�h</summary>
        private static string _ownSectionCd = "";

        /// <summary>���_�Ǘ�</summary>
        private static bool _sectionOption = false;

        /// <summary>�ŗ��ݒ胊�X�g</summary>
        private static ArrayList _taxRateSetList = null;

        /// <summary>���[�o�͐ݒ�f�[�^�N���X</summary>
        private static PrtOutSet _prtOutSet = null;

        /// <summary>�S�̏����l�ݒ�f�[�^�N���X</summary>
        private static AllDefSet _allDefSet = null;

        // �������Ӑ�R�[�h���X�g
        private List<int> _sumClaimCustCodeList;

        // �v�Z�㐿�����z�̃L���b�V��
        private Dictionary<string, long> afCalDemandPriceDic;

        private int _endDays = 0;       // �����̌���

        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
        private bool _taxReductionDone = false;
        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<

        #endregion

        //================================================================================
        //  �O���񋟃v���p�e�B
        //================================================================================
        #region public property
        /// <summary>
        /// �������[���oDataSet
        /// </summary>
        public DataSet DemandDataSet
        {
            get { return _demandDataSet; }
        }

        /// <summary>
        /// ���Ӑ搿�����z�f�[�^�e�[�u��
        /// </summary>
        public DataTable CustDmdPrcDataTable
        {
            get { return _custDmdPrcDataTable; }
        }

        /// <summary>
        /// ���Ӑ搿�����z�f�[�^�r���[(��ʕ\���p)
        /// </summary>
        public DataView CustDmdPrcDataView
        {
            get { return _custDmdPrcDataView; }
        }

        /// <summary>
        /// ���Ӑ搿�����z�f�[�^�r���[(����p)
        /// </summary>
        public DataView CustDmdPrcDataViewPrint
        {
            get { return _custDmdPrcDataViewPrint; }
        }

        /// <summary>���_��񃊃X�g</summary>
        public Hashtable SectionTable
        {
            get { return sectionTable; }
        }

        /// <summary>���_�R�[�h���X�g</summary>
        public ArrayList SecCodeList
        {
            get { return secCodeList; }
        }

        /// <summary>��������ݒ�</summary>
        public BillPrtSt BillPrtStData
        {
            get { return _billPrtSt; }
        }

        /// <summary>�S�̏����l�ݒ�</summary>
        public AllDefSet AllDefSetData
        {
            get { return _allDefSet; }
        }

        /// <summary>���_�Ǘ��@�\�L��[true:�L��,false:����]</summary>
        public bool SectionOption
        {
            get { return _sectionOption; }
            set { _sectionOption = value; }
        }

        /// <summary>�����_�R�[�h</summary>
        public string OwnSectionCd
        {
            get { return _ownSectionCd; }
            set { _ownSectionCd = value; }
        }

        #endregion

        //================================================================================
        //  �R���X�g���N�^�[
        //================================================================================
        #region �R���X�g���N�^�[
        /// <summary>
        /// ���������s(����)���o���A�N�Z�X�N���X�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������s(����)���o���A�N�Z�X�N���X�̐V�����C���X�^���X���쐬���܂��B</br>
        /// <br></br>
        /// </remarks>
        public SumDemandPrintAcs()
        {
            SettingDataSet();
        }
        #endregion

        // ===============================================================================
        // ��O�N���X
        // ===============================================================================
        #region ��O�N���X
        private class DemandPrintException : ApplicationException
        {
            private int _status;

            #region constructor
            public DemandPrintException(string message, int status)
                : base(message)
            {
                this._status = status;
            }
            #endregion

            #region public property
            public int Status
            {
                get { return this._status; }
            }
            #endregion
        }
        #endregion

        //================================================================================
        //  �ÓI�R���X�g���N�^�[
        //================================================================================
        #region �ÓI�R���X�g���N�^�[
        /// <summary>
        /// ���������s(����)���o���A�N�Z�X�N���X�ÓI�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������s(����)���o���A�N�Z�X�N���X�̐V�����C���X�^���X���쐬���܂��B</br>
        /// <br></br>
        /// </remarks>
        static SumDemandPrintAcs()
        {
            // ���_�擾���i�A�N�Z�X�N���X�C���X�^���X��
            mSecInfoAcs = new SecInfoAcs();

            // ��������ݒ�A�N�Z�X�N���X�C���X�^���X��
            mBillPrtStAcs = new BillPrtStAcs();

            // �ŗ��ݒ�A�N�Z�X�N���X�C���X�^���X��
            mTaxRateSetAcs = new TaxRateSetAcs();

            // ���[�o�͐ݒ�A�N�Z�X�N���X�C���X�^���X��
            mPrtOutSetAcs = new PrtOutSetAcs();

            // �S�̏����l�ݒ�A�N�Z�X�N���X�C���X�^���X��
            mAllDefSetAcs = new AllDefSetAcs();

            // �S�̍��ڕ\���ݒ�̃A�N�Z�X�N���X�C���X�^���X��
            mAlItmDspNmAcs = new AlItmDspNmAcs();

            // ����������p�^�[���ݒ�}�X�^�A�N�Z�X�N���X�C���X�^���X��
            _dmdPrtPtnAcs = new DmdPrtPtnAcs();

            // ���Ӑ�}�X�^�̃A�N�Z�X�N���X�C���X�^���X��
            _customerInfoAcs = new CustomerInfoAcs();

            sectionTable = new Hashtable();
            secCodeList = new ArrayList();

            // �����ꗗ�i�����j�f�[�^�����[�g�I�u�W�F�N�g �C���X�^���X��
            _iSumBillTableDB = (ISumBillTableDB)MediationSumBillTableDB.GetSumBillTableDB();
        }
        #endregion

        //================================================================================
        //  �O���񋟊֐�
        //================================================================================
        #region public methods
        /// <summary>
        /// ���������s(����)�f�[�^����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�f�[�^�����������܂��B</br>
        /// <br></br>
        /// </remarks>
        public void InitializeDemandData()
        {
            _custDmdPrcDataTable.Rows.Clear();
            _custDmdPrcPrintDataTable.Rows.Clear();

            // �t�B���^����������
            _custDmdPrcDataView.RowFilter = "";
            _custDmdPrcDataViewPrint.RowFilter = "";

            // �����C���N�������g�񏉊���
            DataColumn column = _custDmdPrcDataTable.Columns[CT_CsDmd_UniqueID];
            column.AutoIncrementSeed = 1;

            // �L���b�V���̏�����
            _sumClaimCustCodeList = new List<int>();
            afCalDemandPriceDic = new Dictionary<string, long>();
        }

        /// <summary>
        /// ��������ݒ�f�[�^�Ǎ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       :��������ݒ�f�[�^�̓Ǎ����s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int ReadBillPrtSt(string enterpriseCode, out string message)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // ��������ݒ���擾
                _billPrtSt = null;
                BillPrtSt billPrtSt;

                status = mBillPrtStAcs.Read(out billPrtSt, enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            _billPrtSt = billPrtSt;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            message = "��������ݒ���s���ĉ�����";
                            return status;
                        }
                    default:
                        message = "��������ݒ�̎擾�Ɏ��s���܂���";
                        return status;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �����f�[�^�Ǎ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : �����f�[�^�̓Ǎ����s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int InitialDataRead(string enterpriseCode, out string message)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // ���_���擾
                sectionTable.Clear();
                secCodeList.Clear();

                ArrayList ar = new ArrayList();

                // �S�Ѓ��R�[�h�ǉ�����
                SecInfoSet secAll = new SecInfoSet();
                secAll.SectionCode = CT_AllSectionCode;
                secAll.CompanyName1 = "�S��";
                secAll.SectionGuideNm = "�S��";

                sectionTable.Add(CT_AllSectionCode, secAll);
                secCodeList.Add(CT_AllSectionCode);

                for (int i = 0; i < mSecInfoAcs.SecInfoSetList.Length; i++)
                {
                    sectionTable.Add(mSecInfoAcs.SecInfoSetList[i].SectionCode, mSecInfoAcs.SecInfoSetList[i].Clone());
                    secCodeList.Add(mSecInfoAcs.SecInfoSetList[i].SectionCode);
                }
                secCodeList.Sort(new SecInfoKey0());


                // �S�̏����l�ݒu�擾
                message = "�S�̏����l�ݒ�̓ǂݍ���";
                status = ReadAllDefSet(out _allDefSet, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // �S�̍��ڕ\���ݒ� 
                message = "�S�̍��ڕ\���ݒ�̓ǂݍ���";
                status = mAlItmDspNmAcs.ReadStatic(out _alItmDspNm, enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    default:
                        message = "�S�̍��ڕ\���ݒ�̓ǂݍ��݂Ɏ��s���܂���";
                        break;
                }
            }
            catch (Exception ex)
            {
                message += "�G���[ " + "\n\r";
                message += ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �ŗ��ݒ�f�[�^�擾
        /// </summary>
        /// <param name="taxRateSet">�ŗ�</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="taxRateCode">�ŗ��ݒ�R�[�h</param>
        /// <param name="date">������E���s�����i�ŗ��擾������t�j</param>
        /// <returns>ConstantManagement.DB_Status ctDB_NORMAL:����擾 ctDB_NOT_FOUND:�擾�f�[�^�����@�ȊO:�ʐM�G���[</returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int ReadTaxRateSet(out double taxRate, out int consTaxLayMethod, string enterpriseCode, int taxRateCode, DateTime date)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            int lDate = 0;
            int lTaxRateStartDate = 0;
            int lTaxRateEndDate = 0;
            int lTaxRateStartDate2 = 0;
            int lTaxRateEndDate2 = 0;
            int lTaxRateStartDate3 = 0;
            int lTaxRateEndDate3 = 0;

            taxRate = 0;
            consTaxLayMethod = 0;

            if (_taxRateSetList == null)
            {
                // �ŗ��ݒ�擾
                status = mTaxRateSetAcs.Search(out _taxRateSetList, enterpriseCode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        return status;
                    default:
                        throw new DemandPrintException("�ŗ��ݒ�̎擾�Ɏ��s���܂����B", status);
                }
            }

            if (_taxRateSetList != null)
            {
                try
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    foreach (TaxRateSet ns in _taxRateSetList)
                    {
                        if (taxRateCode == ns.TaxRateCode)
                        {
                            consTaxLayMethod = ns.ConsTaxLayMethod;

                            lDate = TDateTime.DateTimeToLongDate("YYYYMMDD", date);
                            lTaxRateStartDate = TDateTime.DateTimeToLongDate("YYYYMMDD", ns.TaxRateStartDate);
                            lTaxRateEndDate = TDateTime.DateTimeToLongDate("YYYYMMDD", ns.TaxRateEndDate);
                            lTaxRateStartDate2 = TDateTime.DateTimeToLongDate("YYYYMMDD", ns.TaxRateStartDate2);
                            lTaxRateEndDate2 = TDateTime.DateTimeToLongDate("YYYYMMDD", ns.TaxRateEndDate2);
                            lTaxRateStartDate3 = TDateTime.DateTimeToLongDate("YYYYMMDD", ns.TaxRateStartDate3);
                            lTaxRateEndDate3 = TDateTime.DateTimeToLongDate("YYYYMMDD", ns.TaxRateEndDate3);

                            if ((lDate >= lTaxRateStartDate) && (lDate <= lTaxRateEndDate))
                            {
                                taxRate = ns.TaxRate;
                            }
                            else if ((lDate >= lTaxRateStartDate2) && (lDate <= lTaxRateEndDate2))
                            {
                                taxRate = ns.TaxRate2;
                            }
                            else if ((lDate >= lTaxRateStartDate3) && (lDate <= lTaxRateEndDate3))
                            {
                                taxRate = ns.TaxRate;
                            }

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            return status;
                        }
                    }
                    return status;
                }
                catch (DemandPrintException ex)
                {
                    status = ex.Status;
                }
                catch (Exception)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            return status;
        }

        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="prtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            prtOutSet = null;
            message = "";
            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (_prtOutSet != null)
                {
                    prtOutSet = _prtOutSet.Clone();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    string sectionCode = "";

                    if (LoginInfoAcquisition.Employee != null)
                    {
                        sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                    }

                    status = mPrtOutSetAcs.Read(out _prtOutSet, LoginInfoAcquisition.EnterpriseCode, sectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            prtOutSet = _prtOutSet.Clone();
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            prtOutSet = new PrtOutSet();
                            break;
                        default:
                            prtOutSet = new PrtOutSet();
                            message = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂����B";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// �S�̏����l�ݒ�Ǎ�
        /// </summary>
        /// <param name="prtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̑S�̏����l�ݒ�̓Ǎ����s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int ReadAllDefSet(out AllDefSet allDefSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            allDefSet = null;
            message = "";
            // --- ADD  ���r��  2010/02/01 ---------->>>>>
            AllDefSet allDefSetZero = null;
            // --- ADD  ���r��  2010/02/01 ----------<<<<<

            try
            {
                string sectionCode = "";

                if (LoginInfoAcquisition.Employee != null)
                {
                    sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                }

                ArrayList retList = new ArrayList();
                status = mAllDefSetAcs.Search(out retList, LoginInfoAcquisition.EnterpriseCode);
                
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        foreach (AllDefSet workAllDefSet in retList)
                        {
                            if (workAllDefSet.SectionCode == sectionCode)
                            {
                                // ���ꋒ�_
                                allDefSet = workAllDefSet.Clone();
                                break;
                            }
                            // --- ADD  ���r��  2010/02/01 ---------->>>>>
                            if (workAllDefSet.SectionCode.Trim() == "00")
                            {
                                allDefSetZero = workAllDefSet;
                            }
                            // --- ADD  ���r��  2010/02/01 ----------<<<<<
                        }
                        if (allDefSet == null)
                        {
                            // --- UPD  ���r��  2010/02/01 ---------->>>>>
                            //// ���ꋒ�_�������ꍇ�̓G���[                                
                            //allDefSet = new AllDefSet();
                            //message = "�S�̏����l�ݒ肪�ݒ肳��Ă��܂���B";
                            allDefSet = allDefSetZero;
                            // --- UPD  ���r��  2010/02/01 ----------<<<<<
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        allDefSet = new AllDefSet();
                        message = "�S�̏����l�ݒ肪�ݒ肳��Ă��܂���B";
                        break;
                    default:
                        allDefSet = new AllDefSet();
                        message = "�S�̏����l�ݒ�̓Ǎ��Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// ����@�\���_�擾
        /// </summary>
        /// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
        /// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
        /// <param name="ctrlSectionCode">�Ώې��䋒�_�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Y�����_�̋��_������̓Ǎ����s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int GetOwnSeCtrlCode(string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode)
        {
            // �Ώې��䋒�_�̏����l�͎����_
            ctrlSectionCode = sectionCode;

            SecInfoSet secInfoSet;

            int status = mSecInfoAcs.GetSecInfo(sectionCode, out secInfoSet);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    if (secInfoSet != null)
                    {
                        ctrlSectionCode = secInfoSet.SectionCode;
                    }
                    break;
                default:
                    break;
            }
            return status;
        }

        /// <summary>
        /// �{�Ћ@�\�L���擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>true: �{��,false: ���_</returns>
        /// <remarks>
        /// <br>Note       : �{�Ћ@�\�L���`�F�b�N���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public bool CheckMainOfficeFunc(string sectionCode)
        {
            if (mSecInfoAcs.GetMainOfficeFuncFlag(sectionCode) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ���Ж��̎擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="companyNameCd">���Ж��̃R�[�h</param>
        /// <param name="companyNm">���Ж���</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Y�����_�̎��Ж��̏��̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int ReadCompanyName(string sectionCode, SecInfoAcs.CompanyNameCd companyNameCd, out CompanyNm companyNm)
        {
            SecInfoSet secInfoSet;
            int status = mSecInfoAcs.GetSecInfo(sectionCode, companyNameCd, out secInfoSet, out companyNm);

            return status;
        }

        /// <summary>
        /// �S�̍��ڕ\���ݒ�f�[�^�N���X�擾
        /// </summary>
        /// <returns>�S�̍��ڕ\���ݒ�f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �S�̍��ڕ\���ݒ�f�[�^�N���X�̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public AlItmDspNm GetAlItmDspNm()
        {
            AlItmDspNm retAlItmDspNm = null;

            if (_alItmDspNm != null)
            {
                retAlItmDspNm = _alItmDspNm.Clone();
            }
            else
            {
                retAlItmDspNm = new AlItmDspNm();
            }

            return retAlItmDspNm;
        }

        /// <summary>
        /// ���������s(����)���o����
        /// </summary>
        /// <param name="extraInfo">���o�����f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="errDspMsg">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : ���������s(����)���𒊏o���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int SearchDemandList(SumExtrInfo_DemandTotal extraInfo, out string message, out string errDspMsg)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errDspMsg = "";

            try
            {
                // DataSet������
                this.InitializeDemandData();

                ArrayList custDmdPrcList = new ArrayList();
                ArrayList dmdPrtPtnParamList = new ArrayList();
                
                // ���o���������[�J�[�N���X�փR�s�[
                SumExtrInfo_DemandTotalWork extraInfoWork = new SumExtrInfo_DemandTotalWork();
                extraInfoWork = this.CopyToExtraInfoWorkFromExtraInfo(extraInfo);

                object paraObj = null;
                object retObj = null;
                object paraAddObj = null;
                object retAddObj = null;

                paraObj = (object)extraInfoWork;

                status = _iSumBillTableDB.SearchBillTable(out retObj, paraObj);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // �����̌������擾
                            _endDays = DateTime.DaysInMonth(extraInfo.AddUpDate.Year, extraInfo.AddUpDate.Month);
                            
                            // --- UPD  ���r��  2010/02/01 ---------->>>>>                                                        
                            //retAddObj  = retObj;
                            retAddObj = (retObj as CustomSerializeArrayList)[0];
                            // --- UPD  ���r��  2010/02/01 ----------<<<<<
                            paraAddObj = (object)dmdPrtPtnParamList;

                            custDmdPrcList = retAddObj as ArrayList;

                            // --- ADD  ���r��  2010/02/01 ---------->>>>>
                            object AllDefSetObj = null;
                            AllDefSetObj = (retObj as CustomSerializeArrayList)[1];
                            ReadAllDefSetWork(AllDefSetObj as ArrayList);

                            paraAddObj = (object)dmdPrtPtnParamList;

                            custDmdPrcList = retAddObj as ArrayList;
                            // --- ADD  ���r��  2010/02/01 ----------<<<<<

                            // �������zDataTable�쐬
                            foreach (SumRsltInfo_DemandTotalWork csdmd in custDmdPrcList)
                            {
                                DataRow row = CustDmdPrcWorkToDataRow(extraInfo, csdmd);
                                if (row != null)
                                {
                                    // ���o�Ώۃf�[�^
                                    this._custDmdPrcDataTable.Rows.Add(row);
                                }
                            }

                            // �������R�[�h�̍쐬
                            CreateSumDmdRow(extraInfo);

                            // �t�B���^�[�p�̌v�Z�㐿�����z��ݒ�
                            SetAfCalDemandPriceFilter();

                            // ���o�Ώۃf�[�^�Ȃ�
                            if (_custDmdPrcDataTable.Rows.Count == 0) status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        message = "�����f�[�^�̒��o�Ɏ��s���܂���";
                        break;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }

        // --- ADD  ���r��  2010/02/01 ---------->>>>>
        /// <summary>
        /// �S�̏����l�ݒ�̓��e���X�V
        /// </summary>
        /// <param name="arrayList"></param>
        private void ReadAllDefSetWork(ArrayList arrayList)
        {
            AllDefSetWork allDefSetWork = null;
            AllDefSetWork allDefSetWorkZero = null;

            string sectionCode = "";

            if (LoginInfoAcquisition.Employee != null)
            {
                sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }

            foreach (AllDefSetWork workAllDefSet in arrayList)
            {
                if (workAllDefSet.SectionCode == sectionCode)
                {
                    //���ꋒ�_
                    allDefSetWork = workAllDefSet;
                    break;
                }
            
                if (workAllDefSet.SectionCode.Trim() == "00")
                {
                    allDefSetWorkZero = workAllDefSet;
                }
            }
            if (allDefSetWork == null)
            {
                allDefSetWork = allDefSetWorkZero;
            }
            if (allDefSetWork != null)
            {
                _allDefSet = CopyToAllDefSetFromAllDefSetWork(allDefSetWork);
            }
        }

        /// <summary>
        /// �S�̏����l�ݒ�}�X�^���擾
        /// </summary>
        /// <param name="allDefSetWork"></param>
        /// <returns></returns>
        private AllDefSet CopyToAllDefSetFromAllDefSetWork(AllDefSetWork allDefSetWork)
        {
            AllDefSet allDefSet = new AllDefSet();

            allDefSet.CreateDateTime = allDefSetWork.CreateDateTime;  // �쐬����
            allDefSet.UpdateDateTime = allDefSetWork.UpdateDateTime;  // �X�V����
            allDefSet.EnterpriseCode = allDefSetWork.EnterpriseCode;  // ��ƃR�[�h
            allDefSet.FileHeaderGuid = allDefSetWork.FileHeaderGuid;  // GUID
            allDefSet.UpdEmployeeCode = allDefSetWork.UpdEmployeeCode;  // �X�V�]�ƈ��R�[�h
            allDefSet.UpdAssemblyId1 = allDefSetWork.UpdAssemblyId1;  // �X�V�A�Z���u��ID1
            allDefSet.UpdAssemblyId2 = allDefSetWork.UpdAssemblyId2;  // �X�V�A�Z���u��ID2
            allDefSet.LogicalDeleteCode = allDefSetWork.LogicalDeleteCode;  // �_���폜�敪
            allDefSet.SectionCode = allDefSetWork.SectionCode;  // ���_�R�[�h
            allDefSet.TotalAmountDispWayCd = allDefSetWork.TotalAmountDispWayCd;  // ���z�\�����@�敪
            allDefSet.DefDspCustTtlDay = allDefSetWork.DefDspCustTtlDay;  // �����\���ڋq����
            allDefSet.DefDspCustClctMnyDay = allDefSetWork.DefDspCustClctMnyDay;  // �����\���ڋq�W����
            allDefSet.DefDspClctMnyMonthCd = allDefSetWork.DefDspClctMnyMonthCd;  // �����\���W�����敪
            allDefSet.IniDspPrslOrCorpCd = allDefSetWork.IniDspPrslOrCorpCd;  // �����\���l�E�@�l�敪
            allDefSet.InitDspDmDiv = allDefSetWork.InitDspDmDiv;  // �����\��DM�敪
            allDefSet.DefDspBillPrtDivCd = allDefSetWork.DefDspBillPrtDivCd;  // �����\���������o�͋敪
            allDefSet.EraNameDispCd1 = allDefSetWork.EraNameDispCd1;  // �����\���敪�P
            allDefSet.EraNameDispCd2 = allDefSetWork.EraNameDispCd2;  // �����\���敪�Q
            allDefSet.EraNameDispCd3 = allDefSetWork.EraNameDispCd3;  // �����\���敪�R
            allDefSet.GoodsNoInpDiv = allDefSetWork.GoodsNoInpDiv;  // ���i�ԍ����͋敪
            allDefSet.CnsTaxAutoCorrDiv = allDefSetWork.CnsTaxAutoCorrDiv;  // ����Ŏ����␳�敪
            allDefSet.RemainCntMngDiv = allDefSetWork.RemainCntMngDiv;  // �c���Ǘ��敪
            allDefSet.MemoMoveDiv = allDefSetWork.MemoMoveDiv;  // �������ʋ敪
            allDefSet.RemCntAutoDspDiv = allDefSetWork.RemCntAutoDspDiv;  // �c�������\���敪
            allDefSet.TtlAmntDspRateDivCd = allDefSetWork.TtlAmntDspRateDivCd;  // ���z�\���|���K�p�敪
            allDefSet.DefTtlBillOutput = allDefSetWork.DefTtlBillOutput;  // �����\�����v�������o�͋敪
            allDefSet.DefDtlBillOutput = allDefSetWork.DefDtlBillOutput;  // �����\�����א������o�͋敪
            allDefSet.DefSlTtlBillOutput = allDefSetWork.DefSlTtlBillOutput;  // �����\���`�[���v�������o�͋敪

            return allDefSet;
        }
        // --- ADD  ���r��  2010/02/01 ----------<<<<<
    

        /// <summary>
        /// �I���s�󎚑I���E��I����ԏ���
        /// </summary>
        /// <param name="_uniqueID">���j�[�NID</param>
        /// <remarks>
        /// <br>Note       : �I���s�̈󎚏�Ԃ�ݒ肵�܂��B</br>
        /// <br></br>
        /// </remarks>
        public void SelectedPrintRow(int _uniqueID)
        {
            // ------------------------------------------------------------//
            // Find ���\�b�h���g���A���AView�̃\�[�g����ύX�������Ȃ��ׁA //
            // DataTable�ɍX�V��������B                                   //
            // ------------------------------------------------------------//
            DataRow _row = _custDmdPrcDataTable.Rows.Find(_uniqueID);

            // ��v����s�����݂���I
            if (_row != null)
            {
                bool printFlag = (bool)_row[CT_CsDmd_PrintFlag];

                _row.BeginEdit();
                _row[CT_CsDmd_PrintFlag] = !printFlag;
                _row.EndEdit();
            }
        }

        /// <summary>
        /// �I���s�󎚑I���E��I����ԏ���(�w��^)
        /// </summary>
        /// <param name="_uniqueID">���j�[�NID</param>
        /// <param name="selected">true:�I��,false:��I��</param>
        /// <remarks>
        /// <br>Note       : �I���s�̈󎚏�Ԃ�ݒ肵�܂��B</br>
        /// <br></br>
        /// </remarks>
        public void SelectedPrintRow(int _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find ���\�b�h���g���A���AView�̃\�[�g����ύX�������Ȃ��ׁA //
            // DataTable�ɍX�V��������B                                   //
            // ------------------------------------------------------------//
            DataRow _row = _custDmdPrcDataTable.Rows.Find(_uniqueID);

            // ��v����s�����݂���I
            if (_row != null)
            {
                _row.BeginEdit();
                _row[CT_CsDmd_PrintFlag] = selected;
                _row.EndEdit();
            }
        }

        /// <summary>
        /// ���o�f�[�^�\���pDataView�@�t�B���^�ݒ�
        /// </summary>
        /// <param name="outPutDiv">�o�͋敪</param>
        /// <param name="sumCustDtl">�������Ӑ����</param>
        /// <remarks>
        /// <br>Note       : ���o�f�[�^�Ƀt�B���^��ݒ肵�܂��B</br>
        /// <br></br>
        /// </remarks>
        // --- UPD  ���r��  2010/02/01 ---------->>>>>
        //public void SelectViewData(int outPutDiv, int sumCustDtl)
        public void SelectViewData(int outPutDiv, int sumCustDtl, int issueType)
        // --- UPD  ���r��  2010/02/01 ----------<<<<<
        {
            string strQuery = "";
            string strQuery1 = "";
            // --- ADD  ���r��  2010/02/01 ---------->>>>>
            string strQuery2 = "";
            // --- ADD  ���r��  2010/02/01 ----------<<<<<

            // �v�Z�㐿�����z(�t�B���^�[�p)�Ńt�B���^�[�����쐬
            //if (sumCustDtl != 2)
            //{
                switch (outPutDiv)
                {
                    case 0: // �S�ďo�� 
                        break;
                    case 1: // �O�ƃv���X���z���o��
                        strQuery = String.Format("{0} >= {1}",
                            CT_CsDmd_AfCalDemandPriceFilter,
                            0);
                        break;
                    case 2: // �v���X���z�̂ݏo��
                        strQuery = String.Format("{0} > {1}",
                            CT_CsDmd_AfCalDemandPriceFilter,
                            0);
                        break;
                    case 3: // �O�̂ݏo��
                        strQuery = String.Format("{0} = {1}",
                            CT_CsDmd_AfCalDemandPriceFilter,
                            0);
                        break;
                    case 4: // �v���X���z�ƃ}�C�i�X���z���o��
                        strQuery = String.Format("{0} <> {1}",
                            CT_CsDmd_AfCalDemandPriceFilter,
                            0);
                        break;
                    case 5: // �O�ƃ}�C�i�X���z���o��
                        strQuery = String.Format("{0} <= {1}",
                            CT_CsDmd_AfCalDemandPriceFilter,
                            0);
                        break;
                    case 6: // �}�C�i�X���z�̂ݏo��
                        strQuery = String.Format("{0} < {1}",
                            CT_CsDmd_AfCalDemandPriceFilter,
                            0);
                        break;
                    default:
                        break;
                }
            //}
            
            if (sumCustDtl == 1)  //  �������Ӑ���󁨈󎚂��Ȃ�
            {
                if (outPutDiv == 0)
                {
                    strQuery = String.Format("{0} = {1}",
                    CT_CsDmd_DataType,
                    true);
                }
                else
                {
                    strQuery1 = String.Format(" AND {0} = {1}",
                    CT_CsDmd_DataType,
                    true);
                }
            }

            // --- UPD  ���r��  2010/02/01 ---------->>>>>
            switch (issueType)
            {                
                //���v������
                case 50:
                    {
                        strQuery2 = string.Empty;
                        if (!string.IsNullOrEmpty(strQuery) || !string.IsNullOrEmpty(strQuery1))
                        {
                            strQuery2 = " AND ";
                        }
                            //�S�̏����l�ݒ�u�o�͂���v
                            if (AllDefSetData.DefTtlBillOutput == 0)
                            {
                                //���Ӑ�}�X�^�u�W���v�܂��́u�g�p�v
                                strQuery2 += string.Format("{0} <> {1}",
                                CT_Blnce_TotalBillOutputDiv,
                                2);
                            }
                            //�S�̏����l�ݒ�u�o�͂��Ȃ��v
                            else if(AllDefSetData.DefTtlBillOutput == 1)
                            {
                                //���Ӑ�}�X�^�u�g�p�v
                                strQuery2 += string.Format("{0} = {1}",
                                CT_Blnce_TotalBillOutputDiv,
                                1);
                            }
                            break;
                    }
                //���א�����                
                case 60:
                    {
                        //
                        strQuery2 = string.Empty;
                        if (!string.IsNullOrEmpty(strQuery) || !string.IsNullOrEmpty(strQuery1))
                        {
                            strQuery2 = " AND ";
                        }
                        //�S�̏����l�ݒ�u�o�͂���v
                        if (AllDefSetData.DefDtlBillOutput == 0)
                        {
                            //���Ӑ�}�X�^�u�W���v�܂��́u�g�p�v
                            strQuery2 += string.Format("{0} <> {1}",
                            CT_Blnce_DetailBillOutputCode,
                            2);
                        }
                        //�S�̏����l�ݒ�u�o�͂��Ȃ��v
                        else if (AllDefSetData.DefDtlBillOutput == 1)
                        {
                            //���Ӑ�}�X�^�u�g�p�v
                            strQuery2 += string.Format("{0} = {1}",
                            CT_Blnce_DetailBillOutputCode,
                            1);
                        }
                        break;
                    }                    
                //�`�[���v������
                case 70:
                    {
                        strQuery2 = string.Empty;
                        if (!string.IsNullOrEmpty(strQuery) || !string.IsNullOrEmpty(strQuery1))
                        {
                            strQuery2 = " AND ";
                        }
                            //�S�̏����l�ݒ�u�o�͂���v
                            if (AllDefSetData.DefSlTtlBillOutput == 0)
                            {
                                //���Ӑ�}�X�^�u�W���v�܂��́u�g�p�v
                                strQuery2 += string.Format("{0} <> {1}",
                                CT_Blnce_SlipTtlBillOutputDiv,
                                2);
                            }
                            //�S�̏����l�ݒ�u�o�͂��Ȃ��v
                            else if (AllDefSetData.DefSlTtlBillOutput == 1)
                            {
                                //���Ӑ�}�X�^�u�g�p�v
                                strQuery2 += string.Format("{0} = {1}",
                                CT_Blnce_SlipTtlBillOutputDiv,
                                1);
                            }
                            break;
                    }
            }
                    
            // �N�G���ݒ�
            //_custDmdPrcDataView.RowFilter = strQuery + strQuery1;
            _custDmdPrcDataView.RowFilter = strQuery + strQuery1 + strQuery2;
            // --- UPD  ���r��  2010/02/01 ----------<<<<<
        }

        /// <summary>
        /// ����p�f�[�^�e�[�u���쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����p�f�[�^�e�[�u�����쐬���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int MakePrintDataTable()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // ����C���f�b�N�X
            int printOder = 0;

            // ����pDataTable������
            _custDmdPrcPrintDataTable.Rows.Clear();
            _custDmdPrcDataViewPrint.RowFilter = "";

            // �\���pDataView�������pDataTable�ɐݒ�
            if (_custDmdPrcDataView.Count != 0)
            {
                for (int i = 0; i < _custDmdPrcDataView.Count; i++)
                {
                    DataRow row = _custDmdPrcDataView[i].Row;

                    // ����L��					
                    if ((bool)row[CT_CsDmd_PrintFlag])
                    {
                        printOder++;
                        row.BeginEdit();
                        // ����p�C���f�b�N�X�t��
                        row[CT_CsDmd_PrintIndex] = printOder;
                        row.EndEdit();
                        // �s��ǉ�					
                        _custDmdPrcPrintDataTable.ImportRow(row);
                    }
                }
            }

            if (_custDmdPrcPrintDataTable.Rows.Count > 0)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }

        /// <summary>
        /// ����p�f�[�^�e�[�u���쐬����(����ꎞ���f�����ݒ�)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����p�f�[�^�e�[�u�����쐬���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int MakePrintDataTable(int pcardPrtSuspendcnt, SumExtrInfo_DemandTotal extrInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // ����C���f�b�N�X
            int printOder = 0;

            // ����pDataTable������
            _custDmdPrcPrintDataTable.Rows.Clear();
            _custDmdPrcDataViewPrint.RowFilter = "";

            string strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_SumClaimCustCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_ClaimCode;
            if (extrInfo.SortOrder == 1)
            {
                // �S���ҏ�
                if (extrInfo.CustomerAgentDivCd == 0)
                {
                    // �ڋq�S��
                    strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_CustomerAgentCd + "," + CT_CsDmd_SumClaimCustCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_ClaimCode;
                }
                else
                {
                    // �W���S��
                    strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_BillCollecterCd + "," + CT_CsDmd_SumClaimCustCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_ClaimCode;
                }
            }
            else if (extrInfo.SortOrder == 2)
            {
                // �n�揇
                strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_SalesAreaCode + "," + CT_CsDmd_SumClaimCustCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_ClaimCode;
            }

            // --- ADD  ���r��  2010/02/24 ---------->>>>>
            ////
            //string rowFilter = "";
            //if (_custDmdPrcDataView.RowFilter != "")
            //{
            //    rowFilter = _custDmdPrcDataView.RowFilter;
            //}
            // Filter�ݒ�
            string rowFilter = "";
            if (_custDmdPrcDataView.RowFilter != "")
            {
                rowFilter = _custDmdPrcDataView.RowFilter;
            }
            // --- ADD  ���r��  2010/02/24 ----------<<<<<

            // --- UPD  ���r��  2010/02/24 ---------->>>>>                       
            // ���[�N�p��DataView
            //DataView workDataView = new DataView(_custDmdPrcDataTable, _custDmdPrcDataTable.DefaultView.RowFilter, strSort, DataViewRowState.CurrentRows);            
            DataView workDataView = new DataView(_custDmdPrcDataTable, rowFilter, strSort, DataViewRowState.CurrentRows);
            // --- UPD  ���r��  2010/02/24 ----------<<<<<

            // �\���pDataView�������pDataTable�ɐݒ�
            if (workDataView.Count != 0)
            {
                //for (int i = 0; i < _custDmdPrcDataView.Count; i++)
                for (int i = 0; i < workDataView.Count; i++)
                {
                    DataRow row = workDataView[i].Row;

                    switch (extrInfo.SlipPrtKind)
                    {
                        // --- UPD  ���r��  2010/02/01 ---------->>>>>
                        //���v������
                        case 50:
                            {
                                //���Ӑ�}�X�^�̋敪�u0�F�W���v
                                if ((int)row[CT_Blnce_TotalBillOutputDiv] == 0)
                                {
                                    //�S�̏����l�ݒ�}�X�^�̋敪�u1�F�o�͂��Ȃ��v
                                    if (AllDefSetData.DefTtlBillOutput == 1)
                                    {
                                        //������Ȃ�
                                        continue;
                                    }
                                }
                                //���Ӑ�}�X�^�̋敪�u2�F���g�p�v
                                else if ((int)row[CT_Blnce_TotalBillOutputDiv] == 2)
                                {
                                    //������Ȃ�
                                    continue;
                                }
                                break;
                            }
                        //���א�����                       
                        case 60:
                            {
                                //���Ӑ�}�X�^�̋敪�u0:�W���v
                                if ((int)row[CT_Blnce_DetailBillOutputCode] == 0)
                                {
                                    //�S�̏����l�ݒ�}�X�^�̋敪�u1:�o�͂��Ȃ��v
                                    if (AllDefSetData.DefDtlBillOutput == 1)
                                    {
                                        //������Ȃ�
                                        continue;
                                    }
                                }
                                //���Ӑ�}�X�^�̋敪�u2:���g�p�v
                                else if ((int)row[CT_Blnce_DetailBillOutputCode] == 2)
                                {
                                    //������Ȃ�
                                    continue;
                                }
                                break;
                            }                            
                        //�`�[���v������
                        case 70:
                            {
                                //���Ӑ�}�X�^�̋敪�u0�F�W���v
                                if ((int)row[CT_Blnce_SlipTtlBillOutputDiv] == 0)
                                {
                                    //�S�̏����l�ݒ�}�X�^�̋敪�u2�F�o�͂��Ȃ��v
                                    if (AllDefSetData.DefSlTtlBillOutput == 1)
                                    {
                                        //������Ȃ�
                                        continue;
                                    }
                                }
                                //���Ӑ�}�X�^�̋敪�u2�F���g�p�v
                                else if ((int)row[CT_Blnce_SlipTtlBillOutputDiv] == 2)
                                {
                                    //������Ȃ�
                                    continue;
                                }
                                break;

                                //// �������֌W
                                //if ((int)row[CT_Blnce_BillOutputCode] == 1)
                                //{
                                //    // ������Ȃ�
                                //    continue;
                                //}
                                //break;
                            }
                        // --- UPD  ���r��  2010/02/01 ----------<<<<<
                    }
                    
                    // ����L��					
                    if ((bool)row[CT_CsDmd_PrintFlag])
                    {
                        printOder++;
                        row.BeginEdit();
                        // ����p�C���f�b�N�X�t��
                        row[CT_CsDmd_PrintIndex] = printOder;
                        row.EndEdit();
                        // �s��ǉ�					
                        _custDmdPrcPrintDataTable.ImportRow(row);
                    }

                    // ����ꎞ���f����
                    if ((pcardPrtSuspendcnt != 0) && (printOder >= pcardPrtSuspendcnt))
                    {
                        break;
                    }
                }
            }
            _custDmdPrcDataViewPrint.Sort = strSort;
            
            if (_custDmdPrcPrintDataTable.Rows.Count > 0)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }

        #endregion

        //================================================================================
        //  �����֐�
        //================================================================================
        #region private methods
        /// <summary>
        /// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private void SettingDataSet()
        {

            if (_demandDataSet == null)
            {
                _demandDataSet = new DataSet(CT_DemandDataSet);

                CreateCustDmdPrTable();
            }
        }
        /// <summary>
        /// ���Ӑ搿�����z�e�[�u�����쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Update Note: 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private void CreateCustDmdPrTable()
        {
            //�@���Ӑ搿�����zDataTable�쐬
            _custDmdPrcDataTable = new DataTable(CT_CustDmdPrcDataTable);
            _custDmdPrcDataView  = new DataView();

            _custDmdPrcPrintDataTable = new DataTable(CT_CustDmdPrcDataTable);
            _custDmdPrcDataViewPrint  = new DataView();

            // ���j�[�NID(�����C���N�������g��)
            DataColumn UniqueID = new DataColumn(CT_CsDmd_UniqueID, typeof(System.Int32), "", MappingType.Element);
            UniqueID.Caption = "���j�[�NID";
            UniqueID.AutoIncrement = true;
            UniqueID.AutoIncrementSeed = 1;
            UniqueID.AutoIncrementStep = 1;
            UniqueID.ReadOnly = true;

            // ���R�[�h�^�C�v
            DataColumn DataType = new DataColumn(CT_CsDmd_DataType, typeof(Boolean), "", MappingType.Element);
            DataType.Caption = "���R�[�h�^�C�v";

            // ���R�[�h��
            DataColumn RecordName = new DataColumn(CT_CsDmd_RecordName, typeof(String), "", MappingType.Element);
            DataType.Caption = "���R�[�h��";
            
            // ����t���O
            DataColumn PrintFlag = new DataColumn(CT_CsDmd_PrintFlag, typeof(Boolean), "", MappingType.Element);
            PrintFlag.Caption = "����t���O";

            // ����p�C���f�b�N�X
            DataColumn PrintIndex = new DataColumn(CT_CsDmd_PrintIndex, typeof(System.Int32), "", MappingType.Element);
            PrintIndex.Caption = "����p�C���f�b�N�X";

            // �v�㋒�_�R�[�h
            DataColumn AddUpSecCode = new DataColumn(CT_CsDmd_AddUpSecCode, typeof(String), "", MappingType.Element);
            AddUpSecCode.Caption = "�v�㋒�_�R�[�h";

            // �v�㋒�_����
            DataColumn AddUpSecName = new DataColumn(CT_CsDmd_AddUpSecName, typeof(String), "", MappingType.Element);
            AddUpSecName.Caption = "�������_��";
            
            // �������_�R�[�h
            DataColumn ClaimSectionCode = new DataColumn(CT_CsDmd_ClaimSectionCode, typeof(String), "", MappingType.Element);
            ClaimSectionCode.Caption = "�������_�R�[�h";

            // �������_����
            DataColumn ClaimSectionName = new DataColumn(CT_CsDmd_ClaimSectionName, typeof(String), "", MappingType.Element);
            ClaimSectionName.Caption = "�������_����";
            
            // ���ы��_�R�[�h
            DataColumn ResultsSectCd = new DataColumn(CT_CsDmd_ResultsSectCd, typeof(String), "", MappingType.Element);
            ResultsSectCd.Caption = "���ы��_�R�[�h";
            
            // �������Ӑ�R�[�h
            DataColumn SumClaimCustCode = new DataColumn(CT_CsDmd_SumClaimCustCode, typeof(System.Int32), "", MappingType.Element);
            SumClaimCustCode.Caption = "�������Ӑ�R�[�h";

            // �������Ӑ�R�[�h(���o���ʕ\���p)
            DataColumn SumClaimCustCodeDisp = new DataColumn(CT_CsDmd_SumClaimCustCodeDisp, typeof(System.String), "", MappingType.Element);
            SumClaimCustCodeDisp.Caption = "�������Ӑ�R�[�h";

            // �������Ӑ旪��
            DataColumn SumClaimCustSnm = new DataColumn(CT_CsDmd_SumClaimCustSnm, typeof(String), "", MappingType.Element);
            SumClaimCustSnm.Caption = "�������Ӑ旪��";

            // ������R�[�h
            DataColumn ClaimCode = new DataColumn(CT_CsDmd_ClaimCode, typeof(System.Int32), "", MappingType.Element);
            ClaimCode.Caption = "������R�[�h";

            // ������R�[�h(���o���ʕ\���p)
            DataColumn ClaimCodeDisp = new DataColumn(CT_CsDmd_ClaimCodeDisp, typeof(String), "", MappingType.Element);
            ClaimCodeDisp.Caption = "������R�[�h";
            
            // �����於��
            DataColumn ClaimName = new DataColumn(CT_CsDmd_ClaimName, typeof(String), "", MappingType.Element);
            ClaimName.Caption = "�����於��";

            // �����於��2
            DataColumn ClaimName2 = new DataColumn(CT_CsDmd_ClaimName2, typeof(String), "", MappingType.Element);
            ClaimName2.Caption = "�����於�̂Q";

            // �����旪��
            DataColumn ClaimSnm = new DataColumn(CT_CsDmd_ClaimSnm, typeof(String), "", MappingType.Element);
            ClaimSnm.Caption = "�����旪��";

            // ���Ӑ�R�[�h
            DataColumn CustomerCode = new DataColumn(CT_CsDmd_CustomerCode, typeof(System.Int32), "", MappingType.Element);
            CustomerCode.Caption = "���Ӑ�R�[�h";

            // ���Ӑ於��
            DataColumn CustomerName = new DataColumn(CT_CsDmd_CustomerName, typeof(String), "", MappingType.Element);
            CustomerName.Caption = "���Ӑ於��";

            // ���Ӑ於��2
            DataColumn CustomerName2 = new DataColumn(CT_CsDmd_CustomerName2, typeof(String), "", MappingType.Element);
            CustomerName2.Caption = "���Ӑ於�̂Q";

            // ���Ӑ旪��
            DataColumn CustomerSnm = new DataColumn(CT_CsDmd_CustomerSnm, typeof(String), "", MappingType.Element);
            CustomerSnm.Caption = "���Ӑ旪��";

            // �v��N����
            DataColumn AddUpDate = new DataColumn(CT_CsDmd_AddUpDate, typeof(System.DateTime), "", MappingType.Element);
            AddUpDate.Caption = "�v��N����";

            // �v��N����(Int�^)
            DataColumn AddUpDateInt = new DataColumn(CT_CsDmd_AddUpDateInt, typeof(System.Int32), "", MappingType.Element);
            AddUpDateInt.Caption = "�v��N����";

            // �v��N��
            DataColumn AddUpYearMonth = new DataColumn(CT_CsDmd_AddUpYearMonth, typeof(System.DateTime), "", MappingType.Element);
            AddUpYearMonth.Caption = "�v��N��";

            // �O�񐿋��z
            DataColumn LastTimeDemand = new DataColumn(CT_CsDmd_LastTimeDemand, typeof(System.Int64), "", MappingType.Element);
            LastTimeDemand.Caption = "�O�񐿋��z";

            // ����������z�i�ʏ�����j
            DataColumn ThisTimeDmdNrml = new DataColumn(CT_CsDmd_ThisTimeDmdNrml, typeof(System.Int64), "", MappingType.Element);
            ThisTimeDmdNrml.Caption = "����������z�i�ʏ�����j";

            // ����萔���z�i�ʏ�����j
            DataColumn ThisTimeFeeDmdNrml = new DataColumn(CT_CsDmd_ThisTimeFeeDmdNrml, typeof(System.Int64), "", MappingType.Element);
            ThisTimeFeeDmdNrml.Caption = "����萔���z�i�ʏ�����j";

            // ����l���z�i�ʏ�����j
            DataColumn ThisTimeDisDmdNrml = new DataColumn(CT_CsDmd_ThisTimeDisDmdNrml, typeof(System.Int64), "", MappingType.Element);
            ThisTimeDisDmdNrml.Caption = "����l���z�i�ʏ�����j";

            // ����J�z�c���i�����v�j[����J�z�c�����O�񐿋��z�|�����z�i�����v�j]
            DataColumn ThisTimeTtlBlcDmd = new DataColumn(CT_CsDmd_ThisTimeTtlBlcDmd, typeof(System.Int64), "", MappingType.Element);
            ThisTimeTtlBlcDmd.Caption = "����J�z�c���i�����v�j";

            // ���E�㍡�񔄏���z
            DataColumn OfsThisTimeSales = new DataColumn(CT_CsDmd_OfsThisTimeSales, typeof(System.Int64), "", MappingType.Element);
            OfsThisTimeSales.Caption = "���E�㍡�񔄏���z";

            // ���E�㍡�񔄏�����
            DataColumn OfsThisSalesTax = new DataColumn(CT_CsDmd_OfsThisSalesTax, typeof(System.Int64), "", MappingType.Element);
            OfsThisSalesTax.Caption = "���E�㍡�񔄏�����";

            // ���E�㍡�񍇌v������z
            DataColumn OfsThisSalesSum = new DataColumn(CT_CsDmd_OfsThisSalesSum, typeof(System.Int64), "", MappingType.Element);
            OfsThisSalesSum.Caption = "���E�㍡�񍇌v������z";

            // ���񔄏���z
            DataColumn ThisTimeSales = new DataColumn(CT_CsDmd_ThisTimeSales, typeof(System.Int64), "", MappingType.Element);
            ThisTimeSales.Caption = "���񔄏���z";

            // ���񔄏�ԕi���z
            DataColumn ThisSalesPricRgds = new DataColumn(CT_CsDmd_ThisSalesPricRgds, typeof(System.Int64), "", MappingType.Element);
            ThisSalesPricRgds.Caption = "���񔄏�ԕi���z";

            // ���񔄏�l�����z
            DataColumn ThisSalesPricDis = new DataColumn(CT_CsDmd_ThisSalesPricDis, typeof(System.Int64), "", MappingType.Element);
            ThisSalesPricDis.Caption = "���񔄏�l�����z";

            // ���񔄏�ԕi�E�l�����z
            DataColumn ThisSalesPricRgdsDis = new DataColumn(CT_CsDmd_ThisSalesPricRgdsDis, typeof(System.Int64), "", MappingType.Element);
            ThisSalesPricRgdsDis.Caption = "���񔄏�ԕi�E�l�����z";

            // �c�������z
            DataColumn BalanceAdjust = new DataColumn(CT_CsDmd_BalanceAdjust, typeof(System.Int64), "", MappingType.Element);
            BalanceAdjust.Caption = "�c�������z";

            // �v�Z�㐿�����z
            DataColumn AfCalDemandPrice = new DataColumn(CT_CsDmd_AfCalDemandPrice, typeof(System.Int64), "", MappingType.Element);
            AfCalDemandPrice.Caption = "�v�Z�㐿�����z";

            // �v�Z�㐿�����z(�t�B���^�[�p)
            DataColumn AfCalDemandPriceFilter = new DataColumn(CT_CsDmd_AfCalDemandPriceFilter, typeof(System.Int64), "", MappingType.Element);
            AfCalDemandPriceFilter.Caption = "�v�Z�㐿�����z(�t�B���^�[�p)";
            
            // ����`�[����
            DataColumn SaleslSlipCount = new DataColumn(CT_CsDmd_SaleslSlipCount, typeof(System.Int32), "", MappingType.Element);
            SaleslSlipCount.Caption = "����`�[����";

            // �[�������敪
            DataColumn FractionProcCd = new DataColumn(CT_CsDmd_FractionProcCd, typeof(System.Int32), "", MappingType.Element);
            FractionProcCd.Caption = "�[�������敪";

            // ���E�㍡�񔄏�����(����p)
            DataColumn PrintTtlConsTaxDmd = new DataColumn(CT_CsDmd_PrintTtlConsTaxDmd, typeof(String), "", MappingType.Element);
            PrintTtlConsTaxDmd.Caption = "���E�㍡�񔄏�����";
            
            // ****************
            // ���Ӑ���
            // ****************
            // ����
            DataColumn TotalDay = new DataColumn(CT_CsDmd_TotalDay, typeof(System.Int32), "", MappingType.Element);
            TotalDay.Caption = "����";

            // ����(����p)
            DataColumn PrintTotalDay = new DataColumn(CT_CsDmd_PrintTotalDay, typeof(String), "", MappingType.Element);
            PrintTotalDay.Caption = "����";

            // �W�����敪����
            DataColumn CollectMoneyName = new DataColumn(CT_CsDmd_CollectMoneyName, typeof(String), "", MappingType.Element);
            CollectMoneyName.Caption = "�W�����敪����";

            // �W����
            DataColumn CollectMoneyDay = new DataColumn(CT_CsDmd_CollectMoneyDay, typeof(System.Int32), "", MappingType.Element);
            CollectMoneyDay.Caption = "�W����";

            // �W����(����p)
            DataColumn CollectMoneyDayNm = new DataColumn(CT_CsDmd_CollectMoneyDayNm, typeof(String), "", MappingType.Element);
            CollectMoneyDayNm.Caption = "�W����(����p)";

            // �ڋq�S���]�ƈ��R�[�h
            DataColumn CustomerAgentCd = new DataColumn(CT_CsDmd_CustomerAgentCd, typeof(String), "", MappingType.Element);
            CustomerAgentCd.Caption = "�ڋq�S���]�ƈ��R�[�h";

            // �ڋq�S���]�ƈ�����
            DataColumn CustomerAgentNm = new DataColumn(CT_CsDmd_CustomerAgentNm, typeof(String), "", MappingType.Element);
            CustomerAgentNm.Caption = "�ڋq�S���]�ƈ�����";

            // �W���S���]�ƈ��R�[�h
            DataColumn BillCollecterCd = new DataColumn(CT_CsDmd_BillCollecterCd, typeof(String), "", MappingType.Element);
            BillCollecterCd.Caption = "�W���S���]�ƈ��R�[�h";

            // �W���S���]�ƈ�����
            DataColumn BillCollecterNm = new DataColumn(CT_CsDmd_BillCollecterNm, typeof(String), "", MappingType.Element);
            BillCollecterNm.Caption = "�W���S���]�ƈ�����";

            // ����p�]�ƈ��R�[�h
            DataColumn EmployeeCd = new DataColumn(CT_CsDmd_EmployeeCd, typeof(String), "", MappingType.Element);
            EmployeeCd.Caption = "����p�]�ƈ��R�[�h";

            // ����p�]�ƈ�����
            DataColumn EmployeeNm = new DataColumn(CT_CsDmd_EmployeeNm, typeof(String), "", MappingType.Element);
            EmployeeNm.Caption = "����p�]�ƈ�����";

            // ���z�\���敪
            DataColumn TotalAmountDispWayCd = new DataColumn(CT_CsDmd_TotalAmountDispWayCd, typeof(Int32), "", MappingType.Element);
            TotalAmountDispWayCd.Caption = "���z�\���敪";

            // ����p�������z
            DataColumn PrintAfCalDemandPrice = new DataColumn(CT_CsDmd_PrintAfCalDemandPrice, typeof(String), "", MappingType.Element);

            // �����c��
            DataColumn DemandBalance = new DataColumn(CT_CsDmd_DemandBalance, typeof(System.Int64), "", MappingType.Element);

            // ������z
            DataColumn NetSales = new DataColumn(CT_CsDmd_NetSales, typeof(System.Int64), "", MappingType.Element);

            // �����
            DataColumn CollectRate = new DataColumn(CT_CsDmd_CollectRate, typeof(double), "", MappingType.Element);

            // ����c��(���v���v�Z�p)
            DataColumn CollectDemand = new DataColumn(CT_CsDmd_CollectDemand, typeof(System.Int64), "", MappingType.Element);

            // �̔��G���A�R�[�h
            DataColumn SalesAreaCode = new DataColumn(CT_CsDmd_SalesAreaCode, typeof(System.Int32), "", MappingType.Element);

            // �̔��G���A�R�[�h
            DataColumn SalesAreaName = new DataColumn(CT_CsDmd_SalesAreaName, typeof(String), "", MappingType.Element);

            //--------------------------------------------------
            //  �c����������
            //--------------------------------------------------
            // �󒍂R��O�c��(�O�X�X��)
            DataColumn AcpOdrTtl3TmBfBlDmd = new DataColumn(CT_Blnce_AcpOdrTtl3TmBfBlDmd, typeof(System.Int64), "", MappingType.Element);

            // �󒍂Q��O�c��(�O�X��)
            DataColumn AcpOdrTtl2TmBfBlDmd = new DataColumn(CT_Blnce_AcpOdrTtl2TmBfBlDmd, typeof(System.Int64), "", MappingType.Element);

            // ����(����敪)
            DataColumn MoneyKindDiv101 = new DataColumn(CT_Blnce_MoneyKindDiv101, typeof(System.Int64), "", MappingType.Element);

            // �U��(����敪)
            DataColumn MoneyKindDiv102 = new DataColumn(CT_Blnce_MoneyKindDiv102, typeof(System.Int64), "", MappingType.Element);

            // ���؎�(����敪)
            DataColumn MoneyKindDiv107 = new DataColumn(CT_Blnce_MoneyKindDiv107, typeof(System.Int64), "", MappingType.Element);

            // ��`(����敪)
            DataColumn MoneyKindDiv105 = new DataColumn(CT_Blnce_MoneyKindDiv105, typeof(System.Int64), "", MappingType.Element);

            // ���E(����敪)
            DataColumn MoneyKindDiv106 = new DataColumn(CT_Blnce_MoneyKindDiv106, typeof(System.Int64), "", MappingType.Element);

            // ���̑�(����敪)
            DataColumn MoneyKindDiv109 = new DataColumn(CT_Blnce_MoneyKindDiv109, typeof(System.Int64), "", MappingType.Element);

            // �����U��(����敪)
            DataColumn MoneyKindDiv112 = new DataColumn(CT_Blnce_MoneyKindDiv112, typeof(System.Int64), "", MappingType.Element);
            
            // �������o�͋敪�R�[�h
            DataColumn BillOutputCode = new DataColumn(CT_Blnce_BillOutputCode, typeof(Int32), "", MappingType.Element);
            
            // �̎����o�͋敪�R�[�h
            DataColumn ReceiptOutputCode = new DataColumn(CT_Blnce_ReceiptOutputCode, typeof(Int32), "", MappingType.Element);  // ADD 2009/04/07

            // --- ADD  ���r��  2010/02/01 ---------->>>>>
            //���v�������o�͋敪�R�[�h
            DataColumn TotalBillOutputDiv = new DataColumn(CT_Blnce_TotalBillOutputDiv, typeof(Int32), "", MappingType.Element);

            //���א������o�͋敪�R�[�h
            DataColumn DetailBillOutputCode = new DataColumn(CT_Blnce_DetailBillOutputCode, typeof(Int32), "", MappingType.Element);

            //�`�[���v�������o�͋敪�R�[�h
            DataColumn SlipTtlBillOutputDiv = new DataColumn(CT_Blnce_SlipTtlBillOutputDiv, typeof(Int32), "", MappingType.Element);

            // --- ADD  ���r��  2010/02/01 ----------<<<<<

            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
            //  ����z(�v�ŗ�1)
            DataColumn TotalThisTimeSalesTaxRate1 = new DataColumn(Col_TotalThisTimeSalesTaxRate1, typeof(System.Int64), "", MappingType.Element);
            // ����z(�v�ŗ�2)
            DataColumn TotalThisTimeSalesTaxRate2 = new DataColumn(Col_TotalThisTimeSalesTaxRate2, typeof(System.Int64), "", MappingType.Element);
            // ����z(�v���̑�)
            DataColumn TotalThisTimeSalesOther = new DataColumn(Col_TotalThisTimeSalesOther, typeof(System.Int64), "", MappingType.Element);
            // �ԕi�l��(�v�ŗ�1)
            DataColumn TotalThisRgdsDisPricTaxRate1 = new DataColumn(Col_TotalThisRgdsDisPricTaxRate1, typeof(System.Int64), "", MappingType.Element);
            // �ԕi�l��(�v�ŗ�2)
            DataColumn TotalThisRgdsDisPricTaxRate2 = new DataColumn(Col_TotalThisRgdsDisPricTaxRate2, typeof(System.Int64), "", MappingType.Element);
            // �ԕi�l��(�v���̑�)
            DataColumn TotalThisRgdsDisPricOther = new DataColumn(Col_TotalThisRgdsDisPricOther, typeof(System.Int64), "", MappingType.Element);
            // ������z(�v�ŗ�1)
            DataColumn TotalPureSalesTaxRate1 = new DataColumn(Col_TotalPureSalesTaxRate1, typeof(System.Int64), "", MappingType.Element);
            // ������z(�v�ŗ�2)
            DataColumn TotalPureSalesTaxRate2 = new DataColumn(Col_TotalPureSalesTaxRate2, typeof(System.Int64), "", MappingType.Element);
            // ������z(�v���̑�)
            DataColumn TotalPureSalesOther = new DataColumn(Col_TotalPureSalesOther, typeof(System.Int64), "", MappingType.Element);
            // �����(�v�ŗ�1)
            DataColumn TotalSalesPricTaxTaxRate1 = new DataColumn(Col_TotalSalesPricTaxTaxRate1, typeof(System.Int64), "", MappingType.Element);
            // �����(�v�ŗ�2)
            DataColumn TotalSalesPricTaxTaxRate2 = new DataColumn(Col_TotalSalesPricTaxTaxRate2, typeof(System.Int64), "", MappingType.Element);
            // �����(�v���̑�)
            DataColumn TotalSalesPricTaxOther = new DataColumn(Col_TotalSalesPricTaxOther, typeof(System.Int64), "", MappingType.Element);
            // ���񍇌v(�v�ŗ�1)
            DataColumn TotalThisSalesSumTaxRate1 = new DataColumn(Col_TotalThisSalesSumTaxRate1, typeof(System.Int64), "", MappingType.Element);
            // ���񍇌v(�v�ŗ�2)
            DataColumn TotalThisSalesSumTaxRate2 = new DataColumn(Col_TotalThisSalesSumTaxRate2, typeof(System.Int64), "", MappingType.Element);
            // ���񍇌v(�v���̑�)
            DataColumn TotalThisSalesSumTaxOther = new DataColumn(Col_TotalThisSalesSumTaxOther, typeof(System.Int64), "", MappingType.Element);
            // ����(�v�ŗ�1)
            DataColumn TotalSalesSlipCountTaxRate1 = new DataColumn(Col_TotalSalesSlipCountTaxRate1, typeof(System.Int64), "", MappingType.Element);
            // ����(�v�ŗ�2)
            DataColumn TotalSalesSlipCountTaxRate2 = new DataColumn(Col_TotalSalesSlipCountTaxRate2, typeof(System.Int64), "", MappingType.Element);
            // ����(�v���̑�)
            DataColumn TotalSalesSlipCountOther = new DataColumn(Col_TotalSalesSlipCountOther, typeof(System.Int64), "", MappingType.Element);
            // �ŗ�1�^�C�g��
            DataColumn TitleTaxRate1 = new DataColumn(Col_TitleTaxRate1, typeof(System.String), "", MappingType.Element);
            // �ŗ�2�^�C�g��
            DataColumn TitleTaxRate2 = new DataColumn(Col_TitleTaxRate2, typeof(System.String), "", MappingType.Element);
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
            // --- ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
            // ����z(�v��ې�)
            DataColumn TotalThisTimeSalesTaxFree = new DataColumn(Col_TotalThisTimeSalesTaxFree, typeof(System.Int64), "", MappingType.Element);
            // �ԕi�l��(�v��ې�)
            DataColumn TotalThisRgdsDisPricTaxFree = new DataColumn(Col_TotalThisRgdsDisPricTaxFree, typeof(System.Int64), "", MappingType.Element);
            // ������z(�v��ې�)
            DataColumn TotalPureSalesTaxFree = new DataColumn(Col_TotalPureSalesTaxFree, typeof(System.Int64), "", MappingType.Element);
            // �����(�v��ې�)
            DataColumn TotalSalesPricTaxTaxFree = new DataColumn(Col_TotalSalesPricTaxTaxFree, typeof(System.Int64), "", MappingType.Element);
            // ���񍇌v(�v��ې�)
            DataColumn TotalThisSalesSumTaxFree = new DataColumn(Col_TotalThisSalesSumTaxFree, typeof(System.Int64), "", MappingType.Element);
            // ����(�v��ې�)
            DataColumn TotalSalesSlipCountTaxFree = new DataColumn(Col_TotalSalesSlipCountTaxFree, typeof(System.Int64), "", MappingType.Element);
            // --- ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    
            _demandDataSet.Tables.AddRange(new DataTable[] { _custDmdPrcDataTable });
            _custDmdPrcDataTable.Columns.AddRange(new DataColumn[]{
                UniqueID,
                    DataType,
                    RecordName,
				    PrintFlag,
				    PrintIndex,
				    AddUpSecCode,
				    AddUpSecName,
                    ClaimSectionCode,
                    ClaimSectionName,
                    ResultsSectCd,
                    SumClaimCustCode,
                    SumClaimCustCodeDisp,
                    SumClaimCustSnm,
                    ClaimCode,
                    ClaimCodeDisp,
                    ClaimName,
                    ClaimName2,
                    ClaimSnm,
				    CustomerCode,
                    CustomerName,
                    CustomerName2,
                    CustomerSnm,
                    AddUpDate,
				    AddUpDateInt,		
				    AddUpYearMonth,
                    LastTimeDemand,
                    DemandBalance,
                    ThisTimeDmdNrml,        
                    ThisTimeFeeDmdNrml,     
                    ThisTimeDisDmdNrml,
                    ThisTimeTtlBlcDmd,
                    OfsThisTimeSales,
                    OfsThisSalesTax,
                    OfsThisSalesSum,
                    ThisTimeSales,
                    ThisSalesPricRgds,
                    ThisSalesPricDis,
                    ThisSalesPricRgdsDis,
                    BalanceAdjust,
                    AfCalDemandPrice,
                    AfCalDemandPriceFilter,
                    SaleslSlipCount,
                    FractionProcCd,
                    PrintTtlConsTaxDmd,
                    CollectMoneyName,
				    CollectMoneyDay,
				    CollectMoneyDayNm,
                    TotalDay,
				    PrintTotalDay,
				    CustomerAgentCd,
				    CustomerAgentNm,
				    BillCollecterCd,
				    BillCollecterNm,
				    EmployeeCd,
				    EmployeeNm,
                    TotalAmountDispWayCd,
                    PrintAfCalDemandPrice,
                    NetSales,
                    CollectRate,
                    CollectDemand,
                    SalesAreaCode,
                    SalesAreaName,
                    AcpOdrTtl3TmBfBlDmd,
                    AcpOdrTtl2TmBfBlDmd,
                    MoneyKindDiv101,
                    MoneyKindDiv102,
                    MoneyKindDiv107,
                    MoneyKindDiv105,
                    MoneyKindDiv106,
                    MoneyKindDiv109,
                    MoneyKindDiv112,
                    BillOutputCode,
                // --- ADD  ���r��  2010/02/01 ---------->>>>>
                    //ReceiptOutputCode
                    ReceiptOutputCode,
                    TotalBillOutputDiv,
                    DetailBillOutputCode,
                    SlipTtlBillOutputDiv,
                // --- ADD  ���r��  2010/02/01 ----------<<<<<
                �@// --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
                �@�@TotalThisTimeSalesTaxRate1,
                    TotalThisTimeSalesTaxRate2,
                    TotalThisTimeSalesTaxFree,// ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    TotalThisTimeSalesOther,
                    TotalThisRgdsDisPricTaxRate1,
                    TotalThisRgdsDisPricTaxRate2,
                    TotalThisRgdsDisPricTaxFree,// ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    TotalThisRgdsDisPricOther,
                    TotalPureSalesTaxRate1,
                    TotalPureSalesTaxRate2,
                    TotalPureSalesTaxFree,// ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    TotalPureSalesOther,
                    TotalSalesPricTaxTaxRate1,
                    TotalSalesPricTaxTaxRate2,
                    TotalSalesPricTaxTaxFree,// ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    TotalSalesPricTaxOther,
                    TotalThisSalesSumTaxRate1,
                    TotalThisSalesSumTaxRate2,
                    TotalThisSalesSumTaxFree,// ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    TotalThisSalesSumTaxOther,
                    TotalSalesSlipCountTaxRate1,
                    TotalSalesSlipCountTaxRate2,
                    TotalSalesSlipCountTaxFree,// ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    TotalSalesSlipCountOther,
                    TitleTaxRate1,
                    TitleTaxRate2,
�@�@�@�@�@�@�@�@�@�@// --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
			    });
            // �v���C�}���[�L�[�����j�[�NID�ɐݒ�
            _custDmdPrcDataTable.PrimaryKey = new DataColumn[] { UniqueID };
            _custDmdPrcDataView.Table = _custDmdPrcDataTable;
            // �\�[�g���F�������_�{�������Ӑ�{���ы��_�{�������Ӑ�
            _custDmdPrcDataView.Sort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_SumClaimCustCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_ClaimCode;

            // ����pDataTable�쐬
            _custDmdPrcPrintDataTable = _custDmdPrcDataTable.Clone();
            _custDmdPrcDataViewPrint.Table = _custDmdPrcPrintDataTable;
            // �\�[�g���F�������_�{�������Ӑ�{���ы��_�{�������Ӑ�
            _custDmdPrcDataViewPrint.Sort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_SumClaimCustCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_ClaimCode;
            
            _custDmdPrcDataViewPrint.RowFilter = String.Format("{0} = {1}", CT_CsDmd_PrintFlag, true);

        }

        /// <summary>
        /// ���Ӑ搿�����z���f�[�^�s�ݒ菈��(����)
        /// </summary>
        /// <param name="extraInfo">���o�����f�[�^�N���X</param>
        /// <param name="rsltInfo_DemandTotalWork">���o���ʃf�[�^���[�N�N���X</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note        : ���Ӑ搿�����z�����f�[�^�s�֐ݒ肵�܂��B</br>
        /// <br>Update Note : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/04/13</br>
        /// </remarks>
        private DataRow CustDmdPrcWorkToDataRow(SumExtrInfo_DemandTotal extraInfo, SumRsltInfo_DemandTotalWork rsltInfo_DemandTotalWork)
        {
            DataRow newRow = _custDmdPrcDataTable.NewRow();

            // �������Ӑ�R�[�h�̎擾
            if (!_sumClaimCustCodeList.Contains(rsltInfo_DemandTotalWork.SumClaimCustCode))
            {
                _sumClaimCustCodeList.Add(rsltInfo_DemandTotalWork.SumClaimCustCode);
            }
            
            // ���|�敪�̃`�F�b�N
            if (extraInfo.SlipPrtKind == 0)
            {
                // ���s�^�C�v�F�����ꗗ�\�i�����j
                if (extraInfo.AccRecDivCd != -1)
                {
                    // ���o�����̔��|�敪��"�S��"�ȊO
                    if (extraInfo.AccRecDivCd != rsltInfo_DemandTotalWork.AccRecDivCd)
                    {
                        // ���|�敪����v���Ȃ��ꍇ�͒��o�ΏۊO
                        return null;
                    }
                }
            }
            else
            {
                // ���s�^�C�v�F�������i�����j
                if (rsltInfo_DemandTotalWork.AccRecDivCd == 0)
                {
                    // ���|�敪��"���|"�ȊO�͒��o�ΏۊO
                    return null;
                }
            }
            
            // ���R�[�h�^�C�v�i�W�v���R�[�h��false�j
            newRow[CT_CsDmd_DataType] = false;
            // ���R�[�h��
            newRow[CT_CsDmd_RecordName] = "�W�v���R�[�h";
            // ����t���O
            newRow[CT_CsDmd_PrintFlag] = true;

            // �v�㋒�_�R�[�h
            string secCode = rsltInfo_DemandTotalWork.AddUpSecCode;
            newRow[CT_CsDmd_AddUpSecCode] = secCode;
            // �v�㋒�_����
            if (_sectionOption)
            {
                if (SectionTable.ContainsKey(secCode))
                {
                    newRow[CT_CsDmd_AddUpSecName] = ((SecInfoSet)SectionTable[secCode]).SectionGuideNm;
                }
                else
                {
                    newRow[CT_CsDmd_AddUpSecName] = "";
                }
            }
            else
            {
                newRow[CT_CsDmd_AddUpSecName] = "";
            }
            
            // �������_�R�[�h
            string claimSecCode = rsltInfo_DemandTotalWork.ClaimSectionCode;
            newRow[CT_CsDmd_ClaimSectionCode] = claimSecCode;
            // �������_����
            if (_sectionOption)
            {
                if (SectionTable.ContainsKey(claimSecCode))
                {
                    newRow[CT_CsDmd_ClaimSectionName] = ((SecInfoSet)SectionTable[claimSecCode]).SectionGuideNm;
                }
                else
                {
                    newRow[CT_CsDmd_ClaimSectionName] = "";
                }
            }
            else
            {
                newRow[CT_CsDmd_ClaimSectionName] = "";
            }

            // ���ы��_�R�[�h�i4/23���݁A"00"���Ԃ��Ă���j
            newRow[CT_CsDmd_ResultsSectCd] = rsltInfo_DemandTotalWork.ResultsSectCd;

            // �������Ӑ�R�[�h
            newRow[CT_CsDmd_SumClaimCustCode] = rsltInfo_DemandTotalWork.SumClaimCustCode;
            // �������Ӑ�R�[�h(���o���ʕ\���p)
            newRow[CT_CsDmd_SumClaimCustCodeDisp] = rsltInfo_DemandTotalWork.SumClaimCustCode.ToString("d08");

            // �������Ӑ旪��
            // 2010/07/01 >>>
            //newRow[CT_CsDmd_SumClaimCustSnm] = rsltInfo_DemandTotalWork.SumClaimCustName;
            newRow[CT_CsDmd_SumClaimCustSnm] = nameJoin(rsltInfo_DemandTotalWork.SumClaimCustName1, rsltInfo_DemandTotalWork.SumClaimCustName2);
            // 2010/07/01 <<<
            
            // ������R�[�h
            newRow[CT_CsDmd_ClaimCode] = rsltInfo_DemandTotalWork.ClaimCode;
            // ������R�[�h(���o���ʕ\���p)
            newRow[CT_CsDmd_ClaimCodeDisp] = rsltInfo_DemandTotalWork.ClaimCode.ToString("d08");
            
            // �����於��
            newRow[CT_CsDmd_ClaimName] = rsltInfo_DemandTotalWork.ClaimName;
            // �����於��2
            newRow[CT_CsDmd_ClaimName2] = rsltInfo_DemandTotalWork.ClaimName2;
            // �����旪��
            newRow[CT_CsDmd_ClaimSnm] = rsltInfo_DemandTotalWork.ClaimSnm;

            // ���Ӑ�R�[�h
            newRow[CT_CsDmd_CustomerCode] = rsltInfo_DemandTotalWork.CustomerCode;
            // ���Ӑ於��
            newRow[CT_CsDmd_CustomerName] = rsltInfo_DemandTotalWork.CustomerName;
            // ���Ӑ於��2
            newRow[CT_CsDmd_CustomerName2] = rsltInfo_DemandTotalWork.CustomerName2;
            // ���Ӑ旪��
            newRow[CT_CsDmd_CustomerSnm] = rsltInfo_DemandTotalWork.CustomerSnm;
            
            // �v��N����
            newRow[CT_CsDmd_AddUpDate] = rsltInfo_DemandTotalWork.AddUpDate;
            // �v��N����(Int�^)
            newRow[CT_CsDmd_AddUpDateInt] = TDateTime.DateTimeToLongDate(rsltInfo_DemandTotalWork.AddUpDate);
            // �v��N��
            newRow[CT_CsDmd_AddUpYearMonth] = rsltInfo_DemandTotalWork.AddUpYearMonth;

            // �O�񐿋��z 
            newRow[CT_CsDmd_LastTimeDemand] = rsltInfo_DemandTotalWork.LastTimeDemand;
            
            // ����������z�i�ʏ�����j
            newRow[CT_CsDmd_ThisTimeDmdNrml] = rsltInfo_DemandTotalWork.ThisTimeDmdNrml;

            // ����萔���z�i�ʏ�����j
            newRow[CT_CsDmd_ThisTimeFeeDmdNrml] = rsltInfo_DemandTotalWork.ThisTimeFeeDmdNrml;

            // ����l���z(�ʏ����)
            newRow[CT_CsDmd_ThisTimeDisDmdNrml] = rsltInfo_DemandTotalWork.ThisTimeDisDmdNrml;

            // ����J�z�c���i�����v�j
            newRow[CT_CsDmd_ThisTimeTtlBlcDmd] = rsltInfo_DemandTotalWork.ThisTimeTtlBlcDmd;

            // ���E�㍡�񔄏���z
            newRow[CT_CsDmd_OfsThisTimeSales] = rsltInfo_DemandTotalWork.OfsThisTimeSales;

            // ���E�㍡�񔄏�����
            newRow[CT_CsDmd_OfsThisSalesTax] = rsltInfo_DemandTotalWork.OfsThisSalesTax;

            // ���E�㍡�񍇌v������z
            // ���E�㍡�񔄏���z�{���E�㍡�񔄏�����
            Int64 ofsThisSalesSum = rsltInfo_DemandTotalWork.OfsThisTimeSales + rsltInfo_DemandTotalWork.OfsThisSalesTax;
            newRow[CT_CsDmd_OfsThisSalesSum] = ofsThisSalesSum;
            
            // ���񔄏���z
            newRow[CT_CsDmd_ThisTimeSales] = rsltInfo_DemandTotalWork.ThisTimeSales;

            // ���񔄏�ԕi���z
            newRow[CT_CsDmd_ThisSalesPricRgds] = rsltInfo_DemandTotalWork.ThisSalesPricRgds;

            // ���񔄏�l�����z
            newRow[CT_CsDmd_ThisSalesPricDis] = rsltInfo_DemandTotalWork.ThisSalesPricDis;

            // ���񔄏�ԕi�E�l�����z
            long thisSalesPricRgdsDis = (Int64)(rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis);
            newRow[CT_CsDmd_ThisSalesPricRgdsDis] = -thisSalesPricRgdsDis;
            
            // �c�������z
            newRow[CT_CsDmd_BalanceAdjust] = rsltInfo_DemandTotalWork.BalanceAdjust;

            // �v�Z�㐿�����z
            newRow[CT_CsDmd_AfCalDemandPrice] = rsltInfo_DemandTotalWork.AfCalDemandPrice;

            // --- DEL  ���r��  2010/02/24 ---------->>>>>
            ////�v�Z�㐿�����z���L���b�V���o�^
            //string key = secCode.TrimEnd() + "-" + rsltInfo_DemandTotalWork.SumClaimCustCode.ToString("d08");
            //if ((bool)newRow[CT_CsDmd_DataType])
            //{
            //    // �W�v���R�[�h
            //    if (afCalDemandPriceDic.ContainsKey(key))
            //    {
            //        long afCalDemandPrice = afCalDemandPriceDic[key] + rsltInfo_DemandTotalWork.AfCalDemandPrice;
            //        afCalDemandPriceDic.Remove(key);
            //    }
            //    afCalDemandPriceDic.Add(key, rsltInfo_DemandTotalWork.AfCalDemandPrice);
            //}
            // --- DEL  ���r��  2010/02/24 ----------<<<<<
                            
            // ����`�[����
            newRow[CT_CsDmd_SaleslSlipCount] = rsltInfo_DemandTotalWork.SalesSlipCount;

            // �[�������敪
            newRow[CT_CsDmd_FractionProcCd] = rsltInfo_DemandTotalWork.FractionProcCd;

            // �W�v���R�[�h�̏ꍇ
            if (_allDefSet.TotalAmountDispWayCd == 0)
            {
                // ���z�\�����Ȃ��Ŕ���(���E�㍡�񔄏�����) 
                newRow[CT_CsDmd_PrintTtlConsTaxDmd] = rsltInfo_DemandTotalWork.OfsThisSalesTax.ToString("#,##0");
            }
            else
            {
                // ���z�\������ō���(���E�㍡�񔄏�����)
                newRow[CT_CsDmd_PrintTtlConsTaxDmd] = "(" + rsltInfo_DemandTotalWork.OfsThisSalesTax.ToString("#,##0") + ")";
            }
            
            // ����p�������z
            newRow[CT_CsDmd_PrintAfCalDemandPrice] = "\\" + rsltInfo_DemandTotalWork.AfCalDemandPrice.ToString("#,##0");

            // *********************
            // ���Ӑ�֘A����
            // *********************
            // ����
            newRow[CT_CsDmd_TotalDay] = rsltInfo_DemandTotalWork.TotalDay;

            // ����(����p)
            if (rsltInfo_DemandTotalWork.TotalDay != 0)
            {
                newRow[CT_CsDmd_PrintTotalDay] = String.Format("{0,2}��", rsltInfo_DemandTotalWork.TotalDay);
            }

            // �W�����敪����
            newRow[CT_CsDmd_CollectMoneyName] = rsltInfo_DemandTotalWork.CollectMoneyName;

            // �W����
            newRow[CT_CsDmd_CollectMoneyDay] = rsltInfo_DemandTotalWork.CollectMoneyDay;

            // �W����(����p)
            if (rsltInfo_DemandTotalWork.CollectMoneyDay != 0)
            {
                // �����������󎚋敪 = 1(28�`31���͖����ƈ�) ��28���ȍ~�̏ꍇ
                if (rsltInfo_DemandTotalWork.CollectMoneyDay >= 28 && _billPrtSt.BillLastDayPrtDiv == 1)
                {
                    newRow[CT_CsDmd_CollectMoneyDayNm] = "����";
                }
                else
                {
                    newRow[CT_CsDmd_CollectMoneyDayNm] = String.Format("{0}��", rsltInfo_DemandTotalWork.CollectMoneyDay);
                }
            }
            else
            {
                newRow[CT_CsDmd_CollectMoneyDayNm] = "";
            }

            // �ڋq�S���]�ƈ��R�[�h
            newRow[CT_CsDmd_CustomerAgentCd] = rsltInfo_DemandTotalWork.CustomerAgentCd;

            // �ڋq�S���]�ƈ�����
            newRow[CT_CsDmd_CustomerAgentNm] = rsltInfo_DemandTotalWork.CustomerAgentNm;

            // �W���S���]�ƈ��R�[�h
            newRow[CT_CsDmd_BillCollecterCd] = rsltInfo_DemandTotalWork.BillCollecterCd;

            // �W���S���]�ƈ�����
            newRow[CT_CsDmd_BillCollecterNm] = rsltInfo_DemandTotalWork.BillCollecterNm;

            // ���z�\���敪
            newRow[CT_CsDmd_TotalAmountDispWayCd] = rsltInfo_DemandTotalWork.TotalAmountDispWayCd;

            // �����c��
            newRow[CT_CsDmd_DemandBalance] = rsltInfo_DemandTotalWork.LastTimeDemand + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd;

            // ������z
            newRow[CT_CsDmd_NetSales] = rsltInfo_DemandTotalWork.OfsThisTimeSales;
            
            // �����
            Int64 collectDemand = 0;
            double collectRate = 0.0;
            if (extraInfo.CollectRatePrtDiv == 0)
            {
                // �O��c�v�Z
                collectDemand = rsltInfo_DemandTotalWork.LastTimeDemand + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd;
            }
            else if (extraInfo.CollectRatePrtDiv == 1)
            {
                // ������v�Z
                if (rsltInfo_DemandTotalWork.CollectMoneyCode == 0)
                {
                    // ����
                    if ((rsltInfo_DemandTotalWork.TotalDay < _endDays) && (rsltInfo_DemandTotalWork.TotalDay < rsltInfo_DemandTotalWork.CollectMoneyDay))
                    {
                        // �����������ȊO�ŁA�������W��������̏ꍇ�͓�������
                        collectDemand = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd
                                      + rsltInfo_DemandTotalWork.LastTimeDemand + rsltInfo_DemandTotalWork.OfsThisTimeSales
                                      + rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis
                                      + rsltInfo_DemandTotalWork.OfsThisSalesTax;
                    }
                    else
                    {
                        // ��L�ȊO�͗�������
                        collectDemand = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd
                                      + rsltInfo_DemandTotalWork.LastTimeDemand;
                    }
                }
                else if (rsltInfo_DemandTotalWork.CollectMoneyCode == 1)
                {
                    // ����
                    collectDemand = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd
                                  + rsltInfo_DemandTotalWork.LastTimeDemand;
                }
                else if (rsltInfo_DemandTotalWork.CollectMoneyCode == 2)
                {
                    // ���X��
                    collectDemand = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd;
                }
                else
                {
                    // ���X�X��
                    collectDemand = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd;                    
                }
            }

            // �O��c�^��������z�ƍ�������z���[���ȊO�̏ꍇ������v�Z
            if ((collectDemand != 0) && (rsltInfo_DemandTotalWork.ThisTimeDmdNrml != 0))
            {
                collectRate = (double)rsltInfo_DemandTotalWork.ThisTimeDmdNrml * 100 / (double)collectDemand;
            }
            newRow[CT_CsDmd_CollectRate] = collectRate;

            // ����c��(���v���v�Z�p)
            newRow[CT_CsDmd_CollectDemand] = collectDemand;

            // �̔��G���A�R�[�h
            newRow[CT_CsDmd_SalesAreaCode] = rsltInfo_DemandTotalWork.SalesAreaCode;

            // �̔��G���A����
            newRow[CT_CsDmd_SalesAreaName] = rsltInfo_DemandTotalWork.SalesAreaName;

            // �󒍂R��O�c��(�O�X�X��)
            newRow[CT_Blnce_AcpOdrTtl3TmBfBlDmd] = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd;

            // �󒍂Q��O�c��(�O�X��)
            newRow[CT_Blnce_AcpOdrTtl2TmBfBlDmd] = rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd;

            // ����(����敪)
            newRow[CT_Blnce_MoneyKindDiv101] = 0;
            // �U��(����敪)
            newRow[CT_Blnce_MoneyKindDiv102] = 0;
            // ���؎�(����敪)
            newRow[CT_Blnce_MoneyKindDiv107] = 0;
            // ��`(����敪)
            newRow[CT_Blnce_MoneyKindDiv105] = 0;
            // ���E(����敪)
            newRow[CT_Blnce_MoneyKindDiv106] = 0;
            // �����U��(����敪)
            newRow[CT_Blnce_MoneyKindDiv112] = 0;
            // ���̑�
            newRow[CT_Blnce_MoneyKindDiv109] = 0;
            
            foreach (SumRsltInfo_DepsitTotalWork work in rsltInfo_DemandTotalWork.MoneyKindList)
            {
                if (work.MoneyKindDiv == 101)
                {
                    // ����(����敪)
                    newRow[CT_Blnce_MoneyKindDiv101] = work.Deposit;
                }
                else if (work.MoneyKindDiv == 102)
                {
                    // �U��(����敪)
                    newRow[CT_Blnce_MoneyKindDiv102] = work.Deposit;
                }
                else if (work.MoneyKindDiv == 107)
                {
                    // ���؎�(����敪)
                    newRow[CT_Blnce_MoneyKindDiv107] = work.Deposit;
                }
                else if (work.MoneyKindDiv == 105)
                {
                    // ��`(����敪)
                    newRow[CT_Blnce_MoneyKindDiv105] = work.Deposit;
                }
                else if (work.MoneyKindDiv == 106)
                {
                    // ���E(����敪)
                    newRow[CT_Blnce_MoneyKindDiv106] = work.Deposit;
                }
                else if (work.MoneyKindDiv == 112)
                {
                    // �����U��(����敪)
                    newRow[CT_Blnce_MoneyKindDiv112] = work.Deposit;
                }
                else
                {
                    // ���̑�
                    newRow[CT_Blnce_MoneyKindDiv109] = (long)newRow[CT_Blnce_MoneyKindDiv109] + work.Deposit;
                }                
            }
            
            // �������o�͋敪�R�[�h
            newRow[CT_Blnce_BillOutputCode] = rsltInfo_DemandTotalWork.BillOutputCode;            
            // �̎����o�͋敪�R�[�h
            newRow[CT_Blnce_ReceiptOutputCode] = rsltInfo_DemandTotalWork.ReceiptOutputCode;

            // --- ADD  ���r��  2010/02/01 ---------->>>>>
            //���v�������o�͋敪�R�[�h
            newRow[CT_Blnce_TotalBillOutputDiv] = rsltInfo_DemandTotalWork.TotalBillOutputDiv;

            //���א������o�͋敪�R�[�h
            newRow[CT_Blnce_DetailBillOutputCode] = rsltInfo_DemandTotalWork.DetailBillOutputCode;

            //�`�[���v�������o�͋敪�R�[�h
            newRow[CT_Blnce_SlipTtlBillOutputDiv] = rsltInfo_DemandTotalWork.SlipTtlBillOutputDiv;

            // --- ADD  ���r��  2010/02/01 ----------<<<<<

            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
            if (_taxReductionDone)
            {
                // ����z(�v�ŗ�1)
                newRow[Col_TotalThisTimeSalesTaxRate1] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisTimeSalesTaxRate1");
                // ����z(�v�ŗ�2)
                newRow[Col_TotalThisTimeSalesTaxRate2] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisTimeSalesTaxRate2");
                // ����z(�v���̑�)
                newRow[Col_TotalThisTimeSalesOther] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisTimeSalesOther");
                // �ԕi�l��(�v�ŗ�1)
                newRow[Col_TotalThisRgdsDisPricTaxRate1] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisRgdsDisPricTaxRate1");
                // �ԕi�l��(�v�ŗ�2)
                newRow[Col_TotalThisRgdsDisPricTaxRate2] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisRgdsDisPricTaxRate2");
                // �ԕi�l��(�v���̑�)
                newRow[Col_TotalThisRgdsDisPricOther] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisRgdsDisPricOther");
                // ������z(�v�ŗ�1)
                newRow[Col_TotalPureSalesTaxRate1] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalPureSalesTaxRate1");
                // ������z(�v�ŗ�2)
                newRow[Col_TotalPureSalesTaxRate2] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalPureSalesTaxRate2");
                // ������z(�v���̑�)
                newRow[Col_TotalPureSalesOther] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalPureSalesOther");
                // �����(�v�ŗ�1)
                newRow[Col_TotalSalesPricTaxTaxRate1] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesPricTaxTaxRate1");
                // �����(�v�ŗ�2)
                newRow[Col_TotalSalesPricTaxTaxRate2] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesPricTaxTaxRate2");
                // �����(�v���̑�)
                newRow[Col_TotalSalesPricTaxOther] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesPricTaxOther");
                // ���񍇌v(�v�ŗ�1)
                newRow[Col_TotalThisSalesSumTaxRate1] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisSalesSumTaxRate1");
                // ���񍇌v(�v�ŗ�2)
                newRow[Col_TotalThisSalesSumTaxRate2] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisSalesSumTaxRate2");
                // ���񍇌v(�v���̑�)
                newRow[Col_TotalThisSalesSumTaxOther] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisSalesSumTaxOther");
                // ����(�v�ŗ�1)
                newRow[Col_TotalSalesSlipCountTaxRate1] = (int)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesSlipCountTaxRate1");
                // ����(�v�ŗ�2)
                newRow[Col_TotalSalesSlipCountTaxRate2] = (int)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesSlipCountTaxRate2");
                // ����(�v���̑�)
                newRow[Col_TotalSalesSlipCountOther] = (int)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesSlipCountOther");
                // �ŗ�1�^�C�g��
                newRow[Col_TitleTaxRate1] = Convert.ToInt32((double)GetPropertyValue(extraInfo, "TaxRate1") * 100) + "%";
                // �ŗ�2�^�C�g��
                newRow[Col_TitleTaxRate2] = Convert.ToInt32((double)GetPropertyValue(extraInfo, "TaxRate2") * 100) + "%";
                // --- ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                // ����z(�v��ې�)
                newRow[Col_TotalThisTimeSalesTaxFree] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisTimeSalesTaxFree");
                // �ԕi�l��(�v��ې�)
                newRow[Col_TotalThisRgdsDisPricTaxFree] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisRgdsDisPricTaxFree");
                // ������z(�v��ې�)
                newRow[Col_TotalPureSalesTaxFree] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalPureSalesTaxFree");
                // �����(�v��ې�)
                newRow[Col_TotalSalesPricTaxTaxFree] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesPricTaxTaxFree");
                // ���񍇌v(�v��ې�)
                newRow[Col_TotalThisSalesSumTaxFree] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisSalesSumTaxFree");
                // ����(�v��ې�)
                newRow[Col_TotalSalesSlipCountTaxFree] = (int)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesSlipCountTaxFree");
                // --- ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
            }
            else
            {
                // ����z(�v�ŗ�1)
                newRow[Col_TotalThisTimeSalesTaxRate1] = 0;
                // ����z(�v�ŗ�2)
                newRow[Col_TotalThisTimeSalesTaxRate2] = 0;
                // ����z(�v���̑�)
                newRow[Col_TotalThisTimeSalesOther] = 0;
                // �ԕi�l��(�v�ŗ�1)
                newRow[Col_TotalThisRgdsDisPricTaxRate1] = 0;
                // �ԕi�l��(�v�ŗ�2)
                newRow[Col_TotalThisRgdsDisPricTaxRate2] = 0;
                // �ԕi�l��(�v���̑�)
                newRow[Col_TotalThisRgdsDisPricOther] = 0;
                // ������z(�v�ŗ�1)
                newRow[Col_TotalPureSalesTaxRate1] = 0;
                // ������z(�v�ŗ�2)
                newRow[Col_TotalPureSalesTaxRate2] = 0;
                // ������z(�v���̑�)
                newRow[Col_TotalPureSalesOther] = 0;
                // �����(�v�ŗ�1)
                newRow[Col_TotalSalesPricTaxTaxRate1] = 0;
                // �����(�v�ŗ�2)
                newRow[Col_TotalSalesPricTaxTaxRate2] = 0;
                // �����(�v���̑�)
                newRow[Col_TotalSalesPricTaxOther] = 0;
                // ���񍇌v(�v�ŗ�1)
                newRow[Col_TotalThisSalesSumTaxRate1] = 0;
                // ���񍇌v(�v�ŗ�2)
                newRow[Col_TotalThisSalesSumTaxRate2] = 0;
                // ���񍇌v(�v���̑�)
                newRow[Col_TotalThisSalesSumTaxOther] = 0;
                // ����(�v�ŗ�1)
                newRow[Col_TotalSalesSlipCountTaxRate1] = 0;
                // ����(�v�ŗ�2)
                newRow[Col_TotalSalesSlipCountTaxRate2] = 0;
                // ����(�v���̑�)
                newRow[Col_TotalSalesSlipCountOther] = 0;
                //--- ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                // ����z(�v��ې�)
                newRow[Col_TotalThisTimeSalesTaxFree] = 0;
                // �ԕi�l��(�v��ې�)
                newRow[Col_TotalThisRgdsDisPricTaxFree] = 0;
                // ������z(�v��ې�)
                newRow[Col_TotalPureSalesTaxFree] = 0;
                // �����(�v��ې�)
                newRow[Col_TotalSalesPricTaxTaxFree] = 0;
                // ���񍇌v(�v��ې�)
                newRow[Col_TotalThisSalesSumTaxFree] = 0;
                // ����(�v��ې�)
                newRow[Col_TotalSalesSlipCountTaxFree] = 0;
                //--- ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                // �ŗ�1�^�C�g��
                newRow[Col_TitleTaxRate1] = string.Empty;
                // �ŗ�2�^�C�g��
                newRow[Col_TitleTaxRate2] = string.Empty;
            }
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<

            newRow.EndEdit();

            return newRow;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���o�����N���X�˒��o�������[�N�N���X�j
        /// </summary>
        /// <param name="extraInfo">���o�����N���X</param>
        /// <returns>���o�������[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���o�����N���X���璊�o�������[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private SumExtrInfo_DemandTotalWork CopyToExtraInfoWorkFromExtraInfo(SumExtrInfo_DemandTotal extraInfo)
        {
            SumExtrInfo_DemandTotalWork extraInfoWork = new SumExtrInfo_DemandTotalWork();

            // ���_
            if (extraInfo.ResultsAddUpSecList.Length != 0)
            {
                if (extraInfo.ResultsAddUpSecList[0] == "")
                {
                    // �S�Ђ̎�
                    extraInfoWork.ResultsAddUpSecList = new string[1];						// ���_�R�[�h
                    extraInfoWork.ResultsAddUpSecList[0] = "";
                }
                else
                {
                    extraInfoWork.ResultsAddUpSecList = extraInfo.ResultsAddUpSecList;      // ���_�R�[�h
                }
            }
            else
            {
                extraInfoWork.ResultsAddUpSecList = new string[0];                          // ���_�R�[�h
            }

            extraInfoWork.AddUpDate = extraInfo.AddUpDate;                          // ����
            
            if (extraInfo.CustomerAgentDivCd == 0)
            {
                extraInfoWork.CustomerAgentCdSt = extraInfo.CustomerAgentCdSt;      // �ڋq�S����(�J�n)
                extraInfoWork.CustomerAgentCdEd = extraInfo.CustomerAgentCdEd;      // �ڋq�S����(�I��)
                extraInfoWork.BillCollecterCdSt = "";                               // �W���S����(�J�n)
                extraInfoWork.BillCollecterCdEd = "";                               // �W���S����(�I��)
            }
            else
            {
                extraInfoWork.BillCollecterCdSt = extraInfo.BillCollecterCdSt;      // �W���S����(�J�n)
                extraInfoWork.BillCollecterCdEd = extraInfo.BillCollecterCdEd;      // �W���S����(�I��)
                extraInfoWork.CustomerAgentCdSt = "";                               // �ڋq�S����(�J�n)
                extraInfoWork.CustomerAgentCdEd = "";                               // �ڋq�S����(�I��)
            }

            extraInfoWork.SalesAreaCodeSt = extraInfo.SalesAreaCodeSt;              // �̔��G���A�R�[�h(�J�n)
            extraInfoWork.SalesAreaCodeEd = extraInfo.SalesAreaCodeEd;              // �̔��G���A�R�[�h(�I��)
            
            extraInfoWork.CustomerCodeSt = extraInfo.CustomerCodeSt;                // ���Ӑ�R�[�h(�J�n)
            extraInfoWork.CustomerCodeEd = extraInfo.CustomerCodeEd;                // ���Ӑ�R�[�h(�I��)
            extraInfoWork.EnterpriseCode = extraInfo.EnterpriseCode;                // ��ƃR�[�h
            
            extraInfoWork.SlipPrtKind = extraInfo.SlipPrtKind;                      // �`�[������

            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
            _taxReductionDone = IsTaxReductionDone();
            if (_taxReductionDone)
            {
                // �ŕʓ���󎚋敪
                SetPropertyValue(extraInfoWork, "TaxPrintDiv", (int)GetPropertyValue(extraInfo, "TaxPrintDiv"));
                // �ŗ�1
                SetPropertyValue(extraInfoWork, "TaxRate1", (double)GetPropertyValue(extraInfo, "TaxRate1"));
                // �ŗ�2
                SetPropertyValue(extraInfoWork, "TaxRate2", (double)GetPropertyValue(extraInfo, "TaxRate2"));
            }
            else
            {
                // �ŕʓ���󎚋敪
                SetPropertyValue(extraInfoWork, "TaxPrintDiv", 1);
            }
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
            
            return extraInfoWork;
        }
        
        #endregion

        // ===============================================================================
        // ICompare������
        // ===============================================================================
        #region ICompare �̎�����
        /// <summary>
        /// ���_�R�[�h���בւ��pKEY
        /// </summary>
        class SecInfoKey0 : IComparer
        {
            public int Compare(object x, object y)
            {
                string cx, cy;
                cx = x.ToString();
                cy = y.ToString();

                return cx.CompareTo(cy);
            }
        }
        #endregion

        /// <summary>
        /// �t�B���^�[�p�̌v�Z�㐿�����z��ݒ�
        /// </summary>
        private void SetAfCalDemandPriceFilter()
        {
            for (int i = 0; i < this._custDmdPrcDataTable.Rows.Count; i++)
            {
                // �v�㋒�_�R�[�h�Ƒ������Ӑ�R�[�h�ŃL�[�쐬
                string sectionCd = (string)this._custDmdPrcDataTable.Rows[i][CT_CsDmd_AddUpSecCode];
                string claimCode = ((int)this._custDmdPrcDataTable.Rows[i][CT_CsDmd_SumClaimCustCode]).ToString("d08");
                string key = sectionCd.TrimEnd() + "-" + claimCode;

                // �v�Z�㐿�����z�̎擾
                long afCalDemandPrice = 0;
                if (afCalDemandPriceDic.ContainsKey(key))
                {
                    afCalDemandPrice = afCalDemandPriceDic[key];
                }
                // �v�Z�㐿�����z(�t�B���^�[�p)�ɐݒ�
                this._custDmdPrcDataTable.Rows[i][CT_CsDmd_AfCalDemandPriceFilter] = afCalDemandPrice;
            }
        }

        /// <summary>
        /// �������R�[�h�쐬����
        /// </summary>
        /// <param name="extraInfo">���o����</param>
        /// <remarks>
        /// <br>Note       : �W�v���R�[�h���瑍�����R�[�h���쐬���܂��B</br>
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private void CreateSumDmdRow(SumExtrInfo_DemandTotal extraInfo)
        {
            foreach (int sumClaimCustCode in _sumClaimCustCodeList)
            {
                DataRow newRow = this._custDmdPrcDataTable.NewRow();
                newRow.BeginEdit();

                this._custDmdPrcDataTable.DefaultView.RowFilter = CT_CsDmd_SumClaimCustCode + " = " + sumClaimCustCode.ToString();
                // 2010/03/12 Add �Y���Ȃ��̏ꍇ�̓R���e�B�j���[ >>>
                if (this._custDmdPrcDataTable.DefaultView.Count == 0)
                    continue;
                // 2010/03/12 Add <<<
                for (int i = 0; i < this._custDmdPrcDataTable.DefaultView.Count; i++)
                {
                    DataRow sumClaimCustRow = this._custDmdPrcDataTable.DefaultView[i].Row;

                    if (i == 0)
                    {
                        // �P���R�[�h�ڂ̏W�v���R�[�h�̓��e���R�s�[
                        newRow[CT_CsDmd_DataType] = true;   // ���R�[�h�^�C�v
                        newRow[CT_CsDmd_RecordName] = "�������R�[�h";   // ���R�[�h����
                        newRow[CT_CsDmd_PrintFlag] = true;  // ����t���O
                        newRow[CT_CsDmd_AddUpSecCode] = sumClaimCustRow[CT_CsDmd_AddUpSecCode];     // �v�㋒�_�R�[�h
                        newRow[CT_CsDmd_AddUpSecName] = sumClaimCustRow[CT_CsDmd_AddUpSecName];     // �v�㋒�_����
                        newRow[CT_CsDmd_ClaimSectionCode] = sumClaimCustRow[CT_CsDmd_ClaimSectionCode];     // �������_�R�[�h
                        newRow[CT_CsDmd_ClaimSectionName] = sumClaimCustRow[CT_CsDmd_ClaimSectionName];     // �������_����
                        newRow[CT_CsDmd_ResultsSectCd] = sumClaimCustRow[CT_CsDmd_ResultsSectCd];       // ���ы��_�R�[�h
                        newRow[CT_CsDmd_SumClaimCustCode] = sumClaimCustRow[CT_CsDmd_SumClaimCustCode];     // �������Ӑ�R�[�h
                        newRow[CT_CsDmd_SumClaimCustCodeDisp] = sumClaimCustRow[CT_CsDmd_SumClaimCustCodeDisp];     // �������Ӑ�R�[�h(���o���ʕ\���p)
                        newRow[CT_CsDmd_SumClaimCustSnm] = sumClaimCustRow[CT_CsDmd_SumClaimCustSnm];   // �������Ӑ旪��
                        newRow[CT_CsDmd_ClaimCode] = 0;     // ������R�[�h
                        newRow[CT_CsDmd_ClaimCodeDisp] = "00000000";    // ������R�[�h(���o���ʕ\���p)
                        newRow[CT_CsDmd_ClaimSnm] = string.Empty;       // �����旪��
                        newRow[CT_CsDmd_AddUpDateInt] = sumClaimCustRow[CT_CsDmd_AddUpDateInt];     // �v��N����(Int�^)
                        newRow[CT_CsDmd_CustomerAgentCd] = sumClaimCustRow[CT_CsDmd_CustomerAgentCd];       // �ڋq�S���]�ƈ��R�[�h
                        newRow[CT_CsDmd_CustomerAgentNm] = sumClaimCustRow[CT_CsDmd_CustomerAgentNm];       // �ڋq�S���]�ƈ�����
                        newRow[CT_CsDmd_BillCollecterCd] = sumClaimCustRow[CT_CsDmd_BillCollecterCd];       // �W���S���]�ƈ��R�[�h
                        newRow[CT_CsDmd_BillCollecterNm] = sumClaimCustRow[CT_CsDmd_BillCollecterNm];       // �W���S���]�ƈ�����
                        newRow[CT_CsDmd_SalesAreaCode] = sumClaimCustRow[CT_CsDmd_SalesAreaCode];       // �̔��G���A�R�[�h
                        newRow[CT_CsDmd_SalesAreaName] = sumClaimCustRow[CT_CsDmd_SalesAreaName];       // �̔��G���A����
                        newRow[CT_Blnce_BillOutputCode] = sumClaimCustRow[CT_Blnce_BillOutputCode];     // �������o�͋敪�R�[�h
                        // --- ADD  ���r��  2010/02/01 ---------->>>>>
                        newRow[CT_Blnce_TotalBillOutputDiv] = sumClaimCustRow[CT_Blnce_TotalBillOutputDiv];   //���v�������o�͋敪�R�[�h
                        newRow[CT_Blnce_DetailBillOutputCode] = sumClaimCustRow[CT_Blnce_DetailBillOutputCode];   //���א������o�͋敪�R�[�h
                        newRow[CT_Blnce_SlipTtlBillOutputDiv] = sumClaimCustRow[CT_Blnce_SlipTtlBillOutputDiv];   //�`�[���v�������o�͋敪�R�[�h
                        // --- ADD  ���r��  2010/02/01 ----------<<<<<

                        newRow[CT_CsDmd_DemandBalance] = sumClaimCustRow[CT_CsDmd_DemandBalance];   // �����c��
                        newRow[CT_CsDmd_ThisTimeDmdNrml] = sumClaimCustRow[CT_CsDmd_ThisTimeDmdNrml];   // ����������z�i�ʏ�����j
                        newRow[CT_CsDmd_ThisTimeTtlBlcDmd] = sumClaimCustRow[CT_CsDmd_ThisTimeTtlBlcDmd];   // ����J�z�c���i�����v�j
                        newRow[CT_CsDmd_ThisTimeSales] = sumClaimCustRow[CT_CsDmd_ThisTimeSales];   // ���񔄏���z
                        newRow[CT_CsDmd_ThisSalesPricRgdsDis] = sumClaimCustRow[CT_CsDmd_ThisSalesPricRgdsDis];     // ���񔄏�ԕi�E�l�����z
                        newRow[CT_CsDmd_NetSales] = sumClaimCustRow[CT_CsDmd_NetSales];     // ������z
                        newRow[CT_CsDmd_OfsThisTimeSales] = sumClaimCustRow[CT_CsDmd_OfsThisTimeSales];     // ���E�㍡�񔄏���z
                        newRow[CT_CsDmd_OfsThisSalesTax] = sumClaimCustRow[CT_CsDmd_OfsThisSalesTax];       // ���E�㍡�񔄏�����
                        newRow[CT_CsDmd_OfsThisSalesSum] = sumClaimCustRow[CT_CsDmd_OfsThisSalesSum];       // ���E�㍡�񍇌v������z
                        newRow[CT_CsDmd_AfCalDemandPrice] = sumClaimCustRow[CT_CsDmd_AfCalDemandPrice];     // �v�Z�㐿�����z
                        newRow[CT_CsDmd_CollectDemand] = sumClaimCustRow[CT_CsDmd_CollectDemand];       // ����c��(���v���v�Z�p)
                        newRow[CT_CsDmd_SaleslSlipCount] = sumClaimCustRow[CT_CsDmd_SaleslSlipCount];   // ����`�[����
                        newRow[CT_Blnce_AcpOdrTtl3TmBfBlDmd] = sumClaimCustRow[CT_Blnce_AcpOdrTtl3TmBfBlDmd];   // �󒍂R��O�c��(�O�X�X��)
                        newRow[CT_Blnce_AcpOdrTtl2TmBfBlDmd] = sumClaimCustRow[CT_Blnce_AcpOdrTtl2TmBfBlDmd];   // �󒍂Q��O�c��(�O�X��)
                        newRow[CT_CsDmd_LastTimeDemand] = sumClaimCustRow[CT_CsDmd_LastTimeDemand];     // �O�񐿋��z
                        newRow[CT_Blnce_MoneyKindDiv101] = sumClaimCustRow[CT_Blnce_MoneyKindDiv101];   // ����(����敪)
                        newRow[CT_Blnce_MoneyKindDiv102] = sumClaimCustRow[CT_Blnce_MoneyKindDiv102];   // �U��(����敪)
                        newRow[CT_Blnce_MoneyKindDiv107] = sumClaimCustRow[CT_Blnce_MoneyKindDiv107];   // ���؎�(����敪)
                        newRow[CT_Blnce_MoneyKindDiv105] = sumClaimCustRow[CT_Blnce_MoneyKindDiv105];   // ��`(����敪)
                        newRow[CT_Blnce_MoneyKindDiv106] = sumClaimCustRow[CT_Blnce_MoneyKindDiv106];   // ���E(����敪)
                        newRow[CT_Blnce_MoneyKindDiv112] = sumClaimCustRow[CT_Blnce_MoneyKindDiv112];   // �����U��(����敪)
                        newRow[CT_Blnce_MoneyKindDiv109] = sumClaimCustRow[CT_Blnce_MoneyKindDiv109];   // ���̑�(����敪)
                        newRow[CT_CsDmd_ThisTimeFeeDmdNrml] = sumClaimCustRow[CT_CsDmd_ThisTimeFeeDmdNrml];     // ����萔���z�i�ʏ�����j
                        newRow[CT_CsDmd_ThisTimeDisDmdNrml] = sumClaimCustRow[CT_CsDmd_ThisTimeDisDmdNrml];     // ����l���z(�ʏ����)
                        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
                        // ����z(�v�ŗ�1)
                        newRow[Col_TotalThisTimeSalesTaxRate1] = sumClaimCustRow[Col_TotalThisTimeSalesTaxRate1];
                        // ����z(�v�ŗ�2)
                        newRow[Col_TotalThisTimeSalesTaxRate2] = sumClaimCustRow[Col_TotalThisTimeSalesTaxRate2];
                        // ����z(�v���̑�)
                        newRow[Col_TotalThisTimeSalesOther] = sumClaimCustRow[Col_TotalThisTimeSalesOther];
                        // �ԕi�l��(�v�ŗ�1)
                        newRow[Col_TotalThisRgdsDisPricTaxRate1] = sumClaimCustRow[Col_TotalThisRgdsDisPricTaxRate1];
                        // �ԕi�l��(�v�ŗ�2)
                        newRow[Col_TotalThisRgdsDisPricTaxRate2] = sumClaimCustRow[Col_TotalThisRgdsDisPricTaxRate2];
                        // �ԕi�l��(�v���̑�)
                        newRow[Col_TotalThisRgdsDisPricOther] = sumClaimCustRow[Col_TotalThisRgdsDisPricOther];
                        // ������z(�v�ŗ�1)
                        newRow[Col_TotalPureSalesTaxRate1] = sumClaimCustRow[Col_TotalPureSalesTaxRate1];
                        // ������z(�v�ŗ�2)
                        newRow[Col_TotalPureSalesTaxRate2] = sumClaimCustRow[Col_TotalPureSalesTaxRate2];
                        // ������z(�v���̑�)
                        newRow[Col_TotalPureSalesOther] = sumClaimCustRow[Col_TotalPureSalesOther];
                        // �����(�v�ŗ�1)
                        newRow[Col_TotalSalesPricTaxTaxRate1] = sumClaimCustRow[Col_TotalSalesPricTaxTaxRate1];
                        // �����(�v�ŗ�2)
                        newRow[Col_TotalSalesPricTaxTaxRate2] = sumClaimCustRow[Col_TotalSalesPricTaxTaxRate2];
                        // �����(�v���̑�)
                        newRow[Col_TotalSalesPricTaxOther] = sumClaimCustRow[Col_TotalSalesPricTaxOther];
                        // ���񍇌v(�v�ŗ�1)
                        newRow[Col_TotalThisSalesSumTaxRate1] = sumClaimCustRow[Col_TotalThisSalesSumTaxRate1];
                        // ���񍇌v(�v�ŗ�2)
                        newRow[Col_TotalThisSalesSumTaxRate2] = sumClaimCustRow[Col_TotalThisSalesSumTaxRate2];
                        // ���񍇌v(�v���̑�)
                        newRow[Col_TotalThisSalesSumTaxOther] = sumClaimCustRow[Col_TotalThisSalesSumTaxOther];
                        // ����(�v�ŗ�1)
                        newRow[Col_TotalSalesSlipCountTaxRate1] = sumClaimCustRow[Col_TotalSalesSlipCountTaxRate1];
                        // ����(�v�ŗ�2)
                        newRow[Col_TotalSalesSlipCountTaxRate2] = sumClaimCustRow[Col_TotalSalesSlipCountTaxRate2];
                        // ����(�v���̑�)
                        newRow[Col_TotalSalesSlipCountOther] = sumClaimCustRow[Col_TotalSalesSlipCountOther];
                        // �ŗ�1�^�C�g��
                        newRow[Col_TitleTaxRate1] = sumClaimCustRow[Col_TitleTaxRate1];
                        // �ŗ�2�^�C�g��
                        newRow[Col_TitleTaxRate2] = sumClaimCustRow[Col_TitleTaxRate2];
                        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
                        //--- ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                        // ����z(�v��ې�)
                        newRow[Col_TotalThisTimeSalesTaxFree] = sumClaimCustRow[Col_TotalThisTimeSalesTaxFree];
                        // �ԕi�l��(�v��ې�)
                        newRow[Col_TotalThisRgdsDisPricTaxFree] = sumClaimCustRow[Col_TotalThisRgdsDisPricTaxFree];
                        // ������z(�v��ې�)
                        newRow[Col_TotalPureSalesTaxFree] = sumClaimCustRow[Col_TotalPureSalesTaxFree];
                        // �����(�v��ې�)
                        newRow[Col_TotalSalesPricTaxTaxFree] = sumClaimCustRow[Col_TotalSalesPricTaxTaxFree];
                        // ���񍇌v(�v��ې�)
                        newRow[Col_TotalThisSalesSumTaxFree] = sumClaimCustRow[Col_TotalThisSalesSumTaxFree];
                        // ����(�v��ې�)
                        newRow[Col_TotalSalesSlipCountTaxFree] = sumClaimCustRow[Col_TotalSalesSlipCountTaxFree];
                        //--- ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    }
                    else
                    {
                        // �Q���R�[�h�ڈȍ~�͋��z���W�v
                        newRow[CT_CsDmd_DemandBalance] = (long)newRow[CT_CsDmd_DemandBalance] + (long)sumClaimCustRow[CT_CsDmd_DemandBalance];      // �����c��
                        newRow[CT_CsDmd_ThisTimeDmdNrml] = (long)newRow[CT_CsDmd_ThisTimeDmdNrml] + (long)sumClaimCustRow[CT_CsDmd_ThisTimeDmdNrml];    // ����������z�i�ʏ�����j
                        newRow[CT_CsDmd_ThisTimeTtlBlcDmd] = (long)newRow[CT_CsDmd_ThisTimeTtlBlcDmd] + (long)sumClaimCustRow[CT_CsDmd_ThisTimeTtlBlcDmd];  // ����J�z�c���i�����v�j
                        newRow[CT_CsDmd_ThisTimeSales] = (long)newRow[CT_CsDmd_ThisTimeSales] + (long)sumClaimCustRow[CT_CsDmd_ThisTimeSales];      // ���񔄏���z
                        newRow[CT_CsDmd_ThisSalesPricRgdsDis] = (long)newRow[CT_CsDmd_ThisSalesPricRgdsDis] + (long)sumClaimCustRow[CT_CsDmd_ThisSalesPricRgdsDis];     // ���񔄏�ԕi�E�l�����z
                        newRow[CT_CsDmd_NetSales] = (long)newRow[CT_CsDmd_NetSales] + (long)sumClaimCustRow[CT_CsDmd_NetSales];     // ������z
                        newRow[CT_CsDmd_OfsThisTimeSales] = (long)newRow[CT_CsDmd_OfsThisTimeSales] + (long)sumClaimCustRow[CT_CsDmd_OfsThisTimeSales];     // ���E�㍡�񔄏���z
                        newRow[CT_CsDmd_OfsThisSalesTax] = (long)newRow[CT_CsDmd_OfsThisSalesTax] + (long)sumClaimCustRow[CT_CsDmd_OfsThisSalesTax];        // ���E�㍡�񔄏�����
                        newRow[CT_CsDmd_OfsThisSalesSum] = (long)newRow[CT_CsDmd_OfsThisSalesSum] + (long)sumClaimCustRow[CT_CsDmd_OfsThisSalesSum];        // ���E�㍡�񍇌v������z
                        newRow[CT_CsDmd_AfCalDemandPrice] = (long)newRow[CT_CsDmd_AfCalDemandPrice] + (long)sumClaimCustRow[CT_CsDmd_AfCalDemandPrice];     // �v�Z�㐿�����z
                        newRow[CT_CsDmd_CollectDemand] = (long)newRow[CT_CsDmd_CollectDemand] + (long)sumClaimCustRow[CT_CsDmd_CollectDemand];      // ����c��(���v���v�Z�p)
                        newRow[CT_CsDmd_SaleslSlipCount] = (int)newRow[CT_CsDmd_SaleslSlipCount] + (int)sumClaimCustRow[CT_CsDmd_SaleslSlipCount];      // ����`�[����
                        newRow[CT_Blnce_AcpOdrTtl3TmBfBlDmd] = (long)newRow[CT_Blnce_AcpOdrTtl3TmBfBlDmd] + (long)sumClaimCustRow[CT_Blnce_AcpOdrTtl3TmBfBlDmd];    // �󒍂R��O�c��(�O�X�X��)
                        newRow[CT_Blnce_AcpOdrTtl2TmBfBlDmd] = (long)newRow[CT_Blnce_AcpOdrTtl2TmBfBlDmd] + (long)sumClaimCustRow[CT_Blnce_AcpOdrTtl2TmBfBlDmd];    // �󒍂Q��O�c��(�O�X��)
                        newRow[CT_CsDmd_LastTimeDemand] = (long)newRow[CT_CsDmd_LastTimeDemand] + (long)sumClaimCustRow[CT_CsDmd_LastTimeDemand];       // �O�񐿋��z
                        newRow[CT_Blnce_MoneyKindDiv101] = (long)newRow[CT_Blnce_MoneyKindDiv101] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv101];    // ����(����敪)
                        newRow[CT_Blnce_MoneyKindDiv102] = (long)newRow[CT_Blnce_MoneyKindDiv102] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv102];    // �U��(����敪)
                        newRow[CT_Blnce_MoneyKindDiv107] = (long)newRow[CT_Blnce_MoneyKindDiv107] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv107];    // ���؎�(����敪)
                        newRow[CT_Blnce_MoneyKindDiv105] = (long)newRow[CT_Blnce_MoneyKindDiv105] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv105];    // ��`(����敪)
                        newRow[CT_Blnce_MoneyKindDiv106] = (long)newRow[CT_Blnce_MoneyKindDiv106] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv106];    // ���E(����敪)
                        newRow[CT_Blnce_MoneyKindDiv112] = (long)newRow[CT_Blnce_MoneyKindDiv112] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv112];    // �����U��(����敪)
                        newRow[CT_Blnce_MoneyKindDiv109] = (long)newRow[CT_Blnce_MoneyKindDiv109] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv109];    // ���̑�(����敪)
                        newRow[CT_CsDmd_ThisTimeFeeDmdNrml] = (long)newRow[CT_CsDmd_ThisTimeFeeDmdNrml] + (long)sumClaimCustRow[CT_CsDmd_ThisTimeFeeDmdNrml];   // ����萔���z�i�ʏ�����j
                        newRow[CT_CsDmd_ThisTimeDisDmdNrml] = (long)newRow[CT_CsDmd_ThisTimeDisDmdNrml] + (long)sumClaimCustRow[CT_CsDmd_ThisTimeDisDmdNrml];   // ����l���z(�ʏ����)
                        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
                        // ����z(�v�ŗ�1)
                        newRow[Col_TotalThisTimeSalesTaxRate1] = (long)newRow[Col_TotalThisTimeSalesTaxRate1] + (long)sumClaimCustRow[Col_TotalThisTimeSalesTaxRate1];
                        // ����z(�v�ŗ�2)
                        newRow[Col_TotalThisTimeSalesTaxRate2] = (long)newRow[Col_TotalThisTimeSalesTaxRate2] + (long)sumClaimCustRow[Col_TotalThisTimeSalesTaxRate2];
                        // ����z(�v���̑�)
                        newRow[Col_TotalThisTimeSalesOther] = (long)newRow[Col_TotalThisTimeSalesOther] + (long)sumClaimCustRow[Col_TotalThisTimeSalesOther];
                        // �ԕi�l��(�v�ŗ�1)
                        newRow[Col_TotalThisRgdsDisPricTaxRate1] = (long)newRow[Col_TotalThisRgdsDisPricTaxRate1] + (long)sumClaimCustRow[Col_TotalThisRgdsDisPricTaxRate1];
                        // �ԕi�l��(�v�ŗ�2)
                        newRow[Col_TotalThisRgdsDisPricTaxRate2] = (long)newRow[Col_TotalThisRgdsDisPricTaxRate2] + (long)sumClaimCustRow[Col_TotalThisRgdsDisPricTaxRate2];
                        // �ԕi�l��(�v���̑�)
                        newRow[Col_TotalThisRgdsDisPricOther] = (long)newRow[Col_TotalThisRgdsDisPricOther] + (long)sumClaimCustRow[Col_TotalThisRgdsDisPricOther];
                        // ������z(�v�ŗ�1)
                        newRow[Col_TotalPureSalesTaxRate1] = (long)newRow[Col_TotalPureSalesTaxRate1] + (long)sumClaimCustRow[Col_TotalPureSalesTaxRate1];
                        // ������z(�v�ŗ�2)
                        newRow[Col_TotalPureSalesTaxRate2] = (long)newRow[Col_TotalPureSalesTaxRate2] + (long)sumClaimCustRow[Col_TotalPureSalesTaxRate2];
                        // ������z(�v���̑�)
                        newRow[Col_TotalPureSalesOther] = (long)newRow[Col_TotalPureSalesOther] + (long)sumClaimCustRow[Col_TotalPureSalesOther];
                        // �����(�v�ŗ�1)
                        newRow[Col_TotalSalesPricTaxTaxRate1] = (long)newRow[Col_TotalSalesPricTaxTaxRate1] + (long)sumClaimCustRow[Col_TotalSalesPricTaxTaxRate1];
                        // �����(�v�ŗ�2)
                        newRow[Col_TotalSalesPricTaxTaxRate2] = (long)newRow[Col_TotalSalesPricTaxTaxRate2] + (long)sumClaimCustRow[Col_TotalSalesPricTaxTaxRate2];
                        // �����(�v���̑�)
                        newRow[Col_TotalSalesPricTaxOther] = (long)newRow[Col_TotalSalesPricTaxOther] + (long)sumClaimCustRow[Col_TotalSalesPricTaxOther];
                        // ���񍇌v(�v�ŗ�1)
                        newRow[Col_TotalThisSalesSumTaxRate1] = (long)newRow[Col_TotalThisSalesSumTaxRate1] + (long)sumClaimCustRow[Col_TotalThisSalesSumTaxRate1];
                        // ���񍇌v(�v�ŗ�2)
                        newRow[Col_TotalThisSalesSumTaxRate2] = (long)newRow[Col_TotalThisSalesSumTaxRate2] + (long)sumClaimCustRow[Col_TotalThisSalesSumTaxRate2];
                        // ���񍇌v(�v���̑�)
                        newRow[Col_TotalThisSalesSumTaxOther] = (long)newRow[Col_TotalThisSalesSumTaxOther] + (long)sumClaimCustRow[Col_TotalThisSalesSumTaxOther];
                        // ����(�v�ŗ�1)
                        newRow[Col_TotalSalesSlipCountTaxRate1] = (long)newRow[Col_TotalSalesSlipCountTaxRate1] + (long)sumClaimCustRow[Col_TotalSalesSlipCountTaxRate1];
                        // ����(�v�ŗ�2)
                        newRow[Col_TotalSalesSlipCountTaxRate2] = (long)newRow[Col_TotalSalesSlipCountTaxRate2] + (long)sumClaimCustRow[Col_TotalSalesSlipCountTaxRate2];
                        // ����(�v���̑�)
                        newRow[Col_TotalSalesSlipCountOther] = (long)newRow[Col_TotalSalesSlipCountOther] + (long)sumClaimCustRow[Col_TotalSalesSlipCountOther];
                        // �ŗ�1�^�C�g��
                        newRow[Col_TitleTaxRate1] = sumClaimCustRow[Col_TitleTaxRate1];
                        // �ŗ�2�^�C�g��
                        newRow[Col_TitleTaxRate2] = sumClaimCustRow[Col_TitleTaxRate2];
                        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
                        //--- ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                        // ����z(�v��ې�)
                        newRow[Col_TotalThisTimeSalesTaxFree] = (long)newRow[Col_TotalThisTimeSalesTaxFree] + (long)sumClaimCustRow[Col_TotalThisTimeSalesTaxFree];
                        // �ԕi�l��(�v��ې�)
                        newRow[Col_TotalThisRgdsDisPricTaxFree] = (long)newRow[Col_TotalThisRgdsDisPricTaxFree] + (long)sumClaimCustRow[Col_TotalThisRgdsDisPricTaxFree];
                        // ������z(�v��ې�)
                        newRow[Col_TotalPureSalesTaxFree] = (long)newRow[Col_TotalPureSalesTaxFree] + (long)sumClaimCustRow[Col_TotalPureSalesTaxFree];
                        // �����(�v��ې�)
                        newRow[Col_TotalSalesPricTaxTaxFree] = (long)newRow[Col_TotalSalesPricTaxTaxFree] + (long)sumClaimCustRow[Col_TotalSalesPricTaxTaxFree];
                        // ���񍇌v(�v��ې�)
                        newRow[Col_TotalThisSalesSumTaxFree] = (long)newRow[Col_TotalThisSalesSumTaxFree] + (long)sumClaimCustRow[Col_TotalThisSalesSumTaxFree];
                        // ����(�v��ې�)
                        newRow[Col_TotalSalesSlipCountTaxFree] = (long)newRow[Col_TotalSalesSlipCountTaxFree] + (long)sumClaimCustRow[Col_TotalSalesSlipCountTaxFree];
                        //--- ADD 2022/08/30 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    }
                    // --- ADD  ���r��  2010/02/24 ---------->>>>>
                    // �L���b�V���o�^��KEY����
                    string key = ((string)sumClaimCustRow[CT_CsDmd_AddUpSecCode]).TrimEnd() + "-" + ((int)sumClaimCustRow[CT_CsDmd_SumClaimCustCode]).ToString("d08");
                    // ���z�W�v
                    long afCalDemandPrice;
                    if (afCalDemandPriceDic.ContainsKey(key))
                    {
                        afCalDemandPrice = afCalDemandPriceDic[key] + (long)sumClaimCustRow[CT_CsDmd_AfCalDemandPrice];
                        afCalDemandPriceDic.Remove(key);
                    }
                    else
                    {
                        afCalDemandPrice = (long)sumClaimCustRow[CT_CsDmd_AfCalDemandPrice];
                    }
                    afCalDemandPriceDic.Add(key, afCalDemandPrice);
                    // --- ADD  ���r��  2010/02/24 ----------<<<<<                    
                }

                // ���Ӑ���̎擾�i�W�����敪���́A�W�����j
                CustomerInfo customerInfo;
                int status = GetCustomerInfo((int)newRow[CT_CsDmd_SumClaimCustCode], extraInfo.EnterpriseCode, out customerInfo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    newRow[CT_CsDmd_CollectMoneyName] = customerInfo.CollectMoneyName;// �W�����敪����
                    newRow[CT_CsDmd_CollectMoneyDay] = customerInfo.CollectMoneyDay;// �W����
                    // �W����(����p)
                    if (customerInfo.CollectMoneyDay != 0)
                    {
                        // �����������󎚋敪 = 1(28�`31���͖����ƈ�) ��28���ȍ~�̏ꍇ
                        if (customerInfo.CollectMoneyDay >= 28 && _billPrtSt.BillLastDayPrtDiv == 1)
                        {
                            newRow[CT_CsDmd_CollectMoneyDayNm] = "����";
                        }
                        else
                        {
                            newRow[CT_CsDmd_CollectMoneyDayNm] = String.Format("{0}��", customerInfo.CollectMoneyDay);
                        }
                    }
                    else
                    {
                        newRow[CT_CsDmd_CollectMoneyDayNm] = "";
                    }
                }

                // ��������
                if (_allDefSet.TotalAmountDispWayCd == 0)
                {
                    // ���z�\�����Ȃ��Ŕ���
                    newRow[CT_CsDmd_PrintTtlConsTaxDmd] = ((long)newRow[CT_CsDmd_OfsThisSalesTax]).ToString("#,##0");
                }
                else
                {
                    // ���z�\������ō���
                    newRow[CT_CsDmd_PrintTtlConsTaxDmd] = "(" + ((long)newRow[CT_CsDmd_OfsThisSalesTax]).ToString("#,##0") + ")";
                }

                // ������v�Z
                double collectRate = 0.0;
                if (((long)newRow[CT_CsDmd_CollectDemand] != 0) && ((long)newRow[CT_CsDmd_ThisTimeDmdNrml] != 0))
                {
                    collectRate = double.Parse(newRow[CT_CsDmd_ThisTimeDmdNrml].ToString()) * 100 / double.Parse(newRow[CT_CsDmd_CollectDemand].ToString());
                }
                newRow[CT_CsDmd_CollectRate] = collectRate;

                newRow.EndEdit();

                this._custDmdPrcDataTable.Rows.Add(newRow);
            }

            this._custDmdPrcDataTable.DefaultView.RowFilter = string.Empty;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�̎擾
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerInfo">���Ӑ���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�̏����擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private int GetCustomerInfo(int customerCode, string enterpriseCode, out CustomerInfo customerInfo)
        {
            int status;

            customerInfo = new CustomerInfo();

            try
            {
                status = _customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, customerCode, true, out customerInfo);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    customerInfo = new CustomerInfo();
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�\���̏o�͂��s���܂��B</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "���������s(����)�f�[�^���o����", iMsg, iSt, iButton, iDefButton);
        }

        // 2010/07/01 Add >>>
        /// <summary>
        /// ���̂P�Ɩ��̂Q���������܂��B
        /// </summary>
        /// <param name="name1">���̂P</param>
        /// <param name="name2">���̂Q</param>
        /// <returns></returns>
        private string nameJoin(string name1, string name2)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            int count = sjisEnc.GetByteCount(name1);
            int spaceCount = 0;
            string n1 = "";
            string n2 = "";
            if (count <= 20)
            {
                spaceCount = 20 - count;
                if (sjisEnc.GetByteCount(name2) > 20)
                {
                    n2 = name2.Substring(0, 10);
                }
                else
                {
                    n2 = name2;
                }
                n1 = name1;
                for (; spaceCount > 0; spaceCount--)
                {
                    n1 = n1 + " ";
                }
                return n1 + n2;
            }
            else if (count < 40)
            {
                if (sjisEnc.GetByteCount(name2) > 40 - count)
                {
                    n2 = name2.Substring(0, (40 - count) / 2);
                }
                else
                {
                    n2 = name2;
                }
                return name1 + n2;
            }
            else
            {
                return name1;
            }
        }
        // 2010/07/01 Add <<<

        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
        #region �y���ŗ��Ή��ς�
        /// <summary>
        /// �y���ŗ��Ή����������菈��
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private bool IsTaxReductionDone()
        {
            // �y���ŗ��Ή�������
            bool doneFlag = false;

            // U�N���X
            PMHNB02252UA uiObj = new PMHNB02252UA();
            doneFlag = ContainMember(uiObj, "TaxReductionUIDone");
            if (!doneFlag) return doneFlag;

            // E�N���X
            SumExtrInfo_DemandTotal demandTotal = new SumExtrInfo_DemandTotal();
            doneFlag = ContainProperty(demandTotal, "TaxPrintDiv");
            if (!doneFlag) return doneFlag;

            // D�N���X
            SumExtrInfo_DemandTotalWork demandTotalWork = new SumExtrInfo_DemandTotalWork();
            doneFlag = ContainProperty(demandTotalWork, "TaxPrintDiv");

            return doneFlag;
        }

        /// <summary>
        /// ���[�N�Ƀp�����[�^�����݂��邩���菈��
        /// </summary>
        /// <param name="instance">���[�N�Ώ�</param>
        /// <param name="propertyName">�p�����[�^��</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private bool ContainProperty(object instance, string propertyName)
        {
            // ���[�N�Ƀp�����[�^�����݂��邩�t���O
            bool existFlag = false;

            if (instance != null && !string.IsNullOrEmpty(propertyName))
            {
                PropertyInfo findedPropertyInfo = instance.GetType().GetProperty(propertyName);

                if (findedPropertyInfo != null)
                {
                    existFlag = true;
                }
            }

            return existFlag;
        }

        /// <summary>
        /// �N���X�Ƀ����o�[�����݂��邩���菈��
        /// </summary>
        /// <param name="instance">���[�N�Ώ�</param>
        /// <param name="propertyName">�p�����[�^��</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private bool ContainMember(object instance, string propertyName)
        {
            // ���[�N�Ƀp�����[�^�����݂��邩�t���O
            bool existFlag = false;

            if (instance != null)
            {
                MemberInfo[] findedMemberInfo = instance.GetType().GetMember(propertyName);

                // �ϐ�������ꍇ�A�ŐV�o�W���[���Ƃ���
                if (findedMemberInfo != null && findedMemberInfo.Length > 0)
                {
                    existFlag = true;
                }
            }

            return existFlag;
        }

        /// <summary>
        /// �p�����[�^�l���擾���鏈��
        /// </summary>
        /// <param name="instance">���[�N�Ώ�</param>
        /// <param name="propertyName">�p�����[�^��</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private object GetPropertyValue(object instance, string propertyName)
        {
            // �p�����[�^�ݒ�l
            object propertyValue = null;

            foreach (PropertyInfo p in instance.GetType().GetProperties())
            {
                if (propertyName.Equals(p.Name))
                {
                    propertyValue = p.GetValue(instance, null);
                    break;
                }
            }

            return propertyValue;
        }

        /// <summary>
        /// �p�����[�^�ɃZ�b�g���鏈��
        /// </summary>
        /// <param name="instance">���[�N�Ώ�</param>
        /// <param name="propertyName">�p�����[�^��</param>
        /// <param name="settingValue">�ݒ�l</param>
        /// <remarks>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private void SetPropertyValue(object instance, string propertyName, object settingValue)
        {
            foreach (PropertyInfo p in instance.GetType().GetProperties())
            {
                if (propertyName.Equals(p.Name))
                {
                    p.SetValue(instance, settingValue, null);
                    break;
                }
            }
        }
        #endregion
        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
    }
}
