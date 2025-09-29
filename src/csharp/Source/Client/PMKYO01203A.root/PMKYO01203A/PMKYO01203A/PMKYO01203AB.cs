//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M����
// �v���O�����T�v   : ���M�f�[�^�ϊ��������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/06/08  �C�����e : �}�X�^����M�s���Ή��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �C �� ��  2010/02/02  �C�����e : �������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770021-00 �쐬�S�� : ���O
// �� �� ��  2021/04/12  �C�����e : ���Ӑ惁�����̒ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �}�X�^����M�����X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : �}�X�^����M�����ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009.04.02<br />
    /// <br>Update Note: 2021/04/12 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
    /// </remarks>
    public class MstConvertReceive
    {
        /// <summary>
        /// ���_���ݒ�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="secInfoSetWork">���_���ݒ�f�[�^</param>
        /// <returns>DC���_���ݒ�f�[�^</returns>
        public static DCSecInfoSetWork SearchDataFromUpdateData(APSecInfoSetWork secInfoSetWork)
        {
            if (secInfoSetWork == null)
            {
                return null;
            }

            DCSecInfoSetWork dcSecInfoSetWork = new DCSecInfoSetWork();
            // ���_���ݒ�f�[�^�ϊ�
            dcSecInfoSetWork.CreateDateTime = secInfoSetWork.CreateDateTime;
            dcSecInfoSetWork.UpdateDateTime = secInfoSetWork.UpdateDateTime;
            dcSecInfoSetWork.EnterpriseCode = secInfoSetWork.EnterpriseCode;
            dcSecInfoSetWork.FileHeaderGuid = secInfoSetWork.FileHeaderGuid;
            dcSecInfoSetWork.UpdEmployeeCode = secInfoSetWork.UpdEmployeeCode;
            dcSecInfoSetWork.UpdAssemblyId1 = secInfoSetWork.UpdAssemblyId1;
            dcSecInfoSetWork.UpdAssemblyId2 = secInfoSetWork.UpdAssemblyId2;
            dcSecInfoSetWork.LogicalDeleteCode = secInfoSetWork.LogicalDeleteCode;
            dcSecInfoSetWork.SectionCode = secInfoSetWork.SectionCode;
            dcSecInfoSetWork.SectionGuideNm = secInfoSetWork.SectionGuideNm;
            dcSecInfoSetWork.SectionGuideSnm = secInfoSetWork.SectionGuideSnm;
            dcSecInfoSetWork.CompanyNameCd1 = secInfoSetWork.CompanyNameCd1;
            dcSecInfoSetWork.MainOfficeFuncFlag = secInfoSetWork.MainOfficeFuncFlag;
            dcSecInfoSetWork.IntroductionDate = secInfoSetWork.IntroductionDate;
            dcSecInfoSetWork.SectWarehouseCd1 = secInfoSetWork.SectWarehouseCd1;
            dcSecInfoSetWork.SectWarehouseCd2 = secInfoSetWork.SectWarehouseCd2;
            dcSecInfoSetWork.SectWarehouseCd3 = secInfoSetWork.SectWarehouseCd3;

            return dcSecInfoSetWork;
        }

        /// <summary>
        /// ����}�X�^�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="subSectionWork">AP����}�X�^�f�[�^</param>
        /// <returns>DC����}�X�^�f�[�^</returns>
        public static DCSubSectionWork SearchDataFromUpdateData(APSubSectionWork subSectionWork)
        {
            if (subSectionWork == null)
            {
                return null;
            }

            DCSubSectionWork dcSubSectionWork = new DCSubSectionWork();

            // ����}�X�^�f�[�^�ϊ�
            dcSubSectionWork.CreateDateTime = subSectionWork.CreateDateTime;
            dcSubSectionWork.UpdateDateTime = subSectionWork.UpdateDateTime;
            dcSubSectionWork.EnterpriseCode = subSectionWork.EnterpriseCode;
            dcSubSectionWork.FileHeaderGuid = subSectionWork.FileHeaderGuid;
            dcSubSectionWork.UpdEmployeeCode = subSectionWork.UpdEmployeeCode;
            dcSubSectionWork.UpdAssemblyId1 = subSectionWork.UpdAssemblyId1;
            dcSubSectionWork.UpdAssemblyId2 = subSectionWork.UpdAssemblyId2;
            dcSubSectionWork.LogicalDeleteCode = subSectionWork.LogicalDeleteCode;
            dcSubSectionWork.SectionCode = subSectionWork.SectionCode;
            dcSubSectionWork.SubSectionCode = subSectionWork.SubSectionCode;
            dcSubSectionWork.SubSectionName = subSectionWork.SubSectionName;

            return dcSubSectionWork;
        }

        /// <summary>
        /// �]�ƈ��}�X�^�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="employeeWork">�]�ƈ��}�X�^�f�[�^</param>
        /// <returns>DC�]�ƈ��}�X�^�f�[�^</returns>
        public static DCEmployeeWork SearchDataFromUpdateData(APEmployeeWork employeeWork)
        {
            if (employeeWork == null)
            {
                return null;
            }

            DCEmployeeWork dcEmployeeWork = new DCEmployeeWork();

            // �]�ƈ��}�X�^�f�[�^�ϊ�
            dcEmployeeWork.CreateDateTime = employeeWork.CreateDateTime;
            dcEmployeeWork.UpdateDateTime = employeeWork.UpdateDateTime;
            dcEmployeeWork.EnterpriseCode = employeeWork.EnterpriseCode;
            dcEmployeeWork.FileHeaderGuid = employeeWork.FileHeaderGuid;
            dcEmployeeWork.UpdEmployeeCode = employeeWork.UpdEmployeeCode;
            dcEmployeeWork.UpdAssemblyId1 = employeeWork.UpdAssemblyId1;
            dcEmployeeWork.UpdAssemblyId2 = employeeWork.UpdAssemblyId2;
            dcEmployeeWork.LogicalDeleteCode = employeeWork.LogicalDeleteCode;
            dcEmployeeWork.EmployeeCode = employeeWork.EmployeeCode;
            dcEmployeeWork.Name = employeeWork.Name;
            dcEmployeeWork.Kana = employeeWork.Kana;
            dcEmployeeWork.ShortName = employeeWork.ShortName;
            dcEmployeeWork.SexCode = employeeWork.SexCode;
            dcEmployeeWork.SexName = employeeWork.SexName;
            dcEmployeeWork.Birthday = employeeWork.Birthday;
            dcEmployeeWork.CompanyTelNo = employeeWork.CompanyTelNo;
            dcEmployeeWork.PortableTelNo = employeeWork.PortableTelNo;
            dcEmployeeWork.PostCode = employeeWork.PostCode;
            dcEmployeeWork.BusinessCode = employeeWork.BusinessCode;
            dcEmployeeWork.FrontMechaCode = employeeWork.FrontMechaCode;
            dcEmployeeWork.InOutsideCompanyCode = employeeWork.InOutsideCompanyCode;
            dcEmployeeWork.BelongSectionCode = employeeWork.BelongSectionCode;
            dcEmployeeWork.LvrRtCstGeneral = employeeWork.LvrRtCstGeneral;
            dcEmployeeWork.LvrRtCstCarInspect = employeeWork.LvrRtCstCarInspect;
            dcEmployeeWork.LvrRtCstBodyPaint = employeeWork.LvrRtCstBodyPaint;
            dcEmployeeWork.LvrRtCstBodyRepair = employeeWork.LvrRtCstBodyRepair;
            dcEmployeeWork.LoginId = employeeWork.LoginId;
            dcEmployeeWork.LoginPassword = employeeWork.LoginPassword;
            dcEmployeeWork.UserAdminFlag = employeeWork.UserAdminFlag;
            dcEmployeeWork.EnterCompanyDate = employeeWork.EnterCompanyDate;
            dcEmployeeWork.RetirementDate = employeeWork.RetirementDate;
            dcEmployeeWork.AuthorityLevel1 = employeeWork.AuthorityLevel1;
            dcEmployeeWork.AuthorityLevel2 = employeeWork.AuthorityLevel2;

            return dcEmployeeWork;
        }

        /// <summary>
        /// �]�ƈ��ڍ׃}�X�^�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="employeeDtlWork">�]�ƈ��ڍ׃}�X�^�f�[�^</param>
        /// <returns>DC�]�ƈ��ڍ׃}�X�^�f�[�^</returns>
        public static DCEmployeeDtlWork SearchDataFromUpdateData(APEmployeeDtlWork employeeDtlWork)
        {
            if (employeeDtlWork == null)
            {
                return null;
            }

            DCEmployeeDtlWork dcEmployeeDtlWork = new DCEmployeeDtlWork();

            // �]�ƈ��ڍ׃}�X�^�f�[�^�ϊ�
            dcEmployeeDtlWork.CreateDateTime = employeeDtlWork.CreateDateTime;
            dcEmployeeDtlWork.UpdateDateTime = employeeDtlWork.UpdateDateTime;
            dcEmployeeDtlWork.EnterpriseCode = employeeDtlWork.EnterpriseCode;
            dcEmployeeDtlWork.FileHeaderGuid = employeeDtlWork.FileHeaderGuid;
            dcEmployeeDtlWork.UpdEmployeeCode = employeeDtlWork.UpdEmployeeCode;
            dcEmployeeDtlWork.UpdAssemblyId1 = employeeDtlWork.UpdAssemblyId1;
            dcEmployeeDtlWork.UpdAssemblyId2 = employeeDtlWork.UpdAssemblyId2;
            dcEmployeeDtlWork.LogicalDeleteCode = employeeDtlWork.LogicalDeleteCode;
            dcEmployeeDtlWork.EmployeeCode = employeeDtlWork.EmployeeCode;
            dcEmployeeDtlWork.BelongSubSectionCode = employeeDtlWork.BelongSubSectionCode;
            dcEmployeeDtlWork.EmployAnalysCode1 = employeeDtlWork.EmployAnalysCode1;
            dcEmployeeDtlWork.EmployAnalysCode2 = employeeDtlWork.EmployAnalysCode2;
            dcEmployeeDtlWork.EmployAnalysCode3 = employeeDtlWork.EmployAnalysCode3;
            dcEmployeeDtlWork.EmployAnalysCode4 = employeeDtlWork.EmployAnalysCode4;
            dcEmployeeDtlWork.EmployAnalysCode5 = employeeDtlWork.EmployAnalysCode5;
            dcEmployeeDtlWork.EmployAnalysCode6 = employeeDtlWork.EmployAnalysCode6;
            dcEmployeeDtlWork.UOESnmDiv = employeeDtlWork.UOESnmDiv;
            dcEmployeeDtlWork.MailAddrKindCode1 = employeeDtlWork.MailAddrKindCode1;
            dcEmployeeDtlWork.MailAddrKindName1 = employeeDtlWork.MailAddrKindName1;
            dcEmployeeDtlWork.MailAddress1 = employeeDtlWork.MailAddress1;
            dcEmployeeDtlWork.MailSendCode1 = employeeDtlWork.MailSendCode1;
            dcEmployeeDtlWork.MailAddrKindCode2 = employeeDtlWork.MailAddrKindCode2;
            dcEmployeeDtlWork.MailAddrKindName2 = employeeDtlWork.MailAddrKindName2;
            dcEmployeeDtlWork.MailAddress2 = employeeDtlWork.MailAddress2;
            dcEmployeeDtlWork.MailSendCode2 = employeeDtlWork.MailSendCode2;

            return dcEmployeeDtlWork;
        }

        /// <summary>
        /// �q�Ƀ}�X�^�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="warehouseWork">�q�Ƀ}�X�^�f�[�^</param>
        /// <returns>DC�q�Ƀ}�X�^�f�[�^</returns>
        public static DCWarehouseWork SearchDataFromUpdateData(APWarehouseWork warehouseWork)
        {
            if (warehouseWork == null)
            {
                return null;
            }

            DCWarehouseWork dcWarehouseWork = new DCWarehouseWork();

            // �q�Ƀ}�X�^�f�[�^�ϊ�
            dcWarehouseWork.CreateDateTime = warehouseWork.CreateDateTime;
            dcWarehouseWork.UpdateDateTime = warehouseWork.UpdateDateTime;
            dcWarehouseWork.EnterpriseCode = warehouseWork.EnterpriseCode;
            dcWarehouseWork.FileHeaderGuid = warehouseWork.FileHeaderGuid;
            dcWarehouseWork.UpdEmployeeCode = warehouseWork.UpdEmployeeCode;
            dcWarehouseWork.UpdAssemblyId1 = warehouseWork.UpdAssemblyId1;
            dcWarehouseWork.UpdAssemblyId2 = warehouseWork.UpdAssemblyId2;
            dcWarehouseWork.LogicalDeleteCode = warehouseWork.LogicalDeleteCode;
            dcWarehouseWork.SectionCode = warehouseWork.SectionCode;
            dcWarehouseWork.WarehouseCode = warehouseWork.WarehouseCode;
            dcWarehouseWork.WarehouseName = warehouseWork.WarehouseName;
            dcWarehouseWork.WarehouseNote1 = warehouseWork.WarehouseNote1;
            dcWarehouseWork.CustomerCode = warehouseWork.CustomerCode;
            dcWarehouseWork.MainMngWarehouseCd = warehouseWork.MainMngWarehouseCd;
            dcWarehouseWork.StockBlnktRemark = warehouseWork.StockBlnktRemark;

            return dcWarehouseWork;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="customerWork">���Ӑ�}�X�^�f�[�^</param>
        /// <returns>DC���Ӑ�}�X�^�f�[�^</returns>
        public static DCCustomerWork SearchDataFromUpdateData(APCustomerWork customerWork)
        {
            if (customerWork == null)
            {
                return null;
            }

            DCCustomerWork dcCustomerWork = new DCCustomerWork();

            // ���Ӑ�}�X�^�f�[�^�ϊ�
            dcCustomerWork.CreateDateTime = customerWork.CreateDateTime;
            dcCustomerWork.UpdateDateTime = customerWork.UpdateDateTime;
            dcCustomerWork.EnterpriseCode = customerWork.EnterpriseCode;
            dcCustomerWork.FileHeaderGuid = customerWork.FileHeaderGuid;
            dcCustomerWork.UpdEmployeeCode = customerWork.UpdEmployeeCode;
            dcCustomerWork.UpdAssemblyId1 = customerWork.UpdAssemblyId1;
            dcCustomerWork.UpdAssemblyId2 = customerWork.UpdAssemblyId2;
            dcCustomerWork.LogicalDeleteCode = customerWork.LogicalDeleteCode;
            dcCustomerWork.CustomerCode = customerWork.CustomerCode;
            dcCustomerWork.CustomerSubCode = customerWork.CustomerSubCode;
            dcCustomerWork.Name = customerWork.Name;
            dcCustomerWork.Name2 = customerWork.Name2;
            dcCustomerWork.HonorificTitle = customerWork.HonorificTitle;
            dcCustomerWork.Kana = customerWork.Kana;
            dcCustomerWork.CustomerSnm = customerWork.CustomerSnm;
            dcCustomerWork.OutputNameCode = customerWork.OutputNameCode;
            dcCustomerWork.OutputName = customerWork.OutputName;
            dcCustomerWork.CorporateDivCode = customerWork.CorporateDivCode;
            dcCustomerWork.CustomerAttributeDiv = customerWork.CustomerAttributeDiv;
            dcCustomerWork.JobTypeCode = customerWork.JobTypeCode;
            dcCustomerWork.BusinessTypeCode = customerWork.BusinessTypeCode;
            dcCustomerWork.SalesAreaCode = customerWork.SalesAreaCode;
            dcCustomerWork.PostNo = customerWork.PostNo;
            dcCustomerWork.Address1 = customerWork.Address1;
            dcCustomerWork.Address3 = customerWork.Address3;
            dcCustomerWork.Address4 = customerWork.Address4;
            dcCustomerWork.HomeTelNo = customerWork.HomeTelNo;
            dcCustomerWork.OfficeTelNo = customerWork.OfficeTelNo;
            dcCustomerWork.PortableTelNo = customerWork.PortableTelNo;
            dcCustomerWork.HomeFaxNo = customerWork.HomeFaxNo;
            dcCustomerWork.OfficeFaxNo = customerWork.OfficeFaxNo;
            dcCustomerWork.OthersTelNo = customerWork.OthersTelNo;
            dcCustomerWork.MainContactCode = customerWork.MainContactCode;
            dcCustomerWork.SearchTelNo = customerWork.SearchTelNo;
            dcCustomerWork.MngSectionCode = customerWork.MngSectionCode;
            dcCustomerWork.InpSectionCode = customerWork.InpSectionCode;
            dcCustomerWork.CustAnalysCode1 = customerWork.CustAnalysCode1;
            dcCustomerWork.CustAnalysCode2 = customerWork.CustAnalysCode2;
            dcCustomerWork.CustAnalysCode3 = customerWork.CustAnalysCode3;
            dcCustomerWork.CustAnalysCode4 = customerWork.CustAnalysCode4;
            dcCustomerWork.CustAnalysCode5 = customerWork.CustAnalysCode5;
            dcCustomerWork.CustAnalysCode6 = customerWork.CustAnalysCode6;
            // DEL 2010/02/02 MANTIS�Ή�[14953]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            // TODO:�g�p���Ȃ��c�������o�͋敪�R�[�h
            //dcCustomerWork.BillOutputCode = customerWork.BillOutputCode;
            // DEL 2010/02/02 MANTIS�Ή�[14953]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<
            dcCustomerWork.BillOutputName = customerWork.BillOutputName;
            dcCustomerWork.TotalDay = customerWork.TotalDay;
            dcCustomerWork.CollectMoneyCode = customerWork.CollectMoneyCode;
            dcCustomerWork.CollectMoneyName = customerWork.CollectMoneyName;
            dcCustomerWork.CollectMoneyDay = customerWork.CollectMoneyDay;
            dcCustomerWork.CollectCond = customerWork.CollectCond;
            dcCustomerWork.CollectSight = customerWork.CollectSight;
            dcCustomerWork.ClaimCode = customerWork.ClaimCode;
            dcCustomerWork.TransStopDate = customerWork.TransStopDate;
            dcCustomerWork.DmOutCode = customerWork.DmOutCode;
            dcCustomerWork.DmOutName = customerWork.DmOutName;
            dcCustomerWork.MainSendMailAddrCd = customerWork.MainSendMailAddrCd;
            dcCustomerWork.MailAddrKindCode1 = customerWork.MailAddrKindCode1;
            dcCustomerWork.MailAddrKindName1 = customerWork.MailAddrKindName1;
            dcCustomerWork.MailAddress1 = customerWork.MailAddress1;
            dcCustomerWork.MailSendCode1 = customerWork.MailSendCode1;
            dcCustomerWork.MailSendName1 = customerWork.MailSendName1;
            dcCustomerWork.MailAddrKindCode2 = customerWork.MailAddrKindCode2;
            dcCustomerWork.MailAddrKindName2 = customerWork.MailAddrKindName2;
            dcCustomerWork.MailAddress2 = customerWork.MailAddress2;
            dcCustomerWork.MailSendCode2 = customerWork.MailSendCode2;
            dcCustomerWork.MailSendName2 = customerWork.MailSendName2;
            dcCustomerWork.CustomerAgentCd = customerWork.CustomerAgentCd;
            dcCustomerWork.BillCollecterCd = customerWork.BillCollecterCd;
            dcCustomerWork.OldCustomerAgentCd = customerWork.OldCustomerAgentCd;
            dcCustomerWork.CustAgentChgDate = customerWork.CustAgentChgDate;
            dcCustomerWork.AcceptWholeSale = customerWork.AcceptWholeSale;
            dcCustomerWork.CreditMngCode = customerWork.CreditMngCode;
            dcCustomerWork.DepoDelCode = customerWork.DepoDelCode;
            dcCustomerWork.AccRecDivCd = customerWork.AccRecDivCd;
            dcCustomerWork.CustSlipNoMngCd = customerWork.CustSlipNoMngCd;
            dcCustomerWork.PureCode = customerWork.PureCode;
            dcCustomerWork.CustCTaXLayRefCd = customerWork.CustCTaXLayRefCd;
            dcCustomerWork.ConsTaxLayMethod = customerWork.ConsTaxLayMethod;
            dcCustomerWork.TotalAmountDispWayCd = customerWork.TotalAmountDispWayCd;
            dcCustomerWork.TotalAmntDspWayRef = customerWork.TotalAmntDspWayRef;
            dcCustomerWork.AccountNoInfo1 = customerWork.AccountNoInfo1;
            dcCustomerWork.AccountNoInfo2 = customerWork.AccountNoInfo2;
            dcCustomerWork.AccountNoInfo3 = customerWork.AccountNoInfo3;
            dcCustomerWork.SalesUnPrcFrcProcCd = customerWork.SalesUnPrcFrcProcCd;
            dcCustomerWork.SalesMoneyFrcProcCd = customerWork.SalesMoneyFrcProcCd;
            dcCustomerWork.SalesCnsTaxFrcProcCd = customerWork.SalesCnsTaxFrcProcCd;
            dcCustomerWork.CustomerSlipNoDiv = customerWork.CustomerSlipNoDiv;
            dcCustomerWork.NTimeCalcStDate = customerWork.NTimeCalcStDate;
            dcCustomerWork.CustomerAgent = customerWork.CustomerAgent;
            dcCustomerWork.ClaimSectionCode = customerWork.ClaimSectionCode;
            dcCustomerWork.CarMngDivCd = customerWork.CarMngDivCd;
            dcCustomerWork.BillPartsNoPrtCd = customerWork.BillPartsNoPrtCd;
            dcCustomerWork.DeliPartsNoPrtCd = customerWork.DeliPartsNoPrtCd;
            dcCustomerWork.DefSalesSlipCd = customerWork.DefSalesSlipCd;
            dcCustomerWork.LavorRateRank = customerWork.LavorRateRank;
            dcCustomerWork.SlipTtlPrn = customerWork.SlipTtlPrn;
            dcCustomerWork.DepoBankCode = customerWork.DepoBankCode;
            dcCustomerWork.CustWarehouseCd = customerWork.CustWarehouseCd;
            dcCustomerWork.QrcodePrtCd = customerWork.QrcodePrtCd;
            dcCustomerWork.DeliHonorificTtl = customerWork.DeliHonorificTtl;
            dcCustomerWork.BillHonorificTtl = customerWork.BillHonorificTtl;
            dcCustomerWork.EstmHonorificTtl = customerWork.EstmHonorificTtl;
            dcCustomerWork.RectHonorificTtl = customerWork.RectHonorificTtl;
            dcCustomerWork.DeliHonorTtlPrtDiv = customerWork.DeliHonorTtlPrtDiv;
            dcCustomerWork.BillHonorTtlPrtDiv = customerWork.BillHonorTtlPrtDiv;
            dcCustomerWork.EstmHonorTtlPrtDiv = customerWork.EstmHonorTtlPrtDiv;
            dcCustomerWork.RectHonorTtlPrtDiv = customerWork.RectHonorTtlPrtDiv;
            dcCustomerWork.Note1 = customerWork.Note1;
            dcCustomerWork.Note2 = customerWork.Note2;
            dcCustomerWork.Note3 = customerWork.Note3;
            dcCustomerWork.Note4 = customerWork.Note4;
            dcCustomerWork.Note5 = customerWork.Note5;
            dcCustomerWork.Note6 = customerWork.Note6;
            dcCustomerWork.Note7 = customerWork.Note7;
            dcCustomerWork.Note8 = customerWork.Note8;
            dcCustomerWork.Note9 = customerWork.Note9;
            dcCustomerWork.Note10 = customerWork.Note10;
            dcCustomerWork.SalesSlipPrtDiv = customerWork.SalesSlipPrtDiv;
            dcCustomerWork.ShipmSlipPrtDiv = customerWork.ShipmSlipPrtDiv;
            dcCustomerWork.AcpOdrrSlipPrtDiv = customerWork.AcpOdrrSlipPrtDiv;
            dcCustomerWork.EstimatePrtDiv = customerWork.EstimatePrtDiv;
            dcCustomerWork.UOESlipPrtDiv = customerWork.UOESlipPrtDiv;
            dcCustomerWork.ReceiptOutputCode = customerWork.ReceiptOutputCode;

            // ADD 2009/05/25 --->>>
            dcCustomerWork.CustomerEpCode = customerWork.CustomerEpCode;
            dcCustomerWork.CustomerSecCode = customerWork.CustomerSecCode;
            dcCustomerWork.OnlineKindDiv = customerWork.OnlineKindDiv;
            // ADD 2009/05/25 ---<<<
            // ADD 2010/02/02 MANTIS�Ή�[14953]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            dcCustomerWork.TotalBillOutputDiv = customerWork.TotalBillOutputDiv;        // ���v�������o�͋敪
            dcCustomerWork.DetailBillOutputCode = customerWork.DetailBillOutputCode;    // ���א������o�͋敪
            dcCustomerWork.SlipTtlBillOutputDiv = customerWork.SlipTtlBillOutputDiv;    // �`�[���v�������o�͋敪
            // ADD 2010/02/02 MANTIS�Ή�[14953]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            return dcCustomerWork;
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�ϓ����)�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="customerChangeWork">���Ӑ�}�X�^(�ϓ����)�f�[�^</param>
        /// <returns>DC���Ӑ�}�X�^(�ϓ����)�f�[�^</returns>
        public static DCCustomerChangeWork SearchDataFromUpdateData(APCustomerChangeWork customerChangeWork)
        {
            if (customerChangeWork == null)
            {
                return null;
            }

            DCCustomerChangeWork dcCustomerChangeWork = new DCCustomerChangeWork();

            //���Ӑ�}�X�^(�ϓ����)�f�[�^�ϊ�
            dcCustomerChangeWork.CreateDateTime = customerChangeWork.CreateDateTime;
            dcCustomerChangeWork.UpdateDateTime = customerChangeWork.UpdateDateTime;
            dcCustomerChangeWork.EnterpriseCode = customerChangeWork.EnterpriseCode;
            dcCustomerChangeWork.FileHeaderGuid = customerChangeWork.FileHeaderGuid;
            dcCustomerChangeWork.UpdEmployeeCode = customerChangeWork.UpdEmployeeCode;
            dcCustomerChangeWork.UpdAssemblyId1 = customerChangeWork.UpdAssemblyId1;
            dcCustomerChangeWork.UpdAssemblyId2 = customerChangeWork.UpdAssemblyId2;
            dcCustomerChangeWork.LogicalDeleteCode = customerChangeWork.LogicalDeleteCode;
            dcCustomerChangeWork.CustomerCode = customerChangeWork.CustomerCode;
            dcCustomerChangeWork.CreditMoney = customerChangeWork.CreditMoney;
            dcCustomerChangeWork.WarningCreditMoney = customerChangeWork.WarningCreditMoney;
            dcCustomerChangeWork.PrsntAccRecBalance = customerChangeWork.PrsntAccRecBalance;

            return dcCustomerChangeWork;
        }

        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
        /// <summary>
        /// ���Ӑ�}�X�^(�������)�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="customerMemoWork">���Ӑ�}�X�^(�������)�f�[�^</param>
        /// <returns>DC���Ӑ�}�X�^(�������)�f�[�^</returns>
        public static DCCustomerMemoWork SearchDataFromUpdateData(APCustomerMemoWork customerMemoWork)
        {
            if (customerMemoWork == null)
            {
                return null;
            }

            DCCustomerMemoWork dcCustomerMemoWork = new DCCustomerMemoWork();

            //���Ӑ�}�X�^(�������)�f�[�^�ϊ�
            dcCustomerMemoWork.CreateDateTime = customerMemoWork.CreateDateTime;
            dcCustomerMemoWork.UpdateDateTime = customerMemoWork.UpdateDateTime;
            dcCustomerMemoWork.EnterpriseCode = customerMemoWork.EnterpriseCode;
            dcCustomerMemoWork.FileHeaderGuid = customerMemoWork.FileHeaderGuid;
            dcCustomerMemoWork.UpdEmployeeCode = customerMemoWork.UpdEmployeeCode;
            dcCustomerMemoWork.UpdAssemblyId1 = customerMemoWork.UpdAssemblyId1;
            dcCustomerMemoWork.UpdAssemblyId2 = customerMemoWork.UpdAssemblyId2;
            dcCustomerMemoWork.LogicalDeleteCode = customerMemoWork.LogicalDeleteCode;
            dcCustomerMemoWork.CustomerCode = customerMemoWork.CustomerCode;
            dcCustomerMemoWork.NoteInfo = customerMemoWork.NoteInfo;
            dcCustomerMemoWork.DisplayDivCode = customerMemoWork.DisplayDivCode;

            return dcCustomerMemoWork;
        }
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="custSlipMngWork">���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^</param>
        /// <returns>DC���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^</returns>
        public static DCCustSlipMngWork SearchDataFromUpdateData(APCustSlipMngWork custSlipMngWork)
        {
            if (custSlipMngWork == null)
            {
                return null;
            }

            DCCustSlipMngWork dcCustSlipMngWork = new DCCustSlipMngWork();

            // ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^�ϊ�
            dcCustSlipMngWork.CreateDateTime = custSlipMngWork.CreateDateTime;
            dcCustSlipMngWork.UpdateDateTime = custSlipMngWork.UpdateDateTime;
            dcCustSlipMngWork.EnterpriseCode = custSlipMngWork.EnterpriseCode;
            dcCustSlipMngWork.FileHeaderGuid = custSlipMngWork.FileHeaderGuid;
            dcCustSlipMngWork.UpdEmployeeCode = custSlipMngWork.UpdEmployeeCode;
            dcCustSlipMngWork.UpdAssemblyId1 = custSlipMngWork.UpdAssemblyId1;
            dcCustSlipMngWork.UpdAssemblyId2 = custSlipMngWork.UpdAssemblyId2;
            dcCustSlipMngWork.LogicalDeleteCode = custSlipMngWork.LogicalDeleteCode;
            dcCustSlipMngWork.DataInputSystem = custSlipMngWork.DataInputSystem;
            dcCustSlipMngWork.SlipPrtKind = custSlipMngWork.SlipPrtKind;
            dcCustSlipMngWork.SectionCode = custSlipMngWork.SectionCode;
            dcCustSlipMngWork.CustomerCode = custSlipMngWork.CustomerCode;
            dcCustSlipMngWork.SlipPrtSetPaperId = custSlipMngWork.SlipPrtSetPaperId;

            return dcCustSlipMngWork;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="custRateGroupWork">���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^</param>
        /// <returns>DC���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^</returns>
        public static DCCustRateGroupWork SearchDataFromUpdateData(APCustRateGroupWork custRateGroupWork)
        {
            if (custRateGroupWork == null)
            {
                return null;
            }

            DCCustRateGroupWork dcCustRateGroupWork = new DCCustRateGroupWork();

            // ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�ϊ�
            dcCustRateGroupWork.CreateDateTime = custRateGroupWork.CreateDateTime;
            dcCustRateGroupWork.UpdateDateTime = custRateGroupWork.UpdateDateTime;
            dcCustRateGroupWork.EnterpriseCode = custRateGroupWork.EnterpriseCode;
            dcCustRateGroupWork.FileHeaderGuid = custRateGroupWork.FileHeaderGuid;
            dcCustRateGroupWork.UpdEmployeeCode = custRateGroupWork.UpdEmployeeCode;
            dcCustRateGroupWork.UpdAssemblyId1 = custRateGroupWork.UpdAssemblyId1;
            dcCustRateGroupWork.UpdAssemblyId2 = custRateGroupWork.UpdAssemblyId2;
            dcCustRateGroupWork.LogicalDeleteCode = custRateGroupWork.LogicalDeleteCode;
            dcCustRateGroupWork.CustomerCode = custRateGroupWork.CustomerCode;
            dcCustRateGroupWork.PureCode = custRateGroupWork.PureCode;
            dcCustRateGroupWork.GoodsMakerCd = custRateGroupWork.GoodsMakerCd;
            dcCustRateGroupWork.CustRateGrpCode = custRateGroupWork.CustRateGrpCode;

            return dcCustRateGroupWork;
        }

        /// <summary>
        /// ���Ӑ�i�`�[�ԍ��j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="custSlipNoSetWork">���Ӑ�i�`�[�ԍ��j�f�[�^</param>
        /// <returns>DC���Ӑ�i�`�[�ԍ��j�f�[�^</returns>
        public static DCCustSlipNoSetWork SearchDataFromUpdateData(APCustSlipNoSetWork custSlipNoSetWork)
        {
            if (custSlipNoSetWork == null)
            {
                return null;
            }

            DCCustSlipNoSetWork dcCustSlipNoSetWork = new DCCustSlipNoSetWork();

            // ���Ӑ�i�`�[�ԍ��j�f�[�^�ϊ�
            dcCustSlipNoSetWork.CreateDateTime = custSlipNoSetWork.CreateDateTime;
            dcCustSlipNoSetWork.UpdateDateTime = custSlipNoSetWork.UpdateDateTime;
            dcCustSlipNoSetWork.EnterpriseCode = custSlipNoSetWork.EnterpriseCode;
            dcCustSlipNoSetWork.FileHeaderGuid = custSlipNoSetWork.FileHeaderGuid;
            dcCustSlipNoSetWork.UpdEmployeeCode = custSlipNoSetWork.UpdEmployeeCode;
            dcCustSlipNoSetWork.UpdAssemblyId1 = custSlipNoSetWork.UpdAssemblyId1;
            dcCustSlipNoSetWork.UpdAssemblyId2 = custSlipNoSetWork.UpdAssemblyId2;
            dcCustSlipNoSetWork.LogicalDeleteCode = custSlipNoSetWork.LogicalDeleteCode;
            dcCustSlipNoSetWork.CustomerCode = custSlipNoSetWork.CustomerCode;
            dcCustSlipNoSetWork.AddUpYearMonth = custSlipNoSetWork.AddUpYearMonth;
            dcCustSlipNoSetWork.PresentCustSlipNo = custSlipNoSetWork.PresentCustSlipNo;
            dcCustSlipNoSetWork.StartCustSlipNo = custSlipNoSetWork.StartCustSlipNo;
            dcCustSlipNoSetWork.EndCustSlipNo = custSlipNoSetWork.EndCustSlipNo;

            return dcCustSlipNoSetWork;
        }

        /// <summary>
        /// �d����}�X�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="supplierWork">�d����}�X�^</param>
        /// <returns>DC�d����}�X�^</returns>
        public static DCSupplierWork SearchDataFromUpdateData(APSupplierWork supplierWork)
        {
            if (supplierWork == null)
            {
                return null;
            }

            DCSupplierWork dcSupplierWork = new DCSupplierWork();

            // �d����}�X�^�ϊ�
            dcSupplierWork.CreateDateTime = supplierWork.CreateDateTime;
            dcSupplierWork.UpdateDateTime = supplierWork.UpdateDateTime;
            dcSupplierWork.EnterpriseCode = supplierWork.EnterpriseCode;
            dcSupplierWork.FileHeaderGuid = supplierWork.FileHeaderGuid;
            dcSupplierWork.UpdEmployeeCode = supplierWork.UpdEmployeeCode;
            dcSupplierWork.UpdAssemblyId1 = supplierWork.UpdAssemblyId1;
            dcSupplierWork.UpdAssemblyId2 = supplierWork.UpdAssemblyId2;
            dcSupplierWork.LogicalDeleteCode = supplierWork.LogicalDeleteCode;
            dcSupplierWork.SupplierCd = supplierWork.SupplierCd;
            dcSupplierWork.MngSectionCode = supplierWork.MngSectionCode;
            dcSupplierWork.InpSectionCode = supplierWork.InpSectionCode;
            dcSupplierWork.PaymentSectionCode = supplierWork.PaymentSectionCode;
            dcSupplierWork.SupplierNm1 = supplierWork.SupplierNm1;
            dcSupplierWork.SupplierNm2 = supplierWork.SupplierNm2;
            dcSupplierWork.SuppHonorificTitle = supplierWork.SuppHonorificTitle;
            dcSupplierWork.SupplierKana = supplierWork.SupplierKana;
            dcSupplierWork.SupplierSnm = supplierWork.SupplierSnm;
            dcSupplierWork.OrderHonorificTtl = supplierWork.OrderHonorificTtl;
            dcSupplierWork.BusinessTypeCode = supplierWork.BusinessTypeCode;
            dcSupplierWork.SalesAreaCode = supplierWork.SalesAreaCode;
            dcSupplierWork.SupplierPostNo = supplierWork.SupplierPostNo;
            dcSupplierWork.SupplierAddr1 = supplierWork.SupplierAddr1;
            dcSupplierWork.SupplierAddr3 = supplierWork.SupplierAddr3;
            dcSupplierWork.SupplierAddr4 = supplierWork.SupplierAddr4;
            dcSupplierWork.SupplierTelNo = supplierWork.SupplierTelNo;
            dcSupplierWork.SupplierTelNo1 = supplierWork.SupplierTelNo1;
            dcSupplierWork.SupplierTelNo2 = supplierWork.SupplierTelNo2;
            dcSupplierWork.PureCode = supplierWork.PureCode;
            dcSupplierWork.PaymentMonthCode = supplierWork.PaymentMonthCode;
            dcSupplierWork.PaymentMonthName = supplierWork.PaymentMonthName;
            dcSupplierWork.PaymentDay = supplierWork.PaymentDay;
            dcSupplierWork.SuppCTaxLayRefCd = supplierWork.SuppCTaxLayRefCd;
            dcSupplierWork.SuppCTaxLayCd = supplierWork.SuppCTaxLayCd;
            dcSupplierWork.SuppCTaxationCd = supplierWork.SuppCTaxationCd;
            dcSupplierWork.SuppEnterpriseCd = supplierWork.SuppEnterpriseCd;
            dcSupplierWork.PayeeCode = supplierWork.PayeeCode;
            dcSupplierWork.SupplierAttributeDiv = supplierWork.SupplierAttributeDiv;
            dcSupplierWork.SuppTtlAmntDspWayCd = supplierWork.SuppTtlAmntDspWayCd;
            dcSupplierWork.StckTtlAmntDspWayRef = supplierWork.StckTtlAmntDspWayRef;
            dcSupplierWork.PaymentCond = supplierWork.PaymentCond;
            dcSupplierWork.PaymentTotalDay = supplierWork.PaymentTotalDay;
            dcSupplierWork.PaymentSight = supplierWork.PaymentSight;
            dcSupplierWork.StockAgentCode = supplierWork.StockAgentCode;
            dcSupplierWork.StockUnPrcFrcProcCd = supplierWork.StockUnPrcFrcProcCd;
            dcSupplierWork.StockMoneyFrcProcCd = supplierWork.StockMoneyFrcProcCd;
            dcSupplierWork.StockCnsTaxFrcProcCd = supplierWork.StockCnsTaxFrcProcCd;
            dcSupplierWork.NTimeCalcStDate = supplierWork.NTimeCalcStDate;
            dcSupplierWork.SupplierNote1 = supplierWork.SupplierNote1;
            dcSupplierWork.SupplierNote2 = supplierWork.SupplierNote2;
            dcSupplierWork.SupplierNote3 = supplierWork.SupplierNote3;
            dcSupplierWork.SupplierNote4 = supplierWork.SupplierNote4;

            return dcSupplierWork;
        }

        /// <summary>
        /// ���[�J�[�i���[�U�[�o�^���j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="makerUWork">���[�J�[�i���[�U�[�o�^���j�f�[�^</param>
        /// <returns>DC���[�J�[�i���[�U�[�o�^���j�f�[�^</returns>
        public static DCMakerUWork SearchDataFromUpdateData(APMakerUWork makerUWork)
        {
            if (makerUWork == null)
            {
                return null;
            }

            DCMakerUWork dcMakerUWork = new DCMakerUWork();

            // ���[�J�[�i���[�U�[�o�^���j�f�[�^�ϊ�
            dcMakerUWork.CreateDateTime = makerUWork.CreateDateTime;
            dcMakerUWork.UpdateDateTime = makerUWork.UpdateDateTime;
            dcMakerUWork.EnterpriseCode = makerUWork.EnterpriseCode;
            dcMakerUWork.FileHeaderGuid = makerUWork.FileHeaderGuid;
            dcMakerUWork.UpdEmployeeCode = makerUWork.UpdEmployeeCode;
            dcMakerUWork.UpdAssemblyId1 = makerUWork.UpdAssemblyId1;
            dcMakerUWork.UpdAssemblyId2 = makerUWork.UpdAssemblyId2;
            dcMakerUWork.LogicalDeleteCode = makerUWork.LogicalDeleteCode;
            dcMakerUWork.GoodsMakerCd = makerUWork.GoodsMakerCd;
            dcMakerUWork.MakerName = makerUWork.MakerName;
            dcMakerUWork.MakerShortName = makerUWork.MakerShortName;
            dcMakerUWork.MakerKanaName = makerUWork.MakerKanaName;
            dcMakerUWork.DisplayOrder = makerUWork.DisplayOrder;
            dcMakerUWork.OfferDate = makerUWork.OfferDate;
            dcMakerUWork.OfferDataDiv = makerUWork.OfferDataDiv;

            return dcMakerUWork;
        }

        /// <summary>
        /// �a�k���i�R�[�h(���[�U�[)PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="bLGoodsCdUWork">�a�k���i�R�[�h(���[�U�[)</param>
        /// <returns>DC�a�k���i�R�[�h(���[�U�[)</returns>
        public static DCBLGoodsCdUWork SearchDataFromUpdateData(APBLGoodsCdUWork bLGoodsCdUWork)
        {
            if (bLGoodsCdUWork == null)
            {
                return null;
            }

            DCBLGoodsCdUWork dcBLGoodsCdUWork = new DCBLGoodsCdUWork();

            // �a�k���i�R�[�h(���[�U�[)�ϊ�
            dcBLGoodsCdUWork.CreateDateTime = bLGoodsCdUWork.CreateDateTime;
            dcBLGoodsCdUWork.UpdateDateTime = bLGoodsCdUWork.UpdateDateTime;
            dcBLGoodsCdUWork.EnterpriseCode = bLGoodsCdUWork.EnterpriseCode;
            dcBLGoodsCdUWork.FileHeaderGuid = bLGoodsCdUWork.FileHeaderGuid;
            dcBLGoodsCdUWork.UpdEmployeeCode = bLGoodsCdUWork.UpdEmployeeCode;
            dcBLGoodsCdUWork.UpdAssemblyId1 = bLGoodsCdUWork.UpdAssemblyId1;
            dcBLGoodsCdUWork.UpdAssemblyId2 = bLGoodsCdUWork.UpdAssemblyId2;
            dcBLGoodsCdUWork.LogicalDeleteCode = bLGoodsCdUWork.LogicalDeleteCode;
            dcBLGoodsCdUWork.BLGroupCode = bLGoodsCdUWork.BLGroupCode;
            dcBLGoodsCdUWork.BLGoodsCode = bLGoodsCdUWork.BLGoodsCode;
            dcBLGoodsCdUWork.BLGoodsFullName = bLGoodsCdUWork.BLGoodsFullName;
            dcBLGoodsCdUWork.BLGoodsHalfName = bLGoodsCdUWork.BLGoodsHalfName;
            dcBLGoodsCdUWork.BLGoodsGenreCode = bLGoodsCdUWork.BLGoodsGenreCode;
            dcBLGoodsCdUWork.GoodsRateGrpCode = bLGoodsCdUWork.GoodsRateGrpCode;
            dcBLGoodsCdUWork.OfferDate = bLGoodsCdUWork.OfferDate;
            dcBLGoodsCdUWork.OfferDataDiv = bLGoodsCdUWork.OfferDataDiv;

            return dcBLGoodsCdUWork;
        }

        /// <summary>
        /// ���i�i���[�U�[�o�^���jPramData��UIData�ڍ�����
        /// </summary>
        /// <param name="goodsUWork">AP���i�i���[�U�[�o�^���j</param>
        /// <returns>DC���i�i���[�U�[�o�^���j</returns>
        public static DCGoodsUWork SearchDataFromUpdateData(APGoodsUWork goodsUWork)
        {
            if (goodsUWork == null)
            {
                return null;
            }

            DCGoodsUWork dcGoodsUWork = new DCGoodsUWork();

            // ���i�i���[�U�[�o�^���j�ϊ�
            dcGoodsUWork.CreateDateTime = goodsUWork.CreateDateTime;
            dcGoodsUWork.UpdateDateTime = goodsUWork.UpdateDateTime;
            dcGoodsUWork.EnterpriseCode = goodsUWork.EnterpriseCode;
            dcGoodsUWork.FileHeaderGuid = goodsUWork.FileHeaderGuid;
            dcGoodsUWork.UpdEmployeeCode = goodsUWork.UpdEmployeeCode;
            dcGoodsUWork.UpdAssemblyId1 = goodsUWork.UpdAssemblyId1;
            dcGoodsUWork.UpdAssemblyId2 = goodsUWork.UpdAssemblyId2;
            dcGoodsUWork.LogicalDeleteCode = goodsUWork.LogicalDeleteCode;
            dcGoodsUWork.GoodsMakerCd = goodsUWork.GoodsMakerCd;
            dcGoodsUWork.GoodsNo = goodsUWork.GoodsNo;
            dcGoodsUWork.GoodsName = goodsUWork.GoodsName;
            dcGoodsUWork.GoodsNameKana = goodsUWork.GoodsNameKana;
            dcGoodsUWork.Jan = goodsUWork.Jan;
            dcGoodsUWork.BLGoodsCode = goodsUWork.BLGoodsCode;
            dcGoodsUWork.DisplayOrder = goodsUWork.DisplayOrder;
            dcGoodsUWork.GoodsRateRank = goodsUWork.GoodsRateRank;
            dcGoodsUWork.TaxationDivCd = goodsUWork.TaxationDivCd;
            dcGoodsUWork.GoodsNoNoneHyphen = goodsUWork.GoodsNoNoneHyphen;
            dcGoodsUWork.OfferDate = goodsUWork.OfferDate;
            dcGoodsUWork.GoodsKindCode = goodsUWork.GoodsKindCode;
            dcGoodsUWork.GoodsNote1 = goodsUWork.GoodsNote1;
            dcGoodsUWork.GoodsNote2 = goodsUWork.GoodsNote2;
            dcGoodsUWork.GoodsSpecialNote = goodsUWork.GoodsSpecialNote;
            dcGoodsUWork.EnterpriseGanreCode = goodsUWork.EnterpriseGanreCode;
            dcGoodsUWork.UpdateDate = goodsUWork.UpdateDate;
            dcGoodsUWork.OfferDataDiv = goodsUWork.OfferDataDiv;

            return dcGoodsUWork;
        }

        /// <summary>
        /// ���i�i���[�U�[�o�^���j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="goodsPriceUWork">���i�i���[�U�[�o�^���j�f�[�^</param>
        /// <returns>���i�i���[�U�[�o�^���j�f�[�^</returns>
        public static DCGoodsPriceUWork SearchDataFromUpdateData(APGoodsPriceUWork goodsPriceUWork)
        {
            if (goodsPriceUWork == null)
            {
                return null;
            }

            DCGoodsPriceUWork dcGoodsPriceUWork = new DCGoodsPriceUWork();

            // ���i�i���[�U�[�o�^���j�f�[�^�ϊ�
            dcGoodsPriceUWork.CreateDateTime = goodsPriceUWork.CreateDateTime;
            dcGoodsPriceUWork.UpdateDateTime = goodsPriceUWork.UpdateDateTime;
            dcGoodsPriceUWork.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
            dcGoodsPriceUWork.FileHeaderGuid = goodsPriceUWork.FileHeaderGuid;
            dcGoodsPriceUWork.UpdEmployeeCode = goodsPriceUWork.UpdEmployeeCode;
            dcGoodsPriceUWork.UpdAssemblyId1 = goodsPriceUWork.UpdAssemblyId1;
            dcGoodsPriceUWork.UpdAssemblyId2 = goodsPriceUWork.UpdAssemblyId2;
            dcGoodsPriceUWork.LogicalDeleteCode = goodsPriceUWork.LogicalDeleteCode;
            dcGoodsPriceUWork.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
            dcGoodsPriceUWork.GoodsNo = goodsPriceUWork.GoodsNo;
            dcGoodsPriceUWork.PriceStartDate = goodsPriceUWork.PriceStartDate;
            dcGoodsPriceUWork.ListPrice = goodsPriceUWork.ListPrice;
            dcGoodsPriceUWork.SalesUnitCost = goodsPriceUWork.SalesUnitCost;
            dcGoodsPriceUWork.StockRate = goodsPriceUWork.StockRate;
            dcGoodsPriceUWork.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv;
            dcGoodsPriceUWork.OfferDate = goodsPriceUWork.OfferDate;
            dcGoodsPriceUWork.UpdateDate = goodsPriceUWork.UpdateDate;

            return dcGoodsPriceUWork;
        }

        /// <summary>
        /// ���i�Ǘ����f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="goodsMngWork">AP���i�Ǘ����f�[�^</param>
        /// <returns>DC���i�Ǘ����f�[�^</returns>
        public static DCGoodsMngWork SearchDataFromUpdateData(APGoodsMngWork goodsMngWork)
        {
            if (goodsMngWork == null)
            {
                return null;
            }

            DCGoodsMngWork dcGoodsMngWork = new DCGoodsMngWork();

            // ���i�Ǘ����f�[�^�ϊ�
            dcGoodsMngWork.CreateDateTime = goodsMngWork.CreateDateTime;
            dcGoodsMngWork.UpdateDateTime = goodsMngWork.UpdateDateTime;
            dcGoodsMngWork.EnterpriseCode = goodsMngWork.EnterpriseCode;
            dcGoodsMngWork.FileHeaderGuid = goodsMngWork.FileHeaderGuid;
            dcGoodsMngWork.UpdEmployeeCode = goodsMngWork.UpdEmployeeCode;
            dcGoodsMngWork.UpdAssemblyId1 = goodsMngWork.UpdAssemblyId1;
            dcGoodsMngWork.UpdAssemblyId2 = goodsMngWork.UpdAssemblyId2;
            dcGoodsMngWork.LogicalDeleteCode = goodsMngWork.LogicalDeleteCode;
            dcGoodsMngWork.SectionCode = goodsMngWork.SectionCode;
            dcGoodsMngWork.GoodsMGroup = goodsMngWork.GoodsMGroup;
            dcGoodsMngWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
            dcGoodsMngWork.BLGoodsCode = goodsMngWork.BLGoodsCode;
            dcGoodsMngWork.GoodsNo = goodsMngWork.GoodsNo;
            dcGoodsMngWork.SupplierCd = goodsMngWork.SupplierCd;
            dcGoodsMngWork.SupplierLot = goodsMngWork.SupplierLot;

            return dcGoodsMngWork;
        }

        /// <summary>
        /// �������i�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="isolIslandPrcWork">AP�������i�f�[�^</param>
        /// <returns>DC�������i�f�[�^</returns>
        public static DCIsolIslandPrcWork SearchDataFromUpdateData(APIsolIslandPrcWork isolIslandPrcWork)
        {
            if (isolIslandPrcWork == null)
            {
                return null;
            }

            DCIsolIslandPrcWork dcIsolIslandPrcWork = new DCIsolIslandPrcWork();

            // �������i�f�[�^�ϊ�;
            dcIsolIslandPrcWork.CreateDateTime = isolIslandPrcWork.CreateDateTime;
            dcIsolIslandPrcWork.UpdateDateTime = isolIslandPrcWork.UpdateDateTime;
            dcIsolIslandPrcWork.EnterpriseCode = isolIslandPrcWork.EnterpriseCode;
            dcIsolIslandPrcWork.FileHeaderGuid = isolIslandPrcWork.FileHeaderGuid;
            dcIsolIslandPrcWork.UpdEmployeeCode = isolIslandPrcWork.UpdEmployeeCode;
            dcIsolIslandPrcWork.UpdAssemblyId1 = isolIslandPrcWork.UpdAssemblyId1;
            dcIsolIslandPrcWork.UpdAssemblyId2 = isolIslandPrcWork.UpdAssemblyId2;
            dcIsolIslandPrcWork.LogicalDeleteCode = isolIslandPrcWork.LogicalDeleteCode;
            dcIsolIslandPrcWork.SectionCode = isolIslandPrcWork.SectionCode;
            dcIsolIslandPrcWork.MakerCode = isolIslandPrcWork.MakerCode;
            dcIsolIslandPrcWork.UpperLimitPrice = isolIslandPrcWork.UpperLimitPrice;
            dcIsolIslandPrcWork.FractionProcUnit = isolIslandPrcWork.FractionProcUnit;
            dcIsolIslandPrcWork.FractionProcCd = isolIslandPrcWork.FractionProcCd;
            dcIsolIslandPrcWork.UpRate = isolIslandPrcWork.UpRate;

            return dcIsolIslandPrcWork;
        }

        /// <summary>
        /// �݌Ƀf�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="stockWork">AP�݌Ƀf�[�^</param>
        /// <returns>DC�݌Ƀf�[�^</returns>
        public static DCStockWork SearchDataFromUpdateData(APStockWork stockWork)
        {
            if (stockWork == null)
            {
                return null;
            }

            DCStockWork dcStockWork = new DCStockWork();

            // �݌Ƀf�[�^�ϊ�
            dcStockWork.CreateDateTime = stockWork.CreateDateTime;
            dcStockWork.UpdateDateTime = stockWork.UpdateDateTime;
            dcStockWork.EnterpriseCode = stockWork.EnterpriseCode;
            dcStockWork.FileHeaderGuid = stockWork.FileHeaderGuid;
            dcStockWork.UpdEmployeeCode = stockWork.UpdEmployeeCode;
            dcStockWork.UpdAssemblyId1 = stockWork.UpdAssemblyId1;
            dcStockWork.UpdAssemblyId2 = stockWork.UpdAssemblyId2;
            dcStockWork.LogicalDeleteCode = stockWork.LogicalDeleteCode;
            dcStockWork.SectionCode = stockWork.SectionCode;
            dcStockWork.WarehouseCode = stockWork.WarehouseCode;
            dcStockWork.GoodsMakerCd = stockWork.GoodsMakerCd;
            dcStockWork.GoodsNo = stockWork.GoodsNo;
            dcStockWork.StockUnitPriceFl = stockWork.StockUnitPriceFl;
            dcStockWork.SupplierStock = stockWork.SupplierStock;
            dcStockWork.AcpOdrCount = stockWork.AcpOdrCount;
            dcStockWork.MonthOrderCount = stockWork.MonthOrderCount;
            dcStockWork.SalesOrderCount = stockWork.SalesOrderCount;
            dcStockWork.StockDiv = stockWork.StockDiv;
            dcStockWork.MovingSupliStock = stockWork.MovingSupliStock;
            dcStockWork.ShipmentPosCnt = stockWork.ShipmentPosCnt;
            dcStockWork.StockTotalPrice = stockWork.StockTotalPrice;
            dcStockWork.LastStockDate = stockWork.LastStockDate;
            dcStockWork.LastSalesDate = stockWork.LastSalesDate;
            dcStockWork.LastInventoryUpdate = stockWork.LastInventoryUpdate;
            dcStockWork.MinimumStockCnt = stockWork.MinimumStockCnt;
            dcStockWork.MaximumStockCnt = stockWork.MaximumStockCnt;
            dcStockWork.NmlSalOdrCount = stockWork.NmlSalOdrCount;
            dcStockWork.SalesOrderUnit = stockWork.SalesOrderUnit;
            dcStockWork.StockSupplierCode = stockWork.StockSupplierCode;
            dcStockWork.GoodsNoNoneHyphen = stockWork.GoodsNoNoneHyphen;
            dcStockWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
            dcStockWork.DuplicationShelfNo1 = stockWork.DuplicationShelfNo1;
            dcStockWork.DuplicationShelfNo2 = stockWork.DuplicationShelfNo2;
            dcStockWork.PartsManagementDivide1 = stockWork.PartsManagementDivide1;
            dcStockWork.PartsManagementDivide2 = stockWork.PartsManagementDivide2;
            dcStockWork.StockNote1 = stockWork.StockNote1;
            dcStockWork.StockNote2 = stockWork.StockNote2;
            dcStockWork.ShipmentCnt = stockWork.ShipmentCnt;
            dcStockWork.ArrivalCnt = stockWork.ArrivalCnt;
            dcStockWork.StockCreateDate = stockWork.StockCreateDate;
            dcStockWork.UpdateDate = stockWork.UpdateDate;

            return dcStockWork;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�ύX���j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="userGdBdUWork">AP���[�U�[�K�C�h�i�{�f�B�j�i���[�U�ύX���j�f�[�^</param>
        /// <returns>DC���[�U�[�K�C�h�i�{�f�B�j�i���[�U�ύX���j�f�[�^</returns>
        public static DCUserGdBdUWork SearchDataFromUpdateData(APUserGdBdUWork userGdBdUWork)
        {
            if (userGdBdUWork == null)
            {
                return null;
            }

            DCUserGdBdUWork dcUserGdBdUWork = new DCUserGdBdUWork();

            // ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�ύX���j�f�[�^�ϊ�
            dcUserGdBdUWork.CreateDateTime = userGdBdUWork.CreateDateTime;
            dcUserGdBdUWork.UpdateDateTime = userGdBdUWork.UpdateDateTime;
            dcUserGdBdUWork.EnterpriseCode = userGdBdUWork.EnterpriseCode;
            dcUserGdBdUWork.FileHeaderGuid = userGdBdUWork.FileHeaderGuid;
            dcUserGdBdUWork.UpdEmployeeCode = userGdBdUWork.UpdEmployeeCode;
            dcUserGdBdUWork.UpdAssemblyId1 = userGdBdUWork.UpdAssemblyId1;
            dcUserGdBdUWork.UpdAssemblyId2 = userGdBdUWork.UpdAssemblyId2;
            dcUserGdBdUWork.LogicalDeleteCode = userGdBdUWork.LogicalDeleteCode;
            dcUserGdBdUWork.UserGuideDivCd = userGdBdUWork.UserGuideDivCd;
            dcUserGdBdUWork.GuideCode = userGdBdUWork.GuideCode;
            dcUserGdBdUWork.GuideName = userGdBdUWork.GuideName;
            dcUserGdBdUWork.GuideType = userGdBdUWork.GuideType;

            return dcUserGdBdUWork;
        }

        /// <summary>
        /// �|���f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="rateWork">AP�|���f�[�^</param>
        /// <returns>DC�|���f�[�^</returns>
        public static DCRateWork SearchDataFromUpdateData(APRateWork rateWork)
        {
            if (rateWork == null)
            {
                return null;
            }

            DCRateWork dcRateWork = new DCRateWork();

            // �|���f�[�^�ϊ�
            dcRateWork.CreateDateTime = rateWork.CreateDateTime;
            dcRateWork.UpdateDateTime = rateWork.UpdateDateTime;
            dcRateWork.EnterpriseCode = rateWork.EnterpriseCode;
            dcRateWork.FileHeaderGuid = rateWork.FileHeaderGuid;
            dcRateWork.UpdEmployeeCode = rateWork.UpdEmployeeCode;
            dcRateWork.UpdAssemblyId1 = rateWork.UpdAssemblyId1;
            dcRateWork.UpdAssemblyId2 = rateWork.UpdAssemblyId2;
            dcRateWork.LogicalDeleteCode = rateWork.LogicalDeleteCode;
            dcRateWork.SectionCode = rateWork.SectionCode;
            dcRateWork.UnitRateSetDivCd = rateWork.UnitRateSetDivCd;
            dcRateWork.UnitPriceKind = rateWork.UnitPriceKind;
            dcRateWork.RateSettingDivide = rateWork.RateSettingDivide;
            dcRateWork.RateMngGoodsCd = rateWork.RateMngGoodsCd;
            dcRateWork.RateMngGoodsNm = rateWork.RateMngGoodsNm;
            dcRateWork.RateMngCustCd = rateWork.RateMngCustCd;
            dcRateWork.RateMngCustNm = rateWork.RateMngCustNm;
            dcRateWork.GoodsMakerCd = rateWork.GoodsMakerCd;
            dcRateWork.GoodsNo = rateWork.GoodsNo;
            dcRateWork.GoodsRateRank = rateWork.GoodsRateRank;
            dcRateWork.GoodsRateGrpCode = rateWork.GoodsRateGrpCode;
            dcRateWork.BLGroupCode = rateWork.BLGroupCode;
            dcRateWork.BLGoodsCode = rateWork.BLGoodsCode;
            dcRateWork.CustomerCode = rateWork.CustomerCode;
            dcRateWork.CustRateGrpCode = rateWork.CustRateGrpCode;
            dcRateWork.SupplierCd = rateWork.SupplierCd;
            dcRateWork.LotCount = rateWork.LotCount;
            dcRateWork.PriceFl = rateWork.PriceFl;
            dcRateWork.RateVal = rateWork.RateVal;
            dcRateWork.UpRate = rateWork.UpRate;
            dcRateWork.GrsProfitSecureRate = rateWork.GrsProfitSecureRate;
            dcRateWork.UnPrcFracProcUnit = rateWork.UnPrcFracProcUnit;
            dcRateWork.UnPrcFracProcDiv = rateWork.UnPrcFracProcDiv;

            return dcRateWork;
        }

        /// <summary>
        /// �|���D��Ǘ��f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="rateProtyMngWork">AP�|���D��Ǘ��f�[�^</param>
        /// <returns>DC�|���D��Ǘ��f�[�^</returns>
        public static DCRateProtyMngWork SearchDataFromUpdateData(APRateProtyMngWork rateProtyMngWork)
        {
            if (rateProtyMngWork == null)
            {
                return null;
            }

            DCRateProtyMngWork dcRateProtyMngWork = new DCRateProtyMngWork();

            // �|���D��Ǘ��f�[�^�ϊ�
            dcRateProtyMngWork.CreateDateTime = rateProtyMngWork.CreateDateTime;
            dcRateProtyMngWork.UpdateDateTime = rateProtyMngWork.UpdateDateTime;
            dcRateProtyMngWork.EnterpriseCode = rateProtyMngWork.EnterpriseCode;
            dcRateProtyMngWork.FileHeaderGuid = rateProtyMngWork.FileHeaderGuid;
            dcRateProtyMngWork.UpdEmployeeCode = rateProtyMngWork.UpdEmployeeCode;
            dcRateProtyMngWork.UpdAssemblyId1 = rateProtyMngWork.UpdAssemblyId1;
            dcRateProtyMngWork.UpdAssemblyId2 = rateProtyMngWork.UpdAssemblyId2;
            dcRateProtyMngWork.LogicalDeleteCode = rateProtyMngWork.LogicalDeleteCode;
            dcRateProtyMngWork.SectionCode = rateProtyMngWork.SectionCode;
            dcRateProtyMngWork.UnitPriceKind = rateProtyMngWork.UnitPriceKind;
            dcRateProtyMngWork.RateSettingDivide = rateProtyMngWork.RateSettingDivide;
            dcRateProtyMngWork.RatePriorityOrder = rateProtyMngWork.RatePriorityOrder;
            dcRateProtyMngWork.RateMngGoodsCd = rateProtyMngWork.RateMngGoodsCd;
            dcRateProtyMngWork.RateMngGoodsNm = rateProtyMngWork.RateMngGoodsNm;
            dcRateProtyMngWork.RateMngCustCd = rateProtyMngWork.RateMngCustCd;
            dcRateProtyMngWork.RateMngCustNm = rateProtyMngWork.RateMngCustNm;

            return dcRateProtyMngWork;
        }

        /// <summary>
        /// ���i�Z�b�g�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="goodsSetWork">AP���i�Z�b�g�f�[�^</param>
        /// <returns>DC���i�Z�b�g�f�[�^</returns>
        public static DCGoodsSetWork SearchDataFromUpdateData(APGoodsSetWork goodsSetWork)
        {
            if (goodsSetWork == null)
            {
                return null;
            }

            DCGoodsSetWork dcGoodsSetWork = new DCGoodsSetWork();

            // ���i�Z�b�g�f�[�^�ϊ�
            dcGoodsSetWork.CreateDateTime = goodsSetWork.CreateDateTime;
            dcGoodsSetWork.UpdateDateTime = goodsSetWork.UpdateDateTime;
            dcGoodsSetWork.EnterpriseCode = goodsSetWork.EnterpriseCode;
            dcGoodsSetWork.FileHeaderGuid = goodsSetWork.FileHeaderGuid;
            dcGoodsSetWork.UpdEmployeeCode = goodsSetWork.UpdEmployeeCode;
            dcGoodsSetWork.UpdAssemblyId1 = goodsSetWork.UpdAssemblyId1;
            dcGoodsSetWork.UpdAssemblyId2 = goodsSetWork.UpdAssemblyId2;
            dcGoodsSetWork.LogicalDeleteCode = goodsSetWork.LogicalDeleteCode;
            dcGoodsSetWork.ParentGoodsMakerCd = goodsSetWork.ParentGoodsMakerCd;
            dcGoodsSetWork.ParentGoodsNo = goodsSetWork.ParentGoodsNo;
            dcGoodsSetWork.SubGoodsMakerCd = goodsSetWork.SubGoodsMakerCd;
            dcGoodsSetWork.SubGoodsNo = goodsSetWork.SubGoodsNo;
            dcGoodsSetWork.CntFl = goodsSetWork.CntFl;
            dcGoodsSetWork.DisplayOrder = goodsSetWork.DisplayOrder;
            dcGoodsSetWork.SetSpecialNote = goodsSetWork.SetSpecialNote;
            dcGoodsSetWork.CatalogShapeNo = goodsSetWork.CatalogShapeNo;

            return dcGoodsSetWork;
        }

        /// <summary>
        /// ���i��ցi���[�U�[�o�^���j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="partsSubstUWork">AP���i��ցi���[�U�[�o�^���j�f�[�^</param>
        /// <returns>DC���i��ցi���[�U�[�o�^���j�f�[�^</returns>
        public static DCPartsSubstUWork SearchDataFromUpdateData(APPartsSubstUWork partsSubstUWork)
        {
            if (partsSubstUWork == null)
            {
                return null;
            }

            DCPartsSubstUWork dcPartsSubstUWork = new DCPartsSubstUWork();

            // ���i��ցi���[�U�[�o�^���j�f�[�^�ϊ�
            dcPartsSubstUWork.CreateDateTime = partsSubstUWork.CreateDateTime;
            dcPartsSubstUWork.UpdateDateTime = partsSubstUWork.UpdateDateTime;
            dcPartsSubstUWork.EnterpriseCode = partsSubstUWork.EnterpriseCode;
            dcPartsSubstUWork.FileHeaderGuid = partsSubstUWork.FileHeaderGuid;
            dcPartsSubstUWork.UpdEmployeeCode = partsSubstUWork.UpdEmployeeCode;
            dcPartsSubstUWork.UpdAssemblyId1 = partsSubstUWork.UpdAssemblyId1;
            dcPartsSubstUWork.UpdAssemblyId2 = partsSubstUWork.UpdAssemblyId2;
            dcPartsSubstUWork.LogicalDeleteCode = partsSubstUWork.LogicalDeleteCode;
            dcPartsSubstUWork.ChgSrcMakerCd = partsSubstUWork.ChgSrcMakerCd;
            dcPartsSubstUWork.ChgSrcGoodsNo = partsSubstUWork.ChgSrcGoodsNo;
            dcPartsSubstUWork.ChgSrcGoodsNoNoneHp = partsSubstUWork.ChgSrcGoodsNoNoneHp;
            dcPartsSubstUWork.ChgDestMakerCd = partsSubstUWork.ChgDestMakerCd;
            dcPartsSubstUWork.ChgDestGoodsNo = partsSubstUWork.ChgDestGoodsNo;
            dcPartsSubstUWork.ChgDestGoodsNoNoneHp = partsSubstUWork.ChgDestGoodsNoNoneHp;
            dcPartsSubstUWork.ApplyStaDate = partsSubstUWork.ApplyStaDate;
            dcPartsSubstUWork.ApplyEndDate = partsSubstUWork.ApplyEndDate;

            return dcPartsSubstUWork;
        }

        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="empSalesTargetWork">AP�]�ƈ��ʔ���ڕW�ݒ�f�[�^</param>
        /// <returns>DC�]�ƈ��ʔ���ڕW�ݒ�f�[�^</returns>
        public static DCEmpSalesTargetWork SearchDataFromUpdateData(APEmpSalesTargetWork empSalesTargetWork)
        {
            if (empSalesTargetWork == null)
            {
                return null;
            }

            DCEmpSalesTargetWork dcEmpSalesTargetWork = new DCEmpSalesTargetWork();

            // �]�ƈ��ʔ���ڕW�ݒ�f�[�^�ϊ�
            dcEmpSalesTargetWork.CreateDateTime = empSalesTargetWork.CreateDateTime;
            dcEmpSalesTargetWork.UpdateDateTime = empSalesTargetWork.UpdateDateTime;
            dcEmpSalesTargetWork.EnterpriseCode = empSalesTargetWork.EnterpriseCode;
            dcEmpSalesTargetWork.FileHeaderGuid = empSalesTargetWork.FileHeaderGuid;
            dcEmpSalesTargetWork.UpdEmployeeCode = empSalesTargetWork.UpdEmployeeCode;
            dcEmpSalesTargetWork.UpdAssemblyId1 = empSalesTargetWork.UpdAssemblyId1;
            dcEmpSalesTargetWork.UpdAssemblyId2 = empSalesTargetWork.UpdAssemblyId2;
            dcEmpSalesTargetWork.LogicalDeleteCode = empSalesTargetWork.LogicalDeleteCode;
            dcEmpSalesTargetWork.SectionCode = empSalesTargetWork.SectionCode;
            dcEmpSalesTargetWork.TargetSetCd = empSalesTargetWork.TargetSetCd;
            dcEmpSalesTargetWork.TargetContrastCd = empSalesTargetWork.TargetContrastCd;
            dcEmpSalesTargetWork.TargetDivideCode = empSalesTargetWork.TargetDivideCode;
            dcEmpSalesTargetWork.TargetDivideName = empSalesTargetWork.TargetDivideName;
            dcEmpSalesTargetWork.EmployeeDivCd = empSalesTargetWork.EmployeeDivCd;
            dcEmpSalesTargetWork.SubSectionCode = empSalesTargetWork.SubSectionCode;
            dcEmpSalesTargetWork.EmployeeCode = empSalesTargetWork.EmployeeCode;
            dcEmpSalesTargetWork.ApplyStaDate = empSalesTargetWork.ApplyStaDate;
            dcEmpSalesTargetWork.ApplyEndDate = empSalesTargetWork.ApplyEndDate;
            dcEmpSalesTargetWork.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney;
            dcEmpSalesTargetWork.SalesTargetProfit = empSalesTargetWork.SalesTargetProfit;
            dcEmpSalesTargetWork.SalesTargetCount = empSalesTargetWork.SalesTargetCount;


            return dcEmpSalesTargetWork;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="custSalesTargetWork">AP���Ӑ�ʔ���ڕW�ݒ�f�[�^</param>
        /// <returns>DC���Ӑ�ʔ���ڕW�ݒ�f�[�^</returns>
        public static DCCustSalesTargetWork SearchDataFromUpdateData(APCustSalesTargetWork custSalesTargetWork)
        {
            if (custSalesTargetWork == null)
            {
                return null;
            }

            DCCustSalesTargetWork dcCustSalesTargetWork = new DCCustSalesTargetWork();

            // ���Ӑ�ʔ���ڕW�ݒ�f�[�^�ϊ�
            dcCustSalesTargetWork.CreateDateTime = custSalesTargetWork.CreateDateTime;
            dcCustSalesTargetWork.UpdateDateTime = custSalesTargetWork.UpdateDateTime;
            dcCustSalesTargetWork.EnterpriseCode = custSalesTargetWork.EnterpriseCode;
            dcCustSalesTargetWork.FileHeaderGuid = custSalesTargetWork.FileHeaderGuid;
            dcCustSalesTargetWork.UpdEmployeeCode = custSalesTargetWork.UpdEmployeeCode;
            dcCustSalesTargetWork.UpdAssemblyId1 = custSalesTargetWork.UpdAssemblyId1;
            dcCustSalesTargetWork.UpdAssemblyId2 = custSalesTargetWork.UpdAssemblyId2;
            dcCustSalesTargetWork.LogicalDeleteCode = custSalesTargetWork.LogicalDeleteCode;
            dcCustSalesTargetWork.SectionCode = custSalesTargetWork.SectionCode;
            dcCustSalesTargetWork.TargetSetCd = custSalesTargetWork.TargetSetCd;
            dcCustSalesTargetWork.TargetContrastCd = custSalesTargetWork.TargetContrastCd;
            dcCustSalesTargetWork.TargetDivideCode = custSalesTargetWork.TargetDivideCode;
            dcCustSalesTargetWork.TargetDivideName = custSalesTargetWork.TargetDivideName;
            dcCustSalesTargetWork.BusinessTypeCode = custSalesTargetWork.BusinessTypeCode;
            dcCustSalesTargetWork.SalesAreaCode = custSalesTargetWork.SalesAreaCode;
            dcCustSalesTargetWork.CustomerCode = custSalesTargetWork.CustomerCode;
            dcCustSalesTargetWork.ApplyStaDate = custSalesTargetWork.ApplyStaDate;
            dcCustSalesTargetWork.ApplyEndDate = custSalesTargetWork.ApplyEndDate;
            dcCustSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney;
            dcCustSalesTargetWork.SalesTargetProfit = custSalesTargetWork.SalesTargetProfit;
            dcCustSalesTargetWork.SalesTargetCount = custSalesTargetWork.SalesTargetCount;

            return dcCustSalesTargetWork;
        }

        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="gcdSalesTargetWork">AP���i�ʔ���ڕW�ݒ�f�[�^</param>
        /// <returns>DC���i�ʔ���ڕW�ݒ�f�[�^</returns>
        public static DCGcdSalesTargetWork SearchDataFromUpdateData(APGcdSalesTargetWork gcdSalesTargetWork)
        {
            if (gcdSalesTargetWork == null)
            {
                return null;
            }

            DCGcdSalesTargetWork dcGcdSalesTargetWork = new DCGcdSalesTargetWork();

            // ���i�ʔ���ڕW�ݒ�f�[�^�ϊ�
            dcGcdSalesTargetWork.CreateDateTime = gcdSalesTargetWork.CreateDateTime;
            dcGcdSalesTargetWork.UpdateDateTime = gcdSalesTargetWork.UpdateDateTime;
            dcGcdSalesTargetWork.EnterpriseCode = gcdSalesTargetWork.EnterpriseCode;
            dcGcdSalesTargetWork.FileHeaderGuid = gcdSalesTargetWork.FileHeaderGuid;
            dcGcdSalesTargetWork.UpdEmployeeCode = gcdSalesTargetWork.UpdEmployeeCode;
            dcGcdSalesTargetWork.UpdAssemblyId1 = gcdSalesTargetWork.UpdAssemblyId1;
            dcGcdSalesTargetWork.UpdAssemblyId2 = gcdSalesTargetWork.UpdAssemblyId2;
            dcGcdSalesTargetWork.LogicalDeleteCode = gcdSalesTargetWork.LogicalDeleteCode;
            dcGcdSalesTargetWork.SectionCode = gcdSalesTargetWork.SectionCode;
            dcGcdSalesTargetWork.TargetSetCd = gcdSalesTargetWork.TargetSetCd;
            dcGcdSalesTargetWork.TargetContrastCd = gcdSalesTargetWork.TargetContrastCd;
            dcGcdSalesTargetWork.TargetDivideCode = gcdSalesTargetWork.TargetDivideCode;
            dcGcdSalesTargetWork.TargetDivideName = gcdSalesTargetWork.TargetDivideName;
            dcGcdSalesTargetWork.GoodsMakerCd = gcdSalesTargetWork.GoodsMakerCd;
            dcGcdSalesTargetWork.GoodsNo = gcdSalesTargetWork.GoodsNo;
            dcGcdSalesTargetWork.BLGroupCode = gcdSalesTargetWork.BLGroupCode;
            dcGcdSalesTargetWork.BLGoodsCode = gcdSalesTargetWork.BLGoodsCode;
            dcGcdSalesTargetWork.SalesCode = gcdSalesTargetWork.SalesCode;
            dcGcdSalesTargetWork.EnterpriseGanreCode = gcdSalesTargetWork.EnterpriseGanreCode;
            dcGcdSalesTargetWork.ApplyStaDate = gcdSalesTargetWork.ApplyStaDate;
            dcGcdSalesTargetWork.ApplyEndDate = gcdSalesTargetWork.ApplyEndDate;
            dcGcdSalesTargetWork.SalesTargetMoney = gcdSalesTargetWork.SalesTargetMoney;
            dcGcdSalesTargetWork.SalesTargetProfit = gcdSalesTargetWork.SalesTargetProfit;
            dcGcdSalesTargetWork.SalesTargetCount = gcdSalesTargetWork.SalesTargetCount;

            return dcGcdSalesTargetWork;
        }

        /// <summary>
        /// ���i�����ށi���[�U�[�o�^���j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="goodsGroupUWork">AP���i�����ށi���[�U�[�o�^���j�f�[�^</param>
        /// <returns>DC���i�����ށi���[�U�[�o�^���j�f�[�^</returns>
        public static DCGoodsGroupUWork SearchDataFromUpdateData(APGoodsGroupUWork goodsGroupUWork)
        {
            if (goodsGroupUWork == null)
            {
                return null;
            }

            DCGoodsGroupUWork dcGoodsGroupUWork = new DCGoodsGroupUWork();

            // ���i�����ށi���[�U�[�o�^���j�f�[�^�ϊ�
            dcGoodsGroupUWork.CreateDateTime = goodsGroupUWork.CreateDateTime;
            dcGoodsGroupUWork.UpdateDateTime = goodsGroupUWork.UpdateDateTime;
            dcGoodsGroupUWork.EnterpriseCode = goodsGroupUWork.EnterpriseCode;
            dcGoodsGroupUWork.FileHeaderGuid = goodsGroupUWork.FileHeaderGuid;
            dcGoodsGroupUWork.UpdEmployeeCode = goodsGroupUWork.UpdEmployeeCode;
            dcGoodsGroupUWork.UpdAssemblyId1 = goodsGroupUWork.UpdAssemblyId1;
            dcGoodsGroupUWork.UpdAssemblyId2 = goodsGroupUWork.UpdAssemblyId2;
            dcGoodsGroupUWork.LogicalDeleteCode = goodsGroupUWork.LogicalDeleteCode;
            dcGoodsGroupUWork.GoodsMGroup = goodsGroupUWork.GoodsMGroup;
            dcGoodsGroupUWork.GoodsMGroupName = goodsGroupUWork.GoodsMGroupName;
            dcGoodsGroupUWork.OfferDate = goodsGroupUWork.OfferDate;
            dcGoodsGroupUWork.OfferDataDiv = goodsGroupUWork.OfferDataDiv;

            return dcGoodsGroupUWork;
        }

        /// <summary>
        /// BL�O���[�v�i���[�U�[�o�^���j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="bLGroupUWork">APBL�O���[�v�i���[�U�[�o�^���j�f�[�^</param>
        /// <returns>DCBL�O���[�v�i���[�U�[�o�^���j�f�[�^</returns>
        public static DCBLGroupUWork SearchDataFromUpdateData(APBLGroupUWork bLGroupUWork)
        {
            if (bLGroupUWork == null)
            {
                return null;
            }

            DCBLGroupUWork dcBLGroupUWork = new DCBLGroupUWork();

            // BL�O���[�v�i���[�U�[�o�^���j�f�[�^�ϊ�
            dcBLGroupUWork.CreateDateTime = bLGroupUWork.CreateDateTime;
            dcBLGroupUWork.UpdateDateTime = bLGroupUWork.UpdateDateTime;
            dcBLGroupUWork.EnterpriseCode = bLGroupUWork.EnterpriseCode;
            dcBLGroupUWork.FileHeaderGuid = bLGroupUWork.FileHeaderGuid;
            dcBLGroupUWork.UpdEmployeeCode = bLGroupUWork.UpdEmployeeCode;
            dcBLGroupUWork.UpdAssemblyId1 = bLGroupUWork.UpdAssemblyId1;
            dcBLGroupUWork.UpdAssemblyId2 = bLGroupUWork.UpdAssemblyId2;
            dcBLGroupUWork.LogicalDeleteCode = bLGroupUWork.LogicalDeleteCode;
            dcBLGroupUWork.GoodsLGroup = bLGroupUWork.GoodsLGroup;
            dcBLGroupUWork.GoodsMGroup = bLGroupUWork.GoodsMGroup;
            dcBLGroupUWork.BLGroupCode = bLGroupUWork.BLGroupCode;
            dcBLGroupUWork.BLGroupName = bLGroupUWork.BLGroupName;
            dcBLGroupUWork.BLGroupKanaName = bLGroupUWork.BLGroupKanaName;
            dcBLGroupUWork.SalesCode = bLGroupUWork.SalesCode;
            dcBLGroupUWork.OfferDate = bLGroupUWork.OfferDate;
            dcBLGroupUWork.OfferDataDiv = bLGroupUWork.OfferDataDiv;

            return dcBLGroupUWork;
        }

        /// <summary>
        /// �����i���[�U�[�o�^�j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="joinPartsUWork">AP�����i���[�U�[�o�^�j�f�[�^</param>
        /// <returns>DC�����i���[�U�[�o�^�j�f�[�^</returns>
        public static DCJoinPartsUWork SearchDataFromUpdateData(APJoinPartsUWork joinPartsUWork)
        {
            if (joinPartsUWork == null)
            {
                return null;
            }

            DCJoinPartsUWork dcJoinPartsUWork = new DCJoinPartsUWork();

            // �����i���[�U�[�o�^�j�f�[�^�ϊ�
            dcJoinPartsUWork.CreateDateTime = joinPartsUWork.CreateDateTime;
            dcJoinPartsUWork.UpdateDateTime = joinPartsUWork.UpdateDateTime;
            dcJoinPartsUWork.EnterpriseCode = joinPartsUWork.EnterpriseCode;
            dcJoinPartsUWork.FileHeaderGuid = joinPartsUWork.FileHeaderGuid;
            dcJoinPartsUWork.UpdEmployeeCode = joinPartsUWork.UpdEmployeeCode;
            dcJoinPartsUWork.UpdAssemblyId1 = joinPartsUWork.UpdAssemblyId1;
            dcJoinPartsUWork.UpdAssemblyId2 = joinPartsUWork.UpdAssemblyId2;
            dcJoinPartsUWork.LogicalDeleteCode = joinPartsUWork.LogicalDeleteCode;
            dcJoinPartsUWork.JoinDispOrder = joinPartsUWork.JoinDispOrder;
            dcJoinPartsUWork.JoinSourceMakerCode = joinPartsUWork.JoinSourceMakerCode;
            dcJoinPartsUWork.JoinSourPartsNoWithH = joinPartsUWork.JoinSourPartsNoWithH;
            dcJoinPartsUWork.JoinSourPartsNoNoneH = joinPartsUWork.JoinSourPartsNoNoneH;
            dcJoinPartsUWork.JoinDestMakerCd = joinPartsUWork.JoinDestMakerCd;
            dcJoinPartsUWork.JoinDestPartsNo = joinPartsUWork.JoinDestPartsNo;
            dcJoinPartsUWork.JoinQty = joinPartsUWork.JoinQty;
            dcJoinPartsUWork.JoinSpecialNote = joinPartsUWork.JoinSpecialNote;

            return dcJoinPartsUWork;
        }

        /// <summary>
        /// TBO�����i���[�U�[�o�^�j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="tBOSearchUWork">APTBO�����i���[�U�[�o�^�j�f�[�^</param>
        /// <returns>DCTBO�����i���[�U�[�o�^�j�f�[�^</returns>
        public static DCTBOSearchUWork SearchDataFromUpdateData(APTBOSearchUWork tBOSearchUWork)
        {
            if (tBOSearchUWork == null)
            {
                return null;
            }

            DCTBOSearchUWork dcTBOSearchUWork = new DCTBOSearchUWork();

            // TBO�����i���[�U�[�o�^�j�f�[�^�ϊ�
            dcTBOSearchUWork.CreateDateTime = tBOSearchUWork.CreateDateTime;
            dcTBOSearchUWork.UpdateDateTime = tBOSearchUWork.UpdateDateTime;
            dcTBOSearchUWork.EnterpriseCode = tBOSearchUWork.EnterpriseCode;
            dcTBOSearchUWork.FileHeaderGuid = tBOSearchUWork.FileHeaderGuid;
            dcTBOSearchUWork.UpdEmployeeCode = tBOSearchUWork.UpdEmployeeCode;
            dcTBOSearchUWork.UpdAssemblyId1 = tBOSearchUWork.UpdAssemblyId1;
            dcTBOSearchUWork.UpdAssemblyId2 = tBOSearchUWork.UpdAssemblyId2;
            dcTBOSearchUWork.LogicalDeleteCode = tBOSearchUWork.LogicalDeleteCode;
            dcTBOSearchUWork.BLGoodsCode = tBOSearchUWork.BLGoodsCode;
            dcTBOSearchUWork.EquipGenreCode = tBOSearchUWork.EquipGenreCode;
            dcTBOSearchUWork.EquipName = tBOSearchUWork.EquipName;
            dcTBOSearchUWork.CarInfoJoinDispOrder = tBOSearchUWork.CarInfoJoinDispOrder;
            dcTBOSearchUWork.JoinDestMakerCd = tBOSearchUWork.JoinDestMakerCd;
            dcTBOSearchUWork.JoinDestPartsNo = tBOSearchUWork.JoinDestPartsNo;
            dcTBOSearchUWork.JoinQty = tBOSearchUWork.JoinQty;
            dcTBOSearchUWork.EquipSpecialNote = tBOSearchUWork.EquipSpecialNote;

            return dcTBOSearchUWork;
        }

        /// <summary>
        /// ���ʃR�[�h�i���[�U�[�o�^�j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="partsPosCodeUWork">AP���ʃR�[�h�i���[�U�[�o�^�j�f�[�^</param>
        /// <returns>DC���ʃR�[�h�i���[�U�[�o�^�j�f�[�^</returns>
        public static DCPartsPosCodeUWork SearchDataFromUpdateData(APPartsPosCodeUWork partsPosCodeUWork)
        {
            if (partsPosCodeUWork == null)
            {
                return null;
            }

            DCPartsPosCodeUWork dcPartsPosCodeUWork = new DCPartsPosCodeUWork();

            // ���ʃR�[�h�i���[�U�[�o�^�j�f�[�^�ϊ�
            dcPartsPosCodeUWork.CreateDateTime = partsPosCodeUWork.CreateDateTime;
            dcPartsPosCodeUWork.UpdateDateTime = partsPosCodeUWork.UpdateDateTime;
            dcPartsPosCodeUWork.EnterpriseCode = partsPosCodeUWork.EnterpriseCode;
            dcPartsPosCodeUWork.FileHeaderGuid = partsPosCodeUWork.FileHeaderGuid;
            dcPartsPosCodeUWork.UpdEmployeeCode = partsPosCodeUWork.UpdEmployeeCode;
            dcPartsPosCodeUWork.UpdAssemblyId1 = partsPosCodeUWork.UpdAssemblyId1;
            dcPartsPosCodeUWork.UpdAssemblyId2 = partsPosCodeUWork.UpdAssemblyId2;
            dcPartsPosCodeUWork.LogicalDeleteCode = partsPosCodeUWork.LogicalDeleteCode;
            dcPartsPosCodeUWork.SectionCode = partsPosCodeUWork.SectionCode;
            dcPartsPosCodeUWork.CustomerCode = partsPosCodeUWork.CustomerCode;
            dcPartsPosCodeUWork.SearchPartsPosCode = partsPosCodeUWork.SearchPartsPosCode;
            dcPartsPosCodeUWork.SearchPartsPosName = partsPosCodeUWork.SearchPartsPosName;
            dcPartsPosCodeUWork.PosDispOrder = partsPosCodeUWork.PosDispOrder;
            dcPartsPosCodeUWork.TbsPartsCode = partsPosCodeUWork.TbsPartsCode;
            dcPartsPosCodeUWork.TbsPartsCdDerivedNo = partsPosCodeUWork.TbsPartsCdDerivedNo;
            // ADD 2009/06/09 ------>>>
            dcPartsPosCodeUWork.OfferDate = partsPosCodeUWork.OfferDate;
            dcPartsPosCodeUWork.OfferDataDiv = partsPosCodeUWork.OfferDataDiv;
            // ADD 2009/06/09 ------<<<
            return dcPartsPosCodeUWork;
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="bLCodeGuideWork">APBL�R�[�h�K�C�h�f�[�^</param>
        /// <returns>DCBL�R�[�h�K�C�h�f�[�^</returns>
        public static DCBLCodeGuideWork SearchDataFromUpdateData(APBLCodeGuideWork bLCodeGuideWork)
        {
            if (bLCodeGuideWork == null)
            {
                return null;
            }

            DCBLCodeGuideWork dcBLCodeGuideWork = new DCBLCodeGuideWork();

            // BL�R�[�h�K�C�h�f�[�^�ϊ�
            dcBLCodeGuideWork.CreateDateTime = bLCodeGuideWork.CreateDateTime;
            dcBLCodeGuideWork.UpdateDateTime = bLCodeGuideWork.UpdateDateTime;
            dcBLCodeGuideWork.EnterpriseCode = bLCodeGuideWork.EnterpriseCode;
            dcBLCodeGuideWork.FileHeaderGuid = bLCodeGuideWork.FileHeaderGuid;
            dcBLCodeGuideWork.UpdEmployeeCode = bLCodeGuideWork.UpdEmployeeCode;
            dcBLCodeGuideWork.UpdAssemblyId1 = bLCodeGuideWork.UpdAssemblyId1;
            dcBLCodeGuideWork.UpdAssemblyId2 = bLCodeGuideWork.UpdAssemblyId2;
            dcBLCodeGuideWork.LogicalDeleteCode = bLCodeGuideWork.LogicalDeleteCode;
            dcBLCodeGuideWork.SectionCode = bLCodeGuideWork.SectionCode;
            dcBLCodeGuideWork.BLCodeDspPage = bLCodeGuideWork.BLCodeDspPage;
            dcBLCodeGuideWork.BLCodeDspRow = bLCodeGuideWork.BLCodeDspRow;
            dcBLCodeGuideWork.BLCodeDspCol = bLCodeGuideWork.BLCodeDspCol;
            dcBLCodeGuideWork.BLGoodsCode = bLCodeGuideWork.BLGoodsCode;
            dcBLCodeGuideWork.BLGoodsName = bLCodeGuideWork.BLGoodsName;

            return dcBLCodeGuideWork;
        }

        /// <summary>
        /// �Ԏ햼�́i���[�U�[�o�^�j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="modelNameUWork">AP�Ԏ햼�́i���[�U�[�o�^�j�f�[�^</param>
        /// <returns>DC�Ԏ햼�́i���[�U�[�o�^�j�f�[�^</returns>
        public static DCModelNameUWork SearchDataFromUpdateData(APModelNameUWork modelNameUWork)
        {
            if (modelNameUWork == null)
            {
                return null;
            }

            DCModelNameUWork dcModelNameUWork = new DCModelNameUWork();

            // �Ԏ햼�́i���[�U�[�o�^�j�f�[�^�ϊ�
            dcModelNameUWork.CreateDateTime = modelNameUWork.CreateDateTime;
            dcModelNameUWork.UpdateDateTime = modelNameUWork.UpdateDateTime;
            dcModelNameUWork.EnterpriseCode = modelNameUWork.EnterpriseCode;
            dcModelNameUWork.FileHeaderGuid = modelNameUWork.FileHeaderGuid;
            dcModelNameUWork.UpdEmployeeCode = modelNameUWork.UpdEmployeeCode;
            dcModelNameUWork.UpdAssemblyId1 = modelNameUWork.UpdAssemblyId1;
            dcModelNameUWork.UpdAssemblyId2 = modelNameUWork.UpdAssemblyId2;
            dcModelNameUWork.LogicalDeleteCode = modelNameUWork.LogicalDeleteCode;
            dcModelNameUWork.ModelUniqueCode = modelNameUWork.ModelUniqueCode;
            dcModelNameUWork.MakerCode = modelNameUWork.MakerCode;
            dcModelNameUWork.ModelCode = modelNameUWork.ModelCode;
            dcModelNameUWork.ModelSubCode = modelNameUWork.ModelSubCode;
            dcModelNameUWork.ModelFullName = modelNameUWork.ModelFullName;
            dcModelNameUWork.ModelHalfName = modelNameUWork.ModelHalfName;
            dcModelNameUWork.ModelAliasName = modelNameUWork.ModelAliasName;
            dcModelNameUWork.OfferDate = modelNameUWork.OfferDate;
            dcModelNameUWork.OfferDataDiv = modelNameUWork.OfferDataDiv;

            return dcModelNameUWork;
        }
    }
}
