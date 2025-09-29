//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M����
// �v���O�����T�v   : ��M�f�[�^�ϊ��������s��
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
    public class MstRecConvertReceive
    {
        /// <summary>
        /// ���_���ݒ�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="secInfoSetWork">DC���_���ݒ�f�[�^</param>
        /// <returns>AP���_���ݒ�f�[�^</returns>
        public static APSecInfoSetWork SearchDataFromUpdateData(DCSecInfoSetWork secInfoSetWork)
        {
            if (secInfoSetWork == null)
            {
                return null;
            }

            APSecInfoSetWork apSecInfoSetWork = new APSecInfoSetWork();
            // ���_���ݒ�f�[�^�ϊ�
            apSecInfoSetWork.CreateDateTime = secInfoSetWork.CreateDateTime;
            apSecInfoSetWork.UpdateDateTime = secInfoSetWork.UpdateDateTime;
            apSecInfoSetWork.EnterpriseCode = secInfoSetWork.EnterpriseCode;
            apSecInfoSetWork.FileHeaderGuid = secInfoSetWork.FileHeaderGuid;
            apSecInfoSetWork.UpdEmployeeCode = secInfoSetWork.UpdEmployeeCode;
            apSecInfoSetWork.UpdAssemblyId1 = secInfoSetWork.UpdAssemblyId1;
            apSecInfoSetWork.UpdAssemblyId2 = secInfoSetWork.UpdAssemblyId2;
            apSecInfoSetWork.LogicalDeleteCode = secInfoSetWork.LogicalDeleteCode;
            apSecInfoSetWork.SectionCode = secInfoSetWork.SectionCode;
            apSecInfoSetWork.SectionGuideNm = secInfoSetWork.SectionGuideNm;
            apSecInfoSetWork.SectionGuideSnm = secInfoSetWork.SectionGuideSnm;
            apSecInfoSetWork.CompanyNameCd1 = secInfoSetWork.CompanyNameCd1;
            apSecInfoSetWork.MainOfficeFuncFlag = secInfoSetWork.MainOfficeFuncFlag;
            apSecInfoSetWork.IntroductionDate = secInfoSetWork.IntroductionDate;
            apSecInfoSetWork.SectWarehouseCd1 = secInfoSetWork.SectWarehouseCd1;
            apSecInfoSetWork.SectWarehouseCd2 = secInfoSetWork.SectWarehouseCd2;
            apSecInfoSetWork.SectWarehouseCd3 = secInfoSetWork.SectWarehouseCd3;

            return apSecInfoSetWork;
        }

        /// <summary>
        /// ����}�X�^�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="subSectionWork">DC����}�X�^�f�[�^</param>
        /// <returns>AP����}�X�^�f�[�^</returns>
        public static APSubSectionWork SearchDataFromUpdateData(DCSubSectionWork subSectionWork)
        {
            if (subSectionWork == null)
            {
                return null;
            }

            APSubSectionWork apSubSectionWork = new APSubSectionWork();

            // ����}�X�^�f�[�^�ϊ�
            apSubSectionWork.CreateDateTime = subSectionWork.CreateDateTime;
            apSubSectionWork.UpdateDateTime = subSectionWork.UpdateDateTime;
            apSubSectionWork.EnterpriseCode = subSectionWork.EnterpriseCode;
            apSubSectionWork.FileHeaderGuid = subSectionWork.FileHeaderGuid;
            apSubSectionWork.UpdEmployeeCode = subSectionWork.UpdEmployeeCode;
            apSubSectionWork.UpdAssemblyId1 = subSectionWork.UpdAssemblyId1;
            apSubSectionWork.UpdAssemblyId2 = subSectionWork.UpdAssemblyId2;
            apSubSectionWork.LogicalDeleteCode = subSectionWork.LogicalDeleteCode;
            apSubSectionWork.SectionCode = subSectionWork.SectionCode;
            apSubSectionWork.SubSectionCode = subSectionWork.SubSectionCode;
            apSubSectionWork.SubSectionName = subSectionWork.SubSectionName;

            return apSubSectionWork;
        }

        /// <summary>
        /// �]�ƈ��}�X�^�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="employeeWork">DC�]�ƈ��}�X�^�f�[�^</param>
        /// <returns>AP�]�ƈ��}�X�^�f�[�^</returns>
        public static APEmployeeWork SearchDataFromUpdateData(DCEmployeeWork employeeWork)
        {
            if (employeeWork == null)
            {
                return null;
            }

            APEmployeeWork apEmployeeWork = new APEmployeeWork();

            // �]�ƈ��}�X�^�f�[�^�ϊ�
            apEmployeeWork.CreateDateTime = employeeWork.CreateDateTime;
            apEmployeeWork.UpdateDateTime = employeeWork.UpdateDateTime;
            apEmployeeWork.EnterpriseCode = employeeWork.EnterpriseCode;
            apEmployeeWork.FileHeaderGuid = employeeWork.FileHeaderGuid;
            apEmployeeWork.UpdEmployeeCode = employeeWork.UpdEmployeeCode;
            apEmployeeWork.UpdAssemblyId1 = employeeWork.UpdAssemblyId1;
            apEmployeeWork.UpdAssemblyId2 = employeeWork.UpdAssemblyId2;
            apEmployeeWork.LogicalDeleteCode = employeeWork.LogicalDeleteCode;
            apEmployeeWork.EmployeeCode = employeeWork.EmployeeCode;
            apEmployeeWork.Name = employeeWork.Name;
            apEmployeeWork.Kana = employeeWork.Kana;
            apEmployeeWork.ShortName = employeeWork.ShortName;
            apEmployeeWork.SexCode = employeeWork.SexCode;
            apEmployeeWork.SexName = employeeWork.SexName;
            apEmployeeWork.Birthday = employeeWork.Birthday;
            apEmployeeWork.CompanyTelNo = employeeWork.CompanyTelNo;
            apEmployeeWork.PortableTelNo = employeeWork.PortableTelNo;
            apEmployeeWork.PostCode = employeeWork.PostCode;
            apEmployeeWork.BusinessCode = employeeWork.BusinessCode;
            apEmployeeWork.FrontMechaCode = employeeWork.FrontMechaCode;
            apEmployeeWork.InOutsideCompanyCode = employeeWork.InOutsideCompanyCode;
            apEmployeeWork.BelongSectionCode = employeeWork.BelongSectionCode;
            apEmployeeWork.LvrRtCstGeneral = employeeWork.LvrRtCstGeneral;
            apEmployeeWork.LvrRtCstCarInspect = employeeWork.LvrRtCstCarInspect;
            apEmployeeWork.LvrRtCstBodyPaint = employeeWork.LvrRtCstBodyPaint;
            apEmployeeWork.LvrRtCstBodyRepair = employeeWork.LvrRtCstBodyRepair;
            apEmployeeWork.LoginId = employeeWork.LoginId;
            apEmployeeWork.LoginPassword = employeeWork.LoginPassword;
            apEmployeeWork.UserAdminFlag = employeeWork.UserAdminFlag;
            apEmployeeWork.EnterCompanyDate = employeeWork.EnterCompanyDate;
            apEmployeeWork.RetirementDate = employeeWork.RetirementDate;
            apEmployeeWork.AuthorityLevel1 = employeeWork.AuthorityLevel1;
            apEmployeeWork.AuthorityLevel2 = employeeWork.AuthorityLevel2;

            return apEmployeeWork;
        }

        /// <summary>
        /// �]�ƈ��ڍ׃}�X�^�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="employeeDtlWork">DC�]�ƈ��ڍ׃}�X�^�f�[�^</param>
        /// <returns>AP�]�ƈ��ڍ׃}�X�^�f�[�^</returns>
        public static APEmployeeDtlWork SearchDataFromUpdateData(DCEmployeeDtlWork employeeDtlWork)
        {
            if (employeeDtlWork == null)
            {
                return null;
            }

            APEmployeeDtlWork apEmployeeDtlWork = new APEmployeeDtlWork();

            // �]�ƈ��ڍ׃}�X�^�f�[�^�ϊ�
            apEmployeeDtlWork.CreateDateTime = employeeDtlWork.CreateDateTime;
            apEmployeeDtlWork.UpdateDateTime = employeeDtlWork.UpdateDateTime;
            apEmployeeDtlWork.EnterpriseCode = employeeDtlWork.EnterpriseCode;
            apEmployeeDtlWork.FileHeaderGuid = employeeDtlWork.FileHeaderGuid;
            apEmployeeDtlWork.UpdEmployeeCode = employeeDtlWork.UpdEmployeeCode;
            apEmployeeDtlWork.UpdAssemblyId1 = employeeDtlWork.UpdAssemblyId1;
            apEmployeeDtlWork.UpdAssemblyId2 = employeeDtlWork.UpdAssemblyId2;
            apEmployeeDtlWork.LogicalDeleteCode = employeeDtlWork.LogicalDeleteCode;
            apEmployeeDtlWork.EmployeeCode = employeeDtlWork.EmployeeCode;
            apEmployeeDtlWork.BelongSubSectionCode = employeeDtlWork.BelongSubSectionCode;
            apEmployeeDtlWork.EmployAnalysCode1 = employeeDtlWork.EmployAnalysCode1;
            apEmployeeDtlWork.EmployAnalysCode2 = employeeDtlWork.EmployAnalysCode2;
            apEmployeeDtlWork.EmployAnalysCode3 = employeeDtlWork.EmployAnalysCode3;
            apEmployeeDtlWork.EmployAnalysCode4 = employeeDtlWork.EmployAnalysCode4;
            apEmployeeDtlWork.EmployAnalysCode5 = employeeDtlWork.EmployAnalysCode5;
            apEmployeeDtlWork.EmployAnalysCode6 = employeeDtlWork.EmployAnalysCode6;
            apEmployeeDtlWork.UOESnmDiv = employeeDtlWork.UOESnmDiv;
            apEmployeeDtlWork.MailAddrKindCode1 = employeeDtlWork.MailAddrKindCode1;
            apEmployeeDtlWork.MailAddrKindName1 = employeeDtlWork.MailAddrKindName1;
            apEmployeeDtlWork.MailAddress1 = employeeDtlWork.MailAddress1;
            apEmployeeDtlWork.MailSendCode1 = employeeDtlWork.MailSendCode1;
            apEmployeeDtlWork.MailAddrKindCode2 = employeeDtlWork.MailAddrKindCode2;
            apEmployeeDtlWork.MailAddrKindName2 = employeeDtlWork.MailAddrKindName2;
            apEmployeeDtlWork.MailAddress2 = employeeDtlWork.MailAddress2;
            apEmployeeDtlWork.MailSendCode2 = employeeDtlWork.MailSendCode2;

            return apEmployeeDtlWork;
        }

        /// <summary>
        /// �q�Ƀ}�X�^�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="warehouseWork">DC�q�Ƀ}�X�^�f�[�^</param>
        /// <returns>AP�q�Ƀ}�X�^�f�[�^</returns>
        public static APWarehouseWork SearchDataFromUpdateData(DCWarehouseWork warehouseWork)
        {
            if (warehouseWork == null)
            {
                return null;
            }

            APWarehouseWork apWarehouseWork = new APWarehouseWork();

            // �q�Ƀ}�X�^�f�[�^�ϊ�
            apWarehouseWork.CreateDateTime = warehouseWork.CreateDateTime;
            apWarehouseWork.UpdateDateTime = warehouseWork.UpdateDateTime;
            apWarehouseWork.EnterpriseCode = warehouseWork.EnterpriseCode;
            apWarehouseWork.FileHeaderGuid = warehouseWork.FileHeaderGuid;
            apWarehouseWork.UpdEmployeeCode = warehouseWork.UpdEmployeeCode;
            apWarehouseWork.UpdAssemblyId1 = warehouseWork.UpdAssemblyId1;
            apWarehouseWork.UpdAssemblyId2 = warehouseWork.UpdAssemblyId2;
            apWarehouseWork.LogicalDeleteCode = warehouseWork.LogicalDeleteCode;
            apWarehouseWork.SectionCode = warehouseWork.SectionCode;
            apWarehouseWork.WarehouseCode = warehouseWork.WarehouseCode;
            apWarehouseWork.WarehouseName = warehouseWork.WarehouseName;
            apWarehouseWork.WarehouseNote1 = warehouseWork.WarehouseNote1;
            apWarehouseWork.CustomerCode = warehouseWork.CustomerCode;
            apWarehouseWork.MainMngWarehouseCd = warehouseWork.MainMngWarehouseCd;
            apWarehouseWork.StockBlnktRemark = warehouseWork.StockBlnktRemark;

            return apWarehouseWork;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="customerWork">DC���Ӑ�}�X�^�f�[�^</param>
        /// <returns>AP���Ӑ�}�X�^�f�[�^</returns>
        public static APCustomerWork SearchDataFromUpdateData(DCCustomerWork customerWork)
        {
            if (customerWork == null)
            {
                return null;
            }

            APCustomerWork apCustomerWork = new APCustomerWork();

            // ���Ӑ�}�X�^�f�[�^�ϊ�
            apCustomerWork.CreateDateTime = customerWork.CreateDateTime;
            apCustomerWork.UpdateDateTime = customerWork.UpdateDateTime;
            apCustomerWork.EnterpriseCode = customerWork.EnterpriseCode;
            apCustomerWork.FileHeaderGuid = customerWork.FileHeaderGuid;
            apCustomerWork.UpdEmployeeCode = customerWork.UpdEmployeeCode;
            apCustomerWork.UpdAssemblyId1 = customerWork.UpdAssemblyId1;
            apCustomerWork.UpdAssemblyId2 = customerWork.UpdAssemblyId2;
            apCustomerWork.LogicalDeleteCode = customerWork.LogicalDeleteCode;
            apCustomerWork.CustomerCode = customerWork.CustomerCode;
            apCustomerWork.CustomerSubCode = customerWork.CustomerSubCode;
            apCustomerWork.Name = customerWork.Name;
            apCustomerWork.Name2 = customerWork.Name2;
            apCustomerWork.HonorificTitle = customerWork.HonorificTitle;
            apCustomerWork.Kana = customerWork.Kana;
            apCustomerWork.CustomerSnm = customerWork.CustomerSnm;
            apCustomerWork.OutputNameCode = customerWork.OutputNameCode;
            apCustomerWork.OutputName = customerWork.OutputName;
            apCustomerWork.CorporateDivCode = customerWork.CorporateDivCode;
            apCustomerWork.CustomerAttributeDiv = customerWork.CustomerAttributeDiv;
            apCustomerWork.JobTypeCode = customerWork.JobTypeCode;
            apCustomerWork.BusinessTypeCode = customerWork.BusinessTypeCode;
            apCustomerWork.SalesAreaCode = customerWork.SalesAreaCode;
            apCustomerWork.PostNo = customerWork.PostNo;
            apCustomerWork.Address1 = customerWork.Address1;
            apCustomerWork.Address3 = customerWork.Address3;
            apCustomerWork.Address4 = customerWork.Address4;
            apCustomerWork.HomeTelNo = customerWork.HomeTelNo;
            apCustomerWork.OfficeTelNo = customerWork.OfficeTelNo;
            apCustomerWork.PortableTelNo = customerWork.PortableTelNo;
            apCustomerWork.HomeFaxNo = customerWork.HomeFaxNo;
            apCustomerWork.OfficeFaxNo = customerWork.OfficeFaxNo;
            apCustomerWork.OthersTelNo = customerWork.OthersTelNo;
            apCustomerWork.MainContactCode = customerWork.MainContactCode;
            apCustomerWork.SearchTelNo = customerWork.SearchTelNo;
            apCustomerWork.MngSectionCode = customerWork.MngSectionCode;
            apCustomerWork.InpSectionCode = customerWork.InpSectionCode;
            apCustomerWork.CustAnalysCode1 = customerWork.CustAnalysCode1;
            apCustomerWork.CustAnalysCode2 = customerWork.CustAnalysCode2;
            apCustomerWork.CustAnalysCode3 = customerWork.CustAnalysCode3;
            apCustomerWork.CustAnalysCode4 = customerWork.CustAnalysCode4;
            apCustomerWork.CustAnalysCode5 = customerWork.CustAnalysCode5;
            apCustomerWork.CustAnalysCode6 = customerWork.CustAnalysCode6;
            // DEL 2010/02/02 MANTIS�Ή�[14953]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            // TODO:�g�p���Ȃ��c�������o�͋敪�R�[�h
            //apCustomerWork.BillOutputCode = customerWork.BillOutputCode;
            // DEL 2010/02/02 MANTIS�Ή�[14953]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<
            apCustomerWork.BillOutputName = customerWork.BillOutputName;
            apCustomerWork.TotalDay = customerWork.TotalDay;
            apCustomerWork.CollectMoneyCode = customerWork.CollectMoneyCode;
            apCustomerWork.CollectMoneyName = customerWork.CollectMoneyName;
            apCustomerWork.CollectMoneyDay = customerWork.CollectMoneyDay;
            apCustomerWork.CollectCond = customerWork.CollectCond;
            apCustomerWork.CollectSight = customerWork.CollectSight;
            apCustomerWork.ClaimCode = customerWork.ClaimCode;
            apCustomerWork.TransStopDate = customerWork.TransStopDate;
            apCustomerWork.DmOutCode = customerWork.DmOutCode;
            apCustomerWork.DmOutName = customerWork.DmOutName;
            apCustomerWork.MainSendMailAddrCd = customerWork.MainSendMailAddrCd;
            apCustomerWork.MailAddrKindCode1 = customerWork.MailAddrKindCode1;
            apCustomerWork.MailAddrKindName1 = customerWork.MailAddrKindName1;
            apCustomerWork.MailAddress1 = customerWork.MailAddress1;
            apCustomerWork.MailSendCode1 = customerWork.MailSendCode1;
            apCustomerWork.MailSendName1 = customerWork.MailSendName1;
            apCustomerWork.MailAddrKindCode2 = customerWork.MailAddrKindCode2;
            apCustomerWork.MailAddrKindName2 = customerWork.MailAddrKindName2;
            apCustomerWork.MailAddress2 = customerWork.MailAddress2;
            apCustomerWork.MailSendCode2 = customerWork.MailSendCode2;
            apCustomerWork.MailSendName2 = customerWork.MailSendName2;
            apCustomerWork.CustomerAgentCd = customerWork.CustomerAgentCd;
            apCustomerWork.BillCollecterCd = customerWork.BillCollecterCd;
            apCustomerWork.OldCustomerAgentCd = customerWork.OldCustomerAgentCd;
            apCustomerWork.CustAgentChgDate = customerWork.CustAgentChgDate;
            apCustomerWork.AcceptWholeSale = customerWork.AcceptWholeSale;
            apCustomerWork.CreditMngCode = customerWork.CreditMngCode;
            apCustomerWork.DepoDelCode = customerWork.DepoDelCode;
            apCustomerWork.AccRecDivCd = customerWork.AccRecDivCd;
            apCustomerWork.CustSlipNoMngCd = customerWork.CustSlipNoMngCd;
            apCustomerWork.PureCode = customerWork.PureCode;
            apCustomerWork.CustCTaXLayRefCd = customerWork.CustCTaXLayRefCd;
            apCustomerWork.ConsTaxLayMethod = customerWork.ConsTaxLayMethod;
            apCustomerWork.TotalAmountDispWayCd = customerWork.TotalAmountDispWayCd;
            apCustomerWork.TotalAmntDspWayRef = customerWork.TotalAmntDspWayRef;
            apCustomerWork.AccountNoInfo1 = customerWork.AccountNoInfo1;
            apCustomerWork.AccountNoInfo2 = customerWork.AccountNoInfo2;
            apCustomerWork.AccountNoInfo3 = customerWork.AccountNoInfo3;
            apCustomerWork.SalesUnPrcFrcProcCd = customerWork.SalesUnPrcFrcProcCd;
            apCustomerWork.SalesMoneyFrcProcCd = customerWork.SalesMoneyFrcProcCd;
            apCustomerWork.SalesCnsTaxFrcProcCd = customerWork.SalesCnsTaxFrcProcCd;
            apCustomerWork.CustomerSlipNoDiv = customerWork.CustomerSlipNoDiv;
            apCustomerWork.NTimeCalcStDate = customerWork.NTimeCalcStDate;
            apCustomerWork.CustomerAgent = customerWork.CustomerAgent;
            apCustomerWork.ClaimSectionCode = customerWork.ClaimSectionCode;
            apCustomerWork.CarMngDivCd = customerWork.CarMngDivCd;
            apCustomerWork.BillPartsNoPrtCd = customerWork.BillPartsNoPrtCd;
            apCustomerWork.DeliPartsNoPrtCd = customerWork.DeliPartsNoPrtCd;
            apCustomerWork.DefSalesSlipCd = customerWork.DefSalesSlipCd;
            apCustomerWork.LavorRateRank = customerWork.LavorRateRank;
            apCustomerWork.SlipTtlPrn = customerWork.SlipTtlPrn;
            apCustomerWork.DepoBankCode = customerWork.DepoBankCode;
            apCustomerWork.CustWarehouseCd = customerWork.CustWarehouseCd;
            apCustomerWork.QrcodePrtCd = customerWork.QrcodePrtCd;
            apCustomerWork.DeliHonorificTtl = customerWork.DeliHonorificTtl;
            apCustomerWork.BillHonorificTtl = customerWork.BillHonorificTtl;
            apCustomerWork.EstmHonorificTtl = customerWork.EstmHonorificTtl;
            apCustomerWork.RectHonorificTtl = customerWork.RectHonorificTtl;
            apCustomerWork.DeliHonorTtlPrtDiv = customerWork.DeliHonorTtlPrtDiv;
            apCustomerWork.BillHonorTtlPrtDiv = customerWork.BillHonorTtlPrtDiv;
            apCustomerWork.EstmHonorTtlPrtDiv = customerWork.EstmHonorTtlPrtDiv;
            apCustomerWork.RectHonorTtlPrtDiv = customerWork.RectHonorTtlPrtDiv;
            apCustomerWork.Note1 = customerWork.Note1;
            apCustomerWork.Note2 = customerWork.Note2;
            apCustomerWork.Note3 = customerWork.Note3;
            apCustomerWork.Note4 = customerWork.Note4;
            apCustomerWork.Note5 = customerWork.Note5;
            apCustomerWork.Note6 = customerWork.Note6;
            apCustomerWork.Note7 = customerWork.Note7;
            apCustomerWork.Note8 = customerWork.Note8;
            apCustomerWork.Note9 = customerWork.Note9;
            apCustomerWork.Note10 = customerWork.Note10;
            apCustomerWork.SalesSlipPrtDiv = customerWork.SalesSlipPrtDiv;
            apCustomerWork.ShipmSlipPrtDiv = customerWork.ShipmSlipPrtDiv;
            apCustomerWork.AcpOdrrSlipPrtDiv = customerWork.AcpOdrrSlipPrtDiv;
            apCustomerWork.EstimatePrtDiv = customerWork.EstimatePrtDiv;
            apCustomerWork.UOESlipPrtDiv = customerWork.UOESlipPrtDiv;
            apCustomerWork.ReceiptOutputCode = customerWork.ReceiptOutputCode;

            // ADD 2009/05/25 --->>>
            apCustomerWork.CustomerEpCode = customerWork.CustomerEpCode;
            apCustomerWork.CustomerSecCode = customerWork.CustomerSecCode;
            apCustomerWork.OnlineKindDiv = customerWork.OnlineKindDiv;
            // ADD 2009/05/25 ---<<<
            // ADD 2010/02/02 MANTIS�Ή�[14953]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            apCustomerWork.TotalBillOutputDiv = customerWork.TotalBillOutputDiv;        // ���v�������o�͋敪
            apCustomerWork.DetailBillOutputCode = customerWork.DetailBillOutputCode;    // ���א������o�͋敪
            apCustomerWork.SlipTtlBillOutputDiv = customerWork.SlipTtlBillOutputDiv;    // �`�[���v�������o�͋敪
            // ADD 2010/02/02 MANTIS�Ή�[14953]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            return apCustomerWork;
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�ϓ����)�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="customerChangeWork">DC���Ӑ�}�X�^(�ϓ����)�f�[�^</param>
        /// <returns>AP���Ӑ�}�X�^(�ϓ����)�f�[�^</returns>
        public static APCustomerChangeWork SearchDataFromUpdateData(DCCustomerChangeWork customerChangeWork)
        {
            if (customerChangeWork == null)
            {
                return null;
            }

            APCustomerChangeWork apCustomerChangeWork = new APCustomerChangeWork();

            //���Ӑ�}�X�^(�ϓ����)�f�[�^�ϊ�
            apCustomerChangeWork.CreateDateTime = customerChangeWork.CreateDateTime;
            apCustomerChangeWork.UpdateDateTime = customerChangeWork.UpdateDateTime;
            apCustomerChangeWork.EnterpriseCode = customerChangeWork.EnterpriseCode;
            apCustomerChangeWork.FileHeaderGuid = customerChangeWork.FileHeaderGuid;
            apCustomerChangeWork.UpdEmployeeCode = customerChangeWork.UpdEmployeeCode;
            apCustomerChangeWork.UpdAssemblyId1 = customerChangeWork.UpdAssemblyId1;
            apCustomerChangeWork.UpdAssemblyId2 = customerChangeWork.UpdAssemblyId2;
            apCustomerChangeWork.LogicalDeleteCode = customerChangeWork.LogicalDeleteCode;
            apCustomerChangeWork.CustomerCode = customerChangeWork.CustomerCode;
            apCustomerChangeWork.CreditMoney = customerChangeWork.CreditMoney;
            apCustomerChangeWork.WarningCreditMoney = customerChangeWork.WarningCreditMoney;
            apCustomerChangeWork.PrsntAccRecBalance = customerChangeWork.PrsntAccRecBalance;

            return apCustomerChangeWork;
        }

        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
        /// <summary>
        /// ���Ӑ�}�X�^(�������)�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="customerMemoWork">DC���Ӑ�}�X�^(�������)�f�[�^</param>
        /// <returns>AP���Ӑ�}�X�^(�������)�f�[�^</returns>
        public static APCustomerMemoWork SearchDataFromUpdateData(DCCustomerMemoWork customerMemoWork)
        {
            if (customerMemoWork == null)
            {
                return null;
            }

            APCustomerMemoWork apCustomerMemoWork = new APCustomerMemoWork();

            //���Ӑ�}�X�^(�������)�f�[�^�ϊ�
            apCustomerMemoWork.CreateDateTime = customerMemoWork.CreateDateTime;
            apCustomerMemoWork.UpdateDateTime = customerMemoWork.UpdateDateTime;
            apCustomerMemoWork.EnterpriseCode = customerMemoWork.EnterpriseCode;
            apCustomerMemoWork.FileHeaderGuid = customerMemoWork.FileHeaderGuid;
            apCustomerMemoWork.UpdEmployeeCode = customerMemoWork.UpdEmployeeCode;
            apCustomerMemoWork.UpdAssemblyId1 = customerMemoWork.UpdAssemblyId1;
            apCustomerMemoWork.UpdAssemblyId2 = customerMemoWork.UpdAssemblyId2;
            apCustomerMemoWork.LogicalDeleteCode = customerMemoWork.LogicalDeleteCode;
            apCustomerMemoWork.CustomerCode = customerMemoWork.CustomerCode;
            apCustomerMemoWork.NoteInfo = customerMemoWork.NoteInfo;
            apCustomerMemoWork.DisplayDivCode = customerMemoWork.DisplayDivCode;

            return apCustomerMemoWork;
        }
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="custSlipMngWork">DC���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^</param>
        /// <returns>AP���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^</returns>
        public static APCustSlipMngWork SearchDataFromUpdateData(DCCustSlipMngWork custSlipMngWork)
        {
            if (custSlipMngWork == null)
            {
                return null;
            }

            APCustSlipMngWork apCustSlipMngWork = new APCustSlipMngWork();

            // ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^�ϊ�
            apCustSlipMngWork.CreateDateTime = custSlipMngWork.CreateDateTime;
            apCustSlipMngWork.UpdateDateTime = custSlipMngWork.UpdateDateTime;
            apCustSlipMngWork.EnterpriseCode = custSlipMngWork.EnterpriseCode;
            apCustSlipMngWork.FileHeaderGuid = custSlipMngWork.FileHeaderGuid;
            apCustSlipMngWork.UpdEmployeeCode = custSlipMngWork.UpdEmployeeCode;
            apCustSlipMngWork.UpdAssemblyId1 = custSlipMngWork.UpdAssemblyId1;
            apCustSlipMngWork.UpdAssemblyId2 = custSlipMngWork.UpdAssemblyId2;
            apCustSlipMngWork.LogicalDeleteCode = custSlipMngWork.LogicalDeleteCode;
            apCustSlipMngWork.DataInputSystem = custSlipMngWork.DataInputSystem;
            apCustSlipMngWork.SlipPrtKind = custSlipMngWork.SlipPrtKind;
            apCustSlipMngWork.SectionCode = custSlipMngWork.SectionCode;
            apCustSlipMngWork.CustomerCode = custSlipMngWork.CustomerCode;
            apCustSlipMngWork.SlipPrtSetPaperId = custSlipMngWork.SlipPrtSetPaperId;

            return apCustSlipMngWork;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="custRateGroupWork">DC���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^</param>
        /// <returns>AP���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^</returns>
        public static APCustRateGroupWork SearchDataFromUpdateData(DCCustRateGroupWork custRateGroupWork)
        {
            if (custRateGroupWork == null)
            {
                return null;
            }

            APCustRateGroupWork apCustRateGroupWork = new APCustRateGroupWork();

            // ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�ϊ�
            apCustRateGroupWork.CreateDateTime = custRateGroupWork.CreateDateTime;
            apCustRateGroupWork.UpdateDateTime = custRateGroupWork.UpdateDateTime;
            apCustRateGroupWork.EnterpriseCode = custRateGroupWork.EnterpriseCode;
            apCustRateGroupWork.FileHeaderGuid = custRateGroupWork.FileHeaderGuid;
            apCustRateGroupWork.UpdEmployeeCode = custRateGroupWork.UpdEmployeeCode;
            apCustRateGroupWork.UpdAssemblyId1 = custRateGroupWork.UpdAssemblyId1;
            apCustRateGroupWork.UpdAssemblyId2 = custRateGroupWork.UpdAssemblyId2;
            apCustRateGroupWork.LogicalDeleteCode = custRateGroupWork.LogicalDeleteCode;
            apCustRateGroupWork.CustomerCode = custRateGroupWork.CustomerCode;
            apCustRateGroupWork.PureCode = custRateGroupWork.PureCode;
            apCustRateGroupWork.GoodsMakerCd = custRateGroupWork.GoodsMakerCd;
            apCustRateGroupWork.CustRateGrpCode = custRateGroupWork.CustRateGrpCode;

            return apCustRateGroupWork;
        }

        /// <summary>
        /// ���Ӑ�i�`�[�ԍ��j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="custSlipNoSetWork">DC���Ӑ�i�`�[�ԍ��j�f�[�^</param>
        /// <returns>AP���Ӑ�i�`�[�ԍ��j�f�[�^</returns>
        public static APCustSlipNoSetWork SearchDataFromUpdateData(DCCustSlipNoSetWork custSlipNoSetWork)
        {
            if (custSlipNoSetWork == null)
            {
                return null;
            }

            APCustSlipNoSetWork apCustSlipNoSetWork = new APCustSlipNoSetWork();

            // ���Ӑ�i�`�[�ԍ��j�f�[�^�ϊ�
            apCustSlipNoSetWork.CreateDateTime = custSlipNoSetWork.CreateDateTime;
            apCustSlipNoSetWork.UpdateDateTime = custSlipNoSetWork.UpdateDateTime;
            apCustSlipNoSetWork.EnterpriseCode = custSlipNoSetWork.EnterpriseCode;
            apCustSlipNoSetWork.FileHeaderGuid = custSlipNoSetWork.FileHeaderGuid;
            apCustSlipNoSetWork.UpdEmployeeCode = custSlipNoSetWork.UpdEmployeeCode;
            apCustSlipNoSetWork.UpdAssemblyId1 = custSlipNoSetWork.UpdAssemblyId1;
            apCustSlipNoSetWork.UpdAssemblyId2 = custSlipNoSetWork.UpdAssemblyId2;
            apCustSlipNoSetWork.LogicalDeleteCode = custSlipNoSetWork.LogicalDeleteCode;
            apCustSlipNoSetWork.CustomerCode = custSlipNoSetWork.CustomerCode;
            apCustSlipNoSetWork.AddUpYearMonth = custSlipNoSetWork.AddUpYearMonth;
            apCustSlipNoSetWork.PresentCustSlipNo = custSlipNoSetWork.PresentCustSlipNo;
            apCustSlipNoSetWork.StartCustSlipNo = custSlipNoSetWork.StartCustSlipNo;
            apCustSlipNoSetWork.EndCustSlipNo = custSlipNoSetWork.EndCustSlipNo;

            return apCustSlipNoSetWork;
        }

        /// <summary>
        /// �d����}�X�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="supplierWork">DC�d����}�X�^</param>
        /// <returns>AP�d����}�X�^</returns>
        public static APSupplierWork SearchDataFromUpdateData(DCSupplierWork supplierWork)
        {
            if (supplierWork == null)
            {
                return null;
            }

            APSupplierWork apSupplierWork = new APSupplierWork();

            // �d����}�X�^�ϊ�
            apSupplierWork.CreateDateTime = supplierWork.CreateDateTime;
            apSupplierWork.UpdateDateTime = supplierWork.UpdateDateTime;
            apSupplierWork.EnterpriseCode = supplierWork.EnterpriseCode;
            apSupplierWork.FileHeaderGuid = supplierWork.FileHeaderGuid;
            apSupplierWork.UpdEmployeeCode = supplierWork.UpdEmployeeCode;
            apSupplierWork.UpdAssemblyId1 = supplierWork.UpdAssemblyId1;
            apSupplierWork.UpdAssemblyId2 = supplierWork.UpdAssemblyId2;
            apSupplierWork.LogicalDeleteCode = supplierWork.LogicalDeleteCode;
            apSupplierWork.SupplierCd = supplierWork.SupplierCd;
            apSupplierWork.MngSectionCode = supplierWork.MngSectionCode;
            apSupplierWork.InpSectionCode = supplierWork.InpSectionCode;
            apSupplierWork.PaymentSectionCode = supplierWork.PaymentSectionCode;
            apSupplierWork.SupplierNm1 = supplierWork.SupplierNm1;
            apSupplierWork.SupplierNm2 = supplierWork.SupplierNm2;
            apSupplierWork.SuppHonorificTitle = supplierWork.SuppHonorificTitle;
            apSupplierWork.SupplierKana = supplierWork.SupplierKana;
            apSupplierWork.SupplierSnm = supplierWork.SupplierSnm;
            apSupplierWork.OrderHonorificTtl = supplierWork.OrderHonorificTtl;
            apSupplierWork.BusinessTypeCode = supplierWork.BusinessTypeCode;
            apSupplierWork.SalesAreaCode = supplierWork.SalesAreaCode;
            apSupplierWork.SupplierPostNo = supplierWork.SupplierPostNo;
            apSupplierWork.SupplierAddr1 = supplierWork.SupplierAddr1;
            apSupplierWork.SupplierAddr3 = supplierWork.SupplierAddr3;
            apSupplierWork.SupplierAddr4 = supplierWork.SupplierAddr4;
            apSupplierWork.SupplierTelNo = supplierWork.SupplierTelNo;
            apSupplierWork.SupplierTelNo1 = supplierWork.SupplierTelNo1;
            apSupplierWork.SupplierTelNo2 = supplierWork.SupplierTelNo2;
            apSupplierWork.PureCode = supplierWork.PureCode;
            apSupplierWork.PaymentMonthCode = supplierWork.PaymentMonthCode;
            apSupplierWork.PaymentMonthName = supplierWork.PaymentMonthName;
            apSupplierWork.PaymentDay = supplierWork.PaymentDay;
            apSupplierWork.SuppCTaxLayRefCd = supplierWork.SuppCTaxLayRefCd;
            apSupplierWork.SuppCTaxLayCd = supplierWork.SuppCTaxLayCd;
            apSupplierWork.SuppCTaxationCd = supplierWork.SuppCTaxationCd;
            apSupplierWork.SuppEnterpriseCd = supplierWork.SuppEnterpriseCd;
            apSupplierWork.PayeeCode = supplierWork.PayeeCode;
            apSupplierWork.SupplierAttributeDiv = supplierWork.SupplierAttributeDiv;
            apSupplierWork.SuppTtlAmntDspWayCd = supplierWork.SuppTtlAmntDspWayCd;
            apSupplierWork.StckTtlAmntDspWayRef = supplierWork.StckTtlAmntDspWayRef;
            apSupplierWork.PaymentCond = supplierWork.PaymentCond;
            apSupplierWork.PaymentTotalDay = supplierWork.PaymentTotalDay;
            apSupplierWork.PaymentSight = supplierWork.PaymentSight;
            apSupplierWork.StockAgentCode = supplierWork.StockAgentCode;
            apSupplierWork.StockUnPrcFrcProcCd = supplierWork.StockUnPrcFrcProcCd;
            apSupplierWork.StockMoneyFrcProcCd = supplierWork.StockMoneyFrcProcCd;
            apSupplierWork.StockCnsTaxFrcProcCd = supplierWork.StockCnsTaxFrcProcCd;
            apSupplierWork.NTimeCalcStDate = supplierWork.NTimeCalcStDate;
            apSupplierWork.SupplierNote1 = supplierWork.SupplierNote1;
            apSupplierWork.SupplierNote2 = supplierWork.SupplierNote2;
            apSupplierWork.SupplierNote3 = supplierWork.SupplierNote3;
            apSupplierWork.SupplierNote4 = supplierWork.SupplierNote4;

            return apSupplierWork;
        }

        /// <summary>
        /// ���[�J�[�i���[�U�[�o�^���j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="makerUWork">DC���[�J�[�i���[�U�[�o�^���j�f�[�^</param>
        /// <returns>AP���[�J�[�i���[�U�[�o�^���j�f�[�^</returns>
        public static APMakerUWork SearchDataFromUpdateData(DCMakerUWork makerUWork)
        {
            if (makerUWork == null)
            {
                return null;
            }

            APMakerUWork apMakerUWork = new APMakerUWork();

            // ���[�J�[�i���[�U�[�o�^���j�f�[�^�ϊ�
            apMakerUWork.CreateDateTime = makerUWork.CreateDateTime;
            apMakerUWork.UpdateDateTime = makerUWork.UpdateDateTime;
            apMakerUWork.EnterpriseCode = makerUWork.EnterpriseCode;
            apMakerUWork.FileHeaderGuid = makerUWork.FileHeaderGuid;
            apMakerUWork.UpdEmployeeCode = makerUWork.UpdEmployeeCode;
            apMakerUWork.UpdAssemblyId1 = makerUWork.UpdAssemblyId1;
            apMakerUWork.UpdAssemblyId2 = makerUWork.UpdAssemblyId2;
            apMakerUWork.LogicalDeleteCode = makerUWork.LogicalDeleteCode;
            apMakerUWork.GoodsMakerCd = makerUWork.GoodsMakerCd;
            apMakerUWork.MakerName = makerUWork.MakerName;
            apMakerUWork.MakerShortName = makerUWork.MakerShortName;
            apMakerUWork.MakerKanaName = makerUWork.MakerKanaName;
            apMakerUWork.DisplayOrder = makerUWork.DisplayOrder;
            apMakerUWork.OfferDate = makerUWork.OfferDate;
            apMakerUWork.OfferDataDiv = makerUWork.OfferDataDiv;

            return apMakerUWork;
        }

        /// <summary>
        /// �a�k���i�R�[�h(���[�U�[)PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="bLGoodsCdUWork">DC�a�k���i�R�[�h(���[�U�[)</param>
        /// <returns>AP�a�k���i�R�[�h(���[�U�[)</returns>
        public static APBLGoodsCdUWork SearchDataFromUpdateData(DCBLGoodsCdUWork bLGoodsCdUWork)
        {
            if (bLGoodsCdUWork == null)
            {
                return null;
            }

            APBLGoodsCdUWork apBLGoodsCdUWork = new APBLGoodsCdUWork();

            // �a�k���i�R�[�h(���[�U�[)�ϊ�
            apBLGoodsCdUWork.CreateDateTime = bLGoodsCdUWork.CreateDateTime;
            apBLGoodsCdUWork.UpdateDateTime = bLGoodsCdUWork.UpdateDateTime;
            apBLGoodsCdUWork.EnterpriseCode = bLGoodsCdUWork.EnterpriseCode;
            apBLGoodsCdUWork.FileHeaderGuid = bLGoodsCdUWork.FileHeaderGuid;
            apBLGoodsCdUWork.UpdEmployeeCode = bLGoodsCdUWork.UpdEmployeeCode;
            apBLGoodsCdUWork.UpdAssemblyId1 = bLGoodsCdUWork.UpdAssemblyId1;
            apBLGoodsCdUWork.UpdAssemblyId2 = bLGoodsCdUWork.UpdAssemblyId2;
            apBLGoodsCdUWork.LogicalDeleteCode = bLGoodsCdUWork.LogicalDeleteCode;
            apBLGoodsCdUWork.BLGroupCode = bLGoodsCdUWork.BLGroupCode;
            apBLGoodsCdUWork.BLGoodsCode = bLGoodsCdUWork.BLGoodsCode;
            apBLGoodsCdUWork.BLGoodsFullName = bLGoodsCdUWork.BLGoodsFullName;
            apBLGoodsCdUWork.BLGoodsHalfName = bLGoodsCdUWork.BLGoodsHalfName;
            apBLGoodsCdUWork.BLGoodsGenreCode = bLGoodsCdUWork.BLGoodsGenreCode;
            apBLGoodsCdUWork.GoodsRateGrpCode = bLGoodsCdUWork.GoodsRateGrpCode;
            apBLGoodsCdUWork.OfferDate = bLGoodsCdUWork.OfferDate;
            apBLGoodsCdUWork.OfferDataDiv = bLGoodsCdUWork.OfferDataDiv;

            return apBLGoodsCdUWork;
        }

        /// <summary>
        /// ���i�i���[�U�[�o�^���jPramData��UIData�ڍ�����
        /// </summary>
        /// <param name="goodsUWork">DC���i�i���[�U�[�o�^���j</param>
        /// <returns>AP���i�i���[�U�[�o�^���j</returns>
        public static APGoodsUWork SearchDataFromUpdateData(DCGoodsUWork goodsUWork)
        {
            if (goodsUWork == null)
            {
                return null;
            }

            APGoodsUWork apGoodsUWork = new APGoodsUWork();

            // ���i�i���[�U�[�o�^���j�ϊ�
            apGoodsUWork.CreateDateTime = goodsUWork.CreateDateTime;
            apGoodsUWork.UpdateDateTime = goodsUWork.UpdateDateTime;
            apGoodsUWork.EnterpriseCode = goodsUWork.EnterpriseCode;
            apGoodsUWork.FileHeaderGuid = goodsUWork.FileHeaderGuid;
            apGoodsUWork.UpdEmployeeCode = goodsUWork.UpdEmployeeCode;
            apGoodsUWork.UpdAssemblyId1 = goodsUWork.UpdAssemblyId1;
            apGoodsUWork.UpdAssemblyId2 = goodsUWork.UpdAssemblyId2;
            apGoodsUWork.LogicalDeleteCode = goodsUWork.LogicalDeleteCode;
            apGoodsUWork.GoodsMakerCd = goodsUWork.GoodsMakerCd;
            apGoodsUWork.GoodsNo = goodsUWork.GoodsNo;
            apGoodsUWork.GoodsName = goodsUWork.GoodsName;
            apGoodsUWork.GoodsNameKana = goodsUWork.GoodsNameKana;
            apGoodsUWork.Jan = goodsUWork.Jan;
            apGoodsUWork.BLGoodsCode = goodsUWork.BLGoodsCode;
            apGoodsUWork.DisplayOrder = goodsUWork.DisplayOrder;
            apGoodsUWork.GoodsRateRank = goodsUWork.GoodsRateRank;
            apGoodsUWork.TaxationDivCd = goodsUWork.TaxationDivCd;
            apGoodsUWork.GoodsNoNoneHyphen = goodsUWork.GoodsNoNoneHyphen;
            apGoodsUWork.OfferDate = goodsUWork.OfferDate;
            apGoodsUWork.GoodsKindCode = goodsUWork.GoodsKindCode;
            apGoodsUWork.GoodsNote1 = goodsUWork.GoodsNote1;
            apGoodsUWork.GoodsNote2 = goodsUWork.GoodsNote2;
            apGoodsUWork.GoodsSpecialNote = goodsUWork.GoodsSpecialNote;
            apGoodsUWork.EnterpriseGanreCode = goodsUWork.EnterpriseGanreCode;
            apGoodsUWork.UpdateDate = goodsUWork.UpdateDate;
            apGoodsUWork.OfferDataDiv = goodsUWork.OfferDataDiv;

            return apGoodsUWork;
        }

        /// <summary>
        /// ���i�i���[�U�[�o�^���j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="goodsPriceUWork">DC���i�i���[�U�[�o�^���j�f�[�^</param>
        /// <returns>AP���i�i���[�U�[�o�^���j�f�[�^</returns>
        public static APGoodsPriceUWork SearchDataFromUpdateData(DCGoodsPriceUWork goodsPriceUWork)
        {
            if (goodsPriceUWork == null)
            {
                return null;
            }

            APGoodsPriceUWork apGoodsPriceUWork = new APGoodsPriceUWork();

            // ���i�i���[�U�[�o�^���j�f�[�^�ϊ�
            apGoodsPriceUWork.CreateDateTime = goodsPriceUWork.CreateDateTime;
            apGoodsPriceUWork.UpdateDateTime = goodsPriceUWork.UpdateDateTime;
            apGoodsPriceUWork.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
            apGoodsPriceUWork.FileHeaderGuid = goodsPriceUWork.FileHeaderGuid;
            apGoodsPriceUWork.UpdEmployeeCode = goodsPriceUWork.UpdEmployeeCode;
            apGoodsPriceUWork.UpdAssemblyId1 = goodsPriceUWork.UpdAssemblyId1;
            apGoodsPriceUWork.UpdAssemblyId2 = goodsPriceUWork.UpdAssemblyId2;
            apGoodsPriceUWork.LogicalDeleteCode = goodsPriceUWork.LogicalDeleteCode;
            apGoodsPriceUWork.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
            apGoodsPriceUWork.GoodsNo = goodsPriceUWork.GoodsNo;
            apGoodsPriceUWork.PriceStartDate = goodsPriceUWork.PriceStartDate;
            apGoodsPriceUWork.ListPrice = goodsPriceUWork.ListPrice;
            apGoodsPriceUWork.SalesUnitCost = goodsPriceUWork.SalesUnitCost;
            apGoodsPriceUWork.StockRate = goodsPriceUWork.StockRate;
            apGoodsPriceUWork.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv;
            apGoodsPriceUWork.OfferDate = goodsPriceUWork.OfferDate;
            apGoodsPriceUWork.UpdateDate = goodsPriceUWork.UpdateDate;

            return apGoodsPriceUWork;
        }

        /// <summary>
        /// ���i�Ǘ����f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="goodsMngWork">DC���i�Ǘ����f�[�^</param>
        /// <returns>AP���i�Ǘ����f�[�^</returns>
        public static APGoodsMngWork SearchDataFromUpdateData(DCGoodsMngWork goodsMngWork)
        {
            if (goodsMngWork == null)
            {
                return null;
            }

            APGoodsMngWork apGoodsMngWork = new APGoodsMngWork();

            // ���i�Ǘ����f�[�^�ϊ�
            apGoodsMngWork.CreateDateTime = goodsMngWork.CreateDateTime;
            apGoodsMngWork.UpdateDateTime = goodsMngWork.UpdateDateTime;
            apGoodsMngWork.EnterpriseCode = goodsMngWork.EnterpriseCode;
            apGoodsMngWork.FileHeaderGuid = goodsMngWork.FileHeaderGuid;
            apGoodsMngWork.UpdEmployeeCode = goodsMngWork.UpdEmployeeCode;
            apGoodsMngWork.UpdAssemblyId1 = goodsMngWork.UpdAssemblyId1;
            apGoodsMngWork.UpdAssemblyId2 = goodsMngWork.UpdAssemblyId2;
            apGoodsMngWork.LogicalDeleteCode = goodsMngWork.LogicalDeleteCode;
            apGoodsMngWork.SectionCode = goodsMngWork.SectionCode;
            apGoodsMngWork.GoodsMGroup = goodsMngWork.GoodsMGroup;
            apGoodsMngWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
            apGoodsMngWork.BLGoodsCode = goodsMngWork.BLGoodsCode;
            apGoodsMngWork.GoodsNo = goodsMngWork.GoodsNo;
            apGoodsMngWork.SupplierCd = goodsMngWork.SupplierCd;
            apGoodsMngWork.SupplierLot = goodsMngWork.SupplierLot;

            return apGoodsMngWork;
        }

        /// <summary>
        /// �������i�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="isolIslandPrcWork">DC�������i�f�[�^</param>
        /// <returns>AP�������i�f�[�^</returns>
        public static APIsolIslandPrcWork SearchDataFromUpdateData(DCIsolIslandPrcWork isolIslandPrcWork)
        {
            if (isolIslandPrcWork == null)
            {
                return null;
            }

            APIsolIslandPrcWork apIsolIslandPrcWork = new APIsolIslandPrcWork();

            // �������i�f�[�^�ϊ�;
            apIsolIslandPrcWork.CreateDateTime = isolIslandPrcWork.CreateDateTime;
            apIsolIslandPrcWork.UpdateDateTime = isolIslandPrcWork.UpdateDateTime;
            apIsolIslandPrcWork.EnterpriseCode = isolIslandPrcWork.EnterpriseCode;
            apIsolIslandPrcWork.FileHeaderGuid = isolIslandPrcWork.FileHeaderGuid;
            apIsolIslandPrcWork.UpdEmployeeCode = isolIslandPrcWork.UpdEmployeeCode;
            apIsolIslandPrcWork.UpdAssemblyId1 = isolIslandPrcWork.UpdAssemblyId1;
            apIsolIslandPrcWork.UpdAssemblyId2 = isolIslandPrcWork.UpdAssemblyId2;
            apIsolIslandPrcWork.LogicalDeleteCode = isolIslandPrcWork.LogicalDeleteCode;
            apIsolIslandPrcWork.SectionCode = isolIslandPrcWork.SectionCode;
            apIsolIslandPrcWork.MakerCode = isolIslandPrcWork.MakerCode;
            apIsolIslandPrcWork.UpperLimitPrice = isolIslandPrcWork.UpperLimitPrice;
            apIsolIslandPrcWork.FractionProcUnit = isolIslandPrcWork.FractionProcUnit;
            apIsolIslandPrcWork.FractionProcCd = isolIslandPrcWork.FractionProcCd;
            apIsolIslandPrcWork.UpRate = isolIslandPrcWork.UpRate;

            return apIsolIslandPrcWork;
        }

        /// <summary>
        /// �݌Ƀf�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="stockWork">DC�݌Ƀf�[�^</param>
        /// <returns>AP�݌Ƀf�[�^</returns>
        public static APStockWork SearchDataFromUpdateData(DCStockWork stockWork)
        {
            if (stockWork == null)
            {
                return null;
            }

            APStockWork apStockWork = new APStockWork();

            // �݌Ƀf�[�^�ϊ�
            apStockWork.CreateDateTime = stockWork.CreateDateTime;
            apStockWork.UpdateDateTime = stockWork.UpdateDateTime;
            apStockWork.EnterpriseCode = stockWork.EnterpriseCode;
            apStockWork.FileHeaderGuid = stockWork.FileHeaderGuid;
            apStockWork.UpdEmployeeCode = stockWork.UpdEmployeeCode;
            apStockWork.UpdAssemblyId1 = stockWork.UpdAssemblyId1;
            apStockWork.UpdAssemblyId2 = stockWork.UpdAssemblyId2;
            apStockWork.LogicalDeleteCode = stockWork.LogicalDeleteCode;
            apStockWork.SectionCode = stockWork.SectionCode;
            apStockWork.WarehouseCode = stockWork.WarehouseCode;
            apStockWork.GoodsMakerCd = stockWork.GoodsMakerCd;
            apStockWork.GoodsNo = stockWork.GoodsNo;
            apStockWork.StockUnitPriceFl = stockWork.StockUnitPriceFl;
            apStockWork.SupplierStock = stockWork.SupplierStock;
            apStockWork.AcpOdrCount = stockWork.AcpOdrCount;
            apStockWork.MonthOrderCount = stockWork.MonthOrderCount;
            apStockWork.SalesOrderCount = stockWork.SalesOrderCount;
            apStockWork.StockDiv = stockWork.StockDiv;
            apStockWork.MovingSupliStock = stockWork.MovingSupliStock;
            apStockWork.ShipmentPosCnt = stockWork.ShipmentPosCnt;
            apStockWork.StockTotalPrice = stockWork.StockTotalPrice;
            apStockWork.LastStockDate = stockWork.LastStockDate;
            apStockWork.LastSalesDate = stockWork.LastSalesDate;
            apStockWork.LastInventoryUpdate = stockWork.LastInventoryUpdate;
            apStockWork.MinimumStockCnt = stockWork.MinimumStockCnt;
            apStockWork.MaximumStockCnt = stockWork.MaximumStockCnt;
            apStockWork.NmlSalOdrCount = stockWork.NmlSalOdrCount;
            apStockWork.SalesOrderUnit = stockWork.SalesOrderUnit;
            apStockWork.StockSupplierCode = stockWork.StockSupplierCode;
            apStockWork.GoodsNoNoneHyphen = stockWork.GoodsNoNoneHyphen;
            apStockWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
            apStockWork.DuplicationShelfNo1 = stockWork.DuplicationShelfNo1;
            apStockWork.DuplicationShelfNo2 = stockWork.DuplicationShelfNo2;
            apStockWork.PartsManagementDivide1 = stockWork.PartsManagementDivide1;
            apStockWork.PartsManagementDivide2 = stockWork.PartsManagementDivide2;
            apStockWork.StockNote1 = stockWork.StockNote1;
            apStockWork.StockNote2 = stockWork.StockNote2;
            apStockWork.ShipmentCnt = stockWork.ShipmentCnt;
            apStockWork.ArrivalCnt = stockWork.ArrivalCnt;
            apStockWork.StockCreateDate = stockWork.StockCreateDate;
            apStockWork.UpdateDate = stockWork.UpdateDate;

            return apStockWork;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�ύX���j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="userGdBdUWork">DC���[�U�[�K�C�h�i�{�f�B�j�i���[�U�ύX���j�f�[�^</param>
        /// <returns>AP���[�U�[�K�C�h�i�{�f�B�j�i���[�U�ύX���j�f�[�^</returns>
        public static APUserGdBdUWork SearchDataFromUpdateData(DCUserGdBdUWork userGdBdUWork)
        {
            if (userGdBdUWork == null)
            {
                return null;
            }

            APUserGdBdUWork apUserGdBdUWork = new APUserGdBdUWork();

            // ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�ύX���j�f�[�^�ϊ�
            apUserGdBdUWork.CreateDateTime = userGdBdUWork.CreateDateTime;
            apUserGdBdUWork.UpdateDateTime = userGdBdUWork.UpdateDateTime;
            apUserGdBdUWork.EnterpriseCode = userGdBdUWork.EnterpriseCode;
            apUserGdBdUWork.FileHeaderGuid = userGdBdUWork.FileHeaderGuid;
            apUserGdBdUWork.UpdEmployeeCode = userGdBdUWork.UpdEmployeeCode;
            apUserGdBdUWork.UpdAssemblyId1 = userGdBdUWork.UpdAssemblyId1;
            apUserGdBdUWork.UpdAssemblyId2 = userGdBdUWork.UpdAssemblyId2;
            apUserGdBdUWork.LogicalDeleteCode = userGdBdUWork.LogicalDeleteCode;
            apUserGdBdUWork.UserGuideDivCd = userGdBdUWork.UserGuideDivCd;
            apUserGdBdUWork.GuideCode = userGdBdUWork.GuideCode;
            apUserGdBdUWork.GuideName = userGdBdUWork.GuideName;
            apUserGdBdUWork.GuideType = userGdBdUWork.GuideType;

            return apUserGdBdUWork;
        }

        /// <summary>
        /// �|���f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="rateWork">DC�|���f�[�^</param>
        /// <returns>AP�|���f�[�^</returns>
        public static APRateWork SearchDataFromUpdateData(DCRateWork rateWork)
        {
            if (rateWork == null)
            {
                return null;
            }

            APRateWork apRateWork = new APRateWork();

            // �|���f�[�^�ϊ�
            apRateWork.CreateDateTime = rateWork.CreateDateTime;
            apRateWork.UpdateDateTime = rateWork.UpdateDateTime;
            apRateWork.EnterpriseCode = rateWork.EnterpriseCode;
            apRateWork.FileHeaderGuid = rateWork.FileHeaderGuid;
            apRateWork.UpdEmployeeCode = rateWork.UpdEmployeeCode;
            apRateWork.UpdAssemblyId1 = rateWork.UpdAssemblyId1;
            apRateWork.UpdAssemblyId2 = rateWork.UpdAssemblyId2;
            apRateWork.LogicalDeleteCode = rateWork.LogicalDeleteCode;
            apRateWork.SectionCode = rateWork.SectionCode;
            apRateWork.UnitRateSetDivCd = rateWork.UnitRateSetDivCd;
            apRateWork.UnitPriceKind = rateWork.UnitPriceKind;
            apRateWork.RateSettingDivide = rateWork.RateSettingDivide;
            apRateWork.RateMngGoodsCd = rateWork.RateMngGoodsCd;
            apRateWork.RateMngGoodsNm = rateWork.RateMngGoodsNm;
            apRateWork.RateMngCustCd = rateWork.RateMngCustCd;
            apRateWork.RateMngCustNm = rateWork.RateMngCustNm;
            apRateWork.GoodsMakerCd = rateWork.GoodsMakerCd;
            apRateWork.GoodsNo = rateWork.GoodsNo;
            apRateWork.GoodsRateRank = rateWork.GoodsRateRank;
            apRateWork.GoodsRateGrpCode = rateWork.GoodsRateGrpCode;
            apRateWork.BLGroupCode = rateWork.BLGroupCode;
            apRateWork.BLGoodsCode = rateWork.BLGoodsCode;
            apRateWork.CustomerCode = rateWork.CustomerCode;
            apRateWork.CustRateGrpCode = rateWork.CustRateGrpCode;
            apRateWork.SupplierCd = rateWork.SupplierCd;
            apRateWork.LotCount = rateWork.LotCount;
            apRateWork.PriceFl = rateWork.PriceFl;
            apRateWork.RateVal = rateWork.RateVal;
            apRateWork.UpRate = rateWork.UpRate;
            apRateWork.GrsProfitSecureRate = rateWork.GrsProfitSecureRate;
            apRateWork.UnPrcFracProcUnit = rateWork.UnPrcFracProcUnit;
            apRateWork.UnPrcFracProcDiv = rateWork.UnPrcFracProcDiv;

            return apRateWork;
        }

        /// <summary>
        /// �|���D��Ǘ��f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="rateProtyMngWork">DC�|���D��Ǘ��f�[�^</param>
        /// <returns>AP�|���D��Ǘ��f�[�^</returns>
        public static APRateProtyMngWork SearchDataFromUpdateData(DCRateProtyMngWork rateProtyMngWork)
        {
            if (rateProtyMngWork == null)
            {
                return null;
            }

            APRateProtyMngWork apRateProtyMngWork = new APRateProtyMngWork();

            // �|���D��Ǘ��f�[�^�ϊ�
            apRateProtyMngWork.CreateDateTime = rateProtyMngWork.CreateDateTime;
            apRateProtyMngWork.UpdateDateTime = rateProtyMngWork.UpdateDateTime;
            apRateProtyMngWork.EnterpriseCode = rateProtyMngWork.EnterpriseCode;
            apRateProtyMngWork.FileHeaderGuid = rateProtyMngWork.FileHeaderGuid;
            apRateProtyMngWork.UpdEmployeeCode = rateProtyMngWork.UpdEmployeeCode;
            apRateProtyMngWork.UpdAssemblyId1 = rateProtyMngWork.UpdAssemblyId1;
            apRateProtyMngWork.UpdAssemblyId2 = rateProtyMngWork.UpdAssemblyId2;
            apRateProtyMngWork.LogicalDeleteCode = rateProtyMngWork.LogicalDeleteCode;
            apRateProtyMngWork.SectionCode = rateProtyMngWork.SectionCode;
            apRateProtyMngWork.UnitPriceKind = rateProtyMngWork.UnitPriceKind;
            apRateProtyMngWork.RateSettingDivide = rateProtyMngWork.RateSettingDivide;
            apRateProtyMngWork.RatePriorityOrder = rateProtyMngWork.RatePriorityOrder;
            apRateProtyMngWork.RateMngGoodsCd = rateProtyMngWork.RateMngGoodsCd;
            apRateProtyMngWork.RateMngGoodsNm = rateProtyMngWork.RateMngGoodsNm;
            apRateProtyMngWork.RateMngCustCd = rateProtyMngWork.RateMngCustCd;
            apRateProtyMngWork.RateMngCustNm = rateProtyMngWork.RateMngCustNm;

            return apRateProtyMngWork;
        }

        /// <summary>
        /// ���i�Z�b�g�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="goodsSetWork">DC���i�Z�b�g�f�[�^</param>
        /// <returns>AP���i�Z�b�g�f�[�^</returns>
        public static APGoodsSetWork SearchDataFromUpdateData(DCGoodsSetWork goodsSetWork)
        {
            if (goodsSetWork == null)
            {
                return null;
            }

            APGoodsSetWork apGoodsSetWork = new APGoodsSetWork();

            // ���i�Z�b�g�f�[�^�ϊ�
            apGoodsSetWork.CreateDateTime = goodsSetWork.CreateDateTime;
            apGoodsSetWork.UpdateDateTime = goodsSetWork.UpdateDateTime;
            apGoodsSetWork.EnterpriseCode = goodsSetWork.EnterpriseCode;
            apGoodsSetWork.FileHeaderGuid = goodsSetWork.FileHeaderGuid;
            apGoodsSetWork.UpdEmployeeCode = goodsSetWork.UpdEmployeeCode;
            apGoodsSetWork.UpdAssemblyId1 = goodsSetWork.UpdAssemblyId1;
            apGoodsSetWork.UpdAssemblyId2 = goodsSetWork.UpdAssemblyId2;
            apGoodsSetWork.LogicalDeleteCode = goodsSetWork.LogicalDeleteCode;
            apGoodsSetWork.ParentGoodsMakerCd = goodsSetWork.ParentGoodsMakerCd;
            apGoodsSetWork.ParentGoodsNo = goodsSetWork.ParentGoodsNo;
            apGoodsSetWork.SubGoodsMakerCd = goodsSetWork.SubGoodsMakerCd;
            apGoodsSetWork.SubGoodsNo = goodsSetWork.SubGoodsNo;
            apGoodsSetWork.CntFl = goodsSetWork.CntFl;
            apGoodsSetWork.DisplayOrder = goodsSetWork.DisplayOrder;
            apGoodsSetWork.SetSpecialNote = goodsSetWork.SetSpecialNote;
            apGoodsSetWork.CatalogShapeNo = goodsSetWork.CatalogShapeNo;

            return apGoodsSetWork;
        }

        /// <summary>
        /// ���i��ցi���[�U�[�o�^���j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="partsSubstUWork">DC���i��ցi���[�U�[�o�^���j�f�[�^</param>
        /// <returns>AP���i��ցi���[�U�[�o�^���j�f�[�^</returns>
        public static APPartsSubstUWork SearchDataFromUpdateData(DCPartsSubstUWork partsSubstUWork)
        {
            if (partsSubstUWork == null)
            {
                return null;
            }

            APPartsSubstUWork apPartsSubstUWork = new APPartsSubstUWork();

            // ���i��ցi���[�U�[�o�^���j�f�[�^�ϊ�
            apPartsSubstUWork.CreateDateTime = partsSubstUWork.CreateDateTime;
            apPartsSubstUWork.UpdateDateTime = partsSubstUWork.UpdateDateTime;
            apPartsSubstUWork.EnterpriseCode = partsSubstUWork.EnterpriseCode;
            apPartsSubstUWork.FileHeaderGuid = partsSubstUWork.FileHeaderGuid;
            apPartsSubstUWork.UpdEmployeeCode = partsSubstUWork.UpdEmployeeCode;
            apPartsSubstUWork.UpdAssemblyId1 = partsSubstUWork.UpdAssemblyId1;
            apPartsSubstUWork.UpdAssemblyId2 = partsSubstUWork.UpdAssemblyId2;
            apPartsSubstUWork.LogicalDeleteCode = partsSubstUWork.LogicalDeleteCode;
            apPartsSubstUWork.ChgSrcMakerCd = partsSubstUWork.ChgSrcMakerCd;
            apPartsSubstUWork.ChgSrcGoodsNo = partsSubstUWork.ChgSrcGoodsNo;
            apPartsSubstUWork.ChgSrcGoodsNoNoneHp = partsSubstUWork.ChgSrcGoodsNoNoneHp;
            apPartsSubstUWork.ChgDestMakerCd = partsSubstUWork.ChgDestMakerCd;
            apPartsSubstUWork.ChgDestGoodsNo = partsSubstUWork.ChgDestGoodsNo;
            apPartsSubstUWork.ChgDestGoodsNoNoneHp = partsSubstUWork.ChgDestGoodsNoNoneHp;
            apPartsSubstUWork.ApplyStaDate = partsSubstUWork.ApplyStaDate;
            apPartsSubstUWork.ApplyEndDate = partsSubstUWork.ApplyEndDate;

            return apPartsSubstUWork;
        }

        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="empSalesTargetWork">DC�]�ƈ��ʔ���ڕW�ݒ�f�[�^</param>
        /// <returns>AP�]�ƈ��ʔ���ڕW�ݒ�f�[�^</returns>
        public static APEmpSalesTargetWork SearchDataFromUpdateData(DCEmpSalesTargetWork empSalesTargetWork)
        {
            if (empSalesTargetWork == null)
            {
                return null;
            }

            APEmpSalesTargetWork apEmpSalesTargetWork = new APEmpSalesTargetWork();

            // �]�ƈ��ʔ���ڕW�ݒ�f�[�^�ϊ�
            apEmpSalesTargetWork.CreateDateTime = empSalesTargetWork.CreateDateTime;
            apEmpSalesTargetWork.UpdateDateTime = empSalesTargetWork.UpdateDateTime;
            apEmpSalesTargetWork.EnterpriseCode = empSalesTargetWork.EnterpriseCode;
            apEmpSalesTargetWork.FileHeaderGuid = empSalesTargetWork.FileHeaderGuid;
            apEmpSalesTargetWork.UpdEmployeeCode = empSalesTargetWork.UpdEmployeeCode;
            apEmpSalesTargetWork.UpdAssemblyId1 = empSalesTargetWork.UpdAssemblyId1;
            apEmpSalesTargetWork.UpdAssemblyId2 = empSalesTargetWork.UpdAssemblyId2;
            apEmpSalesTargetWork.LogicalDeleteCode = empSalesTargetWork.LogicalDeleteCode;
            apEmpSalesTargetWork.SectionCode = empSalesTargetWork.SectionCode;
            apEmpSalesTargetWork.TargetSetCd = empSalesTargetWork.TargetSetCd;
            apEmpSalesTargetWork.TargetContrastCd = empSalesTargetWork.TargetContrastCd;
            apEmpSalesTargetWork.TargetDivideCode = empSalesTargetWork.TargetDivideCode;
            apEmpSalesTargetWork.TargetDivideName = empSalesTargetWork.TargetDivideName;
            apEmpSalesTargetWork.EmployeeDivCd = empSalesTargetWork.EmployeeDivCd;
            apEmpSalesTargetWork.SubSectionCode = empSalesTargetWork.SubSectionCode;
            apEmpSalesTargetWork.EmployeeCode = empSalesTargetWork.EmployeeCode;
            apEmpSalesTargetWork.ApplyStaDate = empSalesTargetWork.ApplyStaDate;
            apEmpSalesTargetWork.ApplyEndDate = empSalesTargetWork.ApplyEndDate;
            apEmpSalesTargetWork.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney;
            apEmpSalesTargetWork.SalesTargetProfit = empSalesTargetWork.SalesTargetProfit;
            apEmpSalesTargetWork.SalesTargetCount = empSalesTargetWork.SalesTargetCount;


            return apEmpSalesTargetWork;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="custSalesTargetWork">DC���Ӑ�ʔ���ڕW�ݒ�f�[�^</param>
        /// <returns>AP���Ӑ�ʔ���ڕW�ݒ�f�[�^</returns>
        public static APCustSalesTargetWork SearchDataFromUpdateData(DCCustSalesTargetWork custSalesTargetWork)
        {
            if (custSalesTargetWork == null)
            {
                return null;
            }

            APCustSalesTargetWork apCustSalesTargetWork = new APCustSalesTargetWork();

            // ���Ӑ�ʔ���ڕW�ݒ�f�[�^�ϊ�
            apCustSalesTargetWork.CreateDateTime = custSalesTargetWork.CreateDateTime;
            apCustSalesTargetWork.UpdateDateTime = custSalesTargetWork.UpdateDateTime;
            apCustSalesTargetWork.EnterpriseCode = custSalesTargetWork.EnterpriseCode;
            apCustSalesTargetWork.FileHeaderGuid = custSalesTargetWork.FileHeaderGuid;
            apCustSalesTargetWork.UpdEmployeeCode = custSalesTargetWork.UpdEmployeeCode;
            apCustSalesTargetWork.UpdAssemblyId1 = custSalesTargetWork.UpdAssemblyId1;
            apCustSalesTargetWork.UpdAssemblyId2 = custSalesTargetWork.UpdAssemblyId2;
            apCustSalesTargetWork.LogicalDeleteCode = custSalesTargetWork.LogicalDeleteCode;
            apCustSalesTargetWork.SectionCode = custSalesTargetWork.SectionCode;
            apCustSalesTargetWork.TargetSetCd = custSalesTargetWork.TargetSetCd;
            apCustSalesTargetWork.TargetContrastCd = custSalesTargetWork.TargetContrastCd;
            apCustSalesTargetWork.TargetDivideCode = custSalesTargetWork.TargetDivideCode;
            apCustSalesTargetWork.TargetDivideName = custSalesTargetWork.TargetDivideName;
            apCustSalesTargetWork.BusinessTypeCode = custSalesTargetWork.BusinessTypeCode;
            apCustSalesTargetWork.SalesAreaCode = custSalesTargetWork.SalesAreaCode;
            apCustSalesTargetWork.CustomerCode = custSalesTargetWork.CustomerCode;
            apCustSalesTargetWork.ApplyStaDate = custSalesTargetWork.ApplyStaDate;
            apCustSalesTargetWork.ApplyEndDate = custSalesTargetWork.ApplyEndDate;
            apCustSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney;
            apCustSalesTargetWork.SalesTargetProfit = custSalesTargetWork.SalesTargetProfit;
            apCustSalesTargetWork.SalesTargetCount = custSalesTargetWork.SalesTargetCount;

            return apCustSalesTargetWork;
        }

        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="gcdSalesTargetWork">DC���i�ʔ���ڕW�ݒ�f�[�^</param>
        /// <returns>AP���i�ʔ���ڕW�ݒ�f�[�^</returns>
        public static APGcdSalesTargetWork SearchDataFromUpdateData(DCGcdSalesTargetWork gcdSalesTargetWork)
        {
            if (gcdSalesTargetWork == null)
            {
                return null;
            }

            APGcdSalesTargetWork apGcdSalesTargetWork = new APGcdSalesTargetWork();

            // ���i�ʔ���ڕW�ݒ�f�[�^�ϊ�
            apGcdSalesTargetWork.CreateDateTime = gcdSalesTargetWork.CreateDateTime;
            apGcdSalesTargetWork.UpdateDateTime = gcdSalesTargetWork.UpdateDateTime;
            apGcdSalesTargetWork.EnterpriseCode = gcdSalesTargetWork.EnterpriseCode;
            apGcdSalesTargetWork.FileHeaderGuid = gcdSalesTargetWork.FileHeaderGuid;
            apGcdSalesTargetWork.UpdEmployeeCode = gcdSalesTargetWork.UpdEmployeeCode;
            apGcdSalesTargetWork.UpdAssemblyId1 = gcdSalesTargetWork.UpdAssemblyId1;
            apGcdSalesTargetWork.UpdAssemblyId2 = gcdSalesTargetWork.UpdAssemblyId2;
            apGcdSalesTargetWork.LogicalDeleteCode = gcdSalesTargetWork.LogicalDeleteCode;
            apGcdSalesTargetWork.SectionCode = gcdSalesTargetWork.SectionCode;
            apGcdSalesTargetWork.TargetSetCd = gcdSalesTargetWork.TargetSetCd;
            apGcdSalesTargetWork.TargetContrastCd = gcdSalesTargetWork.TargetContrastCd;
            apGcdSalesTargetWork.TargetDivideCode = gcdSalesTargetWork.TargetDivideCode;
            apGcdSalesTargetWork.TargetDivideName = gcdSalesTargetWork.TargetDivideName;
            apGcdSalesTargetWork.GoodsMakerCd = gcdSalesTargetWork.GoodsMakerCd;
            apGcdSalesTargetWork.GoodsNo = gcdSalesTargetWork.GoodsNo;
            apGcdSalesTargetWork.BLGroupCode = gcdSalesTargetWork.BLGroupCode;
            apGcdSalesTargetWork.BLGoodsCode = gcdSalesTargetWork.BLGoodsCode;
            apGcdSalesTargetWork.SalesCode = gcdSalesTargetWork.SalesCode;
            apGcdSalesTargetWork.EnterpriseGanreCode = gcdSalesTargetWork.EnterpriseGanreCode;
            apGcdSalesTargetWork.ApplyStaDate = gcdSalesTargetWork.ApplyStaDate;
            apGcdSalesTargetWork.ApplyEndDate = gcdSalesTargetWork.ApplyEndDate;
            apGcdSalesTargetWork.SalesTargetMoney = gcdSalesTargetWork.SalesTargetMoney;
            apGcdSalesTargetWork.SalesTargetProfit = gcdSalesTargetWork.SalesTargetProfit;
            apGcdSalesTargetWork.SalesTargetCount = gcdSalesTargetWork.SalesTargetCount;

            return apGcdSalesTargetWork;
        }

        /// <summary>
        /// ���i�����ށi���[�U�[�o�^���j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="goodsGroupUWork">DC���i�����ށi���[�U�[�o�^���j�f�[�^</param>
        /// <returns>AP���i�����ށi���[�U�[�o�^���j�f�[�^</returns>
        public static APGoodsGroupUWork SearchDataFromUpdateData(DCGoodsGroupUWork goodsGroupUWork)
        {
            if (goodsGroupUWork == null)
            {
                return null;
            }

            APGoodsGroupUWork apGoodsGroupUWork = new APGoodsGroupUWork();

            // ���i�����ށi���[�U�[�o�^���j�f�[�^�ϊ�
            apGoodsGroupUWork.CreateDateTime = goodsGroupUWork.CreateDateTime;
            apGoodsGroupUWork.UpdateDateTime = goodsGroupUWork.UpdateDateTime;
            apGoodsGroupUWork.EnterpriseCode = goodsGroupUWork.EnterpriseCode;
            apGoodsGroupUWork.FileHeaderGuid = goodsGroupUWork.FileHeaderGuid;
            apGoodsGroupUWork.UpdEmployeeCode = goodsGroupUWork.UpdEmployeeCode;
            apGoodsGroupUWork.UpdAssemblyId1 = goodsGroupUWork.UpdAssemblyId1;
            apGoodsGroupUWork.UpdAssemblyId2 = goodsGroupUWork.UpdAssemblyId2;
            apGoodsGroupUWork.LogicalDeleteCode = goodsGroupUWork.LogicalDeleteCode;
            apGoodsGroupUWork.GoodsMGroup = goodsGroupUWork.GoodsMGroup;
            apGoodsGroupUWork.GoodsMGroupName = goodsGroupUWork.GoodsMGroupName;
            apGoodsGroupUWork.OfferDate = goodsGroupUWork.OfferDate;
            apGoodsGroupUWork.OfferDataDiv = goodsGroupUWork.OfferDataDiv;

            return apGoodsGroupUWork;
        }

        /// <summary>
        /// BL�O���[�v�i���[�U�[�o�^���j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="bLGroupUWork">DCBL�O���[�v�i���[�U�[�o�^���j�f�[�^</param>
        /// <returns>APBL�O���[�v�i���[�U�[�o�^���j�f�[�^</returns>
        public static APBLGroupUWork SearchDataFromUpdateData(DCBLGroupUWork bLGroupUWork)
        {
            if (bLGroupUWork == null)
            {
                return null;
            }

            APBLGroupUWork apBLGroupUWork = new APBLGroupUWork();

            // BL�O���[�v�i���[�U�[�o�^���j�f�[�^�ϊ�
            apBLGroupUWork.CreateDateTime = bLGroupUWork.CreateDateTime;
            apBLGroupUWork.UpdateDateTime = bLGroupUWork.UpdateDateTime;
            apBLGroupUWork.EnterpriseCode = bLGroupUWork.EnterpriseCode;
            apBLGroupUWork.FileHeaderGuid = bLGroupUWork.FileHeaderGuid;
            apBLGroupUWork.UpdEmployeeCode = bLGroupUWork.UpdEmployeeCode;
            apBLGroupUWork.UpdAssemblyId1 = bLGroupUWork.UpdAssemblyId1;
            apBLGroupUWork.UpdAssemblyId2 = bLGroupUWork.UpdAssemblyId2;
            apBLGroupUWork.LogicalDeleteCode = bLGroupUWork.LogicalDeleteCode;
            apBLGroupUWork.GoodsLGroup = bLGroupUWork.GoodsLGroup;
            apBLGroupUWork.GoodsMGroup = bLGroupUWork.GoodsMGroup;
            apBLGroupUWork.BLGroupCode = bLGroupUWork.BLGroupCode;
            apBLGroupUWork.BLGroupName = bLGroupUWork.BLGroupName;
            apBLGroupUWork.BLGroupKanaName = bLGroupUWork.BLGroupKanaName;
            apBLGroupUWork.SalesCode = bLGroupUWork.SalesCode;
            apBLGroupUWork.OfferDate = bLGroupUWork.OfferDate;
            apBLGroupUWork.OfferDataDiv = bLGroupUWork.OfferDataDiv;

            return apBLGroupUWork;
        }

        /// <summary>
        /// �����i���[�U�[�o�^�j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="joinPartsUWork">DC�����i���[�U�[�o�^�j�f�[�^</param>
        /// <returns>AP�����i���[�U�[�o�^�j�f�[�^</returns>
        public static APJoinPartsUWork SearchDataFromUpdateData(DCJoinPartsUWork joinPartsUWork)
        {
            if (joinPartsUWork == null)
            {
                return null;
            }

            APJoinPartsUWork apJoinPartsUWork = new APJoinPartsUWork();

            // �����i���[�U�[�o�^�j�f�[�^�ϊ�
            apJoinPartsUWork.CreateDateTime = joinPartsUWork.CreateDateTime;
            apJoinPartsUWork.UpdateDateTime = joinPartsUWork.UpdateDateTime;
            apJoinPartsUWork.EnterpriseCode = joinPartsUWork.EnterpriseCode;
            apJoinPartsUWork.FileHeaderGuid = joinPartsUWork.FileHeaderGuid;
            apJoinPartsUWork.UpdEmployeeCode = joinPartsUWork.UpdEmployeeCode;
            apJoinPartsUWork.UpdAssemblyId1 = joinPartsUWork.UpdAssemblyId1;
            apJoinPartsUWork.UpdAssemblyId2 = joinPartsUWork.UpdAssemblyId2;
            apJoinPartsUWork.LogicalDeleteCode = joinPartsUWork.LogicalDeleteCode;
            apJoinPartsUWork.JoinDispOrder = joinPartsUWork.JoinDispOrder;
            apJoinPartsUWork.JoinSourceMakerCode = joinPartsUWork.JoinSourceMakerCode;
            apJoinPartsUWork.JoinSourPartsNoWithH = joinPartsUWork.JoinSourPartsNoWithH;
            apJoinPartsUWork.JoinSourPartsNoNoneH = joinPartsUWork.JoinSourPartsNoNoneH;
            apJoinPartsUWork.JoinDestMakerCd = joinPartsUWork.JoinDestMakerCd;
            apJoinPartsUWork.JoinDestPartsNo = joinPartsUWork.JoinDestPartsNo;
            apJoinPartsUWork.JoinQty = joinPartsUWork.JoinQty;
            apJoinPartsUWork.JoinSpecialNote = joinPartsUWork.JoinSpecialNote;

            return apJoinPartsUWork;
        }

        /// <summary>
        /// TBO�����i���[�U�[�o�^�j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="tBOSearchUWork">DCTBO�����i���[�U�[�o�^�j�f�[�^</param>
        /// <returns>APTBO�����i���[�U�[�o�^�j�f�[�^</returns>
        public static APTBOSearchUWork SearchDataFromUpdateData(DCTBOSearchUWork tBOSearchUWork)
        {
            if (tBOSearchUWork == null)
            {
                return null;
            }

            APTBOSearchUWork apTBOSearchUWork = new APTBOSearchUWork();

            // TBO�����i���[�U�[�o�^�j�f�[�^�ϊ�
            apTBOSearchUWork.CreateDateTime = tBOSearchUWork.CreateDateTime;
            apTBOSearchUWork.UpdateDateTime = tBOSearchUWork.UpdateDateTime;
            apTBOSearchUWork.EnterpriseCode = tBOSearchUWork.EnterpriseCode;
            apTBOSearchUWork.FileHeaderGuid = tBOSearchUWork.FileHeaderGuid;
            apTBOSearchUWork.UpdEmployeeCode = tBOSearchUWork.UpdEmployeeCode;
            apTBOSearchUWork.UpdAssemblyId1 = tBOSearchUWork.UpdAssemblyId1;
            apTBOSearchUWork.UpdAssemblyId2 = tBOSearchUWork.UpdAssemblyId2;
            apTBOSearchUWork.LogicalDeleteCode = tBOSearchUWork.LogicalDeleteCode;
            apTBOSearchUWork.BLGoodsCode = tBOSearchUWork.BLGoodsCode;
            apTBOSearchUWork.EquipGenreCode = tBOSearchUWork.EquipGenreCode;
            apTBOSearchUWork.EquipName = tBOSearchUWork.EquipName;
            apTBOSearchUWork.CarInfoJoinDispOrder = tBOSearchUWork.CarInfoJoinDispOrder;
            apTBOSearchUWork.JoinDestMakerCd = tBOSearchUWork.JoinDestMakerCd;
            apTBOSearchUWork.JoinDestPartsNo = tBOSearchUWork.JoinDestPartsNo;
            apTBOSearchUWork.JoinQty = tBOSearchUWork.JoinQty;
            apTBOSearchUWork.EquipSpecialNote = tBOSearchUWork.EquipSpecialNote;

            return apTBOSearchUWork;
        }

        /// <summary>
        /// ���ʃR�[�h�i���[�U�[�o�^�j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="partsPosCodeUWork">DC���ʃR�[�h�i���[�U�[�o�^�j�f�[�^</param>
        /// <returns>AP���ʃR�[�h�i���[�U�[�o�^�j�f�[�^</returns>
        public static APPartsPosCodeUWork SearchDataFromUpdateData(DCPartsPosCodeUWork partsPosCodeUWork)
        {
            if (partsPosCodeUWork == null)
            {
                return null;
            }

            APPartsPosCodeUWork apPartsPosCodeUWork = new APPartsPosCodeUWork();

            // ���ʃR�[�h�i���[�U�[�o�^�j�f�[�^�ϊ�
            apPartsPosCodeUWork.CreateDateTime = partsPosCodeUWork.CreateDateTime;
            apPartsPosCodeUWork.UpdateDateTime = partsPosCodeUWork.UpdateDateTime;
            apPartsPosCodeUWork.EnterpriseCode = partsPosCodeUWork.EnterpriseCode;
            apPartsPosCodeUWork.FileHeaderGuid = partsPosCodeUWork.FileHeaderGuid;
            apPartsPosCodeUWork.UpdEmployeeCode = partsPosCodeUWork.UpdEmployeeCode;
            apPartsPosCodeUWork.UpdAssemblyId1 = partsPosCodeUWork.UpdAssemblyId1;
            apPartsPosCodeUWork.UpdAssemblyId2 = partsPosCodeUWork.UpdAssemblyId2;
            apPartsPosCodeUWork.LogicalDeleteCode = partsPosCodeUWork.LogicalDeleteCode;
            apPartsPosCodeUWork.SectionCode = partsPosCodeUWork.SectionCode;
            apPartsPosCodeUWork.CustomerCode = partsPosCodeUWork.CustomerCode;
            apPartsPosCodeUWork.SearchPartsPosCode = partsPosCodeUWork.SearchPartsPosCode;
            apPartsPosCodeUWork.SearchPartsPosName = partsPosCodeUWork.SearchPartsPosName;
            apPartsPosCodeUWork.PosDispOrder = partsPosCodeUWork.PosDispOrder;
            apPartsPosCodeUWork.TbsPartsCode = partsPosCodeUWork.TbsPartsCode;
            apPartsPosCodeUWork.TbsPartsCdDerivedNo = partsPosCodeUWork.TbsPartsCdDerivedNo;
            // ADD 2009/06/09 ------>>>
            apPartsPosCodeUWork.OfferDate = partsPosCodeUWork.OfferDate;
            apPartsPosCodeUWork.OfferDataDiv = partsPosCodeUWork.OfferDataDiv;
            // ADD 2009/06/09 ------<<<

            return apPartsPosCodeUWork;
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="bLCodeGuideWork">DCBL�R�[�h�K�C�h�f�[�^</param>
        /// <returns>APBL�R�[�h�K�C�h�f�[�^</returns>
        public static APBLCodeGuideWork SearchDataFromUpdateData(DCBLCodeGuideWork bLCodeGuideWork)
        {
            if (bLCodeGuideWork == null)
            {
                return null;
            }

            APBLCodeGuideWork apBLCodeGuideWork = new APBLCodeGuideWork();

            // BL�R�[�h�K�C�h�f�[�^�ϊ�
            apBLCodeGuideWork.CreateDateTime = bLCodeGuideWork.CreateDateTime;
            apBLCodeGuideWork.UpdateDateTime = bLCodeGuideWork.UpdateDateTime;
            apBLCodeGuideWork.EnterpriseCode = bLCodeGuideWork.EnterpriseCode;
            apBLCodeGuideWork.FileHeaderGuid = bLCodeGuideWork.FileHeaderGuid;
            apBLCodeGuideWork.UpdEmployeeCode = bLCodeGuideWork.UpdEmployeeCode;
            apBLCodeGuideWork.UpdAssemblyId1 = bLCodeGuideWork.UpdAssemblyId1;
            apBLCodeGuideWork.UpdAssemblyId2 = bLCodeGuideWork.UpdAssemblyId2;
            apBLCodeGuideWork.LogicalDeleteCode = bLCodeGuideWork.LogicalDeleteCode;
            apBLCodeGuideWork.SectionCode = bLCodeGuideWork.SectionCode;
            apBLCodeGuideWork.BLCodeDspPage = bLCodeGuideWork.BLCodeDspPage;
            apBLCodeGuideWork.BLCodeDspRow = bLCodeGuideWork.BLCodeDspRow;
            apBLCodeGuideWork.BLCodeDspCol = bLCodeGuideWork.BLCodeDspCol;
            apBLCodeGuideWork.BLGoodsCode = bLCodeGuideWork.BLGoodsCode;
            apBLCodeGuideWork.BLGoodsName = bLCodeGuideWork.BLGoodsName;

            return apBLCodeGuideWork;
        }

        /// <summary>
        /// �Ԏ햼�́i���[�U�[�o�^�j�f�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="modelNameUWork">DC�Ԏ햼�́i���[�U�[�o�^�j�f�[�^</param>
        /// <returns>AP�Ԏ햼�́i���[�U�[�o�^�j�f�[�^</returns>
        public static APModelNameUWork SearchDataFromUpdateData(DCModelNameUWork modelNameUWork)
        {
            if (modelNameUWork == null)
            {
                return null;
            }

            APModelNameUWork apModelNameUWork = new APModelNameUWork();

            // �Ԏ햼�́i���[�U�[�o�^�j�f�[�^�ϊ�
            apModelNameUWork.CreateDateTime = modelNameUWork.CreateDateTime;
            apModelNameUWork.UpdateDateTime = modelNameUWork.UpdateDateTime;
            apModelNameUWork.EnterpriseCode = modelNameUWork.EnterpriseCode;
            apModelNameUWork.FileHeaderGuid = modelNameUWork.FileHeaderGuid;
            apModelNameUWork.UpdEmployeeCode = modelNameUWork.UpdEmployeeCode;
            apModelNameUWork.UpdAssemblyId1 = modelNameUWork.UpdAssemblyId1;
            apModelNameUWork.UpdAssemblyId2 = modelNameUWork.UpdAssemblyId2;
            apModelNameUWork.LogicalDeleteCode = modelNameUWork.LogicalDeleteCode;
            apModelNameUWork.ModelUniqueCode = modelNameUWork.ModelUniqueCode;
            apModelNameUWork.MakerCode = modelNameUWork.MakerCode;
            apModelNameUWork.ModelCode = modelNameUWork.ModelCode;
            apModelNameUWork.ModelSubCode = modelNameUWork.ModelSubCode;
            apModelNameUWork.ModelFullName = modelNameUWork.ModelFullName;
            apModelNameUWork.ModelHalfName = modelNameUWork.ModelHalfName;
            apModelNameUWork.ModelAliasName = modelNameUWork.ModelAliasName;
            apModelNameUWork.OfferDate = modelNameUWork.OfferDate;
            apModelNameUWork.OfferDataDiv = modelNameUWork.OfferDataDiv;

            return apModelNameUWork;
        }
    }
}
