//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�������[
// �v���O�����T�v   �F�������[�̈�����s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2008/09/04     �C�����e�FPartsman�p�ɏC��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/07     �C�����e�FMantis�y11633�z�̎����o�͋敪�ɂ��������ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/20     �C�����e�FMantis�y13192�z���o��ʂɃ��R�[�h����ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/03     �C�����e�FMantis�y13419�z������͈͎̔w�莞�A�o�͋��z�敪�̕s��Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30531 ��� �r��
// �C����    2010/01/25     �C�����e�FMantis�y14928�z�������o�͋敪�ɂ��������ǉ�
//                                                   ���o���ʂɈ���Ώۂ̓��Ӑ�݂̂�\������悤�C�� 
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F������
// �C����    2011/11/17     �C�����e�FRedmine#7765�̑Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F������
// �C����    2011/11/28     �C�����e�FRedmine#7765�̑Ή�(�ďC��)
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  11170129-00    �쐬�S���F���V��
// �C����    2015/09/17     �C�����e�FRedmine#47028�̐����ꗗ�\Out Of Memory�̑Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  11570208-00    �쐬�S���F���O
// �C����    2020/04/13     �C�����e�FPMKOBETSU-2912 �y���ŗ��̑Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  11800255-00    �쐬�S���F���O
// �C����    2022/08/24     �C�����e�FPMKOBETSU-4225 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
// ---------------------------------------------------------------------//
#define ADD20060410
#define CHG20060418
#define ADD20060425
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
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;
// --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----->>>>>
using System.Reflection;
using Broadleaf.Windows.Forms;
// --- ADD 2020/04/13 ���O �y���ŗ��Ή� -----<<<<<

namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// �������[���o���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������[�ɃA�N�Z�X����N���X�ł��B</br>
    /// <br>Programer  : 980023  �ђJ �k��</br>
    /// <br>Date       : 2007.07.09</br>
    /// <br>Update Note: 20081 �D�c �E�l
    /// <br>           : 2007.10.15 DC.NS�p�ɕύX</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS�Ή�</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date	   : 2008.09.04</br>
    /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/04/13</br>
    /// </remarks>
    public class DemandPrintAcs
    {
        //================================================================================
        //  �O���񋟒萔�Q
        //================================================================================
        #region public constant
        // �V�X�e���敪
        private const int ctSYSTEMDIV_CD = 0;
        // �摜���敪	
        private const int ctIMAGEINFODIV_CODE = 10;  // 10:���Љ摜 20:POS�Ŏg�p����摜

        /// <summary>�������[�f�[�^�Z�b�g��</summary>
        public const string CT_DemandDataSet = "DemandDataSet";
        /// <summary>���Ӑ搿�����z�f�[�^�e�[�u����</summary>
        public const string CT_CustDmdPrcDataTable = "CustDmdPrcDataTable";

        /// <summary>����f�[�^�Z�b�g��</summary>
        public const string CT_SaleDataSet = "SaleDataSet";
        /// <summary>����f�[�^�e�[�u����</summary>
        public const string CT_SaleDataTable = "SaleDataTable";

        /// <summary>�����f�[�^�Z�b�g��</summary>
        public const string CT_DepoDataSet = "DepoDataSet";
        /// <summary>�����f�[�^�e�[�u����</summary>
        public const string CT_DepoDataTable = "DepoDataTable";
        
        // 2008.09.05 30413 ���� �����ύX >>>>>>START
        /// <summary>�S���_�R�[�h</summary>
        //public const string CT_AllSectionCode = "000000";
        public const string CT_AllSectionCode = "00";
        // 2008.09.05 30413 ���� �����ύX <<<<<<END

        //--------------------------------------------------
        //  ���Ӑ搿�����z�J�������
        //--------------------------------------------------
        #region ���Ӑ搿�����z�J�������
        /// <summary>���j�[�NID</summary>
        public const string CT_CsDmd_UniqueID = "UniqueID";

        /// <summary>���R�[�h�^�C�v</summary>
        public const string CT_CsDmd_DataType = "DataType";

        // ADD 2009/04/20 ------>>>
        /// <summary>���R�[�h��</summary>
        public const string CT_CsDmd_RecordName = "RecordName";
        // ADD 2009/04/20 ------<<<

        /// <summary>����t���O</summary>
        public const string CT_CsDmd_PrintFlag = "PrintFlag";

        /// <summary>����p�C���f�b�N�X</summary>
        public const string CT_CsDmd_PrintIndex = "PrintIndex";

        /// <summary>�v�㋒�_�R�[�h</summary>
        public const string CT_CsDmd_AddUpSecCode = "AddUpSecCode";

        /// <summary>�v�㋒�_����</summary>
        public const string CT_CsDmd_AddUpSecName = "AddUpSecName";

        // 2008.09.05 30413 ���� ���ڒǉ� >>>>>>START
        /// <summary>�������_�R�[�h</summary>
        public const string CT_CsDmd_ClaimSectionCode = "ClaimSectionCode";

        /// <summary>�������_����</summary>
        public const string CT_CsDmd_ClaimSectionName = "ClaimSectionName";
        // 2008.09.05 30413 ���� ���ڒǉ� <<<<<<END

        // 2009.01.21 30413 ���� ���ڒǉ� >>>>>>START
        /// <summary>���ы��_�R�[�h</summary>
        public const string CT_CsDmd_ResultsSectCd = "ResultsSectCd";
        // 2009.01.21 30413 ���� ���ڒǉ� <<<<<<END
        
        /// <summary>�������p�^�[���ԍ�</summary>
        public const string CT_CsDmd_DemandPtnNo = "DemandPtnNo";

        /// <summary>�������׏��p�^�[���ԍ�</summary>
        public const string CT_CsDmd_DmdDtlPtnNo = "DmdDtlPtnNo";

        /// <summary>�������E�x�����敪</summary>
        public const string CT_CsDmd_DemandOrPay = "DemandOrPay";

        /// <summary>������R�[�h</summary>
        public const string CT_CsDmd_ClaimCode = "ClaimCode";

        // 2008.11.19 30413 ���� ���o���ʕ\���p >>>>>>START
        /// <summary>������R�[�h(���o���ʕ\���p)</summary>
        public const string CT_CsDmd_ClaimCodeDisp = "ClaimCodeDisp";
        // 2008.11.19 30413 ���� ���o���ʕ\���p <<<<<<END

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

        // 2008.11.19 30413 ���� ���o���ʕ\���p >>>>>>START
        /// <summary>���Ӑ�R�[�h(���o���ʕ\���p)</summary>
        public const string CT_CsDmd_CustomerCodeDisp = "CustomerCodeDisp";

        /// <summary>���Ӑ旪��(���o���ʕ\���p)</summary>
        public const string CT_CsDmd_CustomerSnmDisp = "CustomerSnmDisp";
        // 2008.11.19 30413 ���� ���o���ʕ\���p <<<<<<END
        
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

        // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� >>>>>>START
        /// <summary>�v�Z�㐿�����z(�t�B���^�[�p)</summary>
        public const string CT_CsDmd_AfCalDemandPriceFilter = "AfCalDemandPriceFilter";
        // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� <<<<<<END
            
        /// <summary>����`�[����</summary>
        public const string CT_CsDmd_SaleslSlipCount = "SaleslSlipCount";

        /// <summary>���������s��</summary>
        public const string CT_CsDmd_BillPrintDate = "BillPrintDate";

        /// <summary>���������s��(����p)</summary>
        public const string CT_CsDmd_BillPrintDatePrt = "BillPrintDatePrt";

        /// <summary>�����\���</summary>
        public const string CT_CsDmd_ExpectedDepositDate = "ExpectedDepositDate";

        /// <summary>�����\���(����p)</summary>
        public const string CT_CsDmd_ExpectedDepositDatePrt = "ExpectedDepositDatePrt";

        /// <summary>�������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        public const string CT_CsDmd_CollectCond = "CollectCond";

        /// <summary>����ŗ�</summary>
        public const string CT_CsDmd_ConsTaxRate = "ConsTaxRate";

        /// <summary>�[�������敪</summary>
        public const string CT_CsDmd_FractionProcCd = "FractionProcCd";

        /// <summary>�����X�V���s�N����</summary>
        public const string CT_CsDmd_CAddUpUpdExecDate = "CAddUpUpdExecDate";

        /// <summary>�����X�V���s�N����(����p)</summary>
        public const string CT_CsDmd_CAddUpUpdExecDatePrt = "CAddUpUpdExecDatePrt";

        /// <summary>�����X�V�J�n�N����</summary>
        public const string CT_CsDmd_StartCAddUpUpdDate = "StartCAddUpUpdDate";

        /// <summary>�����X�V�J�n�N����(����p)</summary>
        public const string CT_CsDmd_StartCAddUpUpdDatePrt = "StartCAddUpUpdDatePrt";

        /// <summary>�O������X�V�N����</summary>
        public const string CT_CsDmd_LastCAddUpUpdDate = "LastCAddUpUpdDate";

        /// <summary>�O������X�V�N����(����p)</summary>
        public const string CT_CsDmd_LastCAddUpUpdDatePrt = "LastCAddUpUpdDatePrt";

        /// <summary>�v����t(����p)</summary>
        public const string CT_CsDmd_AddUpADatePrint = "AddUpADatePrint";
        
        /// <summary>�O�񐿋��z(������)</summary>
        public const string CT_CsDmd_ClaimLastTimeDemand = "ClaimLastTimeDemand";

        /// <summary>����������z�i������j</summary>
        public const string CT_CsDmd_ClaimThisTimeDmdNrml = "ClaimThisTimeDmdNrml";

        /// <summary>����J�z�c���i������j</summary>
        public const string CT_CsDmd_ClaimThisTimeTtlBlcDmd = "ClaimThisTimeTtlBlcDmd";

        /// <summary>���񔄏���z�i������j</summary>
        public const string CT_CsDmd_ClaimThisTimeSales = "ClaimThisTimeSales";

        /// <summary>���񔄏�ԕi�E�l�����z�i������j</summary>
        public const string CT_CsDmd_ClaimThisSalesPricRgdsDis = "ClaimThisSalesPricRgdsDis";

        /// <summary>���E�㍡�񔄏���z�i������j</summary>
        public const string CT_CsDmd_ClaimOfsThisTimeSales = "ClaimOfsThisTimeSales";

        /// <summary>���E�㍡�񔄏����Łi������j</summary>
        public const string CT_CsDmd_ClaimOfsThisSalesTax = "ClaimOfsThisSalesTax";

        /// <summary>���E�㍡�񍇌v������z�i������j</summary>
        public const string CT_CsDmd_ClaimOfsThisSalesSum = "ClaimOfsThisSalesSum";

        /// <summary>�v�Z�㐿�����z�i������j</summary>
        public const string CT_CsDmd_ClaimAfCalDemandPrice = "ClaimAfCalDemandPrice";

        /// <summary>����`�[�����i������j</summary>
        public const string CT_CsDmd_ClaimSaleslSlipCount = "ClaimSaleslSlipCount";
        #endregion

        //--------------------------------------------------
        //  ���Ӑ�֘A���
        //--------------------------------------------------
        #region ���Ӑ�֘A���
        /// <summary>����</summary>
        public const string CT_CsDmd_Name = "Name";

        /// <summary>���̂Q</summary>
        public const string CT_CsDmd_Name2 = "Name2";

        /// <summary>����p���Ӑ於�̂P</summary>
        public const string CT_CsDmd_EditCustomerName1 = "EditCustomerName1";

        /// <summary>����p���Ӑ於�̂Q</summary>
        public const string CT_CsDmd_EditCustomerName2 = "EditCustomerName2";

        /// <summary>�J�i</summary>
        public const string CT_CsDmd_Kana = "Kana";

        /// <summary>�X�֔ԍ�</summary>
        public const string CT_CsDmd_PostNo = "PostNo";

        /// <summary>�Z���P�i�s���{���s��S�E�����E���j</summary>
        public const string CT_CsDmd_Address1 = "Address1";

        /// <summary>�Z���Q�i���ځj</summary>
        public const string CT_CsDmd_Address2 = "Address2";

        /// <summary>�Z���R�i�Ԓn�j</summary>
        public const string CT_CsDmd_Address3 = "Address3";

        /// <summary>�Z���S�i�A�p�[�g���́j</summary>
        public const string CT_CsDmd_Address4 = "Address4";

        /// <summary>�ҏW��Z���P�i����p�Z��1�s�ځj</summary>
        public const string CT_CsDmd_EditAddress1 = "EditAddress1";

        /// <summary>�ҏW��Z���Q�i����p�Z��2�s�ځj</summary>
        public const string CT_CsDmd_EditAddress2 = "EditAddress2";

        /// <summary>�ҏW��Z���R�i����p�Z��3�s�ځj</summary>
        public const string CT_CsDmd_EditAddress3 = "EditAddress3";

        /// <summary>�ҏW��Z���P�i���X�g����p�Z��1�s�ځj</summary>
        public const string CT_CsDmd_ListAddress1 = "ListAddress1";

        /// <summary>�ҏW��Z���Q�i���X�g����p�Z��2�s�ځj</summary>
        public const string CT_CsDmd_ListAddress2 = "ListAddress2";

        /// <summary>�ҏW��Z���R�i���X�g����p�Z��3�s�ځj</summary>
        public const string CT_CsDmd_ListAddress3 = "ListAddress3";

        /// <summary>�d�b�ԍ��i����j</summary>
        public const string CT_CsDmd_HomeTelNo = "HomeTelNo";

        /// <summary>�d�b�ԍ��i�Ζ���j</summary>
        public const string CT_CsDmd_OfficeTelNo = "OfficeTelNo";

        /// <summary>�d�b�ԍ��i�g�сj</summary>
        public const string CT_CsDmd_PortableTelNo = "PortableTelNo";

        /// <summary>FAX�ԍ��i����j</summary>
        public const string CT_CsDmd_HomeFaxNo = "HomeFaxNo";

        /// <summary>FAX�ԍ��i�Ζ���j</summary>
        public const string CT_CsDmd_OfficeFaxNo = "OfficeFaxNo";

        /// <summary>�d�b�ԍ��i���̑��j</summary>
        public const string CT_CsDmd_OthersTelNo = "OthersTelNo";

        /// <summary>��A����敪[0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</summary>
        public const string CT_CsDmd_MainContactCode = "MainContactCode";

        /// <summary>��A����^�C�g��</summary>
        public const string CT_CsDmd_MainContactName = "MainContactName";

        /// <summary>��A����d�b�ԍ�</summary>
        public const string CT_CsDmd_MainContactTelNo = "MainContactTelNo";

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

        /// <summary>��U������(����p)</summary>
        public const string CT_CsDmd_CollectMoneyDate = "CollectMoneyDate";

        /// <summary>��x������(����p)</summary>
        public const string CT_CsDmd_PaymentMoneyDate = "PaymentMoneyDate";

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

        /// <summary>�h��</summary>
        public const string CT_CsDmd_HonorificTitle = "HonorificTitle";

        /// <summary>�����R�[�h</summary>
        public const string CT_CsDmd_OutputNameCode = "OutputNameCode";

        /// <summary>��������</summary>
        public const string CT_CsDmd_OutputName = "OutputName";

        /// <summary>���Ӑ敪�̓R�[�h�P</summary>
        public const string CT_CsDmd_CustAnalysCode1 = "CustAnalysCode1";
        /// <summary>���Ӑ敪�̓R�[�h�Q</summary>
        public const string CT_CsDmd_CustAnalysCode2 = "CustAnalysCode2";
        /// <summary>���Ӑ敪�̓R�[�h�R</summary>
        public const string CT_CsDmd_CustAnalysCode3 = "CustAnalysCode3";
        /// <summary>���Ӑ敪�̓R�[�h�S</summary>
        public const string CT_CsDmd_CustAnalysCode4 = "CustAnalysCode4";
        /// <summary>���Ӑ敪�̓R�[�h�T</summary>
        public const string CT_CsDmd_CustAnalysCode5 = "CustAnalysCode5";
        /// <summary>���Ӑ敪�̓R�[�h�U</summary>
        public const string CT_CsDmd_CustAnalysCode6 = "CustAnalysCode6";

        /// <summary>���Ӑ��s1</summary>
        public const string CT_CsDmd_AccountNoInfoTK1 = "AccountNoInfoTK1";
        /// <summary>���Ӑ��s2</summary>
        public const string CT_CsDmd_AccountNoInfoTK2 = "AccountNoInfoTK2";
        /// <summary>���Ӑ��s3</summary>
        public const string CT_CsDmd_AccountNoInfoTK3 = "AccountNoInfoTK3";

        /// <summary>���z�\���敪</summary>
        public const string CT_CsDmd_TotalAmountDispWayCd = "TotalAmountDispWayCd";
        #endregion
        
        //--------------------------------------------------
        //  ���Ж��̏��(����p)
        //--------------------------------------------------
        #region ���Ж��̏��
        /// <summary>����PR��</summary>
        public const string CT_CsDmd_CompanyPr = "CompanyPr";

        /// <summary>���Ж���1</summary>
        public const string CT_CsDmd_CompanyName1 = "CompanyName1";

        /// <summary>���Ж���2</summary>
        public const string CT_CsDmd_CompanyName2 = "CompanyName2";

        /// <summary>�X�֔ԍ�</summary>
        public const string CT_CsDmd_CompanyPostNo = "CompanyPostNo";

        /// <summary>���ЏZ���P�s��(����p)</summary>
        public const string CT_CsDmd_EditCompanyAddress1 = "EditCompanyAddress1";

        /// <summary>���ЏZ���Q�s��(����p)</summary>
        public const string CT_CsDmd_EditCompanyAddress2 = "EditCompanyAddress2";

        /// <summary>���Гd�b�ԍ�1(����p�^�C�g���܂�)</summary>
        public const string CT_CsDmd_EditCompanyTelNo1 = "EditCompanyTelNo1";

        /// <summary>���Гd�b�ԍ�2(����p�^�C�g���܂�)</summary>
        public const string CT_CsDmd_EditCompanyTelNo2 = "EditCompanyTelNo2";

        /// <summary>���Гd�b�ԍ�3(����p�^�C�g���܂�)</summary>
        public const string CT_CsDmd_EditCompanyTelNo3 = "EditCompanyTelNo3";

        /// <summary>��s�U���ē���</summary>
        public const string CT_CsDmd_TransferGuidance = "TransferGuidance";

        /// <summary>��s����1</summary>
        public const string CT_CsDmd_AccountNoInfo1 = "AccountNoInfo1";

        /// <summary>��s����2</summary>
        public const string CT_CsDmd_AccountNoInfo2 = "AccountNoInfo2";

        /// <summary>��s����3</summary>
        public const string CT_CsDmd_AccountNoInfo3 = "AccountNoInfo3";

        /// <summary>���Ѓv���e�N�g1</summary>
        public const string CT_CsDmd_CompanyProt1 = "CompanyProt1";

        /// <summary>���Ѓv���e�N�g2</summary>
        public const string CT_CsDmd_CompanyProt2 = "CompanyProt2";

        /// <summary>�����ݒ�E�v1</summary>
        public const string CT_CsDmd_CompanySetNote1 = "CompanySetNote1";

        /// <summary>�����ݒ�E�v2</summary>
        public const string CT_CsDmd_CompanySetNote2 = "CompanySetNote2";

        /// <summary>���Љ摜</summary>
        public const string CT_CsDmd_CampImgID = "CampImg";

        /// <summary>�摜�R�����g�P</summary>
        public const string CT_CsDmd_ImageCommentForPrt1 = "ImageCommentForPrt1";
        /// <summary>�摜�R�����g�Q</summary>
        public const string CT_CsDmd_ImageCommentForPrt2 = "ImageCommentForPrt2";
        #endregion
        
        //--------------------------------------------------
        //  ���̑�����(����p)
        //--------------------------------------------------
        #region ���̑�����(����p)
        /// <summary>���s�N����</summary>
        public const string CT_CsDmd_Publication = "Publication";

        /// <summary>�����N����</summary>
        public const string CT_CsDmd_TargetAddUpDate = "TargetAddUpDate";

        /// <summary>������</summary>
        public const string CT_CsDmd_TargetAddUpMonth = "TargetAddUpMonth";

        /// <summary>�������z</summary>
        public const string CT_CsDmd_PrintAfCalDemandPrice = "PrintAfCalDemandPrice";

        /// <summary>��������</summary>
        public const string CT_CsDmd_PrintTtlConsTaxDmd = "PrintTtlConsTaxDmd";

        /// <summary>��s1</summary>
        public const string CT_CsDmd_AccountNoInfoDsp1 = "AccountNoInfoDsp1";

        /// <summary>��s2</summary>
        public const string CT_CsDmd_AccountNoInfoDsp2 = "AccountNoInfoDsp2";

        /// <summary>��s3</summary>
        public const string CT_CsDmd_AccountNoInfoDsp3 = "AccountNoInfoDsp3";
        #endregion
        
        // 2008.09.08 30413 ���� ���ڒǉ� >>>>>>START
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
        // 2008.09.08 30413 ���� ���ڒǉ� <<<<<<END

        // --- DEL  ���r��  2010/01/25 ---------->>>>>
        // 2009.01.23 30413 ���� �������o�͋敪��ǉ� >>>>>>START
        /// <summary>�������o�͋敪�R�[�h</summary>
        //public const string CT_Blnce_BillOutputCode = "BillOutputCode";
        // 2009.01.23 30413 ���� �������o�͋敪��ǉ� <<<<<<END
        // --- DEL  ���r��  2010/01/25 ----------<<<<<

        /// <summary>�̎����o�͋敪�R�[�h</summary>
        public const string CT_Blnce_ReceiptOutputCode = "ReceiptOutputCode";       // ADD 2009/04/07
        
        // --- ADD  ���r��  2010/01/25 ---------->>>>>
        /// <summary>���v�������o�͋敪�R�[�h</summary>
        public const string CT_Blnce_TotalBillOutputDiv = "TotalBillOutputDiv";
        /// <summary>���א������o�͋敪�R�[�h</summary>
        public const string CT_Blnce_DetailBillOutputCode = "DetailBillOutputCode";
        /// <summary>�`�[���v�������o�͋敪�R�[�h</summary>
        public const string CT_Blnce_SlipTtlBillOutputDiv = "SlipTtlBillOutputDiv";
        // --- ADD  ���r��  2010/01/25 ----------<<<<<

        ////--------------------------------------------------
        ////  ���׍���
        ////--------------------------------------------------
        #region ����E�������׃J�������(�������׈���p)
        /// <summary>������R�[�h</summary>
        public const string CT_SaleDepo_ClaimCode = "ClaimCode";

        /// <summary>�����於</summary>
        public const string CT_SaleDepo_ClaimName = "ClaimName";

        /// <summary>�����於2</summary>
        public const string CT_SaleDepo_ClaimName2 = "ClaimName2";

        /// <summary>�����旪��</summary>
        public const string CT_SaleDepo_ClaimSnm = "ClaimSnm";

        /// <summary>���Ӑ�R�[�h</summary>
        public const string CT_SaleDepo_CustomerCode = "CustomerCode";

        /// <summary>���Ӑ於</summary>
        public const string CT_SaleDepo_CustomerName = "CustomerName";

        /// <summary>���Ӑ於2</summary>
        public const string CT_SaleDepo_CustomerName2 = "CustomerName2";

        /// <summary>���Ӑ旪��</summary>
        public const string CT_SaleDepo_CustomerSnm = "CustomerSnm";

        // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
        ///// <summary>�ԓ`�敪(0:��,1:��,2���E�ςݍ�)</summary>
        //public const string CT_SaleDepo_DebitNoteDiv = "DebitNoteDiv";
        // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
        
        /// <summary>�v����t</summary>
        public const string CT_SaleDepo_AddUpADate = "AddUpADate";

        /// <summary>�v����t(�\���p)</summary>
        public const string CT_SaleDepo_AddUpADateDisp = "AddUpADateDisp";

        /// <summary>�f�[�^���̓V�X�e��</summary>
        public const string CT_SaleDepo_DataInputSystem = "DataInputSystem";

        /// <summary>�`�[�ԍ��E�����ԍ�</summary>                
        public const string CT_SaleDepo_SalesSlipNum = "SalesSlipNum";

        /// <summary>����`�[�敪</summary>                
        public const string CT_SaleDepo_SalesSlipCd = "SalesSlipCd";

        /// <summary>���|�敪</summary>
        public const string CT_SaleDepo_AccRecDivCd = "AccRecDivCd";

        /// <summary>�����`�[�ԍ�</summary>                
        public const string CT_SaleDepo_PartySaleSlipNum = "PartySaleSlipNum";

        // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
        ///// <summary>�ԍ��A���󒍔ԍ�</summary>                
        //public const string CT_SaleDepo_DebitNLnkAcptAnOdr = "DebitNLnkAcptAnOdr";
        // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
        
        /// <summary>����`�[���v�i�ō��݁j</summary>                
        public const string CT_SaleDepo_SalesTotalTaxInc = "SalesTotalTaxInc";

        /// <summary>����`�[���v�i�Ŕ����j</summary>                
        public const string CT_SaleDepo_SalesTotalTaxExc = "SalesTotalTaxExc";

        /// <summary>����`�[����Ŋz</summary>                
        public const string CT_SaleDepo_SalesTotalTax = "SalesTotalTax";

        /// <summary>�`�[���l</summary>                
        public const string CT_SaleDepo_SlipNote = "SlipNote";

        /// <summary>�`�[���l�Q</summary>                
        public const string CT_SaleDepo_SlipNote2 = "SlipNote2";

        /// <summary>����s�ԍ�</summary>
        public const string CT_SaleDepo_SalesRowNo = "SalesRowNo";

        /// <summary>����`�[�敪�i���ׁj</summary>
        public const string CT_SaleDepo_SalesSlipCdDtl = "SalesSlipCdDtl";

        /// <summary>�󒍔ԍ�</summary>
        public const string CT_SaleDepo_AcceptAnOrderNo = "AcceptAnOrderNo";

        /// <summary>���i���[�J�[�R�[�h</summary>
        public const string CT_SaleDepo_GoodsMakerCd = "GoodsMakerCd";

        /// <summary>���[�J�[����</summary>
        public const string CT_SaleDepo_MakerName = "MakerName";

        /// <summary>���i�ԍ�</summary>
        public const string CT_SaleDepo_GoodsNo = "GoodsNo";

        /// <summary>���i��</summary>
        public const string CT_SaleDepo_GoodsName = "GoodsName";

        // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
        ///// <summary>���i�敪�R�[�h</summary>
        //public const string CT_SaleDepo_MediumGoodsGanreCode = "MediumGoodsGanreCode";

        ///// <summary>���i�敪��</summary>
        //public const string CT_SaleDepo_MediumGoodsGanreName = "MediumGoodsGanreName";

        ///// <summary>���i�敪�O���[�v�R�[�h</summary>
        //public const string CT_SaleDepo_LargeGoodsGanreCode = "LargeGoodsGanreCode";

        ///// <summary>���i�敪�O���[�v��</summary>
        //public const string CT_SaleDepo_LargeGoodsGanreName = "LargeGoodsGanreName";

        ///// <summary>���i�敪�ڍ׃R�[�h</summary>
        //public const string CT_SaleDepo_DetailGoodsGanreCode = "DetailGoodsGanreCode";

        ///// <summary>���i�敪�ڍז���</summary>
        //public const string CT_SaleDepo_DetailGoodsGanreName = "DetailGoodsGanreName";
        // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<<END
        
        /// <summary>BL���i�R�[�h</summary>
        public const string CT_SaleDepo_BLGoodsCode = "BLGoodsCode";

        /// <summary>BL���i�R�[�h����</summary>
        public const string CT_SaleDepo_BLGoodsFullName = "BLGoodsFullName";

        // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
        ///// <summary>���Е��ރR�[�h</summary>
        //public const string CT_SaleDepo_EnterpriseGanreCode = "EnterpriseGanreCode";

        ///// <summary>���Е��ޖ���</summary>
        //public const string CT_SaleDepo_EnterpriseGanreName = "EnterpriseGanreName";

        ///// <summary>�P�ʃR�[�h</summary>
        //public const string CT_SaleDepo_UnitCode = "UnitCode";

        ///// <summary>�P�ʖ���</summary>
        //public const string CT_SaleDepo_UnitName = "UnitName";
        // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
        
        /// <summary>����P���i�ō��C�����j</summary>
        public const string CT_SaleDepo_SalesUnPrcTaxIncFl = "SalesUnPrcTaxIncFl";

        /// <summary>����P���i�Ŕ��C�����j</summary>
        public const string CT_SaleDepo_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";

        /// <summary>�o�א�</summary>
        public const string CT_SaleDepo_ShipmentCnt = "ShipmentCnt";

        /// <summary>������z�i�ō��݁j</summary>
        public const string CT_SaleDepo_SalesMoneyTaxInc = "SalesMoneyTaxInc";

        /// <summary>������z�i�Ŕ����j</summary>
        public const string CT_SaleDepo_SalesMoneyTaxExc = "SalesMoneyTaxExc";

        /// <summary>������z�i�Ŕ��� ����p�j</summary>
        public const string CT_SaleDepo_SalesMoneyTaxExc1 = "SalesMoneyTaxExc1";

        // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
        ///// <summary>����Œ����z</summary>
        //public const string CT_SaleDepo_TaxAdjust = "TaxAdjust";

        ///// <summary>�c�������z</summary>
        //public const string CT_SaleDepo_BalanceAdjust = "BalanceAdjust";
        // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            
        /// <summary>�ېŋ敪</summary>
        public const string CT_SaleDepo_TaxationDivCd = "TaxationDivCd";

        /// <summary>�����`�[�ԍ��i���ׁj</summary>
        public const string CT_SaleDepo_PartySlipNumDtl = "PartySlipNumDtl";

        /// <summary>���ה��l</summary>
        public const string CT_SaleDepo_DtlNote = "DtlNote";

        /// <summary>�`�[�����P</summary>
        public const string CT_SaleDepo_SlipMemo1 = "SlipMemo1";

        /// <summary>�`�[�����Q</summary>
        public const string CT_SaleDepo_SlipMemo2 = "SlipMemo2";

        /// <summary>�`�[�����R</summary>
        public const string CT_SaleDepo_SlipMemo3 = "SlipMemo3";

        // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
        ///// <summary>�`�[�����S</summary>
        //public const string CT_SaleDepo_SlipMemo4 = "SlipMemo4";

        ///// <summary>�`�[�����T</summary>
        //public const string CT_SaleDepo_SlipMemo5 = "SlipMemo5";

        ///// <summary>�`�[�����U</summary>
        //public const string CT_SaleDepo_SlipMemo6 = "SlipMemo6";

        ///// <summary>����p���i�ԍ�</summary>
        //public const string CT_SaleDepo_PrtGoodsNo = "PrtGoodsNo";

        ///// <summary>����p���i����</summary>
        //public const string CT_SaleDepo_PrtGoodsName = "PrtGoodsName";

        ///// <summary>����p���i���[�J�[�R�[�h</summary>
        //public const string CT_SaleDepo_PrtGoodsMakerCd = "PrtGoodsMakerCd";

        ///// <summary>����p���i���[�J�[����</summary>
        //public const string CT_SaleDepo_PrtGoodsMakerNm = "PrtGoodsMakerNm";
        // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            
        /// <summary>�v�㋒�_�R�[�h</summary>
        public const string CT_SaleDepo_AddUpSecCode = "AddUpSecCode";

        /// <summary>�v�㋒�_����</summary>
        public const string CT_SaleDepo_AddUpSecName = "AddUpSecName";

        //--------------------------------------------------
        //  ���׍���(�����p)
        //--------------------------------------------------
        /// <summary>�ԍ������A���ԍ�</summary>
        public const string CT_SaleDepo_DebitNoteLinkDepoNo = "DebitNoteLinkDepoNo";

        /// <summary>�����`�[�ԍ�</summary>
        public const string CT_SaleDepo_DepositSlipNo = "DepositSlipNo";

        /// <summary>��������R�[�h</summary>              
        public const string CT_SaleDepo_DepositKindCode = "DepositKindCode";

        /// <summary>�������햼��</summary>                
        public const string CT_SaleDepo_DepositKindName = "DepositKindName";

        /// <summary>�����v</summary>
        public const string CT_SaleDepo_DepositTotal = "DepositTotal";

        /// <summary>�`�[�E�v</summary>
        public const string CT_SaleDepo_Outline = "Outline";

        /// <summary>��`���</summary>
        public const string CT_SaleDepo_DraftKind = "DraftKind";

        /// <summary>��`��ޖ���</summary>
        public const string CT_SaleDepo_DraftKindName = "DraftKindName";

        /// <summary>��`�敪</summary>
        public const string CT_SaleDepo_DraftDivide = "DraftDivide";

        /// <summary>��`�敪����</summary>
        public const string CT_SaleDepo_DraftDivideName = "DraftDivideName";

        /// <summary>��`�ԍ�</summary>
        public const string CT_SaleDepo_DraftNo = "DraftNo";

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
        //--- ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
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
        //--- ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<

        #endregion
        #endregion

        //================================================================================
        //  �v���C�x�[�g�ϐ�
        //================================================================================
        #region private member
        /// <summary>�����ꗗ�f�[�^�����[�g�I�u�W�F�N�g</summary>
        private static IBillTableDB _iBillTableDB = null;

        /// <summary>�������׃f�[�^�����[�g�I�u�W�F�N�g</summary>
        private static IBillDetailTableDB _iBillDetailTableDB = null;
        
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

        /// <summary>�ϊ��O�Z���f�[�^�N���X</summary>
        private BeforeConvertAddressParam _beforeConvertAddressParam;
        /// <summary>�ϊ���Z���f�[�^�N���X</summary>
        private AfterConvertAddressParam _afterConvertAddressParam;

        // ���Љ摜�C���[�W
        private Image _CampImage = null;
        // �摜�Ǘ��f�[�^�N���X
        private ImageInfo _imageInfo = new ImageInfo();
        // �摜�Ǘ��A�N�Z�X�N���X
        private ImageInfoAcs _imageInfoAcs = new ImageInfoAcs();

        // 2009.01.21 30413 ���� �v�Z�㐿�����z�̃L���b�V����ǉ� >>>>>>START
        // �v�Z�㐿�����z�̃L���b�V��
        private Dictionary<string, long> afCalDemandPriceDic;
        // 2009.01.21 30413 ���� �v�Z�㐿�����z�̃L���b�V����ǉ� <<<<<<END

        // 2009.02.02 30413 ���� ������v�Z�̎d�l�ύX >>>>>>START
        private int _endDays = 0;       // �����̌���
        // 2009.02.02 30413 ���� ������v�Z�̎d�l�ύX <<<<<<END

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
        /// �������[���o���A�N�Z�X�N���X�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������[���o���A�N�Z�X�N���X�̐V�����C���X�^���X���쐬���܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        public DemandPrintAcs()
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
        /// �������[���o���A�N�Z�X�N���X�ÓI�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������[���o���A�N�Z�X�N���X�̐V�����C���X�^���X���쐬���܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        static DemandPrintAcs()
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

            sectionTable = new Hashtable();
            secCodeList = new ArrayList();

            // �����ꗗ�f�[�^�����[�g�I�u�W�F�N�g �C���X�^���X��
            _iBillTableDB = (IBillTableDB)MediationBillTableDB.GetBillTableDB();

            // �������׃f�[�^�����[�g�I�u�W�F�N�g �C���X�^���X��
            _iBillDetailTableDB = (IBillDetailTableDB)MediationBillDetailTableDB.GetBillDetailTableDB();

        }
        #endregion

        //================================================================================
        //  �O���񋟊֐�
        //================================================================================
        #region public methods
        /// <summary>
        /// �������f�[�^����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�f�[�^�����������܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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

            // 2009.01.21 30413 ���� �v�Z�㐿�����z�̃L���b�V����ǉ� >>>>>>START
            afCalDemandPriceDic = new Dictionary<string, long>();
            // 2009.01.21 30413 ���� �v�Z�㐿�����z�̃L���b�V����ǉ� <<<<<<END
        }

        /// <summary>
        /// ��������ݒ�f�[�^�Ǎ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : �����f�[�^�̓Ǎ����s���܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public int ReadAllDefSet(out AllDefSet allDefSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            allDefSet = null;
            message = "";
            AllDefSet allDefSetZero = null;
            try
            {
                string sectionCode = "";

                if (LoginInfoAcquisition.Employee != null)
                {
                    sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                }

                // 2008.09.08 30413 ���� Read���\�b�h�����삵�Ȃ����߁A���\�b�h��ύX >>>>>>START
                //status = mAllDefSetAcs.Read(out allDefSet, LoginInfoAcquisition.EnterpriseCode, sectionCode);
                ArrayList retList = new ArrayList();
                status = mAllDefSetAcs.Search(out retList, LoginInfoAcquisition.EnterpriseCode);
                // 2008.09.08 30413 ���� Read���\�b�h�����삵�Ȃ����߁A���\�b�h��ύX <<<<<<END
                
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // 2008.09.05 30413 ���� Read���\�b�h�����삵�Ȃ����߁A���\�b�h��ύX >>>>>>START
                        foreach (AllDefSet workAllDefSet in retList)
                        {
                            if (workAllDefSet.SectionCode == sectionCode)
                            {
                                // ���ꋒ�_
                                allDefSet = workAllDefSet.Clone();
                                break;
                            }
                            // --- ADD  ���r��  2010/01/25 ---------->>>>>
                            if (workAllDefSet.SectionCode.Trim() == "00")
                            {
                                //���ꋒ�_���Ȃ��ꍇ�͑S�Аݒ������Ă���
                                allDefSetZero = workAllDefSet;
                            }
                            // --- ADD  ���r��  2010/01/25 ----------<<<<<

                        }
                        if (allDefSet == null)
                        {
                            // --- UPD  ���r��  2010/01/25 ---------->>>>>
                            // ���ꋒ�_�������ꍇ�̓G���[                                
                            //allDefSet = new AllDefSet();
                            //message = "�S�̏����l�ݒ肪�ݒ肳��Ă��܂���B";
                            allDefSet = allDefSetZero;
                            // --- UPD  ���r��  2010/01/25 ----------<<<<<
                        }
                        // 2008.09.05 30413 ���� Read���\�b�h�����삵�Ȃ����߁A���\�b�h��ύX <<<<<<END
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
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public int GetOwnSeCtrlCode(string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode)
        {
            // �Ώې��䋒�_�̏����l�͎����_
            ctrlSectionCode = sectionCode;

            SecInfoSet secInfoSet;

            // 2008.09.05 30413 ���� �����ύX >>>>>>START
            //int status = mSecInfoAcs.GetSecInfo(sectionCode, ctrlFuncCode, out secInfoSet);
            int status = mSecInfoAcs.GetSecInfo(sectionCode, out secInfoSet);
            // 2008.09.05 30413 ���� �����ύX <<<<<<END
                
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
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Y�����_�̎��Ж��̏��̎擾���s���܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// ���Ӑ搿�����z�擾
        /// </summary>
        /// <param name="extraInfo">���������o�����f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : �����ꗗ���𒊏o���܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public int ReadCustDmd(ExtrInfo_DemandTotal extraInfo, out string message)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // DataSet������
            this.InitializeDemandData();

            string enterpriseCode = extraInfo.EnterpriseCode;
            string addUpSecCode = extraInfo.ResultsAddUpSecList[0].ToString();
            int customerCode = extraInfo.CustomerCodeSt;
            // 2008.09.08 30413 ���� ������ύX >>>>>>START
            //int targetDate = extraInfo.TargetAddUpDate;
            DateTime addUpDate = extraInfo.AddUpDate;
            // 2008.09.08 30413 ���� ������ύX <<<<<<END
            
            RsltInfo_DemandTotalWork csdmd;
            csdmd = new RsltInfo_DemandTotalWork();

            status = 0;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    DataRow row = CustDmdPrcWorkToDataRow(extraInfo, csdmd);
                    this._custDmdPrcDataTable.Rows.Add(row);

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    message = "���Ӑ搿�����z���̎擾�Ɏ��s���܂���";
                    break;
            }

            return status;
        }

        /// <summary>
        /// �����ꗗ���o����
        /// </summary>
        /// <param name="extraInfo">���������o�����f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : �����ꗗ���𒊏o���܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public int SearchDemandList(ExtrInfo_DemandTotal extraInfo, out string message, out string errDspMsg)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errDspMsg = "";

            try
            {
                // DataSet������
                this.InitializeDemandData();

                ArrayList arCustDmdPrcBef = new ArrayList();
                ArrayList arCustDmdPrcAft = new ArrayList();
                Dictionary<int, DmdPrtPtn> dmdPrtPtnKeyList = new Dictionary<int, DmdPrtPtn>();
                ArrayList dmdPrtPtnParamList = new ArrayList();
                Dictionary<int, string> errDmdGrpSumCustomerList = new Dictionary<int, string>();
                Dictionary<int, string> errDmdDtlCustomerList = new Dictionary<int, string>();

                // 2008.09.08 30413 ���� �폜���� >>>>>>START
                //int startTotalDay = extraInfo.TotalDay;
                //int endTotalDay = extraInfo.TotalDay;
                // 2008.09.08 30413 ���� �폜���� <<<<<<END
            
                // 2008.09.05 30413 ���� �폜���� >>>>>>START
                //// ���Ӑ����28�`31���S�Ċ܂߂�
                //if (startTotalDay >= 28 && extraInfo.IsLastDay)
                //{
                //    startTotalDay = 28;
                //    endTotalDay = 31;
                //}
                // 2008.09.05 30413 ���� �폜���� <<<<<<END
                
                ExtrInfo_DemandTotalWork extraInfoWork = new ExtrInfo_DemandTotalWork();
                extraInfoWork = this.CopyToExtraInfoWorkFromExtraInfo(extraInfo);

                object paraObj = null;
                object retObj = null;
                object paraAddObj = null;
                object retAddObj = null;

                paraObj = (object)extraInfoWork;

                status = _iBillTableDB.SearchBillTable(out retObj, paraObj);
                 
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            arCustDmdPrcBef = retObj as ArrayList;
                            // 2008.09.05 30413 ���� �폜���� >>>>>>START
                            //DmdPrtPtn dmdPrtPtn;

                            //foreach (RsltInfo_DemandTotalWork csdmd in arCustDmdPrcBef)
                            //{
                            //    if (dmdPrtPtnKeyList.ContainsKey(csdmd.DemandPtnNo) == false)
                            //    {
                            //        // ����������p�^�[���擾
                            //        this.GetDmdPrtPtn(csdmd.DemandPtnNo, out dmdPrtPtn);
                            //        // �擾�ς݃p�^�[���̃��X�g�ɒǉ�
                            //        dmdPrtPtnKeyList.Add(csdmd.DemandPtnNo, dmdPrtPtn);
                            //    }
                            //}
                            // 2008.09.05 30413 ���� �폜���� <<<<<<END

                            // 2009.02.02 30413 ���� �����̌������擾 >>>>>>START
                            _endDays = DateTime.DaysInMonth(extraInfo.AddUpDate.Year, extraInfo.AddUpDate.Month);
                            // 2009.02.02 30413 ���� �����̌������擾 <<<<<<END
        
                            // --- ADD  ���r��  2010/01/25 ---------->>>>>
                            //retAddObj  = retObj;                            
                            retAddObj = (retObj as CustomSerializeArrayList)[0];
                            // --- ADD  ���r��  2010/01/25 ----------<<<<<
                            
                            paraAddObj = (object)dmdPrtPtnParamList;

                            arCustDmdPrcAft = retAddObj as ArrayList;

                            // --- ADD  ���r��  2010/01/25 ---------->>>>>
                            object AllDefSetObj = null;
                            AllDefSetObj = (retObj as CustomSerializeArrayList)[1];
                            ReadAllDefSetWork(AllDefSetObj as ArrayList);

                            paraAddObj = (object)dmdPrtPtnParamList;

                            arCustDmdPrcAft = retAddObj as ArrayList;
                            // --- ADD  ���r��  2010/01/25 ----------<<<<<

                            // �������zDataTable�쐬     
                            foreach (RsltInfo_DemandTotalWork csdmd in arCustDmdPrcAft)                                               
                            {
                                // 2008.09.05 30413 ���� �폜���� >>>>>>START
                                //// ����������p�^�[���̎擾�ł��Ȃ����̂͏o�͂��Ȃ�(���b�Z�[�W�_�C�A���O�\��)
                                //if (csdmd.DemandPtnNo == 0)
                                //{
                                //    errDmdGrpSumCustomerList.Add(csdmd.CustomerCode, csdmd.CustomerName);
                                //    continue;
                                //}

                                //// �������׏�����p�^�[���̎擾�ł��Ȃ����̂͏o�͂��Ȃ�(���b�Z�[�W�_�C�A���O�\��)
                                //if (csdmd.DmdDtlPtnNo == 0)
                                //{
                                //    errDmdDtlCustomerList.Add(csdmd.CustomerCode, csdmd.CustomerName);
                                //    continue;
                                //}
                                // 2008.09.05 30413 ���� �폜���� <<<<<<END

                                DataRow row = CustDmdPrcWorkToDataRow(extraInfo, csdmd);

                                // 2009.01.19 30413 ���� �e���Ӑ����̏�����ǉ� >>>>>>START
                                //this._custDmdPrcDataTable.Rows.Add(row);
                                if (row != null)
                                {
                                    // �e���Ӑ����̏�����null���Ԃ��Ă���
                                    this._custDmdPrcDataTable.Rows.Add(row);
                                }
                                // 2009.01.19 30413 ���� �e���Ӑ����̏�����ǉ� <<<<<<END
                            }

                             

                            // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� >>>>>>START
                            // �t�B���^�[�p�̌v�Z�㐿�����z��ݒ�
                            SetAfCalDemandPriceFilter();
                            // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� <<<<<<END
                            
                            // ����������p�^�[���擾�s�\�G���[���b�Z�[�W
                            if (errDmdGrpSumCustomerList.Count > 0)
                            {
                                errDspMsg = "�ȉ��̐�����͐���������p�^�[���̐ݒ肪�s���Ă��Ȃ����ߏo�͂�������܂��B";
                                foreach (KeyValuePair<int, string> errInfo in errDmdGrpSumCustomerList)
                                {
                                    errDspMsg = errDspMsg + "\n";
                                    errDspMsg = errDspMsg + errInfo.Key + " , " + errInfo.Value;
                                }
                            }

                            // �������׏�����p�^�[���擾�s�\�G���[���b�Z�[�W
                            if (errDmdDtlCustomerList.Count > 0)
                            {
                                if (errDspMsg == "")
                                {
                                    errDspMsg = errDspMsg + "\n\n";
                                }
                                errDspMsg = "�ȉ��̐�����͐������׏�����p�^�[���̐ݒ肪�s���Ă��Ȃ����ߏo�͂�������܂��B";
                                foreach (KeyValuePair<int, string> errInfo in errDmdDtlCustomerList)
                                {
                                    errDspMsg = errDspMsg + "\n";
                                    errDspMsg = errDspMsg + errInfo.Key + " , " + errInfo.Value;
                                }
                            }

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


        // --- ADD  ���r��  2010/01/25 ---------->>>>>
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
                    // ���ꋒ�_
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
                //// ���ꋒ�_�������ꍇ�̓G���[                                
                //allDefSet = new AllDefSet();
                //message = "�S�̏����l�ݒ肪�ݒ肳��Ă��܂���B";
                //foreach (AllDefSetWork workAllDefSet in arrayList)
                //{
                //    if (workAllDefSet.SectionCode.Trim() == "00")
                //    {
                //        // ���ꋒ�_
                //        allDefSetWork = workAllDefSet;
                //        break;
                //    }
                //}
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
        // --- ADD  ���r��  2010/01/25 ----------<<<<<

        #region ����E�������ג��o����
        /// <summary>
        /// ����E�������ג��o����
        /// </summary>
        /// <param name="ds">���oDataSet</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="seikingetDetailParamList">����KINGET�p�����[�^���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : ����E�������׏��𒊏o���܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public int SearchSaleDepoDetail(out DataSet dsSale, out DataSet dsDepo, string enterPriseCode, ExtrInfo_DemandDetailWork detailParam, DmdDtlPrtPtn dmdDtlPrtPtn, out string message)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            dsSale = new DataSet(CT_SaleDataSet);
            dsDepo = new DataSet(CT_DepoDataSet);

            // ����E��������DataSet�쐬
            this.CreateSaleTable(ref dsSale);
            this.CreateDepoTable(ref dsDepo);

            DataTable dtSale = dsSale.Tables[CT_SaleDataTable];
            DataTable dtDepo = dsDepo.Tables[CT_DepoDataTable];

            ArrayList htSales = new ArrayList();

            object htSalesObj = null;
            object paramObj = (object)detailParam;

            status = _iBillDetailTableDB.SearchBillDetailTable(out htSalesObj, paramObj);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        htSales = htSalesObj as ArrayList;

                        // ����
                        foreach (RsltInfo_DemandDetailWork detailWork in htSales)
                        {
                            if (detailWork.DepositSlipNo == 0)
                            {
                                // �����͈󎚂��Ȃ�
                                if (detailWork.AccRecDivCd != 0)
                                {
                                    // ����f�[�^
                                    SalesToSaleDtlDataRow(detailWork, ref dtSale, dmdDtlPrtPtn);
                                }
                            }
                            else
                            {
                                // ���������̏ꍇ�͈󎚂��Ȃ�
                                if (detailWork.AutoDepositCd != 1)
                                {
                                    // �����f�[�^
                                    SalesToDepoDtlDataRow(detailWork, ref dtDepo, dmdDtlPrtPtn);
                                }
                            }
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    message = "����E�����f�[�^�̎擾�Ɏ��s���܂���";
                    break;
            }
            return status;
        }
        #endregion
        
        /// <summary>
        /// �I���s�󎚑I���E��I����ԏ���
        /// </summary>
        /// <param name="_uniqueID">���j�[�NID</param>
        /// <remarks>
        /// <br>Note       : ���o�f�[�^�����������܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Note       : ���o�f�[�^�����������܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <param name="outPutDive">�o�͋敪</param>
        /// <param name="outPutDive">��������</param>
        /// <remarks>
        /// <br>Note       : ���o�f�[�^�\���p�f�[�^�r���[�Ƀt�B���^�ݒ���s���܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>        
        // --- UPD  ���r��  2010/01/25 ---------->>>>>
        //public void SelectViewData(int outPutDive, int dmdDtlDiv)        
        public void SelectViewData(int outPutDive, int dmdDtlDiv, int issueType)
        // --- UPD  ���r��  2010/01/25 ----------<<<<<
        {
            string strQuery = "";
            string strQuery1 = "";
            // --- ADD  ���r��  2010/01/25 ---------->>>>>
            string strQuery2 = "";
            // --- ADD  ���r��  2010/01/25 ----------<<<<<

            // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� >>>>>>START
            // �o�͋敪�Ɛ�������ɂ��t�B���^�����쐬
            //switch (outPutDive)
            //{
            //    case 0: // �S�ďo�� 
            //        break;
            //    case 1: // �O�ƃv���X���z���o��
            //        strQuery = String.Format("{0} >= {1}",
            //            CT_CsDmd_AfCalDemandPrice,
            //            0);
            //        break;
            //    case 2: // �v���X���z�̂ݏo��
            //        strQuery = String.Format("{0} > {1}",
            //            CT_CsDmd_AfCalDemandPrice,
            //            0);
            //        break;
            //    case 3: // �O�̂ݏo��
            //        strQuery = String.Format("{0} = {1}",
            //            CT_CsDmd_AfCalDemandPrice,
            //            0);
            //        break;
            //    case 4: // �v���X���z�ƃ}�C�i�X���z���o��
            //        strQuery = String.Format("{0} <> {1}",
            //            CT_CsDmd_AfCalDemandPrice,
            //            0);
            //        break;
            //    case 5: // �O�ƃ}�C�i�X���z���o��
            //        strQuery = String.Format("{0} <= {1}",
            //            CT_CsDmd_AfCalDemandPrice,
            //            0);
            //        break;
            //    case 6: // �}�C�i�X���z�̂ݏo��
            //        strQuery = String.Format("{0} < {1}",
            //            CT_CsDmd_AfCalDemandPrice,
            //            0);
            //        break;
            //    default:
            //        break;
            //}
            // �v�Z�㐿�����z(�t�B���^�[�p)�Ńt�B���^�[�����쐬
            if (dmdDtlDiv != 2)
            {
                switch (outPutDive)
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
            }
            // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� <<<<<<END

            if (dmdDtlDiv == 1)  //  �������󁨐�����
            {
                if (outPutDive == 0)
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

            // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� >>>>>>START
            // ���Ӑ�̏ꍇ�͏o�͋敪�ɂ��t�B���^�[�����쐬�͖���
            if (dmdDtlDiv == 2)  //  �������󁨓��Ӑ�
            {
                //if (outPutDive == 0)
                //{
                strQuery = String.Format("{0} = {1}",
                CT_CsDmd_DataType,
                false);
                //}
                //else
                //{
                //    strQuery1 = String.Format(" AND {0} = {1}",
                //    CT_CsDmd_DataType,
                //    false);
                //}
            }
            // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� <<<<<<END

            // --- ADD  ���r��  2010/01/25 ---------->>>>>
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
                                strQuery2 += string.Format(" {0} <> {1}",
                                CT_Blnce_TotalBillOutputDiv,
                                2);
                            }
                            //�S�̏����l�ݒ�u�o�͂��Ȃ��v
                            else if (AllDefSetData.DefTtlBillOutput == 1)
                            {
                                //���Ӑ�}�X�^�u�g�p�v�̂�
                                strQuery2 += string.Format(" {0} = {1}",
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
                            strQuery2 += string.Format(" {0} <> {1}",
                            CT_Blnce_DetailBillOutputCode,
                            2);
                        }
                        //�S�̏����l�ݒ�u�o�͂��Ȃ��v
                        else if (AllDefSetData.DefDtlBillOutput == 1)
                        {
                            //���Ӑ�}�X�^�u�g�p�v
                            strQuery2 += string.Format(" {0} = {1}",
                            CT_Blnce_DetailBillOutputCode,
                            1);
                        }
                        break;
                    }
                //�`�[���v������
                case 70:
                    {
                        //
                        strQuery2 = string.Empty;
                        if (!string.IsNullOrEmpty(strQuery) || !string.IsNullOrEmpty(strQuery1))
                        {
                            strQuery2 = " AND ";
                        }
                        //�S�̏����l�ݒ�u�o�͂���v
                        if (AllDefSetData.DefSlTtlBillOutput == 0)
                        {
                            //���Ӑ�}�X�^�u�W���v�܂��́u�g�p�v
                            strQuery2 += string.Format(" {0} <> {1}",
                            CT_Blnce_SlipTtlBillOutputDiv,
                            2);
                        }
                        //�S�̏����l�ݒ�u�o�͂��Ȃ��v
                        else if (AllDefSetData.DefSlTtlBillOutput == 1)
                        {
                            //���Ӑ�}�X�^�u�g�p�v
                            strQuery2 += string.Format(" {0} = {1}",
                            CT_Blnce_SlipTtlBillOutputDiv,
                            1);
                        }
                        break;
                    }
            }
            // --- ADD  ���r��  2010/01/25 ----------<<<<<    

            // �N�G���ݒ�
            // --- UPD  ���r��  2010/01/25 ---------->>>>>
            //_custDmdPrcDataView.RowFilter = strQuery + strQuery1;
            _custDmdPrcDataView.RowFilter = strQuery + strQuery1 + strQuery2;
            // --- UPD  ���r��  2010/01/25 ----------<<<<<
        }

        /// <summary>
        /// ����p�f�[�^�e�[�u���쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����p�f�[�^�e�[�u�����쐬���܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 30413 ����</br>
        /// <br>Date       : 2009.01.22</br>
        /// </remarks>
        public int MakePrintDataTable(int pcardPrtSuspendcnt, ExtrInfo_DemandTotal extrInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // ����C���f�b�N�X
            int printOder = 0;

            // ADD 2009/06/03 ------>>>
            // Filter�ݒ�
            string rowFilter = "";
            if (_custDmdPrcDataView.RowFilter != "")
            {
                rowFilter = _custDmdPrcDataView.RowFilter;
            }
            // ADD 2009/06/03 ------<<<
            
            // ����pDataTable������
            _custDmdPrcPrintDataTable.Rows.Clear();
            _custDmdPrcDataViewPrint.RowFilter = "";

            // 2009.01.29 30413 ���� �o�͏��ɑΉ�����悤�ɏC�� >>>>>>START
            string strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_CustomerCode;
            if (extrInfo.SortOrder == 1)
            {
                // �S���ҏ�
                if (extrInfo.CustomerAgentDivCd == 0)
                {
                    // �ڋq�S��
                    strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_CustomerAgentCd + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_CustomerCode;
                }
                else
                {
                    // �W���S��
                    strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_BillCollecterCd + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_CustomerCode;
                }
            }
            else if (extrInfo.SortOrder == 2)
            {
                // �n�揇
                strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_SalesAreaCode + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_CustomerCode;
            }

            // ���[�N�p��DataView
            //DataView workDataView = new DataView(_custDmdPrcDataTable, _custDmdPrcDataTable.DefaultView.RowFilter, strSort, DataViewRowState.CurrentRows);    // DEL 2009/06/03
            DataView workDataView = new DataView(_custDmdPrcDataTable, rowFilter, strSort, DataViewRowState.CurrentRows);   // ADD 2009/06/03

            // �\���pDataView�������pDataTable�ɐݒ�
            //if (_custDmdPrcDataView.Count != 0)
            if (workDataView.Count != 0)
            {
                //for (int i = 0; i < _custDmdPrcDataView.Count; i++)
                for (int i = 0; i < workDataView.Count; i++)
                {
                    //DataRow row = _custDmdPrcDataView[i].Row;
                    DataRow row = workDataView[i].Row;

                    // DEL 2009/04/07 ------>>>
                    //// 2009.01.23 30413 ���� �������o�͋敪��ǉ� >>>>>>START
                    //// �������o�͋敪�`�F�b�N
                    //if ((int)row[CT_Blnce_BillOutputCode] == 1)
                    //{
                    //    // ������Ȃ�
                    //    continue;
                    //}
                    //// 2009.01.23 30413 ���� �������o�͋敪��ǉ� <<<<<<END
                    // DEL 2009/04/07 ------<<<
                    
                    // --- DEL  ���r��  2010/01/25 ---------->>>>>
                    //// UPD 2009/04/07 ------>>>                    
                    //switch (extrInfo.SlipPrtKind)
                    //{
                    //    case 50:
                    //    case 60:
                    //    case 70:
                    //        {
                    //            // �������֌W
                    //            if ((int)row[CT_Blnce_BillOutputCode] == 1)
                    //            {
                    //                // ������Ȃ�
                    //                continue;
                    //            }
                    //            break;
                    //        }                                       
                    //    case 80:
                    //        {
                    //            // �̎���
                    //            if ((int)row[CT_Blnce_ReceiptOutputCode] == 1)
                    //            {
                    //                // ������Ȃ�
                    //                continue;
                    //            }
                    //            break;
                    //        }
                    //}
                    //// UPD 2009/04/07 ------<<<
                    // --- DEL  ���r��  2010/01/25 ---------->>>>>

                    // --- ADD  ���r��  2010/01/25 ---------->>>>>
                    switch (extrInfo.SlipPrtKind)
                    {   
                        //���v������                  
                        case 50:
                            {
                                //���Ӑ�}�X�^�̋敪�u0:�W���v
                                if ((int)row[CT_Blnce_TotalBillOutputDiv] == 0)
                                {
                                    //�S�̏����l�ݒ�}�X�^�̋敪�u1:�o�͂��Ȃ��v
                                    if (AllDefSetData.DefTtlBillOutput == 1)
                                    {
                                        //������Ȃ�
                                        continue;
                                    }                                                                                 
                                }
                                //���Ӑ�}�X�^�̋敪�u2:���g�p�v
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
                                //���Ӑ�}�X�^�̋敪�u0:�W���v
                                if ((int)row[CT_Blnce_SlipTtlBillOutputDiv] == 0)
                                {
                                    //�S�̏����l�ݒ�}�X�^�̋敪�u1:�o�͂��Ȃ��v
                                    if (AllDefSetData.DefSlTtlBillOutput == 1)
                                    {
                                        //������Ȃ�
                                        continue;
                                    }
                                }
                                //���Ӑ�}�X�^�̋敪�u2:���g�p�v
                                else if ((int)row[CT_Blnce_SlipTtlBillOutputDiv] == 2)
                                {
                                    //������Ȃ�
                                    continue;
                                }
                                break;
                            }
                        //�̎���
                        case 80:
                            {
                                // ���Ӑ�}�X�^�̋敪�u1:���Ȃ��v
                                if ((int)row[CT_Blnce_ReceiptOutputCode] == 1)
                                {
                                    // ������Ȃ�
                                    continue;
                                }
                                break;
                            }
                    }
                    // --- ADD  ���r��  2010/01/25 ----------<<<<<
                    
                   
                    
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
            // 2009.01.29 30413 ���� �o�͏��ɑΉ�����悤�ɏC�� <<<<<<END
            
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
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
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

            // ADD 2009/04/20 ------>>>
            // ���R�[�h��
            DataColumn RecordName = new DataColumn(CT_CsDmd_RecordName, typeof(String), "", MappingType.Element);
            DataType.Caption = "���R�[�h��";
            // ADD 2009/04/20 ------<<<
            
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
            // 2009.01.26 30413 ���� �v�㋒�_���������_���ɕύX >>>>>>START
            //AddUpSecName.Caption = "�v�㋒�_";
            AddUpSecName.Caption = "�������_��";
            // 2009.01.26 30413 ���� �v�㋒�_���������_���ɕύX <<<<<<END
            
            // 2008.09.05 30413 ���� ���ڒǉ� >>>>>>START
            // �������_�R�[�h
            DataColumn ClaimSectionCode = new DataColumn(CT_CsDmd_ClaimSectionCode, typeof(String), "", MappingType.Element);
            ClaimSectionCode.Caption = "�������_�R�[�h";

            // �������_����
            DataColumn ClaimSectionName = new DataColumn(CT_CsDmd_ClaimSectionName, typeof(String), "", MappingType.Element);
            ClaimSectionName.Caption = "�������_����";
            // 2008.09.05 30413 ���� ���ڒǉ� <<<<<<END

            // 2009.01.21 30413 ���� ���ڒǉ� >>>>>>START
            // ���ы��_�R�[�h
            DataColumn ResultsSectCd = new DataColumn(CT_CsDmd_ResultsSectCd, typeof(String), "", MappingType.Element);
            ResultsSectCd.Caption = "���ы��_�R�[�h";
            // 2009.01.21 30413 ���� ���ڒǉ� <<<<<<END
        
            // �������p�^�[���ԍ�
            DataColumn DemandPtnNo = new DataColumn(CT_CsDmd_DemandPtnNo, typeof(System.Int32), "", MappingType.Element);
            DemandPtnNo.Caption = "�������p�^�[���ԍ�";

            // �������׏��p�^�[���ԍ�
            DataColumn DmdDtlPtnNo = new DataColumn(CT_CsDmd_DmdDtlPtnNo, typeof(System.Int32), "", MappingType.Element);
            DmdDtlPtnNo.Caption = "�������׏��p�^�[���ԍ�";

            // �������E�x�����敪
            DataColumn DemandOrPay = new DataColumn(CT_CsDmd_DemandOrPay, typeof(System.Int32), "", MappingType.Element);
            DemandOrPay.Caption = "�������E�x�����敪";

            // ������R�[�h
            DataColumn ClaimCode = new DataColumn(CT_CsDmd_ClaimCode, typeof(System.Int32), "", MappingType.Element);
            ClaimCode.Caption = "������R�[�h";

            // 2008.11.19 30413 ���� ���o���ʕ\���p >>>>>>START
            // ������R�[�h(���o���ʕ\���p)
            DataColumn ClaimCodeDisp = new DataColumn(CT_CsDmd_ClaimCodeDisp, typeof(String), "", MappingType.Element);
            ClaimCodeDisp.Caption = "������R�[�h";
            // 2008.11.19 30413 ���� ���o���ʕ\���p <<<<<<END

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

            // 2008.11.19 30413 ���� ���o���ʕ\���p >>>>>>START
            // ���Ӑ�R�[�h(���o���ʕ\���p)
            DataColumn CustomerCodeDisp = new DataColumn(CT_CsDmd_CustomerCodeDisp, typeof(String), "", MappingType.Element);
            CustomerCodeDisp.Caption = "���Ӑ�R�[�h";

            // ���Ӑ旪��(���o���ʕ\���p)
            DataColumn CustomerSnmDisp = new DataColumn(CT_CsDmd_CustomerSnmDisp, typeof(String), "", MappingType.Element);
            CustomerSnmDisp.Caption = "���Ӑ旪��";
            // 2008.11.19 30413 ���� ���o���ʕ\���p <<<<<<END
            
            // 2008.09.08 30413 ���� ���g�p���ڍ폜 >>>>>>START
            //// ����p���Ӑ於�̂P
            //DataColumn EditCustomerName1 = new DataColumn(CT_CsDmd_EditCustomerName1, typeof(String), "", MappingType.Element);
            //EditCustomerName1.Caption = "����p���Ӑ於�̂P";

            //// ����p���Ӑ於�̂Q
            //DataColumn EditCustomerName2 = new DataColumn(CT_CsDmd_EditCustomerName2, typeof(String), "", MappingType.Element);
            //EditCustomerName2.Caption = "����p���Ӑ於�̂Q";
            // 2008.09.08 30413 ���� ���g�p���ڍ폜 <<<<<<END
        
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

            // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� >>>>>>START
            // �v�Z�㐿�����z(�t�B���^�[�p)
            DataColumn AfCalDemandPriceFilter = new DataColumn(CT_CsDmd_AfCalDemandPriceFilter, typeof(System.Int64), "", MappingType.Element);
            AfCalDemandPriceFilter.Caption = "�v�Z�㐿�����z(�t�B���^�[�p)";
            // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� <<<<<<END
        
            // ����`�[����
            DataColumn SaleslSlipCount = new DataColumn(CT_CsDmd_SaleslSlipCount, typeof(System.Int32), "", MappingType.Element);
            SaleslSlipCount.Caption = "����`�[����";

            // ���������s��
            DataColumn BillPrintDate = new DataColumn(CT_CsDmd_BillPrintDate, typeof(System.DateTime), "", MappingType.Element);
            BillPrintDate.Caption = "���������s��";

            // ���������s��(����p)
            DataColumn BillPrintDatePrt = new DataColumn(CT_CsDmd_BillPrintDatePrt, typeof(String), "", MappingType.Element);
            BillPrintDatePrt.Caption = "���������s��(����p)";

            // �����\���
            DataColumn ExpectedDepositDate = new DataColumn(CT_CsDmd_ExpectedDepositDate, typeof(System.DateTime), "", MappingType.Element);
            ExpectedDepositDate.Caption = "�����\���";

            // �����\���(����p)
            DataColumn ExpectedDepositDatePrt = new DataColumn(CT_CsDmd_ExpectedDepositDatePrt, typeof(String), "", MappingType.Element);
            ExpectedDepositDatePrt.Caption = "�����\���(����p)";

            // �������
            DataColumn CollectCond = new DataColumn(CT_CsDmd_CollectCond, typeof(String), "", MappingType.Element);
            CollectCond.Caption = "�������";

            // ����ŗ�
            DataColumn ConsTaxRate = new DataColumn(CT_CsDmd_ConsTaxRate, typeof(System.Double), "", MappingType.Element);
            ConsTaxRate.Caption = "����ŗ�";

            // �[�������敪
            DataColumn FractionProcCd = new DataColumn(CT_CsDmd_FractionProcCd, typeof(System.Int32), "", MappingType.Element);
            FractionProcCd.Caption = "�[�������敪";

            // �����X�V���s�N����
            DataColumn CAddUpUpdExecDate = new DataColumn(CT_CsDmd_CAddUpUpdExecDate, typeof(System.DateTime), "", MappingType.Element);
            CAddUpUpdExecDate.Caption = "�����X�V���s�N����";

            // �����X�V���s�N����(����p)
            DataColumn CAddUpUpdExecDatePrt = new DataColumn(CT_CsDmd_CAddUpUpdExecDatePrt, typeof(String), "", MappingType.Element);
            CAddUpUpdExecDatePrt.Caption = "�����X�V���s�N����(����p)";

            // �����X�V�J�n�N����
            DataColumn StartCAddUpUpdDate = new DataColumn(CT_CsDmd_StartCAddUpUpdDate, typeof(System.DateTime), "", MappingType.Element);
            StartCAddUpUpdDate.Caption = "�����X�V�J�n�N����";

            // �����X�V�J�n�N����(����p)
            DataColumn StartCAddUpUpdDatePrt = new DataColumn(CT_CsDmd_StartCAddUpUpdDatePrt, typeof(String), "", MappingType.Element);
            StartCAddUpUpdDatePrt.Caption = "�����X�V�J�n�N����(����p)";

            // �O������X�V�N����
            DataColumn LastCAddUpUpdDate = new DataColumn(CT_CsDmd_LastCAddUpUpdDate, typeof(System.DateTime), "", MappingType.Element);
            LastCAddUpUpdDate.Caption = "�O������X�V�N����";

            // �O������X�V�N����(����p)
            DataColumn LastCAddUpUpdDatePrt = new DataColumn(CT_CsDmd_LastCAddUpUpdDatePrt, typeof(String), "", MappingType.Element);
            LastCAddUpUpdDatePrt.Caption = "�O������X�V�N����(����p)";

            // �v����t(����p)
            DataColumn AddUpADatePrint = new DataColumn(CT_CsDmd_AddUpADatePrint, typeof(String), "", MappingType.Element);
            AddUpADatePrint.Caption = "�v����t(����p)";

            // ���E�㍡�񔄏�����(����p)
            DataColumn PrintTtlConsTaxDmd = new DataColumn(CT_CsDmd_PrintTtlConsTaxDmd, typeof(String), "", MappingType.Element);
            PrintTtlConsTaxDmd.Caption = "���E�㍡�񔄏�����";
            
            // �O�񐿋��z(������)
            DataColumn ClaimLastTimeDemand = new DataColumn(CT_CsDmd_ClaimLastTimeDemand, typeof(System.Int64), "", MappingType.Element);
            ClaimLastTimeDemand.Caption = "�O�񐿋��z(������)";

            // ����������z�i������j
            DataColumn ClaimThisTimeDmdNrml = new DataColumn(CT_CsDmd_ClaimThisTimeDmdNrml, typeof(System.Int64), "", MappingType.Element);
            ClaimThisTimeDmdNrml.Caption = "����������z�i������j";

            // ����J�z�c���i������j
            DataColumn ClaimThisTimeTtlBlcDmd = new DataColumn(CT_CsDmd_ClaimThisTimeTtlBlcDmd, typeof(System.Int64), "", MappingType.Element);
            ClaimThisTimeTtlBlcDmd.Caption = "����J�z�c���i������j";

            // ���񔄏���z�i������j
            DataColumn ClaimThisTimeSales = new DataColumn(CT_CsDmd_ClaimThisTimeSales, typeof(System.Int64), "", MappingType.Element);
            ClaimThisTimeSales.Caption = "���񔄏���z�i������j";

            // ���񔄏�ԕi�E�l�����z�i������j
            DataColumn ClaimThisSalesPricRgdsDis = new DataColumn(CT_CsDmd_ClaimThisSalesPricRgdsDis, typeof(System.Int64), "", MappingType.Element);
            ClaimThisSalesPricRgdsDis.Caption = "���񔄏�ԕi�E�l�����z�i������j";

            // ���E�㍡�񔄏���z�i������j
            DataColumn ClaimOfsThisTimeSales = new DataColumn(CT_CsDmd_ClaimOfsThisTimeSales, typeof(System.Int64), "", MappingType.Element);
            ClaimOfsThisTimeSales.Caption = "���E�㍡�񔄏���z�i������j";

            // ���E�㍡�񔄏����Łi������j
            DataColumn ClaimOfsThisSalesTax = new DataColumn(CT_CsDmd_ClaimOfsThisSalesTax, typeof(System.Int64), "", MappingType.Element);
            ClaimOfsThisSalesTax.Caption = "���E�㍡�񔄏����Łi������j";

            // ���E�㍡�񍇌v������z�i������j
            DataColumn ClaimOfsThisSalesSum = new DataColumn(CT_CsDmd_ClaimOfsThisSalesSum, typeof(System.Int64), "", MappingType.Element);
            ClaimOfsThisSalesSum.Caption = "���E�㍡�񍇌v������z�i������j";

            // �v�Z�㐿�����z�i������j
            DataColumn ClaimAfCalDemandPrice = new DataColumn(CT_CsDmd_ClaimAfCalDemandPrice, typeof(System.Int64), "", MappingType.Element);
            ClaimAfCalDemandPrice.Caption = "�v�Z�㐿�����z�i������j";

            // ����`�[�����i������j
            DataColumn ClaimSaleslSlipCount = new DataColumn(CT_CsDmd_ClaimSaleslSlipCount, typeof(System.Int64), "", MappingType.Element);
            ClaimSaleslSlipCount.Caption = "����`�[�����i������j";

            // ****************
            // ���Ӑ���
            // ****************
            // ����
            DataColumn Name = new DataColumn(CT_CsDmd_Name, typeof(String), "", MappingType.Element);
            Name.Caption = "����";

            // ���̂Q
            DataColumn Name2 = new DataColumn(CT_CsDmd_Name2, typeof(String), "", MappingType.Element);
            Name2.Caption = "���̂Q";

            // �J�i
            DataColumn Kana = new DataColumn(CT_CsDmd_Kana, typeof(String), "", MappingType.Element);
            Kana.Caption = "�J�i";

            // �X�֔ԍ�
            DataColumn PostNo = new DataColumn(CT_CsDmd_PostNo, typeof(String), "", MappingType.Element);
            PostNo.Caption = "�X�֔ԍ�";

            // �Z���P�i�s���{���s��S�E�����E���j
            DataColumn Address1 = new DataColumn(CT_CsDmd_Address1, typeof(String), "", MappingType.Element);
            Address1.Caption = "�Z���P�i�s���{���s��S�E�����E���j";

            // �Z���Q�i���ځj
            DataColumn Address2 = new DataColumn(CT_CsDmd_Address2, typeof(System.Int32), "", MappingType.Element);
            Address2.Caption = "�Z���Q�i���ځj";

            // �Z���R�i�Ԓn�j
            DataColumn Address3 = new DataColumn(CT_CsDmd_Address3, typeof(String), "", MappingType.Element);
            Address3.Caption = "�Z���R�i�Ԓn�j";

            // �Z���S�i�A�p�[�g���́j
            DataColumn Address4 = new DataColumn(CT_CsDmd_Address4, typeof(String), "", MappingType.Element);
            Address4.Caption = "�Z���S�i�A�p�[�g���́j";

            // �ҏW��Z���P
            DataColumn EditAddress1 = new DataColumn(CT_CsDmd_EditAddress1, typeof(String), "", MappingType.Element);
            EditAddress1.Caption = "�ҏW��Z���P";

            // �ҏW��Z���Q
            DataColumn EditAddress2 = new DataColumn(CT_CsDmd_EditAddress2, typeof(String), "", MappingType.Element);
            EditAddress2.Caption = "�ҏW��Z���Q";

            // �ҏW��Z���R
            DataColumn EditAddress3 = new DataColumn(CT_CsDmd_EditAddress3, typeof(String), "", MappingType.Element);
            EditAddress3.Caption = "�ҏW��Z���R";

            // �ҏW��Z���P�i���X�g����p�Z��1�s�ځj
            DataColumn ListAddress1 = new DataColumn(CT_CsDmd_ListAddress1, typeof(String), "", MappingType.Element);

            // �ҏW��Z���Q�i���X�g����p�Z��2�s�ځj
            DataColumn ListAddress2 = new DataColumn(CT_CsDmd_ListAddress2, typeof(String), "", MappingType.Element);

            // �ҏW��Z���R�i���X�g����p�Z��3�s�ځj
            DataColumn ListAddress3 = new DataColumn(CT_CsDmd_ListAddress3, typeof(String), "", MappingType.Element);

            // �d�b�ԍ��i����
            DataColumn HomeTelNo = new DataColumn(CT_CsDmd_HomeTelNo, typeof(String), "", MappingType.Element);
            HomeTelNo.Caption = "�d�b�ԍ�(����)";

            // �d�b�ԍ��i�Ζ���
            DataColumn OfficeTelNo = new DataColumn(CT_CsDmd_OfficeTelNo, typeof(String), "", MappingType.Element);
            OfficeTelNo.Caption = "�d�b�ԍ��i�Ζ���j";

            // �d�b�ԍ��i�g��
            DataColumn PortableTelNo = new DataColumn(CT_CsDmd_PortableTelNo, typeof(String), "", MappingType.Element);
            PortableTelNo.Caption = "�d�b�ԍ��i�g�сj";

            // FAX�ԍ��i����j
            DataColumn HomeFaxNo = new DataColumn(CT_CsDmd_HomeFaxNo, typeof(String), "", MappingType.Element);
            HomeFaxNo.Caption = "FAX�ԍ��i����j";

            // FAX�ԍ��i�Ζ���j
            DataColumn OfficeFaxNo = new DataColumn(CT_CsDmd_OfficeFaxNo, typeof(String), "", MappingType.Element);
            OfficeFaxNo.Caption = "FAX�ԍ��i�Ζ���j";

            // �d�b�ԍ��i���̑��j
            DataColumn OthersTelNo = new DataColumn(CT_CsDmd_OthersTelNo, typeof(String), "", MappingType.Element);
            OthersTelNo.Caption = "�d�b�ԍ��i���̑��j";

            // ��A����敪[0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���]
            DataColumn MainContactCode = new DataColumn(CT_CsDmd_MainContactCode, typeof(System.Int32), "", MappingType.Element);
            MainContactCode.Caption = "��A����敪";

            // ��A���^�C�g��
            DataColumn MainContactName = new DataColumn(CT_CsDmd_MainContactName, typeof(String), "", MappingType.Element);
            MainContactName.Caption = "��A����敪";

            // ��A����d�b�ԍ�
            DataColumn MainContactTelNo = new DataColumn(CT_CsDmd_MainContactTelNo, typeof(String), "", MappingType.Element);
            MainContactTelNo.Caption = "��A����d�b�ԍ�";

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

            // ��U������(����p)
            DataColumn CollectMoneyDate = new DataColumn(CT_CsDmd_CollectMoneyDate, typeof(String), "", MappingType.Element);
            CollectMoneyDate.Caption = "��U������(����p)";

            // ��x������(����p)
            DataColumn PaymentMoneyDate = new DataColumn(CT_CsDmd_PaymentMoneyDate, typeof(String), "", MappingType.Element);
            PaymentMoneyDate.Caption = "��U������(����p)";

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

            // �h��
            DataColumn HonorificTitle = new DataColumn(CT_CsDmd_HonorificTitle, typeof(String), "", MappingType.Element);
            HonorificTitle.Caption = "�h��";

            // �����R�[�h
            DataColumn OutputNameCode = new DataColumn(CT_CsDmd_OutputNameCode, typeof(System.Int32), "", MappingType.Element);
            OutputNameCode.Caption = "�����R�[�h";

            // ��������
            DataColumn OutputName = new DataColumn(CT_CsDmd_OutputName, typeof(String), "", MappingType.Element);
            OutputName.Caption = "��������";

            // ���Ӑ敪�̓R�[�h�P
            DataColumn CustAnalysCode1 = new DataColumn(CT_CsDmd_CustAnalysCode1, typeof(System.Int32), "", MappingType.Element);
            CustAnalysCode1.Caption = "���Ӑ敪�̓R�[�h�P";
            // ���Ӑ敪�̓R�[�h�Q
            DataColumn CustAnalysCode2 = new DataColumn(CT_CsDmd_CustAnalysCode2, typeof(System.Int32), "", MappingType.Element);
            CustAnalysCode2.Caption = "���Ӑ敪�̓R�[�h�Q";
            // ���Ӑ敪�̓R�[�h�R
            DataColumn CustAnalysCode3 = new DataColumn(CT_CsDmd_CustAnalysCode3, typeof(System.Int32), "", MappingType.Element);
            CustAnalysCode3.Caption = "���Ӑ敪�̓R�[�h�R";
            // ���Ӑ敪�̓R�[�h�S
            DataColumn CustAnalysCode4 = new DataColumn(CT_CsDmd_CustAnalysCode4, typeof(System.Int32), "", MappingType.Element);
            CustAnalysCode4.Caption = "���Ӑ敪�̓R�[�h�S";
            // ���Ӑ敪�̓R�[�h�T
            DataColumn CustAnalysCode5 = new DataColumn(CT_CsDmd_CustAnalysCode5, typeof(System.Int32), "", MappingType.Element);
            CustAnalysCode5.Caption = "���Ӑ敪�̓R�[�h�T";
            // ���Ӑ敪�̓R�[�h�U
            DataColumn CustAnalysCode6 = new DataColumn(CT_CsDmd_CustAnalysCode6, typeof(System.Int32), "", MappingType.Element);
            CustAnalysCode6.Caption = "���Ӑ敪�̓R�[�h�U";

            // ���Ӑ��s1
            DataColumn AccountNoInfoTK1 = new DataColumn(CT_CsDmd_AccountNoInfoTK1, typeof(String), "", MappingType.Element);
            AccountNoInfoTK1.Caption = "���Ӑ��s1";
            // ���Ӑ��s2
            DataColumn AccountNoInfoTK2 = new DataColumn(CT_CsDmd_AccountNoInfoTK2, typeof(String), "", MappingType.Element);
            AccountNoInfoTK2.Caption = "���Ӑ��s2";
            // ���Ӑ��s3
            DataColumn AccountNoInfoTK3 = new DataColumn(CT_CsDmd_AccountNoInfoTK3, typeof(String), "", MappingType.Element);
            AccountNoInfoTK3.Caption = "���Ӑ��s3";

            // ���z�\���敪
            DataColumn TotalAmountDispWayCd = new DataColumn(CT_CsDmd_TotalAmountDispWayCd, typeof(Int32), "", MappingType.Element);
            TotalAmountDispWayCd.Caption = "���z�\���敪";

            // ����PR��
            DataColumn CompanyPr = new DataColumn(CT_CsDmd_CompanyPr, typeof(String), "", MappingType.Element);
            // ���Ж���1
            DataColumn CompanyName1 = new DataColumn(CT_CsDmd_CompanyName1, typeof(String), "", MappingType.Element);
            // ���Ж���2
            DataColumn CompanyName2 = new DataColumn(CT_CsDmd_CompanyName2, typeof(String), "", MappingType.Element);
            // �X�֔ԍ�
            DataColumn CompanyPostNo = new DataColumn(CT_CsDmd_CompanyPostNo, typeof(String), "", MappingType.Element);
            // ���ЏZ���P�s��(����p)
            DataColumn EditCompanyAddress1 = new DataColumn(CT_CsDmd_EditCompanyAddress1, typeof(String), "", MappingType.Element);
            // ���ЏZ���Q�s��(����p)
            DataColumn EditCompanyAddress2 = new DataColumn(CT_CsDmd_EditCompanyAddress2, typeof(String), "", MappingType.Element);
            // ���Гd�b�ԍ�1(����p�^�C�g���܂�)
            DataColumn EditCompanyTelNo1 = new DataColumn(CT_CsDmd_EditCompanyTelNo1, typeof(String), "", MappingType.Element);
            // ���Гd�b�ԍ�2(����p�^�C�g���܂�)
            DataColumn EditCompanyTelNo2 = new DataColumn(CT_CsDmd_EditCompanyTelNo2, typeof(String), "", MappingType.Element);
            // ���Гd�b�ԍ�3(����p�^�C�g���܂�)
            DataColumn EditCompanyTelNo3 = new DataColumn(CT_CsDmd_EditCompanyTelNo3, typeof(String), "", MappingType.Element);
            // ��s�U���ē���
            DataColumn TransferGuidance = new DataColumn(CT_CsDmd_TransferGuidance, typeof(String), "", MappingType.Element);
            // ��s����1
            DataColumn AccountNoInfo1 = new DataColumn(CT_CsDmd_AccountNoInfo1, typeof(String), "", MappingType.Element);
            // ��s����2
            DataColumn AccountNoInfo2 = new DataColumn(CT_CsDmd_AccountNoInfo2, typeof(String), "", MappingType.Element);
            // ��s����3
            DataColumn AccountNoInfo3 = new DataColumn(CT_CsDmd_AccountNoInfo3, typeof(String), "", MappingType.Element);
            // ���Аݒ�E�v1
            DataColumn CompanyProt1 = new DataColumn(CT_CsDmd_CompanyProt1, typeof(String), "", MappingType.Element);
            // ���Аݒ�E�v2
            DataColumn CompanyProt2 = new DataColumn(CT_CsDmd_CompanyProt2, typeof(String), "", MappingType.Element);
            // �����ݒ�E�v1
            DataColumn BillOutline1 = new DataColumn(CT_CsDmd_CompanySetNote1, typeof(String), "", MappingType.Element);
            // �����ݒ�E�v2
            DataColumn BillOutline2 = new DataColumn(CT_CsDmd_CompanySetNote2, typeof(String), "", MappingType.Element);
            // ���s�N����
            DataColumn Publication = new DataColumn(CT_CsDmd_Publication, typeof(String), "", MappingType.Element);
            // �����N����
            DataColumn TargetAddUpDate = new DataColumn(CT_CsDmd_TargetAddUpDate, typeof(String), "", MappingType.Element);
            // ������
            DataColumn TargetAddUpMonth = new DataColumn(CT_CsDmd_TargetAddUpMonth, typeof(System.Int32), "", MappingType.Element);
            // ����p�������z
            DataColumn PrintAfCalDemandPrice = new DataColumn(CT_CsDmd_PrintAfCalDemandPrice, typeof(String), "", MappingType.Element);

            // ���Љ摜
            DataColumn CampImg = new DataColumn(CT_CsDmd_CampImgID, typeof(Image), "", MappingType.Element);
            DataColumn ImageCommentForPrt1 = new DataColumn(CT_CsDmd_ImageCommentForPrt1, typeof(String), "", MappingType.Element);
            DataColumn ImageCommentForPrt2 = new DataColumn(CT_CsDmd_ImageCommentForPrt2, typeof(String), "", MappingType.Element);

            // ��s1
            DataColumn AccountNoInfoDsp1 = new DataColumn(CT_CsDmd_AccountNoInfoDsp1, typeof(String), "", MappingType.Element);
            AccountNoInfoDsp1.Caption = "��s1";
            // ��s2
            DataColumn AccountNoInfoDsp2 = new DataColumn(CT_CsDmd_AccountNoInfoDsp2, typeof(String), "", MappingType.Element);
            AccountNoInfoDsp2.Caption = "��s2";
            // ��s3
            DataColumn AccountNoInfoDsp3 = new DataColumn(CT_CsDmd_AccountNoInfoDsp3, typeof(String), "", MappingType.Element);
            AccountNoInfoDsp3.Caption = "��s3";
            
            // 2008.09.08 30413 ���� ���ڒǉ� >>>>>>START
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
            // 2008.09.08 30413 ���� ���ڒǉ� <<<<<<END

            // --- DEL  ���r��  2010/01/25 ---------->>>>>
            // 2009.01.23 30413 ���� �������o�͋敪��ǉ� >>>>>>START
            // �������o�͋敪�R�[�h
            //DataColumn BillOutputCode = new DataColumn(CT_Blnce_BillOutputCode, typeof(Int32), "", MappingType.Element);
            // 2009.01.23 30413 ���� �������o�͋敪��ǉ� <<<<<<END
            // --- DEL  ���r��  2010/01/25 ----------<<<<<

            // �̎����o�͋敪�R�[�h
            DataColumn ReceiptOutputCode = new DataColumn(CT_Blnce_ReceiptOutputCode, typeof(Int32), "", MappingType.Element);  // ADD 2009/04/07

            // --- ADD  ���r��  2010/01/25 ---------->>>>>
            //���v�������o�͋敪�R�[�h
            DataColumn TotalBillOutputDiv = new DataColumn(CT_Blnce_TotalBillOutputDiv, typeof(Int32), "", MappingType.Element);
            //���א������o�͋敪�R�[�h
            DataColumn DetailBillOutputCode = new DataColumn(CT_Blnce_DetailBillOutputCode, typeof(Int32), "", MappingType.Element);
            //�`�[���v�������o�͋敪�R�[�h
            DataColumn SlipTtlBillOutputDiv = new DataColumn(CT_Blnce_SlipTtlBillOutputDiv, typeof(Int32), "", MappingType.Element);
            // --- ADD  ���r��  2010/01/25 ----------<<<<<

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
            //--- ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
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
            //--- ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
            _demandDataSet.Tables.AddRange(new DataTable[] { _custDmdPrcDataTable });
            _custDmdPrcDataTable.Columns.AddRange(new DataColumn[]{
                UniqueID,
                    DataType,
                    RecordName,     // ADD 2009/04/20
				    PrintFlag,
				    PrintIndex,
				    AddUpSecCode,
				    AddUpSecName,
                    // 2008.09.05 30413 ���� ���ڒǉ� >>>>>>START
                    ClaimSectionCode,
                    ClaimSectionName,
                    // 2008.09.05 30413 ���� ���ڒǉ� <<<<<<END
                    // 2009.01.21 30413 ���� ���ڒǉ� >>>>>>START
                    ResultsSectCd,
                    // 2009.01.21 30413 ���� ���ڒǉ� <<<<<<END
                    DemandPtnNo,
                    DmdDtlPtnNo,
                    DemandOrPay,
                    ClaimCode,
                    // 2008.11.19 30413 ���� ���o���ʕ\���p >>>>>>START
                    ClaimCodeDisp,
                    // 2008.11.19 30413 ���� ���o���ʕ\���p <<<<<<END
                    ClaimName,
                    ClaimName2,
                    ClaimSnm,
				    CustomerCode,
                    CustomerName,
                    CustomerName2,
                    CustomerSnm,
                    // 2008.11.19 30413 ���� ���o���ʕ\���p >>>>>>START
                    CustomerCodeDisp,
                    CustomerSnmDisp,
                    // 2008.11.19 30413 ���� ���o���ʕ\���p <<<<<<END
				    // 2008.09.08 30413 ���� ���g�p���ڍ폜 >>>>>>START
                    //EditCustomerName1,
                    //EditCustomerName2,
				    // 2008.09.08 30413 ���� ���g�p���ڍ폜 <<<<<<END
                    AddUpDate,
				    AddUpDateInt,		
				    AddUpYearMonth,
                    LastTimeDemand,
                    // 2008.11.18 30413 ���� �����c���𒊏o���ʃO���b�h�̑O�񐿋����z�ɒu�������邽�߃e�[�u���ǉ��ʒu��ύX >>>>>>START
                    DemandBalance,
                    // 2008.11.18 30413 ���� �����c���𒊏o���ʃO���b�h�̑O�񐿋����z�ɒu�������邽�߃e�[�u���ǉ��ʒu��ύX <<<<<<END
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
                    // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� >>>>>>START
                    AfCalDemandPriceFilter,
                    // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� <<<<<<END
                    SaleslSlipCount,
                    BillPrintDate,
                    BillPrintDatePrt,
                    ExpectedDepositDate,
                    ExpectedDepositDatePrt,
                    CollectCond,
                    ConsTaxRate,
                    FractionProcCd,
                    CAddUpUpdExecDate,      
                    CAddUpUpdExecDatePrt,   
                    StartCAddUpUpdDate,
                    StartCAddUpUpdDatePrt,
                    LastCAddUpUpdDate,
                    LastCAddUpUpdDatePrt,
                    AddUpADatePrint,
                    PrintTtlConsTaxDmd,
                    CollectMoneyName,
				    CollectMoneyDay,
				    CollectMoneyDayNm,
                    CollectMoneyDate,
                    PaymentMoneyDate,
                    ClaimLastTimeDemand,
                    ClaimThisTimeDmdNrml,
                    ClaimThisTimeTtlBlcDmd,
                    ClaimThisTimeSales,
                    ClaimThisSalesPricRgdsDis,
                    ClaimOfsThisTimeSales,
                    ClaimOfsThisSalesTax,
                    ClaimOfsThisSalesSum,
                    ClaimAfCalDemandPrice,
                    ClaimSaleslSlipCount,
				    Name,
                    Name2,
                    Kana,
                    PostNo,
                    Address1,
                    Address2,
                    Address3,
                    Address4,
                    EditAddress1,
                    EditAddress2,
                    EditAddress3,
                    ListAddress1,
                    ListAddress2,
                    ListAddress3,
                    HomeTelNo,
                    OfficeTelNo,
                    PortableTelNo,
                    HomeFaxNo,
                    OfficeFaxNo,
                    OthersTelNo,
                    MainContactCode,
                    MainContactName,
                    MainContactTelNo,
				    TotalDay,
				    PrintTotalDay,
				    CustomerAgentCd,
				    CustomerAgentNm,
				    BillCollecterCd,
				    BillCollecterNm,
				    EmployeeCd,
				    EmployeeNm,
                    HonorificTitle,
				    OutputNameCode,
				    OutputName,
				    CustAnalysCode1,
				    CustAnalysCode2,
				    CustAnalysCode3,
				    CustAnalysCode4,
				    CustAnalysCode5,
				    CustAnalysCode6,
                    AccountNoInfoTK1,
                    AccountNoInfoTK2,
                    AccountNoInfoTK3,
                    TotalAmountDispWayCd,
                    CompanyPr,
				    CompanyName1,
				    CompanyName2,
				    CompanyPostNo,
				    EditCompanyAddress1,
				    EditCompanyAddress2,
				    EditCompanyTelNo1,
				    EditCompanyTelNo2,
				    EditCompanyTelNo3,
                    CampImg,//20070316 iwa add
                    ImageCommentForPrt1,//20070316 iwa add
                    ImageCommentForPrt2,//20070316 iwa add
				    TransferGuidance,
				    AccountNoInfo1,
				    AccountNoInfo2,
				    AccountNoInfo3,
				    CompanyProt1,
				    CompanyProt2,
				    BillOutline1,
				    BillOutline2,
				    Publication,
				    TargetAddUpDate,
				    TargetAddUpMonth,
				    PrintAfCalDemandPrice,
                    AccountNoInfoDsp1,
                    AccountNoInfoDsp2,
                    AccountNoInfoDsp3,
                    // 2008.09.08 30413 ���� ���ڒǉ� >>>>>>START
                    // 2008.11.18 30413 ���� �����c���𒊏o���ʃO���b�h�̑O�񐿋����z�ɒu�������邽�߃e�[�u���ǉ��ʒu��ύX >>>>>>START
                    //DemandBalance,
                    // 2008.11.18 30413 ���� �����c���𒊏o���ʃO���b�h�̑O�񐿋����z�ɒu�������邽�߃e�[�u���ǉ��ʒu��ύX <<<<<<END
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
                    // 2009.01.22 30413 ���� �������o�͋敪�ǉ� >>>>>>START
                    //MoneyKindDiv112
                    MoneyKindDiv112,
                    // --- UPD  ���r��  2010/01/25 ---------->>>>>
                    // 2008.09.08 30413 ���� ���ڒǉ� <<<<<<END
                    //BillOutputCode    // DEL 2009/04/07
                    //BillOutputCode,     // ADD 2009/04/07
                    // 2009.01.22 30413 ���� �������o�͋敪�ǉ� <<<<<<END                   
                    //ReceiptOutputCode   // ADD 2009/04/07
                    ReceiptOutputCode,
                    TotalBillOutputDiv,
                    DetailBillOutputCode,
                    SlipTtlBillOutputDiv,
                    // --- UPD  ���r��  2010/01/25 ----------<<<<<
                �@�@// --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
                �@�@TotalThisTimeSalesTaxRate1,
                    TotalThisTimeSalesTaxRate2,
                    TotalThisTimeSalesTaxFree,// ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    TotalThisTimeSalesOther,
                    TotalThisRgdsDisPricTaxRate1,
                    TotalThisRgdsDisPricTaxRate2,
                    TotalThisRgdsDisPricTaxFree,// ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    TotalThisRgdsDisPricOther,
                    TotalPureSalesTaxRate1,
                    TotalPureSalesTaxRate2,
                    TotalPureSalesTaxFree,// ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    TotalPureSalesOther,
                    TotalSalesPricTaxTaxRate1,
                    TotalSalesPricTaxTaxRate2,
                    TotalSalesPricTaxTaxFree,// ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    TotalSalesPricTaxOther,
                    TotalThisSalesSumTaxRate1,
                    TotalThisSalesSumTaxRate2,
                    TotalThisSalesSumTaxFree,// ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    TotalThisSalesSumTaxOther,
                    TotalSalesSlipCountTaxRate1,
                    TotalSalesSlipCountTaxRate2,
                    TotalSalesSlipCountTaxFree,// ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    TotalSalesSlipCountOther,
                    TitleTaxRate1,
                    TitleTaxRate2,
�@�@�@�@�@�@�@�@�@�@// --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<

			    });
            // �v���C�}���[�L�[�����j�[�NID�ɐݒ�
            _custDmdPrcDataTable.PrimaryKey = new DataColumn[] { UniqueID };
            _custDmdPrcDataView.Table = _custDmdPrcDataTable;
            // 2009.01.26 30413 ���� �f�t�H���g�͓��Ӑ揇�Ƃ��� >>>>>>START
            //_custDmdPrcDataView.Sort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_CustomerCode + "," + CT_CsDmd_AddUpDate;
            // �������_�{�������Ӑ�{���ы��_�{���Ӑ�
            _custDmdPrcDataView.Sort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_CustomerCode;

            // ����pDataTable�쐬
            _custDmdPrcPrintDataTable = _custDmdPrcDataTable.Clone();
            _custDmdPrcDataViewPrint.Table = _custDmdPrcPrintDataTable;
            //_custDmdPrcDataViewPrint.Sort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_CustomerCode + "," + CT_CsDmd_AddUpDate;
            // �������_�{�������Ӑ�{���ы��_�{���Ӑ�
            _custDmdPrcDataViewPrint.Sort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_CustomerCode;
            // 2009.01.26 30413 ���� �f�t�H���g�͓��Ӑ揇�Ƃ��� <<<<<<END
            
            _custDmdPrcDataViewPrint.RowFilter = String.Format("{0} = {1}", CT_CsDmd_PrintFlag, true);

        }

        #region ���㖾�׃e�[�u�����쐬����
        /// <summary>
        /// ���㖾�׃e�[�u�����쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public void CreateSaleTable(ref DataSet ds)
        {
            DataTable dt = new DataTable(CT_SaleDataTable);
            // �f�[�^�J�������쐬
            // ������R�[�h
            DataColumn ClaimCode = new DataColumn(CT_SaleDepo_ClaimCode, typeof(System.Int32), "", MappingType.Element);
            ClaimCode.Caption = "������R�[�h";
            // �����於
            DataColumn ClaimName = new DataColumn(CT_SaleDepo_ClaimName, typeof(String), "", MappingType.Element);
            ClaimName.Caption = "�����於��";
            // �����於�Q
            DataColumn ClaimName2 = new DataColumn(CT_SaleDepo_ClaimName2, typeof(String), "", MappingType.Element);
            ClaimName2.Caption = "�����於��2";
            // �����旪��
            DataColumn ClaimSnm = new DataColumn(CT_SaleDepo_ClaimSnm, typeof(String), "", MappingType.Element);
            ClaimSnm.Caption = "�����旪��";
            // ���Ӑ�R�[�h
            DataColumn CustomerCode = new DataColumn(CT_SaleDepo_CustomerCode, typeof(System.Int32), "", MappingType.Element);
            CustomerCode.Caption = "���Ӑ�R�[�h";
            // ���Ӑ於
            DataColumn CustomerName = new DataColumn(CT_SaleDepo_CustomerName, typeof(String), "", MappingType.Element);
            CustomerName.Caption = "���Ӑ於��";
            // ���Ӑ於2
            DataColumn CustomerName2 = new DataColumn(CT_SaleDepo_CustomerName2, typeof(String), "", MappingType.Element);
            CustomerName2.Caption = "���Ӑ於��2";
            // ���Ӑ旪��
            DataColumn CustomerSnm = new DataColumn(CT_SaleDepo_CustomerSnm, typeof(String), "", MappingType.Element);
            CustomerSnm.Caption = "���Ӑ旪��";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
            //// �ԓ`�敪(0:��,1:��,2���E�ςݍ�)       
            //DataColumn DebitNoteDiv = new DataColumn(CT_SaleDepo_DebitNoteDiv, typeof(System.Int32), "", MappingType.Element);
            //DebitNoteDiv.Caption = "�ԓ`�敪";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            // �v����t                            
            DataColumn AddUpADate = new DataColumn(CT_SaleDepo_AddUpADate, typeof(System.DateTime), "", MappingType.Element);
            AddUpADate.Caption = "�v����t";
            // �v����t(�\���p)
            DataColumn AddUpADateDisp = new DataColumn(CT_SaleDepo_AddUpADateDisp, typeof(String), "", MappingType.Element);
            AddUpADateDisp.Caption = "�v����t";
            // �f�[�^���̓V�X�e��
            DataColumn DataInputSystem = new DataColumn(CT_SaleDepo_DataInputSystem, typeof(System.Int32), "", MappingType.Element);
            DataInputSystem.Caption = "�f�[�^���̓V�X�e��";
            // �`�[�ԍ��E�����ԍ�                          
            DataColumn SalesSlipNum = new DataColumn(CT_SaleDepo_SalesSlipNum, typeof(System.Int32), "", MappingType.Element);
            SalesSlipNum.Caption = "�`�[�ԍ�";
            // ����`�[�敪                          
            DataColumn SalesSlipCd = new DataColumn(CT_SaleDepo_SalesSlipCd, typeof(String), "", MappingType.Element);
            SalesSlipCd.Caption = "����`�[�敪";
            // ���|�敪                          
            DataColumn AccRecDivCd = new DataColumn(CT_SaleDepo_AccRecDivCd, typeof(String), "", MappingType.Element);
            AccRecDivCd.Caption = "���|�敪";
            // �����`�[�ԍ�
            DataColumn PartySaleSlipNum = new DataColumn(CT_SaleDepo_PartySaleSlipNum, typeof(String), "", MappingType.Element);
            PartySaleSlipNum.Caption = "�����`�[�ԍ�";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
            // �ԍ��A���󒍔ԍ�
            //DataColumn DebitNLnkAcptAnOdr = new DataColumn(CT_SaleDepo_DebitNLnkAcptAnOdr, typeof(String), "", MappingType.Element);
            //DebitNLnkAcptAnOdr.Caption = "�ԍ��A���󒍔ԍ�";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            // ����`�[���v�i�ō��݁j
            DataColumn SalesTotalTaxInc = new DataColumn(CT_SaleDepo_SalesTotalTaxInc, typeof(System.Int64), "", MappingType.Element);
            SalesTotalTaxInc.Caption = "����`�[���v(�ō���)";
            // ������z(�Ŕ���)
            DataColumn SalesTotalTaxExc = new DataColumn(CT_SaleDepo_SalesTotalTaxExc, typeof(System.Int64), "", MappingType.Element);
            SalesTotalTaxExc.Caption = "����`�[���v(�Ŕ���)";
            // ����`�[����Ŋz
            DataColumn SalesTotalTax = new DataColumn(CT_SaleDepo_SalesTotalTax, typeof(System.Int64), "", MappingType.Element);
            SalesTotalTax.Caption = "����`�[����Ŋz";
            // �`�[���l
            DataColumn SlipNote = new DataColumn(CT_SaleDepo_SlipNote, typeof(String), "", MappingType.Element);
            SlipNote.Caption = "�`�[���l";
            // �`�[���l�Q
            DataColumn SlipNote2 = new DataColumn(CT_SaleDepo_SlipNote2, typeof(String), "", MappingType.Element);
            SlipNote2.Caption = "�`�[���l�Q";
            // ����s�ԍ�                          
            DataColumn SalesRowNo = new DataColumn(CT_SaleDepo_SalesRowNo, typeof(System.Int32), "", MappingType.Element);
            SalesRowNo.Caption = "����s�ԍ�";
            // ����`�[�敪�i���ׁj                          
            DataColumn SalesSlipCdDtl = new DataColumn(CT_SaleDepo_SalesSlipCdDtl, typeof(String), "", MappingType.Element);
            SalesSlipCdDtl.Caption = "����`�[�敪�i���ׁj";
            // �󒍔ԍ�                          
            DataColumn AcceptAnOrderNo = new DataColumn(CT_SaleDepo_AcceptAnOrderNo, typeof(String), "", MappingType.Element);
            AcceptAnOrderNo.Caption = "�󒍔ԍ�";
            // ���[�J�[�R�[�h                          
            DataColumn GoodsMakerCd = new DataColumn(CT_SaleDepo_GoodsMakerCd, typeof(System.Int32), "", MappingType.Element);
            GoodsMakerCd.Caption = "���[�J�[�R�[�h";
            // ���[�J�[����                          
            DataColumn MakerName = new DataColumn(CT_SaleDepo_MakerName, typeof(String), "", MappingType.Element);
            MakerName.Caption = "���[�J�[����";
            // ���i�ԍ�
            DataColumn GoodsNo = new DataColumn(CT_SaleDepo_GoodsNo, typeof(String), "", MappingType.Element);
            GoodsNo.Caption = "���i�ԍ�";
            // ���i��
            DataColumn GoodsName = new DataColumn(CT_SaleDepo_GoodsName, typeof(String), "", MappingType.Element);
            GoodsName.Caption = "���i��";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
            //// ���i�敪�R�[�h
            //DataColumn MediumGoodsGanreCode = new DataColumn(CT_SaleDepo_MediumGoodsGanreCode, typeof(String), "", MappingType.Element);
            //MediumGoodsGanreCode.Caption = "���i�敪�R�[�h";
            //// ���i�敪��
            //DataColumn MediumGoodsGanreName = new DataColumn(CT_SaleDepo_MediumGoodsGanreName, typeof(String), "", MappingType.Element);
            //MediumGoodsGanreName.Caption = "���i�敪��";
            //// ���i�敪�O���[�v�R�[�h
            //DataColumn LargeGoodsGanreCode = new DataColumn(CT_SaleDepo_LargeGoodsGanreCode, typeof(String), "", MappingType.Element);
            //LargeGoodsGanreCode.Caption = "���i�敪�O���[�v�R�[�h";
            //// ���i�敪�O���[�v��
            //DataColumn LargeGoodsGanreName = new DataColumn(CT_SaleDepo_LargeGoodsGanreName, typeof(String), "", MappingType.Element);
            //LargeGoodsGanreName.Caption = "���i�敪�O���[�v��";
            //// ���i�敪�ڍ׃R�[�h
            //DataColumn DetailGoodsGanreCode = new DataColumn(CT_SaleDepo_DetailGoodsGanreCode, typeof(String), "", MappingType.Element);
            //DetailGoodsGanreCode.Caption = "���i�敪�ڍ׃R�[�h";
            //// ���i�敪�ڍז���
            //DataColumn DetailGoodsGanreName = new DataColumn(CT_SaleDepo_DetailGoodsGanreName, typeof(String), "", MappingType.Element);
            //DetailGoodsGanreName.Caption = "���i�敪�ڍז���";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            // BL���i�R�[�h                          
            DataColumn BLGoodsCode = new DataColumn(CT_SaleDepo_BLGoodsCode, typeof(System.Int32), "", MappingType.Element);
            BLGoodsCode.Caption = "BL���i�R�[�h";
            // BL���i�R�[�h����
            DataColumn BLGoodsFullName = new DataColumn(CT_SaleDepo_BLGoodsFullName, typeof(String), "", MappingType.Element);
            BLGoodsFullName.Caption = "BL���i�R�[�h����";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
            //// ���Е��ރR�[�h
            //DataColumn EnterpriseGanreCode = new DataColumn(CT_SaleDepo_EnterpriseGanreCode, typeof(System.Int32), "", MappingType.Element);
            //EnterpriseGanreCode.Caption = "���Е��ރR�[�h";
            //// ���Е��ޖ���
            //DataColumn EnterpriseGanreName = new DataColumn(CT_SaleDepo_EnterpriseGanreName, typeof(String), "", MappingType.Element);
            //EnterpriseGanreName.Caption = "���Е��ޖ���";
            //// �P�ʃR�[�h
            //DataColumn UnitCode = new DataColumn(CT_SaleDepo_UnitCode, typeof(System.Int32), "", MappingType.Element);
            //UnitCode.Caption = "�P�ʃR�[�h";
            //// �P�ʖ���
            //DataColumn UnitName = new DataColumn(CT_SaleDepo_UnitName, typeof(String), "", MappingType.Element);
            //UnitName.Caption = "�P�ʖ���";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            // ����P���i�ō��C�����j
            DataColumn SalesUnPrcTaxIncFl = new DataColumn(CT_SaleDepo_SalesUnPrcTaxIncFl, typeof(System.Double), "", MappingType.Element);
            SalesUnPrcTaxIncFl.Caption = "����P���i�ō��C�����j";
            // ����P���i�Ŕ��C�����j
            DataColumn SalesUnPrcTaxExcFl = new DataColumn(CT_SaleDepo_SalesUnPrcTaxExcFl, typeof(System.Double), "", MappingType.Element);
            SalesUnPrcTaxExcFl.Caption = "����P���i�ō��C�����j";
            // �o�א�
            DataColumn ShipmentCnt = new DataColumn(CT_SaleDepo_ShipmentCnt, typeof(System.Double), "", MappingType.Element);
            ShipmentCnt.Caption = "�o�א�";
            // ������z�i�ō��݁j
            DataColumn SalesMoneyTaxInc = new DataColumn(CT_SaleDepo_SalesMoneyTaxInc, typeof(System.Int64), "", MappingType.Element);
            SalesMoneyTaxInc.Caption = "������z�i�ō��݁j";
            // ������z�i�Ŕ����j
            DataColumn SalesMoneyTaxExc = new DataColumn(CT_SaleDepo_SalesMoneyTaxExc, typeof(System.Int64), "", MappingType.Element);
            SalesMoneyTaxExc.Caption = "������z�i�Ŕ����j";
            // ������z�i�Ŕ��� ����p�j
            DataColumn SalesMoneyTaxExc1 = new DataColumn(CT_SaleDepo_SalesMoneyTaxExc1, typeof(System.Int64), "", MappingType.Element);
            SalesMoneyTaxExc1.Caption = "������z�i�Ŕ��� ����p�j";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
            //// ����Œ����z
            //DataColumn TaxAdjust = new DataColumn(CT_SaleDepo_TaxAdjust, typeof(System.Int64), "", MappingType.Element);
            //TaxAdjust.Caption = "����Œ����z";
            //// �c�������z
            //DataColumn BalanceAdjust = new DataColumn(CT_SaleDepo_BalanceAdjust, typeof(System.Int64), "", MappingType.Element);
            //BalanceAdjust.Caption = "�c�������z";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            // �ېŋ敪
            DataColumn TaxationDivCd = new DataColumn(CT_SaleDepo_TaxationDivCd, typeof(System.Int64), "", MappingType.Element);
            TaxationDivCd.Caption = "�ېŋ敪";
            // �����`�[�ԍ��i���ׁj
            DataColumn PartySlipNumDtl = new DataColumn(CT_SaleDepo_PartySlipNumDtl, typeof(String), "", MappingType.Element);
            PartySlipNumDtl.Caption = "�����`�[�ԍ��i���ׁj";
            // ���ה��l
            DataColumn DtlNote = new DataColumn(CT_SaleDepo_DtlNote, typeof(String), "", MappingType.Element);
            DtlNote.Caption = "���ה��l";
            // �`�[�����P
            DataColumn SlipMemo1 = new DataColumn(CT_SaleDepo_SlipMemo1, typeof(String), "", MappingType.Element);
            SlipMemo1.Caption = "�`�[�����P";
            // �`�[�����Q
            DataColumn SlipMemo2 = new DataColumn(CT_SaleDepo_SlipMemo2, typeof(String), "", MappingType.Element);
            SlipMemo2.Caption = "�`�[�����Q";
            // �`�[�����R
            DataColumn SlipMemo3 = new DataColumn(CT_SaleDepo_SlipMemo3, typeof(String), "", MappingType.Element);
            SlipMemo3.Caption = "�`�[�����R";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
            //// �`�[�����S
            //DataColumn SlipMemo4 = new DataColumn(CT_SaleDepo_SlipMemo4, typeof(String), "", MappingType.Element);
            //SlipMemo4.Caption = "�`�[�����S";
            //// �`�[�����T
            //DataColumn SlipMemo5 = new DataColumn(CT_SaleDepo_SlipMemo5, typeof(String), "", MappingType.Element);
            //SlipMemo5.Caption = "�`�[�����T";
            //// �`�[�����U
            //DataColumn SlipMemo6 = new DataColumn(CT_SaleDepo_SlipMemo6, typeof(String), "", MappingType.Element);
            //SlipMemo6.Caption = "�`�[�����U";
            //// ����p���i�ԍ�
            //DataColumn PrtGoodsNo = new DataColumn(CT_SaleDepo_PrtGoodsNo, typeof(String), "", MappingType.Element);
            //PrtGoodsNo.Caption = "����p���i�ԍ�";
            //// ����p���i����
            //DataColumn PrtGoodsName = new DataColumn(CT_SaleDepo_PrtGoodsName, typeof(String), "", MappingType.Element);
            //PrtGoodsName.Caption = "����p���i����";
            //// ����p���i���[�J�[�R�[�h
            //DataColumn PrtGoodsMakerCd = new DataColumn(CT_SaleDepo_PrtGoodsMakerCd, typeof(String), "", MappingType.Element);
            //PrtGoodsMakerCd.Caption = "����p���i���[�J�[�R�[�h";
            //// ����p���i���[�J�[����
            //DataColumn PrtGoodsMakerNm = new DataColumn(CT_SaleDepo_PrtGoodsMakerNm, typeof(String), "", MappingType.Element);
            //PrtGoodsMakerNm.Caption = "����p���i���[�J�[����";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            // �v�㋒�_�R�[�h
            DataColumn AddUpSecCode = new DataColumn(CT_SaleDepo_AddUpSecCode, typeof(String), "", MappingType.Element);
            AddUpSecCode.Caption = "�v�㋒�_�R�[�h";
            // �v�㋒�_����
            DataColumn AddUpSecName = new DataColumn(CT_SaleDepo_AddUpSecName, typeof(String), "", MappingType.Element);
            AddUpSecName.Caption = "�v�㋒�_����";
            // �v����t(����p)
            DataColumn AddUpADatePrint = new DataColumn(CT_SaleDepo_AddUpADatePrint, typeof(String), "", MappingType.Element);
            AddUpADatePrint.Caption = "�v����t(����p)";
            // ����p����(0:�v���[�g�ԍ��w�b�_�[�p,1:����ȊO)
            DataColumn PrintDetailHeaderOder = new DataColumn(CT_SaleDepo_PrintDetailHeaderOder, typeof(System.Int32), "", MappingType.Element);
            PrintDetailHeaderOder.Caption = "����p����";

            ds.Tables.AddRange(new DataTable[] { dt });
            dt.Columns.AddRange(new DataColumn[]{
                                                 ClaimCode,
                                                 ClaimName,
                                                 ClaimName2,
                                                 ClaimSnm,
                                                 CustomerCode,
                                                 CustomerName,
                                                 CustomerName2,
                                                 CustomerSnm,
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
                                                 //DebitNoteDiv,
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
                                                 AddUpADate,
                                                 AddUpADateDisp,
                                                 DataInputSystem,
                                                 SalesSlipNum,
                                                 SalesSlipCd,
                                                 AccRecDivCd,
                                                 PartySaleSlipNum,
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
                                                 //DebitNLnkAcptAnOdr,
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
                                                 SalesTotalTaxInc,
                                                 SalesTotalTaxExc,
                                                 SalesTotalTax,
                                                 SlipNote,
                                                 SlipNote2,
                                                 SalesRowNo,
                                                 SalesSlipCdDtl,
                                                 AcceptAnOrderNo,
                                                 GoodsMakerCd,
                                                 MakerName,
                                                 GoodsNo,
                                                 GoodsName, 
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
                                                 //MediumGoodsGanreCode,
                                                 //MediumGoodsGanreName,
                                                 //LargeGoodsGanreCode,
                                                 //LargeGoodsGanreName,
                                                 //DetailGoodsGanreCode,
                                                 //DetailGoodsGanreName,
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
                                                 BLGoodsCode,
                                                 BLGoodsFullName,
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
                                                 //EnterpriseGanreCode,
                                                 //EnterpriseGanreName,
                                                 //UnitCode,
                                                 //UnitName,
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
                                                 SalesUnPrcTaxIncFl,
                                                 SalesUnPrcTaxExcFl,
                                                 ShipmentCnt,
                                                 SalesMoneyTaxInc,
                                                 SalesMoneyTaxExc,
                                                 SalesMoneyTaxExc1,  
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
                                                 //TaxAdjust, 
                                                 //BalanceAdjust,
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
                                                 TaxationDivCd,
                                                 PartySlipNumDtl,
                                                 DtlNote,
                                                 SlipMemo1,
                                                 SlipMemo2,
                                                 SlipMemo3,
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
                                                 //SlipMemo4,
                                                 //SlipMemo5,
                                                 //SlipMemo6,
                                                 //PrtGoodsNo,
                                                 //PrtGoodsName, 
                                                 //PrtGoodsMakerCd,
                                                 //PrtGoodsMakerNm,
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
                                                 AddUpSecCode,
                                                 AddUpSecName,
                                                 AddUpADatePrint,
                                                 PrintDetailHeaderOder
                                               });
        }
        #endregion
        
        #region �������׃e�[�u�����쐬����
        /// <summary>
        /// �������׃e�[�u�����쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public void CreateDepoTable(ref DataSet ds)
        {
            DataTable dt = new DataTable(CT_DepoDataTable);

            // �f�[�^�J�������쐬
            // ������R�[�h
            DataColumn ClaimCode = new DataColumn(CT_SaleDepo_ClaimCode, typeof(System.Int32), "", MappingType.Element);
            ClaimCode.Caption = "������R�[�h";
            // �����於
            DataColumn ClaimName = new DataColumn(CT_SaleDepo_ClaimName, typeof(String), "", MappingType.Element);
            ClaimName.Caption = "�����於��";
            // �����於2
            DataColumn ClaimName2 = new DataColumn(CT_SaleDepo_ClaimName2, typeof(String), "", MappingType.Element);
            ClaimName2.Caption = "�����於��2";
            // �����旪��
            DataColumn ClaimSnm = new DataColumn(CT_SaleDepo_ClaimSnm, typeof(String), "", MappingType.Element);
            ClaimSnm.Caption = "�����旪��";
            // ���Ӑ�R�[�h
            DataColumn CustomerCode = new DataColumn(CT_SaleDepo_CustomerCode, typeof(System.Int32), "", MappingType.Element);
            CustomerCode.Caption = "���Ӑ�R�[�h";
            // ���Ӑ於
            DataColumn CustomerName = new DataColumn(CT_SaleDepo_CustomerName, typeof(String), "", MappingType.Element);
            CustomerName.Caption = "���Ӑ於��";
            // ���Ӑ於2
            DataColumn CustomerName2 = new DataColumn(CT_SaleDepo_CustomerName2, typeof(String), "", MappingType.Element);
            CustomerName2.Caption = "���Ӑ於��2";
            // ���Ӑ旪��
            DataColumn CustomerSnm = new DataColumn(CT_SaleDepo_CustomerSnm, typeof(String), "", MappingType.Element);
            CustomerSnm.Caption = "���Ӑ旪��";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
            //// �ԓ`�敪(0:��,1:��,2���E�ςݍ�)
            //DataColumn DebitNoteDiv = new DataColumn(CT_SaleDepo_DebitNoteDiv, typeof(System.Int32), "", MappingType.Element);
            //DebitNoteDiv.Caption = "�ԓ`�敪";
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            // �v����t
            DataColumn AddUpADate = new DataColumn(CT_SaleDepo_AddUpADate, typeof(System.DateTime), "", MappingType.Element);
            AddUpADate.Caption = "�v����t";
            // �v����t(�\���p)
            DataColumn AddUpADateDisp = new DataColumn(CT_SaleDepo_AddUpADateDisp, typeof(String), "", MappingType.Element);
            AddUpADateDisp.Caption = "�v����t";
            // �f�[�^���̓V�X�e��
            DataColumn DataInputSystem = new DataColumn(CT_SaleDepo_DataInputSystem, typeof(System.Int32), "", MappingType.Element);
            DataInputSystem.Caption = "�f�[�^���̓V�X�e��";
            // �ԍ������A���ԍ�
            DataColumn DebitNoteLinkDepoNo = new DataColumn(CT_SaleDepo_DebitNoteLinkDepoNo, typeof(System.Int32), "", MappingType.Element);
            DebitNoteLinkDepoNo.Caption = "�ԍ������A���ԍ�";
            // �����`�[�ԍ�
            DataColumn DepositSlipNo = new DataColumn(CT_SaleDepo_DepositSlipNo, typeof(System.Int32), "", MappingType.Element);
            DepositSlipNo.Caption = "�����`�[�ԍ�";
            // ��������R�[�h
            DataColumn DepositKindCode = new DataColumn(CT_SaleDepo_DepositKindCode, typeof(Int32), "", MappingType.Element);
            DepositKindCode.Caption = "��������R�[�h";
            // �������햼��
            DataColumn DepositKindName = new DataColumn(CT_SaleDepo_DepositKindName, typeof(String), "", MappingType.Element);
            DepositKindName.Caption = "�������햼��";
            // �����v
            DataColumn DepositTotal = new DataColumn(CT_SaleDepo_DepositTotal, typeof(System.Int64), "", MappingType.Element);
            DepositTotal.Caption = "�����v";
            // �`�[�E�v
            DataColumn Outline = new DataColumn(CT_SaleDepo_Outline, typeof(String), "", MappingType.Element);
            Outline.Caption = "�`�[�E�v";
            // �v�㋒�_�R�[�h
            DataColumn AddUpSecCode = new DataColumn(CT_SaleDepo_AddUpSecCode, typeof(String), "", MappingType.Element);
            AddUpSecCode.Caption = "�v�㋒�_�R�[�h";
            // �v�㋒�_����
            DataColumn AddUpSecName = new DataColumn(CT_SaleDepo_AddUpSecName, typeof(String), "", MappingType.Element);
            AddUpSecName.Caption = "�v�㋒�_����";
            // �v����t(����p)
            DataColumn AddUpADatePrint = new DataColumn(CT_SaleDepo_AddUpADatePrint, typeof(String), "", MappingType.Element);
            AddUpADatePrint.Caption = "�v����t(����p)";
            // ��`���
            DataColumn DraftKind = new DataColumn(CT_SaleDepo_DraftKind, typeof(System.Int32), "", MappingType.Element);
            DraftKind.Caption = "��`���";
            // ��`��ޖ���
            DataColumn DraftKindName = new DataColumn(CT_SaleDepo_DraftKindName, typeof(String), "", MappingType.Element);
            DraftKindName.Caption = "��`��ޖ���";
            // ��`�敪
            DataColumn DraftDivide = new DataColumn(CT_SaleDepo_DraftDivide, typeof(System.Int32), "", MappingType.Element);
            DraftDivide.Caption = "��`�敪";
            // ��`�敪����
            DataColumn DraftDivideName = new DataColumn(CT_SaleDepo_DraftDivideName, typeof(String), "", MappingType.Element);
            DraftDivideName.Caption = "��`�敪����";
            // ��`�ԍ�
            DataColumn DraftNo = new DataColumn(CT_SaleDepo_DraftNo, typeof(String), "", MappingType.Element);
            DraftNo.Caption = "��`�ԍ�";

            ds.Tables.AddRange(new DataTable[] { dt });
            dt.Columns.AddRange(new DataColumn[]{
                                                 ClaimCode,
                                                 ClaimName,
                                                 ClaimName2,
                                                 ClaimSnm,
                                                 CustomerCode,
                                                 CustomerName,
                                                 CustomerName2,
                                                 CustomerSnm,
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
                                                 //DebitNoteDiv,
                                                 // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
                                                 AddUpADate,
                                                 AddUpADateDisp,
                                                 DataInputSystem,
                                                 DebitNoteLinkDepoNo,
                                                 DepositSlipNo,
                                                 DepositKindCode,
                                                 DepositKindName,
                                                 DepositTotal,
                                                 Outline,
                                                 AddUpSecCode,
                                                 AddUpSecName,
                                                 AddUpADatePrint,
                                                 DraftKind,
                                                 DraftKindName,
                                                 DraftDivide,
                                                 DraftDivideName,
                                                 DraftNo
                                               });
        }
        #endregion
        
        /// <summary>
        /// ���Ӑ搿�����z���f�[�^�s�ݒ菈��(����)
        /// </summary>
        /// <param name="kingetCustDmdPrcWork">����KINGET�߂�p�����[�^</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note        : ���Ӑ搿�����z�����f�[�^�s�֐ݒ肵�܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// <br>Note       : Redmine#47028�̐����ꗗ�\Out Of Memory�̑Ή�</br>
        /// <br>Programer  : ���V��</br>
        /// <br>Date       : 2015/09/17</br>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private DataRow CustDmdPrcWorkToDataRow(ExtrInfo_DemandTotal extraInfo, RsltInfo_DemandTotalWork rsltInfo_DemandTotalWork)
        {
            DataRow newRow = _custDmdPrcDataTable.NewRow();

            // 2009.01.19 30413 ���� �e���Ӑ����̏�����ǉ� >>>>>>START
            if (extraInfo.PrCustDtl == 0)
            {
                // ������Ɋ܂�
                if ((extraInfo.DmdDtl == 0) || (extraInfo.DmdDtl == 2))
                {
                    // 2009.02.06 30413 ���� �v�㋒�_�Ǝ��ы��_���r�Ώۂɒǉ� >>>>>>START
                    // ��������"����"�܂���"���Ӑ�"
                    //if (rsltInfo_DemandTotalWork.ClaimCode == rsltInfo_DemandTotalWork.CustomerCode)
                    if ((rsltInfo_DemandTotalWork.ClaimCode == rsltInfo_DemandTotalWork.CustomerCode) &&
                        (rsltInfo_DemandTotalWork.AddUpSecCode.TrimEnd().Equals(rsltInfo_DemandTotalWork.ResultsSectCd.TrimEnd())))
                    {
                        // �e���R�[�h�͒��o�ΏۊO
                        return null;
                    }
                    // 2009.02.06 30413 ���� �v�㋒�_�Ǝ��ы��_���r�Ώۂɒǉ� <<<<<<END
                }
            }
            // 2009.01.19 30413 ���� �e���Ӑ����̏�����ǉ� <<<<<<END

            // 2009.03.12 30413 ���� ���|�敪�̏�����ǉ� >>>>>>START
            if (extraInfo.SlipPrtKind == 0)
            {
                // ���s�^�C�v�F�����ꗗ�\
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
            //------------ADD BY ������ on 2011/11/28 for Redmine#7765 --------->>>>>>>>>>>
            //------------DEL BY ������ on 2011/11/17 for Redmine#7765 --------->>>>>>>>>>>
            else
            {
                // ���s�^�C�v�F�������^�̎���
                if (rsltInfo_DemandTotalWork.AccRecDivCd == 0)
                {
                    // ���|�敪��"���|"�ȊO�͒��o�ΏۊO
                    return null;
                }
            }
            //------------DEL BY ������ on 2011/11/17 for Redmine#7765 ---------<<<<<<<<<<<<<
            //------------ADD BY ������ on 2011/11/28 for Redmine#7765 ---------<<<<<<<<<<<<<
            // 2009.03.12 30413 ���� ���|�敪�̏�����ǉ� <<<<<<END
            
            // ���R�[�h�^�C�v
            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                newRow[CT_CsDmd_DataType] = true;
            }
            else
            {
                newRow[CT_CsDmd_DataType] = false;
            }

            // ADD 2009/04/20 ------>>>
            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                newRow[CT_CsDmd_RecordName] = "�W�v���R�[�h";
            }
            else if ((rsltInfo_DemandTotalWork.ClaimCode == rsltInfo_DemandTotalWork.CustomerCode) && 
                     (rsltInfo_DemandTotalWork.AddUpSecCode.TrimEnd().Equals(rsltInfo_DemandTotalWork.ResultsSectCd.TrimEnd())))
            {
                newRow[CT_CsDmd_RecordName] = "�e���R�[�h";
            }
            else
            {
                newRow[CT_CsDmd_RecordName] = "�q���R�[�h";
            }
            // ADD 2009/04/20 ------<<<

            // ����t���O
            newRow[CT_CsDmd_PrintFlag] = true;

            string secCode = rsltInfo_DemandTotalWork.AddUpSecCode;

            // �v�㋒�_�R�[�h
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
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //// �������p�^�[���ԍ�
            //newRow[CT_CsDmd_DemandPtnNo] = rsltInfo_DemandTotalWork.DemandPtnNo;

            //// �������׏��p�^�[���ԍ�
            //newRow[CT_CsDmd_DmdDtlPtnNo] = rsltInfo_DemandTotalWork.DmdDtlPtnNo;
            // 2008.09.05 30413 ���� �폜���� <<<<<<END

            string claimSecCode = rsltInfo_DemandTotalWork.ClaimSectionCode;
            // �������_�R�[�h
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

            // 2009.01.21 30413 ���� ���ڒǉ� >>>>>>START
            // ���ы��_�R�[�h
            newRow[CT_CsDmd_ResultsSectCd] = rsltInfo_DemandTotalWork.ResultsSectCd;
            // 2009.01.21 30413 ���� ���ڒǉ� <<<<<<END
        
            // ������R�[�h
            newRow[CT_CsDmd_ClaimCode] = rsltInfo_DemandTotalWork.ClaimCode;

            // 2008.11.19 30413 ���� ���o���ʕ\���p >>>>>>START
            // ������R�[�h(���o���ʕ\���p)
            newRow[CT_CsDmd_ClaimCodeDisp] = rsltInfo_DemandTotalWork.ClaimCode.ToString("d08");
            // 2008.11.19 30413 ���� ���o���ʕ\���p <<<<<<END
            
            // �����於��
            newRow[CT_CsDmd_ClaimName] = rsltInfo_DemandTotalWork.ClaimName;

            // �����於��2
            newRow[CT_CsDmd_ClaimName2] = rsltInfo_DemandTotalWork.ClaimName2;

            // �����旪��
            // 2010/07/01 >>>
            //newRow[CT_CsDmd_ClaimSnm] = rsltInfo_DemandTotalWork.ClaimSnm;
            newRow[CT_CsDmd_ClaimSnm] = nameJoin(rsltInfo_DemandTotalWork.ClaimName, rsltInfo_DemandTotalWork.ClaimName2);
            // 2010/07/01 <<<

            // 2008.11.14 30413 ���� �W�v���R�[�h�̓��Ӑ於�̂Ɨ��͕̂ύX���Ȃ� >>>>>>START
            // ���Ӑ�R�[�h
            //if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            //{
            //    newRow[CT_CsDmd_CustomerCode] = rsltInfo_DemandTotalWork.ClaimCode;
            //}
            //else
            //{
            //    newRow[CT_CsDmd_CustomerCode] = rsltInfo_DemandTotalWork.CustomerCode;
            //}
            newRow[CT_CsDmd_CustomerCode] = rsltInfo_DemandTotalWork.CustomerCode;

            // ���Ӑ於��
            newRow[CT_CsDmd_CustomerName] = rsltInfo_DemandTotalWork.CustomerName;

            // ���Ӑ於��2
            newRow[CT_CsDmd_CustomerName2] = rsltInfo_DemandTotalWork.CustomerName2;

            // ���Ӑ旪��
            //if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            //{
            //    newRow[CT_CsDmd_CustomerSnm] = rsltInfo_DemandTotalWork.ClaimSnm;
            //}
            //else
            //{
            //    newRow[CT_CsDmd_CustomerSnm] = rsltInfo_DemandTotalWork.CustomerSnm;
            //}
            // 2010/07/01 >>>
            //newRow[CT_CsDmd_CustomerSnm] = rsltInfo_DemandTotalWork.CustomerSnm;
            newRow[CT_CsDmd_CustomerSnm] = nameJoin(rsltInfo_DemandTotalWork.CustomerName, rsltInfo_DemandTotalWork.CustomerName2);
            // 2010/07/01 <<<
            // 2008.11.14 30413 ���� �W�v���R�[�h�̓��Ӑ於�̂Ɨ��͕̂ύX���Ȃ� <<<<<<END

            // 2008.11.19 30413 ���� ���o���ʕ\���p >>>>>>START
            // ���Ӑ�R�[�h(���o���ʕ\���p)
            newRow[CT_CsDmd_CustomerCodeDisp] = rsltInfo_DemandTotalWork.CustomerCode.ToString("d08");

            // ���Ӑ旪��(���o���ʕ\���p)
            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                // 2010/07/01 >>>
                //newRow[CT_CsDmd_CustomerSnmDisp] = rsltInfo_DemandTotalWork.ClaimSnm;
                newRow[CT_CsDmd_CustomerSnmDisp] = nameJoin(rsltInfo_DemandTotalWork.ClaimName, rsltInfo_DemandTotalWork.ClaimName2);
                // 2010/07/01 <<<
            }
            else
            {
                // 2010/07/01 >>>
                //newRow[CT_CsDmd_CustomerSnmDisp] = rsltInfo_DemandTotalWork.CustomerSnm;
                newRow[CT_CsDmd_CustomerSnmDisp] = nameJoin(rsltInfo_DemandTotalWork.CustomerName, rsltInfo_DemandTotalWork.CustomerName2);
                // 2010/07/01 <<<
            }
            // 2008.11.19 30413 ���� ���o���ʕ\���p <<<<<<END
            
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
            // 2009.01.28 30413 ���� �v�Z����ύX >>>>>>START
            // 2009.01.16 30413 ���� �v�Z����ύX >>>>>>START
            // 2008.09.08 30413 ���� �v�Z����ύX >>>>>>START
            //Int64 ofsThisSalesSum = rsltInfo_DemandTotalWork.OfsThisTimeSales + rsltInfo_DemandTotalWork.OfsThisSalesTax;
            // ����J�z�c��(�����v)�{���E�㍡�񔄏���z�{���񔄏�ԕi���z�{���񔄏�l�����z�{���E�㍡�񔄏�����
            //Int64 ofsThisSalesSum = rsltInfo_DemandTotalWork.ThisTimeTtlBlcDmd + rsltInfo_DemandTotalWork.OfsThisTimeSales
            //                      + rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis
            //                      + rsltInfo_DemandTotalWork.OfsThisSalesTax;
            // ����J�z�c��(�����v)�{���E�㍡�񔄏���z�{���E�㍡�񔄏�����
            //Int64 ofsThisSalesSum = rsltInfo_DemandTotalWork.ThisTimeTtlBlcDmd + rsltInfo_DemandTotalWork.OfsThisTimeSales
            //                      + rsltInfo_DemandTotalWork.OfsThisSalesTax;
            // ���E�㍡�񔄏���z�{���E�㍡�񔄏�����
            Int64 ofsThisSalesSum = rsltInfo_DemandTotalWork.OfsThisTimeSales + rsltInfo_DemandTotalWork.OfsThisSalesTax;
            newRow[CT_CsDmd_OfsThisSalesSum] = ofsThisSalesSum;
            // 2008.09.08 30413 ���� �v�Z����ύX <<<<<<END
            // 2009.01.16 30413 ���� �v�Z����ύX <<<<<<END
            // 2009.01.28 30413 ���� �v�Z����ύX <<<<<<END
            
            // ���񔄏���z
            newRow[CT_CsDmd_ThisTimeSales] = rsltInfo_DemandTotalWork.ThisTimeSales;

            // ���񔄏�ԕi���z
            newRow[CT_CsDmd_ThisSalesPricRgds] = rsltInfo_DemandTotalWork.ThisSalesPricRgds;

            // ���񔄏�l�����z
            newRow[CT_CsDmd_ThisSalesPricDis] = rsltInfo_DemandTotalWork.ThisSalesPricDis;

            // 2009.02.05 30413 ���� �������t�ɏC�� >>>>>>START
            // ���񔄏�ԕi�E�l�����z
            //newRow[CT_CsDmd_ThisSalesPricRgdsDis] = (Int64)(rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis);
            long thisSalesPricRgdsDis = (Int64)(rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis);
            newRow[CT_CsDmd_ThisSalesPricRgdsDis] = -thisSalesPricRgdsDis;
            // 2009.02.05 30413 ���� �������t�ɏC�� <<<<<<END
            
            // �c�������z
            newRow[CT_CsDmd_BalanceAdjust] = rsltInfo_DemandTotalWork.BalanceAdjust;

            // �v�Z�㐿�����z
            newRow[CT_CsDmd_AfCalDemandPrice] = rsltInfo_DemandTotalWork.AfCalDemandPrice;

            // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� >>>>>>START
            // �v�Z�㐿�����z���L���b�V���o�^
            string key = secCode.TrimEnd() + "-" + rsltInfo_DemandTotalWork.ClaimCode.ToString("d08");
            if ((bool)newRow[CT_CsDmd_DataType])
            {
                // �W�v���R�[�h
                if (!afCalDemandPriceDic.ContainsKey(key))
                {
                    afCalDemandPriceDic.Add(key, rsltInfo_DemandTotalWork.AfCalDemandPrice);
                }
            }
            // 2009.01.21 30413 ���� �v�Z�㐿�����z(�t�B���^�[�p)��ǉ� <<<<<<END
                            
            // ����`�[����
            newRow[CT_CsDmd_SaleslSlipCount] = rsltInfo_DemandTotalWork.SalesSlipCount;

            // ���������s��
            newRow[CT_CsDmd_BillPrintDate] = rsltInfo_DemandTotalWork.BillPrintDate;

            // ���������s��(����p)
            newRow[CT_CsDmd_BillPrintDatePrt] = TDateTime.DateTimeToString("", rsltInfo_DemandTotalWork.BillPrintDate);

            // �����\���
            newRow[CT_CsDmd_ExpectedDepositDate] = rsltInfo_DemandTotalWork.ExpectedDepositDate;

            // �����\���(����p)
            newRow[CT_CsDmd_ExpectedDepositDatePrt] = TDateTime.DateTimeToString("", rsltInfo_DemandTotalWork.ExpectedDepositDate);

            // �������
            switch (rsltInfo_DemandTotalWork.CollectCond)
            {
                case 10:
                    {
                        newRow[CT_CsDmd_CollectCond] = "����";
                        break;
                    }
                case 20:
                    {
                        newRow[CT_CsDmd_CollectCond] = "�U��";
                        break;
                    }
                case 30:
                    {
                        newRow[CT_CsDmd_CollectCond] = "���؎�";
                        break;
                    }
                case 40:
                    {
                        newRow[CT_CsDmd_CollectCond] = "��`";
                        break;
                    }
                case 50:
                    {
                        newRow[CT_CsDmd_CollectCond] = "�萔��";
                        break;
                    }
                case 60:
                    {
                        newRow[CT_CsDmd_CollectCond] = "���E";
                        break;
                    }
                case 70:
                    {
                        newRow[CT_CsDmd_CollectCond] = "�l��";
                        break;
                    }
                case 80:
                    {
                        newRow[CT_CsDmd_CollectCond] = "���̑�";
                        break;
                    }
                default:
                    {
                        // 2008.11.05 30413 ���� ��L�ȊO��"���̑�"�Ƃ��� >>>>>>START
                        //newRow[CT_CsDmd_CollectCond] = "";
                        newRow[CT_CsDmd_CollectCond] = "���̑�";
                        // 2008.11.05 30413 ���� ��L�ȊO��"���̑�"�Ƃ��� <<<<<<END
                        break;
                    }
            }

            // ����ŗ� 
            newRow[CT_CsDmd_ConsTaxRate] = rsltInfo_DemandTotalWork.ConsTaxRate;

            // �[�������敪
            newRow[CT_CsDmd_FractionProcCd] = rsltInfo_DemandTotalWork.FractionProcCd;

            // �����X�V���s�N����
            newRow[CT_CsDmd_CAddUpUpdExecDate] = rsltInfo_DemandTotalWork.CAddUpUpdExecDate;

            // �����X�V���s�N����
            newRow[CT_CsDmd_CAddUpUpdExecDatePrt] = TDateTime.DateTimeToString("", rsltInfo_DemandTotalWork.CAddUpUpdExecDate);

            // �����X�V�J�n�N����
            newRow[CT_CsDmd_StartCAddUpUpdDate] = rsltInfo_DemandTotalWork.StartCAddUpUpdDate;

            // �����X�V�J�n�N����(����p)
            newRow[CT_CsDmd_StartCAddUpUpdDatePrt] = TDateTime.DateTimeToString("", rsltInfo_DemandTotalWork.StartCAddUpUpdDate);

            // �O������X�V�N����
            newRow[CT_CsDmd_LastCAddUpUpdDate] = rsltInfo_DemandTotalWork.LastCAddUpUpdDate;

            // �O������X�V�N����(����p)
            newRow[CT_CsDmd_LastCAddUpUpdDatePrt] = TDateTime.DateTimeToString("", rsltInfo_DemandTotalWork.LastCAddUpUpdDate);

            // �v����t(����p)
            newRow[CT_CsDmd_AddUpADatePrint] = TDateTime.DateTimeToString("", rsltInfo_DemandTotalWork.AddUpDate);

            Int64 ttlConsTaxDmd = rsltInfo_DemandTotalWork.OfsThisSalesTax;
            newRow[CT_CsDmd_OfsThisSalesTax] = ttlConsTaxDmd;

            // 2009.01.19 30413 ���� ���o���ʂ̐e���R�[�h�Ǝq���R�[�h�̏���ł̓[���Œ�ɕύX >>>>>>START
            //// �������Łi�󒍏���Ŋz�{����p����Ŋz�j(����p)
            //// ���z�\�����@
            //if (_allDefSet.TotalAmountDispWayCd == 0)
            //{
            //    // ���z�\�����Ȃ��Ŕ��� 
            //    newRow[CT_CsDmd_PrintTtlConsTaxDmd] = ttlConsTaxDmd.ToString("#,##0");
            //}
            //else
            //{
            //    // ���z�\������ō��� 
            //    newRow[CT_CsDmd_PrintTtlConsTaxDmd] = "(" + ttlConsTaxDmd.ToString("#,##0") + ")";
            //}
            // ���R�[�h�^�C�v�̔���
            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                // �W�v���R�[�h�̏ꍇ
                if (_allDefSet.TotalAmountDispWayCd == 0)
                {
                    // ���z�\�����Ȃ��Ŕ��� 
                    newRow[CT_CsDmd_PrintTtlConsTaxDmd] = ttlConsTaxDmd.ToString("#,##0");
                }
                else
                {
                    // ���z�\������ō��� 
                    newRow[CT_CsDmd_PrintTtlConsTaxDmd] = "(" + ttlConsTaxDmd.ToString("#,##0") + ")";
                }
            }
            else
            {
                // �e���R�[�h�Ǝq���R�[�h�̏ꍇ
                newRow[CT_CsDmd_PrintTtlConsTaxDmd] = "0";
            }
            // 2009.01.19 30413 ���� ���o���ʂ̐e���R�[�h�Ǝq���R�[�h�̏���ł̓[���Œ�ɕύX <<<<<<END
            
            // ����p�������z
            newRow[CT_CsDmd_PrintAfCalDemandPrice] = "\\" + rsltInfo_DemandTotalWork.AfCalDemandPrice.ToString("#,##0");
                    

            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                // �O�񐿋��z 
                newRow[CT_CsDmd_ClaimLastTimeDemand] = rsltInfo_DemandTotalWork.LastTimeDemand;
                
                // ����������z�i�ʏ�����j
                newRow[CT_CsDmd_ClaimThisTimeDmdNrml] = rsltInfo_DemandTotalWork.ThisTimeDmdNrml;
                
                // ����J�z�c���i�����v�j
                newRow[CT_CsDmd_ClaimThisTimeTtlBlcDmd] = rsltInfo_DemandTotalWork.ThisTimeTtlBlcDmd;

                // ���񔄏���z
                newRow[CT_CsDmd_ClaimThisTimeSales] = rsltInfo_DemandTotalWork.ThisTimeSales;

                // ���񔄏�ԕi�E�l�����z
                newRow[CT_CsDmd_ClaimThisSalesPricRgdsDis] = (Int64)(rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis);

                // ���E�㍡�񔄏���z
                newRow[CT_CsDmd_ClaimOfsThisTimeSales] = rsltInfo_DemandTotalWork.OfsThisTimeSales;

                // ���E�㍡�񔄏�����
                newRow[CT_CsDmd_ClaimOfsThisSalesTax] = rsltInfo_DemandTotalWork.OfsThisSalesTax;

                // ���E�㍡�񍇌v������z
                newRow[CT_CsDmd_ClaimOfsThisSalesSum] = ofsThisSalesSum;

                // �v�Z�㐿�����z
                newRow[CT_CsDmd_ClaimAfCalDemandPrice] = rsltInfo_DemandTotalWork.AfCalDemandPrice;

                // ����`�[����
                newRow[CT_CsDmd_ClaimSaleslSlipCount] = rsltInfo_DemandTotalWork.SalesSlipCount;
            }

            // *********************
            // ���Ӑ�֘A����
            // *********************
            // ���Ӑ�R�[�h
            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                // ����
                newRow[CT_CsDmd_Name] = rsltInfo_DemandTotalWork.ClaimName;
                // ���̂Q
                newRow[CT_CsDmd_Name2] = rsltInfo_DemandTotalWork.ClaimName2;
            }
            else
            {
                // ����
                newRow[CT_CsDmd_Name] = rsltInfo_DemandTotalWork.CustomerName;
                // ���̂Q
                newRow[CT_CsDmd_Name2] = rsltInfo_DemandTotalWork.CustomerName2;
            }

            // ���Ӑ於�̕ҏW����(����p)
            string custName1 = "";
            string custName2 = "";
            string custNameKei = "";
            string honorificTitle = "";
            string wrkCustNm1 = "";
            string wrkCustNm2 = "";

            // ���Ӑ�R�[�h
            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                wrkCustNm1 = rsltInfo_DemandTotalWork.ClaimName;
                wrkCustNm2 = rsltInfo_DemandTotalWork.ClaimName2;
            }
            else
            {
                wrkCustNm1 = rsltInfo_DemandTotalWork.CustomerName;
                wrkCustNm2 = rsltInfo_DemandTotalWork.CustomerName2;
            }

            // ���̂Q�͐ݒ肳��Ă��邩
            if (TStrUtils.TrimAll(wrkCustNm2) != "")
            {
                custName1 = wrkCustNm1;     // ���̂P�����Ӑ於�̂P 
                custName2 = wrkCustNm2;     // ���̂Q�����Ӑ於�̂Q
            }
            else
            {
                custName2 = wrkCustNm1;     // ���̂Q�����Ӑ於�̂P 
            }

            // �h��
            honorificTitle = rsltInfo_DemandTotalWork.HonorificTitle;
            custNameKei = TStrUtils.TrimAllEnd(custName2) + " " + honorificTitle;

            //// ����p���Ӑ於�̂P
            //newRow[CT_CsDmd_EditCustomerName1] = custName1;

            //// ����p���Ӑ於�̂Q			
            //if (custName2.Length != 0)
            //{
            //    newRow[CT_CsDmd_EditCustomerName2] = custNameKei;
            //}
            //else
            //{
            //    newRow[CT_CsDmd_EditCustomerName2] = "";
            //}

            // �J�i
            newRow[CT_CsDmd_Kana] = rsltInfo_DemandTotalWork.ClaimNameKana;

            // �X�֔ԍ�
            newRow[CT_CsDmd_PostNo] = rsltInfo_DemandTotalWork.PostNo;

            // �Z���P�E�Q�E�R�E�S
            newRow[CT_CsDmd_Address1] = rsltInfo_DemandTotalWork.Address1;
            newRow[CT_CsDmd_Address2] = rsltInfo_DemandTotalWork.Address2;
            newRow[CT_CsDmd_Address3] = rsltInfo_DemandTotalWork.Address3;
            newRow[CT_CsDmd_Address4] = rsltInfo_DemandTotalWork.Address4;

            #region ���@���v�E���א������p�Z���ҏW
            // �Z���ҏW����
            this._beforeConvertAddressParam.Address1 = rsltInfo_DemandTotalWork.Address1;
            this._beforeConvertAddressParam.Address2 = rsltInfo_DemandTotalWork.Address2;
            this._beforeConvertAddressParam.Address3 = rsltInfo_DemandTotalWork.Address3;
            this._beforeConvertAddressParam.Address4 = rsltInfo_DemandTotalWork.Address4;

            this._beforeConvertAddressParam.ByteLength1 = 50;
            this._beforeConvertAddressParam.ByteLength2 = 50;
            this._beforeConvertAddressParam.ByteLength3 = 50;

            _beforeConvertAddressParam.LineCount = 3;

            AddressConverter.ConvertAddressForSlipType(this._beforeConvertAddressParam, out this._afterConvertAddressParam);

            newRow[CT_CsDmd_EditAddress1] = this._afterConvertAddressParam.Address1;
            newRow[CT_CsDmd_EditAddress2] = this._afterConvertAddressParam.Address2;
            newRow[CT_CsDmd_EditAddress3] = this._afterConvertAddressParam.Address3;
            #endregion

            #region ���@�ꗗ�\�p�Z���ҏW
            // �Z���ҏW����
            this._beforeConvertAddressParam.Address1 = rsltInfo_DemandTotalWork.Address1;
            this._beforeConvertAddressParam.Address2 = rsltInfo_DemandTotalWork.Address2;
            this._beforeConvertAddressParam.Address3 = rsltInfo_DemandTotalWork.Address3;
            this._beforeConvertAddressParam.Address4 = rsltInfo_DemandTotalWork.Address4;

            this._beforeConvertAddressParam.ByteLength1 = 50;
            this._beforeConvertAddressParam.ByteLength2 = 50;
            this._beforeConvertAddressParam.ByteLength3 = 50;

            _beforeConvertAddressParam.LineCount = 3;

            AddressConverter.ConvertAddressForReportType(this._beforeConvertAddressParam, out this._afterConvertAddressParam);

            newRow[CT_CsDmd_ListAddress1] = this._afterConvertAddressParam.Address1;
            newRow[CT_CsDmd_ListAddress2] = this._afterConvertAddressParam.Address2;
            newRow[CT_CsDmd_ListAddress3] = this._afterConvertAddressParam.Address3;
            #endregion

            // �d�b�ԍ��i����
            newRow[CT_CsDmd_HomeTelNo] = rsltInfo_DemandTotalWork.HomeTelNo;

            // �d�b�ԍ��i�Ζ���
            newRow[CT_CsDmd_OfficeTelNo] = rsltInfo_DemandTotalWork.OfficeTelNo;

            // �d�b�ԍ��i�g��
            newRow[CT_CsDmd_PortableTelNo] = rsltInfo_DemandTotalWork.PortableTelNo;

            // FAX�ԍ��i����j
            newRow[CT_CsDmd_HomeFaxNo] = rsltInfo_DemandTotalWork.HomeFaxNo;

            // FAX�ԍ��i�Ζ���j
            newRow[CT_CsDmd_OfficeFaxNo] = rsltInfo_DemandTotalWork.OfficeFaxNo;

            // �d�b�ԍ��i���̑��j
            newRow[CT_CsDmd_OthersTelNo] = rsltInfo_DemandTotalWork.OthersTelNo;

            // ��A����敪[0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���]
            newRow[CT_CsDmd_MainContactCode] = rsltInfo_DemandTotalWork.MainContactCode;

            // ��A����敪����
            newRow[CT_CsDmd_MainContactName] = mAlItmDspNmAcs.GetMainContactDspName(rsltInfo_DemandTotalWork.MainContactCode);

            // ��A����d�b�ԍ�
            switch (rsltInfo_DemandTotalWork.MainContactCode)
            {
                case 0:		// �d�b�ԍ��i����j
                    {
                        newRow[CT_CsDmd_MainContactTelNo] = rsltInfo_DemandTotalWork.HomeTelNo;
                        break;
                    }
                case 1:		// �d�b�ԍ��i�Ζ���j
                    {
                        newRow[CT_CsDmd_MainContactTelNo] = rsltInfo_DemandTotalWork.OfficeTelNo;
                        break;
                    }
                case 2:		// �d�b�ԍ��i�g�сj
                    {
                        newRow[CT_CsDmd_MainContactTelNo] = rsltInfo_DemandTotalWork.PortableTelNo;
                        break;
                    }
                case 3:		// FAX�ԍ��i����j
                    {
                        newRow[CT_CsDmd_MainContactTelNo] = rsltInfo_DemandTotalWork.HomeFaxNo;
                        break;
                    }
                case 4:		// FAX�ԍ��i�Ζ���j
                    {
                        newRow[CT_CsDmd_MainContactTelNo] = rsltInfo_DemandTotalWork.OfficeFaxNo;
                        break;
                    }
                case 5:		// �d�b�ԍ��i���̑��j
                    {
                        newRow[CT_CsDmd_MainContactTelNo] = rsltInfo_DemandTotalWork.OthersTelNo;
                        break;
                    }
                default:
                    break;
            }
            
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
                DateTime addUpDate = rsltInfo_DemandTotalWork.AddUpDate;
                DateTime addMonthDate = addUpDate.AddMonths(rsltInfo_DemandTotalWork.CollectMoneyCode);
                int calcIntDate = 0;

                // �����������󎚋敪 = 1(28�`31���͖����ƈ�) ��28���ȍ~�̏ꍇ
                if (rsltInfo_DemandTotalWork.CollectMoneyDay >= 28 && _billPrtSt.BillLastDayPrtDiv == 1)
                {
                    calcIntDate = TDateTime.GetLastDate(TDateTime.DateTimeToLongDate(addMonthDate));
                    newRow[CT_CsDmd_CollectMoneyDayNm] = "����";
                }
                else
                {
                    calcIntDate = (TDateTime.DateTimeToLongDate(addMonthDate)) / 100 * 100 + rsltInfo_DemandTotalWork.CollectMoneyDay;
                    newRow[CT_CsDmd_CollectMoneyDayNm] = String.Format("{0}��", rsltInfo_DemandTotalWork.CollectMoneyDay);
                }

                // 2008.09.08 30413 ���� ���g�p���ڍ폜 >>>>>>START
                //newRow[CT_CsDmd_CollectMoneyDate] = TDateTime.DateTimeToString("", TDateTime.LongDateToDateTime(calcIntDate));  // ��U������(����p)
                //newRow[CT_CsDmd_PaymentMoneyDate] = TDateTime.DateTimeToString("", TDateTime.LongDateToDateTime(calcIntDate));  // ��x������(����p)
                // 2008.09.08 30413 ���� ���g�p���ڍ폜 <<<<<<END
            }
            else
            {
                newRow[CT_CsDmd_CollectMoneyDayNm] = "";
                // 2008.09.08 30413 ���� ���g�p���ڍ폜 >>>>>>START
                //newRow[CT_CsDmd_CollectMoneyDate] = "";  // ��U������(����p)
                //newRow[CT_CsDmd_PaymentMoneyDate]  = "";  // ��x������(����p)
                // 2008.09.08 30413 ���� ���g�p���ڍ폜 <<<<<<END
            }

            // �ڋq�S���]�ƈ��R�[�h
            newRow[CT_CsDmd_CustomerAgentCd] = rsltInfo_DemandTotalWork.CustomerAgentCd;

            // �ڋq�S���]�ƈ�����
            newRow[CT_CsDmd_CustomerAgentNm] = rsltInfo_DemandTotalWork.CustomerAgentNm;

            // �W���S���]�ƈ��R�[�h
            newRow[CT_CsDmd_BillCollecterCd] = rsltInfo_DemandTotalWork.BillCollecterCd;

            // �W���S���]�ƈ�����
            newRow[CT_CsDmd_BillCollecterNm] = rsltInfo_DemandTotalWork.BillCollecterNm;

            // �h��
            newRow[CT_CsDmd_HonorificTitle] = rsltInfo_DemandTotalWork.HonorificTitle;

            // ���Ӑ��s1
            newRow[CT_CsDmd_AccountNoInfoTK1] = rsltInfo_DemandTotalWork.AccountNoInfo1;
            // ���Ӑ��s2
            newRow[CT_CsDmd_AccountNoInfoTK2] = rsltInfo_DemandTotalWork.AccountNoInfo2;
            // ���Ӑ��s3
            newRow[CT_CsDmd_AccountNoInfoTK3] = rsltInfo_DemandTotalWork.AccountNoInfo3;

            // ���z�\���敪
            newRow[CT_CsDmd_TotalAmountDispWayCd] = rsltInfo_DemandTotalWork.TotalAmountDispWayCd;

            // ���Ж��̏��Ǎ�
            CompanyNm companyNm;
            secCode = rsltInfo_DemandTotalWork.AddUpSecCode;
            // �o�͋��_���u�S�Ёv�̏ꍇ�A�����_�����擾
            if (secCode == CT_AllSectionCode)
            {
                secCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }

            int status = ReadCompanyName(secCode, SecInfoAcs.CompanyNameCd.CompanyNameCd1, out companyNm);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (companyNm != null)
                {
                    // ------ DEL 2015/09/17 ���V�� Redmine#47028 �����ꗗ�\Out Of Memory�̑Ή� ------>>>>>>
                    //// ���Љ摜���擾
                    //ReadImageData(companyNm.ImageInfoCode);
                    // ------ DEL 2015/09/17 ���V�� Redmine#47028 �����ꗗ�\Out Of Memory�̑Ή� ------<<<<<<
                    // ------ ADD 2015/09/17 ���V�� Redmine#47028 �����ꗗ�\Out Of Memory�̑Ή� ------>>>>>>
                    // �����ꗗ�\�ȊO�̏ꍇ�A���Љ摜�����擾����
                    if (extraInfo.SlipPrtKind != 0)
                    {
                        // ���Љ摜���擾
                        ReadImageData(companyNm.ImageInfoCode);
                    }
                    // ------ ADD 2015/09/17 ���V�� Redmine#47028 �����ꗗ�\Out Of Memory�̑Ή� ------<<<<<<

                    // ����PR��
                    newRow[CT_CsDmd_CompanyPr] = companyNm.CompanyPr;

                    // ���Ж���1
                    newRow[CT_CsDmd_CompanyName1] = companyNm.CompanyName1;

                    // ���Ж���2
                    newRow[CT_CsDmd_CompanyName2] = companyNm.CompanyName2;

                    // �X�֔ԍ�
                    newRow[CT_CsDmd_CompanyPostNo] = companyNm.PostNo;

                    #region ���@�Z���ҏW
                    // ���ЏZ���ҏW
                    this._beforeConvertAddressParam.Address1 = companyNm.Address1;
                    // 2008.09.05 30413 ���� �폜���� >>>>>>START
                    //this._beforeConvertAddressParam.Address2 = companyNm.Address2;
                    // 2008.09.05 30413 ���� �폜���� <<<<<<END
                    this._beforeConvertAddressParam.Address3 = companyNm.Address3;
                    this._beforeConvertAddressParam.Address4 = companyNm.Address4;

                    this._beforeConvertAddressParam.ByteLength1 = 50;
                    this._beforeConvertAddressParam.ByteLength2 = 50;
                    this._beforeConvertAddressParam.ByteLength3 = 0;

                    _beforeConvertAddressParam.LineCount = 2;

                    AddressConverter.ConvertAddressForSlipType(this._beforeConvertAddressParam, out this._afterConvertAddressParam);

                    // ���ЏZ���P�s��(����p)
                    newRow[CT_CsDmd_EditCompanyAddress1] = this._afterConvertAddressParam.Address1;

                    // ���ЏZ���Q�s��(����p)
                    newRow[CT_CsDmd_EditCompanyAddress2] = this._afterConvertAddressParam.Address2;
                    #endregion

                    // ���Гd�b�ԍ�1(����p�^�C�g���܂�)
                    newRow[CT_CsDmd_EditCompanyTelNo1] = companyNm.CompanyTelTitle1 + companyNm.CompanyTelNo1;

                    // ���Гd�b�ԍ�2(����p�^�C�g���܂�)
                    newRow[CT_CsDmd_EditCompanyTelNo2] = companyNm.CompanyTelTitle2 + companyNm.CompanyTelNo2;

                    // ���Гd�b�ԍ�3(����p�^�C�g���܂�)
                    newRow[CT_CsDmd_EditCompanyTelNo3] = companyNm.CompanyTelTitle3 + companyNm.CompanyTelNo3;

                    // ��s�U���ē���
                    newRow[CT_CsDmd_TransferGuidance] = companyNm.TransferGuidance;

                    // ��s����1
                    newRow[CT_CsDmd_AccountNoInfo1] = companyNm.AccountNoInfo1;

                    // ��s����2
                    newRow[CT_CsDmd_AccountNoInfo2] = companyNm.AccountNoInfo2;

                    // ��s����3
                    newRow[CT_CsDmd_AccountNoInfo3] = companyNm.AccountNoInfo3;

                    // �����ݒ�E�v1
                    newRow[CT_CsDmd_CompanySetNote1] = companyNm.CompanySetNote1;

                    // �����ݒ�E�v2
                    newRow[CT_CsDmd_CompanySetNote2] = companyNm.CompanySetNote2;

                    if (_CampImage != null)//�摜�Ȃ��
                    {
                        newRow[CT_CsDmd_CampImgID] = _CampImage;
                        newRow[CT_CsDmd_ImageCommentForPrt1] = companyNm.ImageCommentForPrt1;
                        newRow[CT_CsDmd_ImageCommentForPrt2] = companyNm.ImageCommentForPrt2;
                    }
                    else
                    {
                        newRow[CT_CsDmd_CampImgID] = null;
                        newRow[CT_CsDmd_ImageCommentForPrt1] = "";
                        newRow[CT_CsDmd_ImageCommentForPrt2] = "";
                    }
                }
            }
            else
            {
                // ����PR��
                newRow[CT_CsDmd_CompanyPr] = "";
                // ���Ж���1
                newRow[CT_CsDmd_CompanyName1] = "";
                // ���Ж���2
                newRow[CT_CsDmd_CompanyName2] = "";
                // �X�֔ԍ�
                newRow[CT_CsDmd_CompanyPostNo] = "";
                // ���ЏZ���P�s��(����p)
                newRow[CT_CsDmd_EditCompanyAddress1] = "";
                // ���ЏZ���Q�s��(����p)
                newRow[CT_CsDmd_EditCompanyAddress2] = "";
                // ���Гd�b�ԍ�1(����p�^�C�g���܂�)
                newRow[CT_CsDmd_EditCompanyTelNo1] = "";
                // ���Гd�b�ԍ�2(����p�^�C�g���܂�)
                newRow[CT_CsDmd_EditCompanyTelNo2] = "";
                // ���Гd�b�ԍ�3(����p�^�C�g���܂�)
                newRow[CT_CsDmd_EditCompanyTelNo3] = "";
                // ��s�U���ē���
                newRow[CT_CsDmd_TransferGuidance] = "";
                // ��s����1
                newRow[CT_CsDmd_AccountNoInfo1] = "";
                // ��s����2
                newRow[CT_CsDmd_AccountNoInfo2] = "";
                // ��s����3
                newRow[CT_CsDmd_AccountNoInfo3] = "";
                // �����ݒ�E�v1
                newRow[CT_CsDmd_CompanySetNote1] = "";
                // �����ݒ�E�v2
                newRow[CT_CsDmd_CompanySetNote2] = "";
                // ���Ж��v���e�N�g1
                newRow[CT_CsDmd_CompanyProt1] = "";
                // ���Аݒ�E�v2
                newRow[CT_CsDmd_CompanyProt2] = "";

                newRow[CT_CsDmd_CampImgID] = null;
                newRow[CT_CsDmd_ImageCommentForPrt1] = "";
                newRow[CT_CsDmd_ImageCommentForPrt2] = "";
            }

            // ���E�㍡�񍇌v������z�̕��������ɂĔ���
            if (ofsThisSalesSum >= 0)
            {
                // �������E�x�����敪
                newRow[CT_CsDmd_DemandOrPay] = 0;  // ������

                // ��s1
                newRow[CT_CsDmd_AccountNoInfoDsp1] = companyNm.AccountNoInfo1;
                // ��s2
                newRow[CT_CsDmd_AccountNoInfoDsp2] = companyNm.AccountNoInfo2;
                // ��s3
                newRow[CT_CsDmd_AccountNoInfoDsp3] = companyNm.AccountNoInfo3;
            }
            else
            {
                // �������E�x�����敪
                newRow[CT_CsDmd_DemandOrPay] = 1;  // �x����

                // ��s1
                newRow[CT_CsDmd_AccountNoInfoDsp1] = rsltInfo_DemandTotalWork.AccountNoInfo1;
                // ��s2
                newRow[CT_CsDmd_AccountNoInfoDsp2] = rsltInfo_DemandTotalWork.AccountNoInfo2;
                // ��s3
                newRow[CT_CsDmd_AccountNoInfoDsp3] = rsltInfo_DemandTotalWork.AccountNoInfo3;
            }
            
            // 2008.09.08 30413 ���� ���ڒǉ� >>>>>>START
            // �����c��
            newRow[CT_CsDmd_DemandBalance] = rsltInfo_DemandTotalWork.LastTimeDemand + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd;

            // 2009.01.16 30413 ���� ������͑��E�㍡�񔄏���z�ɕύX >>>>>>START
            // ������z
            //newRow[CT_CsDmd_NetSales] = rsltInfo_DemandTotalWork.OfsThisTimeSales + rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis;
            newRow[CT_CsDmd_NetSales] = rsltInfo_DemandTotalWork.OfsThisTimeSales;
            // 2009.01.16 30413 ���� ������͑��E�㍡�񔄏���z�ɕύX <<<<<<END
            
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
                    // 2009.02.02 30413 ���� ���Ӑ�̒����ƏW�����ŉ�����v�Z��ύX >>>>>>START
                    // ����
                    //collectDemand = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd
                    //              + rsltInfo_DemandTotalWork.LastTimeDemand + rsltInfo_DemandTotalWork.OfsThisTimeSales
                    //              + rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis
                    //              + rsltInfo_DemandTotalWork.OfsThisSalesTax;
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
                    // 2009.02.02 30413 ���� ���Ӑ�̒����ƏW�����ŉ�����v�Z��ύX <<<<<<END
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

            // 2008.11.11 30413 ���� ����̏����l��ݒ� >>>>>>START
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
            // 2008.11.11 30413 ���� ����̏����l��ݒ� <<<<<<END
            
            foreach (RsltInfo_DepsitTotalWork work in rsltInfo_DemandTotalWork.MoneyKindList)
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
            // 2008.09.08 30413 ���� ���ڒǉ� <<<<<<END

            // --- DEL  ���r��  2010/01/25 ---------->>>>>
            // 2009.01.23 30413 ���� �������o�͋敪��ǉ� >>>>>>START
            // �������o�͋敪�R�[�h
            //newRow[CT_Blnce_BillOutputCode] = rsltInfo_DemandTotalWork.BillOutputCode;
            // 2009.01.23 30413 ���� �������o�͋敪��ǉ� <<<<<<END
            // --- DEL  ���r��  2010/01/25 ----------<<<<<
        
            // �̎����o�͋敪�R�[�h
            newRow[CT_Blnce_ReceiptOutputCode] = rsltInfo_DemandTotalWork.ReceiptOutputCode;    // ADD 2009/04/07

            // --- ADD  ���r��  2010/01/25 ---------->>>>>
            //���v�������o�͋敪�R�[�h
            newRow[CT_Blnce_TotalBillOutputDiv] = rsltInfo_DemandTotalWork.TotalBillOutputDiv;
            //���א������o�͋敪�R�[�h
            newRow[CT_Blnce_DetailBillOutputCode] = rsltInfo_DemandTotalWork.DetailBillOutputCode;
            //�`�[���v�������o�͋敪�R�[�h
            newRow[CT_Blnce_SlipTtlBillOutputDiv] = rsltInfo_DemandTotalWork.SlipTtlBillOutputDiv;
            // --- ADD  ���r��  2010/01/25 ----------<<<<<

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
                //--- ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
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
                //--- ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
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
                //--- ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
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
                //--- ADD 2022/08/24 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<

                // �ŗ�1�^�C�g��
                newRow[Col_TitleTaxRate1] = string.Empty;
                // �ŗ�2�^�C�g��
                newRow[Col_TitleTaxRate2] = string.Empty;
            }
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<

            newRow.EndEdit();

            return newRow;
        }

        #region �摜�Ǎ�����
        /// <summary>
        /// �摜�Ǎ�����
        /// </summary>
        /// <param name="takeInImageGroupCd">�捞�摜�O���[�v�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �摜�Ǘ��}�X�^����摜�̓ǂݍ��݂��s���܂�</br>
        /// <br>Programmer : 22024 ����@�_�u</br>
        /// <br>Date       : 2005.10.04</br>
        /// </remarks>
        private int ReadImageData(int imageInfoCode)
        {
            int status = -1;
            //int status = 0;

            if (imageInfoCode != 0)
            {
                try
                {
                    // �摜�O���[�v�}�X�^���摜�Ǘ��}�X�^��������
                    ImageInfo imageInfo;

                    status = this._imageInfoAcs.Read(out imageInfo, LoginInfoAcquisition.EnterpriseCode, ctIMAGEINFODIV_CODE, imageInfoCode);
                    if (status == 0)
                    {
                        if (imageInfo != null)
                        {
                            ImageConverter imgconv = new ImageConverter();
                            this._CampImage = (Image)imgconv.ConvertFrom(imageInfo.ImageInfoData);
                        }
                    }
                    else
                    {
                        _CampImage = null;
                    }
                }
                catch
                {
                    _CampImage = null;
                }
            }

            return status;
        }
        #endregion
        
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����ꗗ���o�����N���X�ː����ꗗ���o�������[�N�N���X�j
        /// </summary>
        /// <param name="lgoodsganre">�����ꗗ���o�����N���X</param>
        /// <returns>�����ꗗ���o�������[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �����ꗗ���o�����N���X���琿���ꗗ���o�������[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2006.12.04</br>
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private ExtrInfo_DemandTotalWork CopyToExtraInfoWorkFromExtraInfo(ExtrInfo_DemandTotal extraInfo)
        {
            ExtrInfo_DemandTotalWork extraInfoWork = new ExtrInfo_DemandTotalWork();

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
                    extraInfoWork.ResultsAddUpSecList = extraInfo.ResultsAddUpSecList;// ���_�R�[�h
                }
            }
            else
            {
                extraInfoWork.ResultsAddUpSecList = new string[0];    // ���_�R�[�h
            }

            // 2008.09.08 30413 ���� ���������� >>>>>>START
            //extraInfoWork.AddUpDate = TDateTime.LongDateToDateTime(extraInfo.TargetAddUpDate);  // ����
            extraInfoWork.AddUpDate = extraInfo.AddUpDate;  // ����
            // 2008.09.08 30413 ���� ���������� <<<<<<END
            
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

            // 2008.09.10 30413 ���� �̔��G���A�R�[�h�ǉ� >>>>>>START
            extraInfoWork.SalesAreaCodeSt = extraInfo.SalesAreaCodeSt;              // �̔��G���A�R�[�h(�J�n)
            extraInfoWork.SalesAreaCodeEd = extraInfo.SalesAreaCodeEd;              // �̔��G���A�R�[�h(�I��)
            // 2008.09.10 30413 ���� �̔��G���A�R�[�h�ǉ� <<<<<<END
            
            extraInfoWork.CustomerCodeSt = extraInfo.CustomerCodeSt;            // ���Ӑ�R�[�h(�J�n)
            extraInfoWork.CustomerCodeEd = extraInfo.CustomerCodeEd;            // ���Ӑ�R�[�h(�I��)
            extraInfoWork.EnterpriseCode = extraInfo.EnterpriseCode;            // ��ƃR�[�h
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //extraInfoWork.IsBillOutputOnly = extraInfo.IsJudgeBillOutputCode;   // �u���������s����v������̂ݏo�͋敪
            //extraInfoWork.IsLastDay = extraInfo.IsLastDay;                      // ���Ӑ�������w��(true:28�`31�S�� false:�w������̂�)
            //extraInfoWork.IsOutputAllSecRec = extraInfo.IsOutputAllSecRec;      // �u�S�Ёv�I���敪
            //extraInfoWork.IsSelectAllSection = extraInfo.IsSelectAllSection;    // �S�Ă̋��_���I�����ꂽ���ǂ���
            //extraInfoWork.KanaSt = extraInfo.KanaSt;                            // ���Ӑ�J�i(�J�n)
            //extraInfoWork.KanaEd = extraInfo.KanaEd;                            // ���Ӑ�J�i(�I��)
            //extraInfoWork.ResultsAddUpSecList = (string[])extraInfo.ResultsAddUpSecList.ToArray(typeof(string));  // �I�����_�R�[�h���X�g
            //extraInfoWork.TotalDay = extraInfo.TotalDay;                        // ���Ӑ����
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            extraInfoWork.DmdItems = extraInfo.DmdDtl;                          // ��������
            
            // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� >>>>>>START
            extraInfoWork.SlipPrtKind = extraInfo.SlipPrtKind;                  // �`�[������
            // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� <<<<<<END

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

        #region �����񂩂甄�㖾�׏��f�[�^�s�ݒ菈��
        /// <summary>
        /// �����񂩂甄�㖾�׏��f�[�^�s�ݒ菈��
        /// </summary>
        /// <param name="dmd">��������f�[�^�N���X</param>
        /// <param name="dt">�ݒ肷��DataTable���</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note        : �����񂩂甄�㖾�׏��̃f�[�^�s�֐ݒ肵�܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        private void SalesToSaleDtlDataRow(RsltInfo_DemandDetailWork dmd, ref DataTable dt, DmdDtlPrtPtn dmdDtlPrtPtn)
        {
            DataRow row = dt.NewRow();

            // ���Ӑ�R�[�h
            row[CT_SaleDepo_CustomerCode] = dmd.CustomerCode;
            // ���Ӑ於��
            row[CT_SaleDepo_CustomerName] = dmd.CustomerName;
            // ���Ӑ於��2
            row[CT_SaleDepo_CustomerName2] = dmd.CustomerName2;
            // ���Ӑ旪��
            row[CT_SaleDepo_CustomerSnm] = dmd.CustomerSnm;
            // ������R�[�h
            row[CT_SaleDepo_ClaimCode] = dmd.ClaimCode;
            // �����於��
            row[CT_SaleDepo_ClaimName] = dmd.ClaimName;
            // �����於��2
            row[CT_SaleDepo_ClaimName2] = dmd.ClaimName2;
            // �����旪��
            row[CT_SaleDepo_ClaimSnm] = dmd.ClaimSnm;
            // �v����t
            row[CT_SaleDepo_AddUpADate] = dmd.AddUpADate;
            // �v����t(�\���p)
            row[CT_SaleDepo_AddUpADateDisp] = TDateTime.DateTimeToString("YYYY/MM/DD", dmd.AddUpADate);
            // �v����t(����p)
            row[CT_SaleDepo_AddUpADatePrint] = TDateTime.DateTimeToString("", dmd.AddUpADate);
            // �`�[�ԍ��E�����ԍ�
            row[CT_SaleDepo_SalesSlipNum] = dmd.SalesSlipNum;

            // ����`�[�敪
            if (dmd.SalesSlipCd == 0)
            {
                row[CT_SaleDepo_SalesSlipCd] = "����";
            }
            else
            {
                row[CT_SaleDepo_SalesSlipCd] = "�ԕi";
            }

            // ���|�敪
            if (dmd.AccRecDivCd == 0)
            {
                row[CT_SaleDepo_AccRecDivCd] = "����";
            }
            else
            {
                row[CT_SaleDepo_AccRecDivCd] = "���|";
            }

            // �����`�[�ԍ�
            row[CT_SaleDepo_PartySaleSlipNum] = dmd.PartySaleSlipNum;
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
            //// �ԍ��A���󒍔ԍ�
            //row[CT_SaleDepo_DebitNLnkAcptAnOdr] = dmd.DebitNLnkAcptAnOdr;
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            // ����`�[���v�i�ō��݁j
            if ((dmd.SalesGoodsCd != 2) && (dmd.SalesGoodsCd != 3))
            {
                row[CT_SaleDepo_SalesTotalTaxInc] = dmd.SalesTotalTaxInc;
            }
            else if (dmd.SalesGoodsCd == 2)
            {
                row[CT_SaleDepo_SalesTotalTaxInc] = dmd.SalesSubtotalTax;  // �����
            }
            else if (dmd.SalesGoodsCd == 3)
            {
                row[CT_SaleDepo_SalesTotalTaxInc] = dmd.SalesTotalTaxInc;
            }

            // ����`�[���v�i�Ŕ����j
            if (dmd.SalesGoodsCd == 3)  // �c�������̏ꍇ
            {
                row[CT_SaleDepo_SalesTotalTaxExc] = dmd.SalesTotalTaxInc;
            }
            else
            {
                row[CT_SaleDepo_SalesTotalTaxExc] = dmd.SalesTotalTaxExc;
            }
            // ����`�[����Ŋz
            if (dmd.SalesGoodsCd == 2) // ����Œ����̏ꍇ
            {
                row[CT_SaleDepo_SalesTotalTax] = dmd.SalesSubtotalTax;
            }
            else if (dmd.SalesGoodsCd == 3) // �c�������̏ꍇ
            {
                row[CT_SaleDepo_SalesTotalTax] = 0;
            }
            else
            {
                row[CT_SaleDepo_SalesTotalTax] = dmd.SalesTotalTax;
            }
            // �`�[���l
            row[CT_SaleDepo_SlipNote] = dmd.SlipNote;
            // �`�[���l�Q
            row[CT_SaleDepo_SlipNote2] = dmd.SlipNote2;
            // ����s�ԍ�
            row[CT_SaleDepo_SalesRowNo] = dmd.SalesRowNo;
            // ����`�[�敪�i���ׁj
            switch (dmd.SalesSlipCdDtl)
            {
                case 0:
                    {
                        row[CT_SaleDepo_SalesSlipCdDtl] = "����";
                        break;
                    }
                case 1:
                    {
                        row[CT_SaleDepo_SalesSlipCdDtl] = "�ԕi";
                        break;
                    }
                case 2:
                    {
                        row[CT_SaleDepo_SalesSlipCdDtl] = "�l��";
                        break;
                    }
                case 9:
                    {
                        row[CT_SaleDepo_SalesSlipCdDtl] = "�ꎮ";
                        break;
                    }
                default:
                    {
                        row[CT_SaleDepo_SalesSlipCdDtl] = "";
                        break;
                    }
            }
            // �󒍔ԍ�
            row[CT_SaleDepo_AcceptAnOrderNo] = dmd.AcceptAnOrderNo;
            // ���[�J�[�R�[�h
            row[CT_SaleDepo_GoodsMakerCd] = dmd.GoodsMakerCd;
            // ���[�J�[����
            row[CT_SaleDepo_MakerName] = dmd.MakerName;
            // ���i�ԍ�
            row[CT_SaleDepo_GoodsNo] = dmd.GoodsNo;
            // ���i��
            row[CT_SaleDepo_GoodsName] = dmd.GoodsName;
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
            //// ���i�敪�R�[�h
            //row[CT_SaleDepo_MediumGoodsGanreCode] = dmd.MediumGoodsGanreCode;
            //// ���i�敪��
            //row[CT_SaleDepo_MediumGoodsGanreName] = dmd.MediumGoodsGanreName;
            //// ���i�敪�O���[�v�R�[�h
            //row[CT_SaleDepo_LargeGoodsGanreCode] = dmd.LargeGoodsGanreCode;
            //// ���i�敪�O���[�v��
            //row[CT_SaleDepo_LargeGoodsGanreName] = dmd.LargeGoodsGanreName;
            //// ���i�敪�ڍ׃R�[�h
            //row[CT_SaleDepo_DetailGoodsGanreCode] = dmd.DetailGoodsGanreCode;
            //// ���i�敪�ڍז���
            //row[CT_SaleDepo_DetailGoodsGanreName] = dmd.DetailGoodsGanreName;
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            // BL���i�R�[�h
            row[CT_SaleDepo_BLGoodsCode] = dmd.BLGoodsCode;
            // BL���i�R�[�h����
            row[CT_SaleDepo_BLGoodsFullName] = dmd.BLGoodsFullName;
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
            //// ���Е��ރR�[�h
            //row[CT_SaleDepo_EnterpriseGanreCode] = dmd.EnterpriseGanreCode;
            //// ���Е��ޖ���
            //row[CT_SaleDepo_EnterpriseGanreName] = dmd.EnterpriseGanreName;
            //// �P�ʃR�[�h
            //row[CT_SaleDepo_UnitCode] = dmd.UnitCode;
            //// �P�ʖ���
            //row[CT_SaleDepo_UnitName] = dmd.UnitName;
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<ENd
            // ����P���i�ō��C�����j
            row[CT_SaleDepo_SalesUnPrcTaxIncFl] = dmd.SalesUnPrcTaxIncFl;
            // ����P���i�Ŕ��C�����j
            if ((dmd.SalesGoodsCd != 2) && (dmd.SalesGoodsCd != 3))
            {
                row[CT_SaleDepo_SalesUnPrcTaxExcFl] = dmd.SalesUnPrcTaxExcFl;
            }
            else
            {
                row[CT_SaleDepo_SalesUnPrcTaxExcFl] = 0;
            }
            // �o�א�
            if ((dmd.SalesGoodsCd != 2) && (dmd.SalesGoodsCd != 3))
            {
                row[CT_SaleDepo_ShipmentCnt] = dmd.ShipmentCnt;
            }
            else
            {
                row[CT_SaleDepo_ShipmentCnt] = 0;
            }
            // ������z�i�ō��݁j
            row[CT_SaleDepo_SalesMoneyTaxInc] = dmd.SalesMoneyTaxInc;
            // ������z�i�Ŕ����j
            if (dmd.SalesGoodsCd == 2)
            {
                row[CT_SaleDepo_SalesMoneyTaxExc] = dmd.SalesSubtotalTax;
                row[CT_SaleDepo_SalesMoneyTaxExc1] = dmd.SalesSubtotalTax;
            }
            else if (dmd.SalesGoodsCd == 3)
            {
                row[CT_SaleDepo_SalesMoneyTaxExc] = dmd.SalesTotalTaxInc;
                row[CT_SaleDepo_SalesMoneyTaxExc1] = dmd.SalesTotalTaxInc;
            }
            else
            {
                row[CT_SaleDepo_SalesMoneyTaxExc] = dmd.SalesMoneyTaxExc;
                row[CT_SaleDepo_SalesMoneyTaxExc1] = 0;
            }
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
            //// ����Œ����z
            //row[CT_SaleDepo_TaxAdjust] = dmd.TaxAdjust;
            //// �c�������z
            //row[CT_SaleDepo_BalanceAdjust] = dmd.BalanceAdjust;
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            // �ېŋ敪
            row[CT_SaleDepo_TaxationDivCd] = dmd.TaxationDivCd;
            // �����`�[�ԍ��i���ׁj
            row[CT_SaleDepo_PartySlipNumDtl] = dmd.PartySlipNumDtl;
            // ���ה��l
            row[CT_SaleDepo_DtlNote] = dmd.DtlNote;
            // �`�[�����P
            row[CT_SaleDepo_SlipMemo1] = dmd.SlipMemo1;
            // �`�[�����Q
            row[CT_SaleDepo_SlipMemo2] = dmd.SlipMemo2;
            // �`�[�����R
            row[CT_SaleDepo_SlipMemo3] = dmd.SlipMemo3;
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 >>>>>>START
            ///// �`�[�����S
            //row[CT_SaleDepo_SlipMemo4] = dmd.SlipMemo4;
            //// �`�[�����T
            //row[CT_SaleDepo_SlipMemo5] = dmd.SlipMemo5;
            //// �`�[�����U
            //row[CT_SaleDepo_SlipMemo6] = dmd.SlipMemo6;
            //// ����p���i�ԍ�
            //row[CT_SaleDepo_PrtGoodsNo] = dmd.PrtGoodsNo;
            //// ����p���i����
            //row[CT_SaleDepo_PrtGoodsName] = dmd.PrtGoodsName;
            //// ����p���i���[�J�[�R�[�h
            //row[CT_SaleDepo_PrtGoodsMakerCd] = dmd.PrtGoodsMakerCd;
            //// ����p���i���[�J�[����
            //row[CT_SaleDepo_PrtGoodsMakerNm] = dmd.PrtGoodsMakerNm;
            // 2008.09.16 30413 ���� ���g�p���ڍ폜 <<<<<<END
            /// �v�㋒�_�R�[�h
            row[CT_SaleDepo_AddUpSecCode] = dmd.AddUpSecCode;
            // �v�㋒�_����
            string sectionName = "";
            if (sectionTable.ContainsKey(dmd.AddUpSecCode))
            {
                sectionName = sectionTable[dmd.AddUpSecCode].ToString();
            }
            row[CT_SaleDepo_AddUpSecName] = sectionName;
            // �������
            row[CT_SaleDepo_PrintDetailHeaderOder] = 1;

            if (this.CheckZeroValueDtl(dmd, dmdDtlPrtPtn) == false)
            {
                dt.Rows.Add(row);
            }
        }
        #endregion
        
        #region �����񂩂甄�㖾�׏��f�[�^�s�ݒ菈��
        /// <summary>
        /// �����񂩂甄�㖾�׏��f�[�^�s�ݒ菈��
        /// </summary>
        /// <param name="dmd">��������f�[�^�N���X</param>
        /// <param name="dt">�ݒ肷��DataTable���</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note        : �����񂩂甄�㖾�׏��̃f�[�^�s�֐ݒ肵�܂��B</br>
        /// <br>Programer  : 980023  �ђJ �k��</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        private void SalesToDepoDtlDataRow(RsltInfo_DemandDetailWork dmd, ref DataTable dt, DmdDtlPrtPtn dmdDtlPrtPtn)
        {


            DataRow row = dt.NewRow();

            // ������R�[�h
            row[CT_SaleDepo_ClaimCode] = dmd.ClaimCode;
            // �����於��
            row[CT_SaleDepo_ClaimName] = dmd.ClaimName;
            // �����於��2
            row[CT_SaleDepo_ClaimName2] = dmd.ClaimName2;
            // �����旪��
            row[CT_SaleDepo_ClaimSnm] = dmd.ClaimSnm;
            // ���Ӑ�R�[�h
            row[CT_SaleDepo_CustomerCode] = dmd.CustomerCode;
            // ���Ӑ於��
            row[CT_SaleDepo_CustomerName] = dmd.CustomerName;
            // ���Ӑ於��2
            row[CT_SaleDepo_CustomerName2] = dmd.CustomerName2;
            // ���Ӑ旪��
            row[CT_SaleDepo_CustomerSnm] = dmd.CustomerSnm;
            // �v����t
            row[CT_SaleDepo_AddUpADate] = dmd.AddUpADate;
            // �v����t(�\���p)
            row[CT_SaleDepo_AddUpADateDisp] = TDateTime.DateTimeToString("YYYY/MM/DD", dmd.AddUpADate);
            // �v����t(����p)
            row[CT_SaleDepo_AddUpADatePrint] = TDateTime.DateTimeToString("YYYY/MM/DD", dmd.AddUpADate);
            // �ԍ������A���ԍ�                     
            row[CT_SaleDepo_DebitNoteLinkDepoNo] = dmd.DebitNoteLinkDepoNo;
            // �����`�[�ԍ�                      
            row[CT_SaleDepo_DepositSlipNo] = dmd.DepositSlipNo;
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            ///// ��������R�[�h
            //row[CT_SaleDepo_DepositKindCode] = dmd.DepositKindCode;
            //// �������햼��
            //row[CT_SaleDepo_DepositKindName] = dmd.DepositKindName;
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            /// �����v
            row[CT_SaleDepo_DepositTotal] = dmd.DepositTotal;
            // �`�[�E�v
            row[CT_SaleDepo_Outline] = dmd.Outline;
            // ��`���
            row[CT_SaleDepo_DraftKind] = dmd.DraftKind;
            // ��`��ޖ���
            row[CT_SaleDepo_DraftKindName] = dmd.DraftKindName;
            // ��`�敪
            row[CT_SaleDepo_DraftDivide] = dmd.DraftDivide;
            // ��`�敪����
            row[CT_SaleDepo_DraftDivideName] = dmd.DraftDivideName;
            // ��`�ԍ�
            row[CT_SaleDepo_DraftNo] = dmd.DraftNo;
            // �v�㋒�_�R�[�h
            row[CT_SaleDepo_AddUpSecCode] = dmd.AddUpSecCode;
            // �v�㋒�_����
            string sectionName = "";
            if (sectionTable.ContainsKey(dmd.AddUpSecCode))
            {
                sectionName = sectionTable[dmd.AddUpSecCode].ToString();
            }
            row[CT_SaleDepo_AddUpSecName] = sectionName;

            if (this.CheckZeroValueDtl(dmd, dmdDtlPrtPtn) == false)
            {
                dt.Rows.Add(row);
            }
        }
        #endregion
        
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

        // 2008.09.05 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region ���񐿋����z�[���`�F�b�N
        ///// <summary>
        ///// ���񐿋����z�[���`�F�b�N
        ///// </summary>
        //private bool CheckTotalZeroValue(RsltInfo_DemandTotalWork dmd, DmdPrtPtn dmdPrtPtn)
        //{
        //    /// ���񐿋����z�[���̐������͈󎚂��Ȃ��ꍇ
        //    if (dmdPrtPtn.ThTmDmdZeroPrtDiv == 1)
        //    {
        //        if ((dmd.OfsThisTimeSales == 0) && // ���E�㍡�񔄏���z
        //            (dmd.OfsThisSalesTax == 0))    // ���E�㍡�񔄏�����
        //        {
        //            return true;
        //        }
        //    }
            
        //    return false;   
        //}
        #endregion
        // 2008.09.05 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END

        #region ���׏����׋��z�[���`�F�b�N
        /// <summary>
        /// ���׏����׋��z�[���`�F�b�N
        /// </summary>
        private bool CheckZeroValueDtl(RsltInfo_DemandDetailWork dmd, DmdDtlPrtPtn dmdDtlPrtPtn)
        {
            // ���z�[���~���ה���
            if (dmdDtlPrtPtn.DtlPrcZeroPrtDiv == 1)
            {
                if ((dmd.ShipmentCnt == 0) &&       // �o�א�
                    (dmd.SalesMoneyTaxInc == 0) &&  // ������z�i�ō��݁j
                    (dmd.SalesMoneyTaxExc == 0) &&  // ������z�i�Ŕ����j
                    (dmd.DepositTotal == 0))        // �������v
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        
        // 2008.09.05 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region �������p�^�[���ݒ�̎擾
        ///// <summary>
        ///// �������p�^�[���ݒ�̎擾
        ///// </summary>
        ///// <param name="dmdPrtPtn"></param>
        ///// <param name="ttlSetItemDivList"></param>
        ///// <param name="ttlFormTitleList"></param>
        ///// <returns></returns>
        //private int GetDmdPrtPtn(int demandPtnNo, out DmdPrtPtn dmdPrtPtn)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    dmdPrtPtn = new DmdPrtPtn();

        //    // ����������p�^�[���ݒ�Ǎ�
        //    status = _dmdPrtPtnAcs.ReadStaticMemory(out dmdPrtPtn, LoginInfoAcquisition.EnterpriseCode, demandPtnNo);
            
        //    return status;
        //}
        #endregion
        // 2008.09.05 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END

        /// <summary>
        /// �t�B���^�[�p�̌v�Z�㐿�����z��ݒ�
        /// </summary>
        private void SetAfCalDemandPriceFilter()
        {
            for (int i = 0; i < this._custDmdPrcDataTable.Rows.Count; i++)
            {
                // �v�㋒�_�R�[�h�Ɛ�����R�[�h�ŃL�[�쐬
                string sectionCd = (string)this._custDmdPrcDataTable.Rows[i][CT_CsDmd_AddUpSecCode];
                string claimCode = (string)this._custDmdPrcDataTable.Rows[i][CT_CsDmd_ClaimCodeDisp];
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
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �o�͌����̐ݒ���s���܂��B</br>
        /// <br>Programmer : 980023 �ђJ �k��</br>
        /// <br>Date       : 2007.07.10</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "�������f�[�^���o����", iMsg, iSt, iButton, iDefButton);
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
            MAKAU02012UA uiObj = new MAKAU02012UA();
            doneFlag = ContainMember(uiObj, "TaxReductionUIDone");
            if (!doneFlag) return doneFlag;

            // E�N���X
            ExtrInfo_DemandTotal demandTotal = new ExtrInfo_DemandTotal();
            doneFlag = ContainProperty(demandTotal, "TaxPrintDiv");
            if (!doneFlag) return doneFlag;

            // D�N���X
            ExtrInfo_DemandTotalWork demandTotalWork = new ExtrInfo_DemandTotalWork();
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
