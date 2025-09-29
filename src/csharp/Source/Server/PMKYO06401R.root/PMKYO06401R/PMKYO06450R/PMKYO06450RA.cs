//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : 杍^
// �C �� ��  2009/05/25  �C�����e : ���Ӑ�}�X�^TBL���C�A�E�g�ύX�ɂ��C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ����
// �C �� ��  2009/06/12  �C�����e : public Method��SQL�������ʖڑΉ��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ��� �r��
// �C �� ��  2010/01/21  �C�����e : �������^�C�v���̏o�͋敪�ǉ��i�R���ځj
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/07/26  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : �g���Y
// �C �� ��  2011/08/20  �C�����e : myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/08/25  �C�����e : #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/09/08  �C�����e : #23777 �\�[�X���r���[
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770021-00 �쐬�S�� : ���O
// �� �� ��  2021/04/12  �C�����e : ���Ӑ惁�����̒ǉ�
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�}�X�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: 2021/04/12 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
    /// </remarks>
    [Serializable]
    public class DCCustomerDB : RemoteDB
    {
        #region [Private]
        //ADD 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�---->>>>>
        //���Ӑ�}�X�^
        private int _indexACreateDateTime;
        private int _indexAUpdateDateTime;
        private int _indexAEnterpriseCode;
        private int _indexAFileHeaderGuid;
        private int _indexAUpdEmployeeCode;
        private int _indexAUpdAssemblyId1;
        private int _indexAUpdAssemblyId2;
        private int _indexALogicalDeleteCode;
        private int _indexACustomerCode;
        private int _indexACustomerSubCode;
        private int _indexAName;
        private int _indexAName2;
        private int _indexAHonorificTitle;
        private int _indexAKana;
        private int _indexACustomerSnm;
        private int _indexAOutputNameCode;
        private int _indexAOutputName;
        private int _indexACorporateDivCode;
        private int _indexACustomerAttributeDiv;
        private int _indexAJobTypeCode;
        private int _indexABusinessTypeCode;
        private int _indexASalesAreaCode;
        private int _indexAPostNo;
        private int _indexAAddress1;
        private int _indexAAddress3;
        private int _indexAAddress4;
        private int _indexAHomeTelNo;
        private int _indexAOfficeTelNo;
        private int _indexAPortableTelNo;
        private int _indexAHomeFaxNo;
        private int _indexAOfficeFaxNo;
        private int _indexAOthersTelNo;
        private int _indexAMainContactCode;
        private int _indexASearchTelNo;
        private int _indexAMngSectionCode;
        private int _indexAInpSectionCode;
        private int _indexACustAnalysCode1;
        private int _indexACustAnalysCode2;
        private int _indexACustAnalysCode3;
        private int _indexACustAnalysCode4;
        private int _indexACustAnalysCode5;
        private int _indexACustAnalysCode6;
        private int _indexABillOutputCode;
        private int _indexABillOutputName;
        private int _indexATotalDay;
        private int _indexACollectMoneyCode;
        private int _indexACollectMoneyName;
        private int _indexACollectMoneyDay;
        private int _indexACollectCond;
        private int _indexACollectSight;
        private int _indexAClaimCode;
        private int _indexATransStopDate;
        private int _indexADmOutCode;
        private int _indexADmOutName;
        private int _indexAMainSendMailAddrCd;
        private int _indexAMailAddrKindCode1;
        private int _indexAMailAddrKindName1;
        private int _indexAMailAddress1;
        private int _indexAMailSendCode1;
        private int _indexAMailSendName1;
        private int _indexAMailAddrKindCode2;
        private int _indexAMailAddrKindName2;
        private int _indexAMailAddress2;
        private int _indexAMailSendCode2;
        private int _indexAMailSendName2;
        private int _indexACustomerAgentCd;
        private int _indexABillCollecterCd;
        private int _indexAOldCustomerAgentCd;
        private int _indexACustAgentChgDate;
        private int _indexAAcceptWholeSale;
        private int _indexACreditMngCode;
        private int _indexADepoDelCode;
        private int _indexAAccRecDivCd;
        private int _indexACustSlipNoMngCd;
        private int _indexAPureCode;
        private int _indexACustCTaXLayRefCd;
        private int _indexAConsTaxLayMethod;
        private int _indexATotalAmountDispWayCd;
        private int _indexATotalAmntDspWayRef;
        private int _indexAAccountNoInfo1;
        private int _indexAAccountNoInfo2;
        private int _indexAAccountNoInfo3;
        private int _indexASalesUnPrcFrcProcCd;
        private int _indexASalesMoneyFrcProcCd;
        private int _indexASalesCnsTaxFrcProcCd;
        private int _indexACustomerSlipNoDiv;
        private int _indexANTimeCalcStDate;
        private int _indexACustomerAgent;
        private int _indexAClaimSectionCode;
        private int _indexACarMngDivCd;
        private int _indexABillPartsNoPrtCd;
        private int _indexADeliPartsNoPrtCd;
        private int _indexADefSalesSlipCd;
        private int _indexALavorRateRank;
        private int _indexASlipTtlPrn;
        private int _indexADepoBankCode;
        private int _indexACustWarehouseCd;
        private int _indexAQrcodePrtCd;
        private int _indexADeliHonorificTtl;
        private int _indexABillHonorificTtl;
        private int _indexAEstmHonorificTtl;
        private int _indexARectHonorificTtl;
        private int _indexADeliHonorTtlPrtDiv;
        private int _indexABillHonorTtlPrtDiv;
        private int _indexAEstmHonorTtlPrtDiv;
        private int _indexARectHonorTtlPrtDiv;
        private int _indexANote1;
        private int _indexANote2;
        private int _indexANote3;
        private int _indexANote4;
        private int _indexANote5;
        private int _indexANote6;
        private int _indexANote7;
        private int _indexANote8;
        private int _indexANote9;
        private int _indexANote10;
        private int _indexASalesSlipPrtDiv;
        private int _indexAShipmSlipPrtDiv;
        private int _indexAAcpOdrrSlipPrtDiv;
        private int _indexAEstimatePrtDiv;
        private int _indexAUOESlipPrtDiv;
        private int _indexAReceiptOutputCode;
        private int _indexACustomerEpCode;
        private int _indexACustomerSecCode;
        private int _indexAOnlineKindDiv;
        private int�@_indexATotalBillOutPutDiv;// ���v�������o�͋敪
        private int _indexADetailBillOutputCode;
        private int _indexASlipTtlBillOutputDiv;

        // ���Ӑ�}�X�^�i�|���O���[�v�j
        private int _indexBCreateDateTime;
        private int _indexBUpdateDateTime;
        private int _indexBEnterpriseCode;
        private int _indexBFileHeaderGuid;
        private int _indexBUpdEmployeeCode;
        private int _indexBUpdAssemblyId1;
        private int _indexBUpdAssemblyId2;
        private int _indexBLogicalDeleteCode;
        private int _indexBCustomerCode;
        private int _indexBPureCode;
        private int _indexBGoodsMakerCd;
        private int _indexBCustRateGrpCode;

        // ���Ӑ�}�X�^(�ϓ����)
        private int _indexCCreateDateTime;
        private int _indexCUpdateDateTime;
        private int _indexCEnterpriseCode;
        private int _indexCFileHeaderGuid;
        private int _indexCUpdEmployeeCode;
        private int _indexCUpdAssemblyId1;
        private int _indexCUpdAssemblyId2;
        private int _indexCLogicalDeleteCode;
        private int _indexCCustomerCode;
        private int _indexCCreditMoney;
        private int _indexCWarningCreditMoney;
        private int _indexCPrsntAccRecBalance;

        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
        // ���Ӑ�}�X�^(�������)
        private int _indexFCreateDateTime;
        private int _indexFUpdateDateTime;
        private int _indexFEnterpriseCode;
        private int _indexFFileHeaderGuid;
        private int _indexFUpdEmployeeCode;
        private int _indexFUpdAssemblyId1;
        private int _indexFUpdAssemblyId2;
        private int _indexFLogicalDeleteCode;
        private int _indexFCustomerCode;
        private int _indexFNoteInfo;
        private int _indexFDisplayDivCode;
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<

        // ���Ӑ�}�X�^�i�`�[�Ǘ��j
        private int _indexDCreateDateTime;
        private int _indexDUpdateDateTime;
        private int _indexDEnterpriseCode;
        private int _indexDFileHeaderGuid;
        private int _indexDUpdEmployeeCode;
        private int _indexDUpdAssemblyId1;
        private int _indexDUpdAssemblyId2;
        private int _indexDLogicalDeleteCode;
        private int _indexDDataInputSystem;
        private int _indexDSlipPrtKind;
        private int _indexDSectionCode;
        private int _indexDCustomerCode;
        private int _indexDSlipPrtSetPaperId;

        // ���Ӑ�}�X�^(�`�[�ԍ�)
        private int _indexECreateDateTime;
        private int _indexEUpdateDateTime;
        private int _indexEEnterpriseCode;
        private int _indexEFileHeaderGuid;
        private int _indexEUpdEmployeeCode;
        private int _indexEUpdAssemblyId1;
        private int _indexEUpdAssemblyId2;
        private int _indexELogicalDeleteCode;
        private int _indexECustomerCode;
        private int _indexEAddUpYearMonth;
        private int _indexEPresentCustSlipNo;
        private int _indexEStartCustSlipNo;
        private int _indexEEndCustSlipNo;
        //ADD 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�----<<<<<
        #endregion
        /// <summary>
        /// ���Ӑ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCCustomerDB()
            : base("PMKYO06451D", "Broadleaf.Application.Remoting.ParamData.DCCustomerWork", "CUSTOMERRF")
        {

        }

        #region [Read]
        /// <summary>
        /// ���Ӑ�}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="customerArrList">���Ӑ�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchCustomer(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList customerArrList, out string retMessage)
        {
            return SearchCustomerProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                            sqlTransaction, out customerArrList, out retMessage);
        }
        /// <summary>
        /// ���Ӑ�}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="customerArrList">���Ӑ�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchCustomerProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList customerArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            customerArrList = new ArrayList();
            DCCustomerWork customerWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                
                // --- ADD  ���r��  ���r��  2010/01/21 ---------->>>>>
                //sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, CUSTOMERSUBCODERF, NAMERF, NAME2RF, HONORIFICTITLERF, KANARF, CUSTOMERSNMRF, OUTPUTNAMECODERF, OUTPUTNAMERF, CORPORATEDIVCODERF, CUSTOMERATTRIBUTEDIVRF, JOBTYPECODERF, BUSINESSTYPECODERF, SALESAREACODERF, POSTNORF, ADDRESS1RF, ADDRESS3RF, ADDRESS4RF, HOMETELNORF, OFFICETELNORF, PORTABLETELNORF, HOMEFAXNORF, OFFICEFAXNORF, OTHERSTELNORF, MAINCONTACTCODERF, SEARCHTELNORF, MNGSECTIONCODERF, INPSECTIONCODERF, CUSTANALYSCODE1RF, CUSTANALYSCODE2RF, CUSTANALYSCODE3RF, CUSTANALYSCODE4RF, CUSTANALYSCODE5RF, CUSTANALYSCODE6RF, BILLOUTPUTCODERF, BILLOUTPUTNAMERF, TOTALDAYRF, COLLECTMONEYCODERF, COLLECTMONEYNAMERF, COLLECTMONEYDAYRF, COLLECTCONDRF, COLLECTSIGHTRF, CLAIMCODERF, TRANSSTOPDATERF, DMOUTCODERF, DMOUTNAMERF, MAINSENDMAILADDRCDRF, MAILADDRKINDCODE1RF, MAILADDRKINDNAME1RF, MAILADDRESS1RF, MAILSENDCODE1RF, MAILSENDNAME1RF, MAILADDRKINDCODE2RF, MAILADDRKINDNAME2RF, MAILADDRESS2RF, MAILSENDCODE2RF, MAILSENDNAME2RF, CUSTOMERAGENTCDRF, BILLCOLLECTERCDRF, OLDCUSTOMERAGENTCDRF, CUSTAGENTCHGDATERF, ACCEPTWHOLESALERF, CREDITMNGCODERF, DEPODELCODERF, ACCRECDIVCDRF, CUSTSLIPNOMNGCDRF, PURECODERF, CUSTCTAXLAYREFCDRF, CONSTAXLAYMETHODRF, TOTALAMOUNTDISPWAYCDRF, TOTALAMNTDSPWAYREFRF, ACCOUNTNOINFO1RF, ACCOUNTNOINFO2RF, ACCOUNTNOINFO3RF, SALESUNPRCFRCPROCCDRF, SALESMONEYFRCPROCCDRF, SALESCNSTAXFRCPROCCDRF, CUSTOMERSLIPNODIVRF, NTIMECALCSTDATERF, CUSTOMERAGENTRF, CLAIMSECTIONCODERF, CARMNGDIVCDRF, BILLPARTSNOPRTCDRF, DELIPARTSNOPRTCDRF, DEFSALESSLIPCDRF, LAVORRATERANKRF, SLIPTTLPRNRF, DEPOBANKCODERF, CUSTWAREHOUSECDRF, QRCODEPRTCDRF, DELIHONORIFICTTLRF, BILLHONORIFICTTLRF, ESTMHONORIFICTTLRF, RECTHONORIFICTTLRF, DELIHONORTTLPRTDIVRF, BILLHONORTTLPRTDIVRF, ESTMHONORTTLPRTDIVRF, RECTHONORTTLPRTDIVRF, NOTE1RF, NOTE2RF, NOTE3RF, NOTE4RF, NOTE5RF, NOTE6RF, NOTE7RF, NOTE8RF, NOTE9RF, NOTE10RF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, ACPODRRSLIPPRTDIVRF, ESTIMATEPRTDIVRF, UOESLIPPRTDIVRF, RECEIPTOUTPUTCODERF, CUSTOMEREPCODERF, CUSTOMERSECCODERF, ONLINEKINDDIVRF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, CUSTOMERSUBCODERF, NAMERF, NAME2RF, HONORIFICTITLERF, KANARF, CUSTOMERSNMRF, OUTPUTNAMECODERF, OUTPUTNAMERF, CORPORATEDIVCODERF, CUSTOMERATTRIBUTEDIVRF, JOBTYPECODERF, BUSINESSTYPECODERF, SALESAREACODERF, POSTNORF, ADDRESS1RF, ADDRESS3RF, ADDRESS4RF, HOMETELNORF, OFFICETELNORF, PORTABLETELNORF, HOMEFAXNORF, OFFICEFAXNORF, OTHERSTELNORF, MAINCONTACTCODERF, SEARCHTELNORF, MNGSECTIONCODERF, INPSECTIONCODERF, CUSTANALYSCODE1RF, CUSTANALYSCODE2RF, CUSTANALYSCODE3RF, CUSTANALYSCODE4RF, CUSTANALYSCODE5RF, CUSTANALYSCODE6RF, BILLOUTPUTCODERF, BILLOUTPUTNAMERF, TOTALDAYRF, COLLECTMONEYCODERF, COLLECTMONEYNAMERF, COLLECTMONEYDAYRF, COLLECTCONDRF, COLLECTSIGHTRF, CLAIMCODERF, TRANSSTOPDATERF, DMOUTCODERF, DMOUTNAMERF, MAINSENDMAILADDRCDRF, MAILADDRKINDCODE1RF, MAILADDRKINDNAME1RF, MAILADDRESS1RF, MAILSENDCODE1RF, MAILSENDNAME1RF, MAILADDRKINDCODE2RF, MAILADDRKINDNAME2RF, MAILADDRESS2RF, MAILSENDCODE2RF, MAILSENDNAME2RF, CUSTOMERAGENTCDRF, BILLCOLLECTERCDRF, OLDCUSTOMERAGENTCDRF, CUSTAGENTCHGDATERF, ACCEPTWHOLESALERF, CREDITMNGCODERF, DEPODELCODERF, ACCRECDIVCDRF, CUSTSLIPNOMNGCDRF, PURECODERF, CUSTCTAXLAYREFCDRF, CONSTAXLAYMETHODRF, TOTALAMOUNTDISPWAYCDRF, TOTALAMNTDSPWAYREFRF, ACCOUNTNOINFO1RF, ACCOUNTNOINFO2RF, ACCOUNTNOINFO3RF, SALESUNPRCFRCPROCCDRF, SALESMONEYFRCPROCCDRF, SALESCNSTAXFRCPROCCDRF, CUSTOMERSLIPNODIVRF, NTIMECALCSTDATERF, CUSTOMERAGENTRF, CLAIMSECTIONCODERF, CARMNGDIVCDRF, BILLPARTSNOPRTCDRF, DELIPARTSNOPRTCDRF, DEFSALESSLIPCDRF, LAVORRATERANKRF, SLIPTTLPRNRF, DEPOBANKCODERF, CUSTWAREHOUSECDRF, QRCODEPRTCDRF, DELIHONORIFICTTLRF, BILLHONORIFICTTLRF, ESTMHONORIFICTTLRF, RECTHONORIFICTTLRF, DELIHONORTTLPRTDIVRF, BILLHONORTTLPRTDIVRF, ESTMHONORTTLPRTDIVRF, RECTHONORTTLPRTDIVRF, NOTE1RF, NOTE2RF, NOTE3RF, NOTE4RF, NOTE5RF, NOTE6RF, NOTE7RF, NOTE8RF, NOTE9RF, NOTE10RF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, ACPODRRSLIPPRTDIVRF, ESTIMATEPRTDIVRF, UOESLIPPRTDIVRF, RECEIPTOUTPUTCODERF, CUSTOMEREPCODERF, CUSTOMERSECCODERF, ONLINEKINDDIVRF, TOTALBILLOUTPUTDIVRF, DETAILBILLOUTPUTCODERF, SLIPTTLBILLOUTPUTDIVRF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                // --- ADD  ���r��  ���r��  2010/01/21 ----------<<<<<

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //���Ӑ�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    customerWork = new DCCustomerWork();

                    customerWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    customerWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    customerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    customerWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    customerWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    customerWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    customerWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    customerWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    customerWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
                    customerWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    customerWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                    customerWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                    customerWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                    customerWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    customerWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                    customerWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
                    customerWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
                    customerWork.CustomerAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERATTRIBUTEDIVRF"));
                    customerWork.JobTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOBTYPECODERF"));
                    customerWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                    customerWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                    customerWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                    customerWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                    customerWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                    customerWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                    customerWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
                    customerWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
                    customerWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                    customerWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
                    customerWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
                    customerWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
                    customerWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
                    customerWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
                    customerWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                    customerWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
                    customerWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                    customerWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                    customerWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                    customerWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                    customerWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                    customerWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                    customerWork.BillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLOUTPUTCODERF"));
                    customerWork.BillOutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLOUTPUTNAMERF"));
                    customerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                    customerWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
                    customerWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
                    customerWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
                    customerWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
                    customerWork.CollectSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTSIGHTRF"));
                    customerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                    customerWork.TransStopDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TRANSSTOPDATERF"));
                    customerWork.DmOutCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTCODERF"));
                    customerWork.DmOutName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMOUTNAMERF"));
                    customerWork.MainSendMailAddrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINSENDMAILADDRCDRF"));
                    customerWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
                    customerWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
                    customerWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
                    customerWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
                    customerWork.MailSendName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME1RF"));
                    customerWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
                    customerWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
                    customerWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
                    customerWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));
                    customerWork.MailSendName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME2RF"));
                    customerWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                    customerWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
                    customerWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
                    customerWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF"));
                    customerWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
                    customerWork.CreditMngCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITMNGCODERF"));
                    customerWork.DepoDelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPODELCODERF"));
                    customerWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                    customerWork.CustSlipNoMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNOMNGCDRF"));
                    customerWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                    customerWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));
                    customerWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                    customerWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                    customerWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMNTDSPWAYREFRF"));
                    customerWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                    customerWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                    customerWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                    customerWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));
                    customerWork.SalesMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESMONEYFRCPROCCDRF"));
                    customerWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));
                    customerWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));
                    customerWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
                    customerWork.CustomerAgent = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTRF"));
                    customerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
                    customerWork.CarMngDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGDIVCDRF"));
                    customerWork.BillPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPARTSNOPRTCDRF"));
                    customerWork.DeliPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIPARTSNOPRTCDRF"));
                    customerWork.DefSalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSALESSLIPCDRF"));
                    customerWork.LavorRateRank = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAVORRATERANKRF"));
                    customerWork.SlipTtlPrn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLPRNRF"));
                    customerWork.DepoBankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOBANKCODERF"));
                    customerWork.CustWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSECDRF"));
                    customerWork.QrcodePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRTCDRF"));
                    customerWork.DeliHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORIFICTTLRF"));
                    customerWork.BillHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORIFICTTLRF"));
                    customerWork.EstmHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORIFICTTLRF"));
                    customerWork.RectHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORIFICTTLRF"));
                    customerWork.DeliHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIHONORTTLPRTDIVRF"));
                    customerWork.BillHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLHONORTTLPRTDIVRF"));
                    customerWork.EstmHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMHONORTTLPRTDIVRF"));
                    customerWork.RectHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECTHONORTTLPRTDIVRF"));
                    customerWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                    customerWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                    customerWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                    customerWork.Note4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
                    customerWork.Note5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
                    customerWork.Note6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
                    customerWork.Note7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
                    customerWork.Note8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
                    customerWork.Note9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
                    customerWork.Note10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
                    customerWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
                    customerWork.ShipmSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPPRTDIVRF"));
                    customerWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
                    customerWork.EstimatePrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));
                    customerWork.UOESlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESLIPPRTDIVRF"));
                    customerWork.ReceiptOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIPTOUTPUTCODERF"));
                    // ADD 2009/05/25 --->>>
                    customerWork.CustomerEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMEREPCODERF"));
                    customerWork.CustomerSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSECCODERF"));
                    customerWork.OnlineKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEKINDDIVRF"));
                    // ADD 2009/05/25 ---<<<
                    // --- ADD  ���r��  ���r��  2010/01/21 ---------->>>>>
                    customerWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));  // ���v�������o�͋敪
                    customerWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));  // ���א������o�͋敪
                    customerWork.SlipTtlBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLBILLOUTPUTDIVRF"));  // �`�[���v�������o�͋敪
                    // --- ADD  ���r��  ���r��  2010/01/21 ----------<<<<<
                    customerArrList.Add(customerWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCCustomerDB.SearchCustomer Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion

        # region [Delete]
        /// <summary>
        ///  ���Ӑ�}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcCustomerWork">���Ӑ�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCCustomerWork dcCustomerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcCustomerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  ���Ӑ�}�X�^�f�[�^�폜
        /// </summary>
        /// <param name="dcCustomerWork">���Ӑ�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCCustomerWork dcCustomerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = dcCustomerWork.EnterpriseCode;
            findParaCustomerCode.Value = dcCustomerWork.CustomerCode;


            // ���Ӑ�}�X�^�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// ���Ӑ�}�X�^�o�^
        /// </summary>
        /// <param name="dcCustomerWork">���Ӑ�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCCustomerWork dcCustomerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcCustomerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���Ӑ�}�X�^�o�^
        /// </summary>
        /// <param name="dcCustomerWork">���Ӑ�}�X�^�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���Ӑ�}�X�^�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCCustomerWork dcCustomerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Insert�R�}���h�̐���
            // --- ADD  ���r��  ���r��  2010/01/21 ---------->>>>>
            //sqlCommand.CommandText = "INSERT INTO CUSTOMERRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, CUSTOMERSUBCODERF, NAMERF, NAME2RF, HONORIFICTITLERF, KANARF, CUSTOMERSNMRF, OUTPUTNAMECODERF, OUTPUTNAMERF, CORPORATEDIVCODERF, CUSTOMERATTRIBUTEDIVRF, JOBTYPECODERF, BUSINESSTYPECODERF, SALESAREACODERF, POSTNORF, ADDRESS1RF, ADDRESS3RF, ADDRESS4RF, HOMETELNORF, OFFICETELNORF, PORTABLETELNORF, HOMEFAXNORF, OFFICEFAXNORF, OTHERSTELNORF, MAINCONTACTCODERF, SEARCHTELNORF, MNGSECTIONCODERF, INPSECTIONCODERF, CUSTANALYSCODE1RF, CUSTANALYSCODE2RF, CUSTANALYSCODE3RF, CUSTANALYSCODE4RF, CUSTANALYSCODE5RF, CUSTANALYSCODE6RF, BILLOUTPUTCODERF, BILLOUTPUTNAMERF, TOTALDAYRF, COLLECTMONEYCODERF, COLLECTMONEYNAMERF, COLLECTMONEYDAYRF, COLLECTCONDRF, COLLECTSIGHTRF, CLAIMCODERF, TRANSSTOPDATERF, DMOUTCODERF, DMOUTNAMERF, MAINSENDMAILADDRCDRF, MAILADDRKINDCODE1RF, MAILADDRKINDNAME1RF, MAILADDRESS1RF, MAILSENDCODE1RF, MAILSENDNAME1RF, MAILADDRKINDCODE2RF, MAILADDRKINDNAME2RF, MAILADDRESS2RF, MAILSENDCODE2RF, MAILSENDNAME2RF, CUSTOMERAGENTCDRF, BILLCOLLECTERCDRF, OLDCUSTOMERAGENTCDRF, CUSTAGENTCHGDATERF, ACCEPTWHOLESALERF, CREDITMNGCODERF, DEPODELCODERF, ACCRECDIVCDRF, CUSTSLIPNOMNGCDRF, PURECODERF, CUSTCTAXLAYREFCDRF, CONSTAXLAYMETHODRF, TOTALAMOUNTDISPWAYCDRF, TOTALAMNTDSPWAYREFRF, ACCOUNTNOINFO1RF, ACCOUNTNOINFO2RF, ACCOUNTNOINFO3RF, SALESUNPRCFRCPROCCDRF, SALESMONEYFRCPROCCDRF, SALESCNSTAXFRCPROCCDRF, CUSTOMERSLIPNODIVRF, NTIMECALCSTDATERF, CUSTOMERAGENTRF, CLAIMSECTIONCODERF, CARMNGDIVCDRF, BILLPARTSNOPRTCDRF, DELIPARTSNOPRTCDRF, DEFSALESSLIPCDRF, LAVORRATERANKRF, SLIPTTLPRNRF, DEPOBANKCODERF, CUSTWAREHOUSECDRF, QRCODEPRTCDRF, DELIHONORIFICTTLRF, BILLHONORIFICTTLRF, ESTMHONORIFICTTLRF, RECTHONORIFICTTLRF, DELIHONORTTLPRTDIVRF, BILLHONORTTLPRTDIVRF, ESTMHONORTTLPRTDIVRF, RECTHONORTTLPRTDIVRF, NOTE1RF, NOTE2RF, NOTE3RF, NOTE4RF, NOTE5RF, NOTE6RF, NOTE7RF, NOTE8RF, NOTE9RF, NOTE10RF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, ACPODRRSLIPPRTDIVRF, ESTIMATEPRTDIVRF, UOESLIPPRTDIVRF, RECEIPTOUTPUTCODERF, CUSTOMEREPCODERF, CUSTOMERSECCODERF, ONLINEKINDDIVRF ) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CUSTOMERCODE, @CUSTOMERSUBCODE, @NAME, @NAME2, @HONORIFICTITLE, @KANA, @CUSTOMERSNM, @OUTPUTNAMECODE, @OUTPUTNAME, @CORPORATEDIVCODE, @CUSTOMERATTRIBUTEDIV, @JOBTYPECODE, @BUSINESSTYPECODE, @SALESAREACODE, @POSTNO, @ADDRESS1, @ADDRESS3, @ADDRESS4, @HOMETELNO, @OFFICETELNO, @PORTABLETELNO, @HOMEFAXNO, @OFFICEFAXNO, @OTHERSTELNO, @MAINCONTACTCODE, @SEARCHTELNO, @MNGSECTIONCODE, @INPSECTIONCODE, @CUSTANALYSCODE1, @CUSTANALYSCODE2, @CUSTANALYSCODE3, @CUSTANALYSCODE4, @CUSTANALYSCODE5, @CUSTANALYSCODE6, @BILLOUTPUTCODE, @BILLOUTPUTNAME, @TOTALDAY, @COLLECTMONEYCODE, @COLLECTMONEYNAME, @COLLECTMONEYDAY, @COLLECTCOND, @COLLECTSIGHT, @CLAIMCODE, @TRANSSTOPDATE, @DMOUTCODE, @DMOUTNAME, @MAINSENDMAILADDRCD, @MAILADDRKINDCODE1, @MAILADDRKINDNAME1, @MAILADDRESS1, @MAILSENDCODE1, @MAILSENDNAME1, @MAILADDRKINDCODE2, @MAILADDRKINDNAME2, @MAILADDRESS2, @MAILSENDCODE2, @MAILSENDNAME2, @CUSTOMERAGENTCD, @BILLCOLLECTERCD, @OLDCUSTOMERAGENTCD, @CUSTAGENTCHGDATE, @ACCEPTWHOLESALE, @CREDITMNGCODE, @DEPODELCODE, @ACCRECDIVCD, @CUSTSLIPNOMNGCD, @PURECODE, @CUSTCTAXLAYREFCD, @CONSTAXLAYMETHOD, @TOTALAMOUNTDISPWAYCD, @TOTALAMNTDSPWAYREF, @ACCOUNTNOINFO1, @ACCOUNTNOINFO2, @ACCOUNTNOINFO3, @SALESUNPRCFRCPROCCD, @SALESMONEYFRCPROCCD, @SALESCNSTAXFRCPROCCD, @CUSTOMERSLIPNODIV, @NTIMECALCSTDATE, @CUSTOMERAGENT, @CLAIMSECTIONCODE, @CARMNGDIVCD, @BILLPARTSNOPRTCD, @DELIPARTSNOPRTCD, @DEFSALESSLIPCD, @LAVORRATERANK, @SLIPTTLPRN, @DEPOBANKCODE, @CUSTWAREHOUSECD, @QRCODEPRTCD, @DELIHONORIFICTTL, @BILLHONORIFICTTL, @ESTMHONORIFICTTL, @RECTHONORIFICTTL, @DELIHONORTTLPRTDIV, @BILLHONORTTLPRTDIV, @ESTMHONORTTLPRTDIV, @RECTHONORTTLPRTDIV, @NOTE1, @NOTE2, @NOTE3, @NOTE4, @NOTE5, @NOTE6, @NOTE7, @NOTE8, @NOTE9, @NOTE10, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @ACPODRRSLIPPRTDIV, @ESTIMATEPRTDIV, @UOESLIPPRTDIV, @RECEIPTOUTPUTCODE, @CUSTOMEREPCODE, @CUSTOMERSECCODE, @ONLINEKINDDIV )";
            sqlCommand.CommandText = "INSERT INTO CUSTOMERRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, CUSTOMERSUBCODERF, NAMERF, NAME2RF, HONORIFICTITLERF, KANARF, CUSTOMERSNMRF, OUTPUTNAMECODERF, OUTPUTNAMERF, CORPORATEDIVCODERF, CUSTOMERATTRIBUTEDIVRF, JOBTYPECODERF, BUSINESSTYPECODERF, SALESAREACODERF, POSTNORF, ADDRESS1RF, ADDRESS3RF, ADDRESS4RF, HOMETELNORF, OFFICETELNORF, PORTABLETELNORF, HOMEFAXNORF, OFFICEFAXNORF, OTHERSTELNORF, MAINCONTACTCODERF, SEARCHTELNORF, MNGSECTIONCODERF, INPSECTIONCODERF, CUSTANALYSCODE1RF, CUSTANALYSCODE2RF, CUSTANALYSCODE3RF, CUSTANALYSCODE4RF, CUSTANALYSCODE5RF, CUSTANALYSCODE6RF, BILLOUTPUTCODERF, BILLOUTPUTNAMERF, TOTALDAYRF, COLLECTMONEYCODERF, COLLECTMONEYNAMERF, COLLECTMONEYDAYRF, COLLECTCONDRF, COLLECTSIGHTRF, CLAIMCODERF, TRANSSTOPDATERF, DMOUTCODERF, DMOUTNAMERF, MAINSENDMAILADDRCDRF, MAILADDRKINDCODE1RF, MAILADDRKINDNAME1RF, MAILADDRESS1RF, MAILSENDCODE1RF, MAILSENDNAME1RF, MAILADDRKINDCODE2RF, MAILADDRKINDNAME2RF, MAILADDRESS2RF, MAILSENDCODE2RF, MAILSENDNAME2RF, CUSTOMERAGENTCDRF, BILLCOLLECTERCDRF, OLDCUSTOMERAGENTCDRF, CUSTAGENTCHGDATERF, ACCEPTWHOLESALERF, CREDITMNGCODERF, DEPODELCODERF, ACCRECDIVCDRF, CUSTSLIPNOMNGCDRF, PURECODERF, CUSTCTAXLAYREFCDRF, CONSTAXLAYMETHODRF, TOTALAMOUNTDISPWAYCDRF, TOTALAMNTDSPWAYREFRF, ACCOUNTNOINFO1RF, ACCOUNTNOINFO2RF, ACCOUNTNOINFO3RF, SALESUNPRCFRCPROCCDRF, SALESMONEYFRCPROCCDRF, SALESCNSTAXFRCPROCCDRF, CUSTOMERSLIPNODIVRF, NTIMECALCSTDATERF, CUSTOMERAGENTRF, CLAIMSECTIONCODERF, CARMNGDIVCDRF, BILLPARTSNOPRTCDRF, DELIPARTSNOPRTCDRF, DEFSALESSLIPCDRF, LAVORRATERANKRF, SLIPTTLPRNRF, DEPOBANKCODERF, CUSTWAREHOUSECDRF, QRCODEPRTCDRF, DELIHONORIFICTTLRF, BILLHONORIFICTTLRF, ESTMHONORIFICTTLRF, RECTHONORIFICTTLRF, DELIHONORTTLPRTDIVRF, BILLHONORTTLPRTDIVRF, ESTMHONORTTLPRTDIVRF, RECTHONORTTLPRTDIVRF, NOTE1RF, NOTE2RF, NOTE3RF, NOTE4RF, NOTE5RF, NOTE6RF, NOTE7RF, NOTE8RF, NOTE9RF, NOTE10RF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, ACPODRRSLIPPRTDIVRF, ESTIMATEPRTDIVRF, UOESLIPPRTDIVRF, RECEIPTOUTPUTCODERF, CUSTOMEREPCODERF, CUSTOMERSECCODERF, ONLINEKINDDIVRF, TOTALBILLOUTPUTDIVRF, DETAILBILLOUTPUTCODERF, SLIPTTLBILLOUTPUTDIVRF ) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CUSTOMERCODE, @CUSTOMERSUBCODE, @NAME, @NAME2, @HONORIFICTITLE, @KANA, @CUSTOMERSNM, @OUTPUTNAMECODE, @OUTPUTNAME, @CORPORATEDIVCODE, @CUSTOMERATTRIBUTEDIV, @JOBTYPECODE, @BUSINESSTYPECODE, @SALESAREACODE, @POSTNO, @ADDRESS1, @ADDRESS3, @ADDRESS4, @HOMETELNO, @OFFICETELNO, @PORTABLETELNO, @HOMEFAXNO, @OFFICEFAXNO, @OTHERSTELNO, @MAINCONTACTCODE, @SEARCHTELNO, @MNGSECTIONCODE, @INPSECTIONCODE, @CUSTANALYSCODE1, @CUSTANALYSCODE2, @CUSTANALYSCODE3, @CUSTANALYSCODE4, @CUSTANALYSCODE5, @CUSTANALYSCODE6, @BILLOUTPUTCODE, @BILLOUTPUTNAME, @TOTALDAY, @COLLECTMONEYCODE, @COLLECTMONEYNAME, @COLLECTMONEYDAY, @COLLECTCOND, @COLLECTSIGHT, @CLAIMCODE, @TRANSSTOPDATE, @DMOUTCODE, @DMOUTNAME, @MAINSENDMAILADDRCD, @MAILADDRKINDCODE1, @MAILADDRKINDNAME1, @MAILADDRESS1, @MAILSENDCODE1, @MAILSENDNAME1, @MAILADDRKINDCODE2, @MAILADDRKINDNAME2, @MAILADDRESS2, @MAILSENDCODE2, @MAILSENDNAME2, @CUSTOMERAGENTCD, @BILLCOLLECTERCD, @OLDCUSTOMERAGENTCD, @CUSTAGENTCHGDATE, @ACCEPTWHOLESALE, @CREDITMNGCODE, @DEPODELCODE, @ACCRECDIVCD, @CUSTSLIPNOMNGCD, @PURECODE, @CUSTCTAXLAYREFCD, @CONSTAXLAYMETHOD, @TOTALAMOUNTDISPWAYCD, @TOTALAMNTDSPWAYREF, @ACCOUNTNOINFO1, @ACCOUNTNOINFO2, @ACCOUNTNOINFO3, @SALESUNPRCFRCPROCCD, @SALESMONEYFRCPROCCD, @SALESCNSTAXFRCPROCCD, @CUSTOMERSLIPNODIV, @NTIMECALCSTDATE, @CUSTOMERAGENT, @CLAIMSECTIONCODE, @CARMNGDIVCD, @BILLPARTSNOPRTCD, @DELIPARTSNOPRTCD, @DEFSALESSLIPCD, @LAVORRATERANK, @SLIPTTLPRN, @DEPOBANKCODE, @CUSTWAREHOUSECD, @QRCODEPRTCD, @DELIHONORIFICTTL, @BILLHONORIFICTTL, @ESTMHONORIFICTTL, @RECTHONORIFICTTL, @DELIHONORTTLPRTDIV, @BILLHONORTTLPRTDIV, @ESTMHONORTTLPRTDIV, @RECTHONORTTLPRTDIV, @NOTE1, @NOTE2, @NOTE3, @NOTE4, @NOTE5, @NOTE6, @NOTE7, @NOTE8, @NOTE9, @NOTE10, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @ACPODRRSLIPPRTDIV, @ESTIMATEPRTDIV, @UOESLIPPRTDIV, @RECEIPTOUTPUTCODE, @CUSTOMEREPCODE, @CUSTOMERSECCODE, @ONLINEKINDDIV, @TOTALBILLOUTPUTDIV, @DETAILBILLOUTPUTCODE, @SLIPTTLBILLOUTPUTDIV )";
            // --- ADD  ���r��  ���r��  2010/01/21 ----------<<<<<

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            SqlParameter paraCustomerSubCode = sqlCommand.Parameters.Add("@CUSTOMERSUBCODE", SqlDbType.NVarChar);
            SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
            SqlParameter paraName2 = sqlCommand.Parameters.Add("@NAME2", SqlDbType.NVarChar);
            SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
            SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
            SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
            SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
            SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
            SqlParameter paraCorporateDivCode = sqlCommand.Parameters.Add("@CORPORATEDIVCODE", SqlDbType.Int);
            SqlParameter paraCustomerAttributeDiv = sqlCommand.Parameters.Add("@CUSTOMERATTRIBUTEDIV", SqlDbType.Int);
            SqlParameter paraJobTypeCode = sqlCommand.Parameters.Add("@JOBTYPECODE", SqlDbType.Int);
            SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
            SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
            SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
            SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
            SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
            SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
            SqlParameter paraHomeTelNo = sqlCommand.Parameters.Add("@HOMETELNO", SqlDbType.NVarChar);
            SqlParameter paraOfficeTelNo = sqlCommand.Parameters.Add("@OFFICETELNO", SqlDbType.NVarChar);
            SqlParameter paraPortableTelNo = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
            SqlParameter paraHomeFaxNo = sqlCommand.Parameters.Add("@HOMEFAXNO", SqlDbType.NVarChar);
            SqlParameter paraOfficeFaxNo = sqlCommand.Parameters.Add("@OFFICEFAXNO", SqlDbType.NVarChar);
            SqlParameter paraOthersTelNo = sqlCommand.Parameters.Add("@OTHERSTELNO", SqlDbType.NVarChar);
            SqlParameter paraMainContactCode = sqlCommand.Parameters.Add("@MAINCONTACTCODE", SqlDbType.Int);
            SqlParameter paraSearchTelNo = sqlCommand.Parameters.Add("@SEARCHTELNO", SqlDbType.NChar);
            SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
            SqlParameter paraInpSectionCode = sqlCommand.Parameters.Add("@INPSECTIONCODE", SqlDbType.NChar);
            SqlParameter paraCustAnalysCode1 = sqlCommand.Parameters.Add("@CUSTANALYSCODE1", SqlDbType.Int);
            SqlParameter paraCustAnalysCode2 = sqlCommand.Parameters.Add("@CUSTANALYSCODE2", SqlDbType.Int);
            SqlParameter paraCustAnalysCode3 = sqlCommand.Parameters.Add("@CUSTANALYSCODE3", SqlDbType.Int);
            SqlParameter paraCustAnalysCode4 = sqlCommand.Parameters.Add("@CUSTANALYSCODE4", SqlDbType.Int);
            SqlParameter paraCustAnalysCode5 = sqlCommand.Parameters.Add("@CUSTANALYSCODE5", SqlDbType.Int);
            SqlParameter paraCustAnalysCode6 = sqlCommand.Parameters.Add("@CUSTANALYSCODE6", SqlDbType.Int);
            SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@BILLOUTPUTCODE", SqlDbType.Int);
            SqlParameter paraBillOutputName = sqlCommand.Parameters.Add("@BILLOUTPUTNAME", SqlDbType.NVarChar);
            SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
            SqlParameter paraCollectMoneyCode = sqlCommand.Parameters.Add("@COLLECTMONEYCODE", SqlDbType.Int);
            SqlParameter paraCollectMoneyName = sqlCommand.Parameters.Add("@COLLECTMONEYNAME", SqlDbType.NVarChar);
            SqlParameter paraCollectMoneyDay = sqlCommand.Parameters.Add("@COLLECTMONEYDAY", SqlDbType.Int);
            SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
            SqlParameter paraCollectSight = sqlCommand.Parameters.Add("@COLLECTSIGHT", SqlDbType.Int);
            SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
            SqlParameter paraTransStopDate = sqlCommand.Parameters.Add("@TRANSSTOPDATE", SqlDbType.Int);
            SqlParameter paraDmOutCode = sqlCommand.Parameters.Add("@DMOUTCODE", SqlDbType.Int);
            SqlParameter paraDmOutName = sqlCommand.Parameters.Add("@DMOUTNAME", SqlDbType.NVarChar);
            SqlParameter paraMainSendMailAddrCd = sqlCommand.Parameters.Add("@MAINSENDMAILADDRCD", SqlDbType.Int);
            SqlParameter paraMailAddrKindCode1 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE1", SqlDbType.Int);
            SqlParameter paraMailAddrKindName1 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME1", SqlDbType.NVarChar);
            SqlParameter paraMailAddress1 = sqlCommand.Parameters.Add("@MAILADDRESS1", SqlDbType.NVarChar);
            SqlParameter paraMailSendCode1 = sqlCommand.Parameters.Add("@MAILSENDCODE1", SqlDbType.Int);
            SqlParameter paraMailSendName1 = sqlCommand.Parameters.Add("@MAILSENDNAME1", SqlDbType.NVarChar);
            SqlParameter paraMailAddrKindCode2 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE2", SqlDbType.Int);
            SqlParameter paraMailAddrKindName2 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME2", SqlDbType.NVarChar);
            SqlParameter paraMailAddress2 = sqlCommand.Parameters.Add("@MAILADDRESS2", SqlDbType.NVarChar);
            SqlParameter paraMailSendCode2 = sqlCommand.Parameters.Add("@MAILSENDCODE2", SqlDbType.Int);
            SqlParameter paraMailSendName2 = sqlCommand.Parameters.Add("@MAILSENDNAME2", SqlDbType.NVarChar);
            SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);
            SqlParameter paraBillCollecterCd = sqlCommand.Parameters.Add("@BILLCOLLECTERCD", SqlDbType.NChar);
            SqlParameter paraOldCustomerAgentCd = sqlCommand.Parameters.Add("@OLDCUSTOMERAGENTCD", SqlDbType.NChar);
            SqlParameter paraCustAgentChgDate = sqlCommand.Parameters.Add("@CUSTAGENTCHGDATE", SqlDbType.Int);
            SqlParameter paraAcceptWholeSale = sqlCommand.Parameters.Add("@ACCEPTWHOLESALE", SqlDbType.Int);
            SqlParameter paraCreditMngCode = sqlCommand.Parameters.Add("@CREDITMNGCODE", SqlDbType.Int);
            SqlParameter paraDepoDelCode = sqlCommand.Parameters.Add("@DEPODELCODE", SqlDbType.Int);
            SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
            SqlParameter paraCustSlipNoMngCd = sqlCommand.Parameters.Add("@CUSTSLIPNOMNGCD", SqlDbType.Int);
            SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
            SqlParameter paraCustCTaXLayRefCd = sqlCommand.Parameters.Add("@CUSTCTAXLAYREFCD", SqlDbType.Int);
            SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
            SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
            SqlParameter paraTotalAmntDspWayRef = sqlCommand.Parameters.Add("@TOTALAMNTDSPWAYREF", SqlDbType.Int);
            SqlParameter paraAccountNoInfo1 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO1", SqlDbType.NVarChar);
            SqlParameter paraAccountNoInfo2 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO2", SqlDbType.NVarChar);
            SqlParameter paraAccountNoInfo3 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO3", SqlDbType.NVarChar);
            SqlParameter paraSalesUnPrcFrcProcCd = sqlCommand.Parameters.Add("@SALESUNPRCFRCPROCCD", SqlDbType.Int);
            SqlParameter paraSalesMoneyFrcProcCd = sqlCommand.Parameters.Add("@SALESMONEYFRCPROCCD", SqlDbType.Int);
            SqlParameter paraSalesCnsTaxFrcProcCd = sqlCommand.Parameters.Add("@SALESCNSTAXFRCPROCCD", SqlDbType.Int);
            SqlParameter paraCustomerSlipNoDiv = sqlCommand.Parameters.Add("@CUSTOMERSLIPNODIV", SqlDbType.Int);
            SqlParameter paraNTimeCalcStDate = sqlCommand.Parameters.Add("@NTIMECALCSTDATE", SqlDbType.Int);
            SqlParameter paraCustomerAgent = sqlCommand.Parameters.Add("@CUSTOMERAGENT", SqlDbType.NVarChar);
            SqlParameter paraClaimSectionCode = sqlCommand.Parameters.Add("@CLAIMSECTIONCODE", SqlDbType.NChar);
            SqlParameter paraCarMngDivCd = sqlCommand.Parameters.Add("@CARMNGDIVCD", SqlDbType.Int);
            SqlParameter paraBillPartsNoPrtCd = sqlCommand.Parameters.Add("@BILLPARTSNOPRTCD", SqlDbType.Int);
            SqlParameter paraDeliPartsNoPrtCd = sqlCommand.Parameters.Add("@DELIPARTSNOPRTCD", SqlDbType.Int);
            SqlParameter paraDefSalesSlipCd = sqlCommand.Parameters.Add("@DEFSALESSLIPCD", SqlDbType.Int);
            SqlParameter paraLavorRateRank = sqlCommand.Parameters.Add("@LAVORRATERANK", SqlDbType.Int);
            SqlParameter paraSlipTtlPrn = sqlCommand.Parameters.Add("@SLIPTTLPRN", SqlDbType.Int);
            SqlParameter paraDepoBankCode = sqlCommand.Parameters.Add("@DEPOBANKCODE", SqlDbType.Int);
            SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.NChar);
            SqlParameter paraQrcodePrtCd = sqlCommand.Parameters.Add("@QRCODEPRTCD", SqlDbType.Int);
            SqlParameter paraDeliHonorificTtl = sqlCommand.Parameters.Add("@DELIHONORIFICTTL", SqlDbType.NVarChar);
            SqlParameter paraBillHonorificTtl = sqlCommand.Parameters.Add("@BILLHONORIFICTTL", SqlDbType.NVarChar);
            SqlParameter paraEstmHonorificTtl = sqlCommand.Parameters.Add("@ESTMHONORIFICTTL", SqlDbType.NVarChar);
            SqlParameter paraRectHonorificTtl = sqlCommand.Parameters.Add("@RECTHONORIFICTTL", SqlDbType.NVarChar);
            SqlParameter paraDeliHonorTtlPrtDiv = sqlCommand.Parameters.Add("@DELIHONORTTLPRTDIV", SqlDbType.Int);
            SqlParameter paraBillHonorTtlPrtDiv = sqlCommand.Parameters.Add("@BILLHONORTTLPRTDIV", SqlDbType.Int);
            SqlParameter paraEstmHonorTtlPrtDiv = sqlCommand.Parameters.Add("@ESTMHONORTTLPRTDIV", SqlDbType.Int);
            SqlParameter paraRectHonorTtlPrtDiv = sqlCommand.Parameters.Add("@RECTHONORTTLPRTDIV", SqlDbType.Int);
            SqlParameter paraNote1 = sqlCommand.Parameters.Add("@NOTE1", SqlDbType.NVarChar);
            SqlParameter paraNote2 = sqlCommand.Parameters.Add("@NOTE2", SqlDbType.NVarChar);
            SqlParameter paraNote3 = sqlCommand.Parameters.Add("@NOTE3", SqlDbType.NVarChar);
            SqlParameter paraNote4 = sqlCommand.Parameters.Add("@NOTE4", SqlDbType.NVarChar);
            SqlParameter paraNote5 = sqlCommand.Parameters.Add("@NOTE5", SqlDbType.NVarChar);
            SqlParameter paraNote6 = sqlCommand.Parameters.Add("@NOTE6", SqlDbType.NVarChar);
            SqlParameter paraNote7 = sqlCommand.Parameters.Add("@NOTE7", SqlDbType.NVarChar);
            SqlParameter paraNote8 = sqlCommand.Parameters.Add("@NOTE8", SqlDbType.NVarChar);
            SqlParameter paraNote9 = sqlCommand.Parameters.Add("@NOTE9", SqlDbType.NVarChar);
            SqlParameter paraNote10 = sqlCommand.Parameters.Add("@NOTE10", SqlDbType.NVarChar);
            SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);
            SqlParameter paraShipmSlipPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPPRTDIV", SqlDbType.Int);
            SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);
            SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);
            SqlParameter paraUOESlipPrtDiv = sqlCommand.Parameters.Add("@UOESLIPPRTDIV", SqlDbType.Int);
            SqlParameter paraReceiptOutputCode = sqlCommand.Parameters.Add("@RECEIPTOUTPUTCODE", SqlDbType.Int);
            // ADD 2009/05/25 --->>>
            SqlParameter paraCustomerEpCode = sqlCommand.Parameters.Add("@CUSTOMEREPCODE", SqlDbType.NChar);
            SqlParameter paraCustomerSecCode = sqlCommand.Parameters.Add("@CUSTOMERSECCODE", SqlDbType.NChar);
            SqlParameter paraOnlineKindDiv = sqlCommand.Parameters.Add("@ONLINEKINDDIV", SqlDbType.Int);
            // ADD 2009/05/25 ---<<<
            // --- ADD  ���r��  ���r��  2010/01/21 ---------->>>>>
            SqlParameter paraTotalBillOutputDiv = sqlCommand.Parameters.Add("@TOTALBILLOUTPUTDIV", SqlDbType.Int);  // ���v�������o�͋敪
            SqlParameter paraDetailBillOutputCode = sqlCommand.Parameters.Add("@DETAILBILLOUTPUTCODE", SqlDbType.Int);  // ���א������o�͋敪
            SqlParameter paraSlipTtlBillOutputDiv = sqlCommand.Parameters.Add("@SLIPTTLBILLOUTPUTDIV", SqlDbType.Int);  // �`�[���v�������o�͋敪
            // --- ADD  ���r��  ���r��  2010/01/21 ----------<<<<<

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcCustomerWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcCustomerWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcCustomerWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcCustomerWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcCustomerWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcCustomerWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcCustomerWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.LogicalDeleteCode);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CustomerCode);
            paraCustomerSubCode.Value = SqlDataMediator.SqlSetString(dcCustomerWork.CustomerSubCode);
            paraName.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Name);
            paraName2.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Name2);
            paraHonorificTitle.Value = SqlDataMediator.SqlSetString(dcCustomerWork.HonorificTitle);
            paraKana.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Kana);
            paraCustomerSnm.Value = SqlDataMediator.SqlSetString(dcCustomerWork.CustomerSnm);
            paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.OutputNameCode);
            paraOutputName.Value = SqlDataMediator.SqlSetString(dcCustomerWork.OutputName);
            paraCorporateDivCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CorporateDivCode);
            paraCustomerAttributeDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CustomerAttributeDiv);
            paraJobTypeCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.JobTypeCode);
            paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.BusinessTypeCode);
            paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.SalesAreaCode);
            paraPostNo.Value = SqlDataMediator.SqlSetString(dcCustomerWork.PostNo);
            paraAddress1.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Address1);
            paraAddress3.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Address3);
            paraAddress4.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Address4);
            paraHomeTelNo.Value = SqlDataMediator.SqlSetString(dcCustomerWork.HomeTelNo);
            paraOfficeTelNo.Value = SqlDataMediator.SqlSetString(dcCustomerWork.OfficeTelNo);
            paraPortableTelNo.Value = SqlDataMediator.SqlSetString(dcCustomerWork.PortableTelNo);
            paraHomeFaxNo.Value = SqlDataMediator.SqlSetString(dcCustomerWork.HomeFaxNo);
            paraOfficeFaxNo.Value = SqlDataMediator.SqlSetString(dcCustomerWork.OfficeFaxNo);
            paraOthersTelNo.Value = SqlDataMediator.SqlSetString(dcCustomerWork.OthersTelNo);
            paraMainContactCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.MainContactCode);
            paraSearchTelNo.Value = SqlDataMediator.SqlSetString(dcCustomerWork.SearchTelNo);
            paraMngSectionCode.Value = SqlDataMediator.SqlSetString(dcCustomerWork.MngSectionCode);
            paraInpSectionCode.Value = SqlDataMediator.SqlSetString(dcCustomerWork.InpSectionCode);
            paraCustAnalysCode1.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CustAnalysCode1);
            paraCustAnalysCode2.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CustAnalysCode2);
            paraCustAnalysCode3.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CustAnalysCode3);
            paraCustAnalysCode4.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CustAnalysCode4);
            paraCustAnalysCode5.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CustAnalysCode5);
            paraCustAnalysCode6.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CustAnalysCode6);
            paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.BillOutputCode);
            paraBillOutputName.Value = SqlDataMediator.SqlSetString(dcCustomerWork.BillOutputName);
            paraTotalDay.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.TotalDay);
            paraCollectMoneyCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CollectMoneyCode);
            paraCollectMoneyName.Value = SqlDataMediator.SqlSetString(dcCustomerWork.CollectMoneyName);
            paraCollectMoneyDay.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CollectMoneyDay);
            paraCollectCond.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CollectCond);
            paraCollectSight.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CollectSight);
            paraClaimCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.ClaimCode);
            paraTransStopDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcCustomerWork.TransStopDate);
            paraDmOutCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.DmOutCode);
            paraDmOutName.Value = SqlDataMediator.SqlSetString(dcCustomerWork.DmOutName);
            paraMainSendMailAddrCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.MainSendMailAddrCd);
            paraMailAddrKindCode1.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.MailAddrKindCode1);
            paraMailAddrKindName1.Value = SqlDataMediator.SqlSetString(dcCustomerWork.MailAddrKindName1);
            paraMailAddress1.Value = SqlDataMediator.SqlSetString(dcCustomerWork.MailAddress1);
            paraMailSendCode1.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.MailSendCode1);
            paraMailSendName1.Value = SqlDataMediator.SqlSetString(dcCustomerWork.MailSendName1);
            paraMailAddrKindCode2.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.MailAddrKindCode2);
            paraMailAddrKindName2.Value = SqlDataMediator.SqlSetString(dcCustomerWork.MailAddrKindName2);
            paraMailAddress2.Value = SqlDataMediator.SqlSetString(dcCustomerWork.MailAddress2);
            paraMailSendCode2.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.MailSendCode2);
            paraMailSendName2.Value = SqlDataMediator.SqlSetString(dcCustomerWork.MailSendName2);
            paraCustomerAgentCd.Value = SqlDataMediator.SqlSetString(dcCustomerWork.CustomerAgentCd);
            paraBillCollecterCd.Value = SqlDataMediator.SqlSetString(dcCustomerWork.BillCollecterCd);
            paraOldCustomerAgentCd.Value = SqlDataMediator.SqlSetString(dcCustomerWork.OldCustomerAgentCd);
            paraCustAgentChgDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcCustomerWork.CustAgentChgDate);
            paraAcceptWholeSale.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.AcceptWholeSale);
            paraCreditMngCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CreditMngCode);
            paraDepoDelCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.DepoDelCode);
            paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.AccRecDivCd);
            paraCustSlipNoMngCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CustSlipNoMngCd);
            paraPureCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.PureCode);
            paraCustCTaXLayRefCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CustCTaXLayRefCd);
            paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.ConsTaxLayMethod);
            paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.TotalAmountDispWayCd);
            paraTotalAmntDspWayRef.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.TotalAmntDspWayRef);
            paraAccountNoInfo1.Value = SqlDataMediator.SqlSetString(dcCustomerWork.AccountNoInfo1);
            paraAccountNoInfo2.Value = SqlDataMediator.SqlSetString(dcCustomerWork.AccountNoInfo2);
            paraAccountNoInfo3.Value = SqlDataMediator.SqlSetString(dcCustomerWork.AccountNoInfo3);
            paraSalesUnPrcFrcProcCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.SalesUnPrcFrcProcCd);
            paraSalesMoneyFrcProcCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.SalesMoneyFrcProcCd);
            paraSalesCnsTaxFrcProcCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.SalesCnsTaxFrcProcCd);
            paraCustomerSlipNoDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CustomerSlipNoDiv);
            paraNTimeCalcStDate.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.NTimeCalcStDate);
            paraCustomerAgent.Value = SqlDataMediator.SqlSetString(dcCustomerWork.CustomerAgent);
            paraClaimSectionCode.Value = SqlDataMediator.SqlSetString(dcCustomerWork.ClaimSectionCode);
            paraCarMngDivCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.CarMngDivCd);
            paraBillPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.BillPartsNoPrtCd);
            paraDeliPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.DeliPartsNoPrtCd);
            paraDefSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.DefSalesSlipCd);
            paraLavorRateRank.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.LavorRateRank);
            paraSlipTtlPrn.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.SlipTtlPrn);
            paraDepoBankCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.DepoBankCode);
            paraCustWarehouseCd.Value = SqlDataMediator.SqlSetString(dcCustomerWork.CustWarehouseCd);
            paraQrcodePrtCd.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.QrcodePrtCd);
            paraDeliHonorificTtl.Value = SqlDataMediator.SqlSetString(dcCustomerWork.DeliHonorificTtl);
            paraBillHonorificTtl.Value = SqlDataMediator.SqlSetString(dcCustomerWork.BillHonorificTtl);
            paraEstmHonorificTtl.Value = SqlDataMediator.SqlSetString(dcCustomerWork.EstmHonorificTtl);
            paraRectHonorificTtl.Value = SqlDataMediator.SqlSetString(dcCustomerWork.RectHonorificTtl);
            paraDeliHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.DeliHonorTtlPrtDiv);
            paraBillHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.BillHonorTtlPrtDiv);
            paraEstmHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.EstmHonorTtlPrtDiv);
            paraRectHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.RectHonorTtlPrtDiv);
            paraNote1.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Note1);
            paraNote2.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Note2);
            paraNote3.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Note3);
            paraNote4.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Note4);
            paraNote5.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Note5);
            paraNote6.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Note6);
            paraNote7.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Note7);
            paraNote8.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Note8);
            paraNote9.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Note9);
            paraNote10.Value = SqlDataMediator.SqlSetString(dcCustomerWork.Note10);
            paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.SalesSlipPrtDiv);
            paraShipmSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.ShipmSlipPrtDiv);
            paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.AcpOdrrSlipPrtDiv);
            paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.EstimatePrtDiv);
            paraUOESlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.UOESlipPrtDiv);
            paraReceiptOutputCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.ReceiptOutputCode);
            // ADD 2009/05/25 --->>>
            paraCustomerEpCode.Value = SqlDataMediator.SqlSetString(dcCustomerWork.CustomerEpCode);
            paraCustomerSecCode.Value = SqlDataMediator.SqlSetString(dcCustomerWork.CustomerSecCode);
            paraOnlineKindDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.OnlineKindDiv);
            // ADD 2009/05/25 ---<<<
            // --- ADD  ���r��  ���r��  2010/01/21 ---------->>>>>
            paraTotalBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.TotalBillOutputDiv);  // ���v�������o�͋敪
            paraDetailBillOutputCode.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.DetailBillOutputCode);  // ���א������o�͋敪
            paraSlipTtlBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(dcCustomerWork.SlipTtlBillOutputDiv);  // �`�[���v�������o�͋敪
            // --- ADD  ���r��  ���r��  2010/01/21 ----------<<<<<
            // ���Ӑ�}�X�^�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j
        #region [Read]
        #region DEL 2011/09/08 sundx #23777 �\�[�X���r���[
        ///// <summary>
        ///// ���Ӑ�}�X�^�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="pagamList">��������</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="customerArrList">���Ӑ�}�X�^�f�[�^�I�u�W�F�N�g</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���Ӑ�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2011/07/26</br>
        //public int SearchCustomer(string enterpriseCodes, object pagamList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList customerArrList, out string retMessage)
        //{
        //    return SearchCustomerProc(enterpriseCodes, pagamList, sqlConnection,
        //                    sqlTransaction, out customerArrList, out retMessage);
        //}
        ///// <summary>
        ///// ���Ӑ�}�X�^�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="paramList">��������</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="customerArrList">���Ӑ�}�X�^�f�[�^�I�u�W�F�N�g</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���Ӑ�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2011/07/26</br>
        //private int SearchCustomerProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList customerArrList, out string retMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    customerArrList = new ArrayList();
        //    //DCCustomerWork customerWork = null;//DEL 2011/08/20 �r���[�i�`�F�b�N
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    CustomerProcParamWork param = paramList as CustomerProcParamWork;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, CUSTOMERSUBCODERF, NAMERF, NAME2RF, HONORIFICTITLERF, KANARF, CUSTOMERSNMRF, OUTPUTNAMECODERF, OUTPUTNAMERF, CORPORATEDIVCODERF, CUSTOMERATTRIBUTEDIVRF, JOBTYPECODERF, BUSINESSTYPECODERF, SALESAREACODERF, POSTNORF, ADDRESS1RF, ADDRESS3RF, ADDRESS4RF, HOMETELNORF, OFFICETELNORF, PORTABLETELNORF, HOMEFAXNORF, OFFICEFAXNORF, OTHERSTELNORF, MAINCONTACTCODERF, SEARCHTELNORF, MNGSECTIONCODERF, INPSECTIONCODERF, CUSTANALYSCODE1RF, CUSTANALYSCODE2RF, CUSTANALYSCODE3RF, CUSTANALYSCODE4RF, CUSTANALYSCODE5RF, CUSTANALYSCODE6RF, BILLOUTPUTCODERF, BILLOUTPUTNAMERF, TOTALDAYRF, COLLECTMONEYCODERF, COLLECTMONEYNAMERF, COLLECTMONEYDAYRF, COLLECTCONDRF, COLLECTSIGHTRF, CLAIMCODERF, TRANSSTOPDATERF, DMOUTCODERF, DMOUTNAMERF, MAINSENDMAILADDRCDRF, MAILADDRKINDCODE1RF, MAILADDRKINDNAME1RF, MAILADDRESS1RF, MAILSENDCODE1RF, MAILSENDNAME1RF, MAILADDRKINDCODE2RF, MAILADDRKINDNAME2RF, MAILADDRESS2RF, MAILSENDCODE2RF, MAILSENDNAME2RF, CUSTOMERAGENTCDRF, BILLCOLLECTERCDRF, OLDCUSTOMERAGENTCDRF, CUSTAGENTCHGDATERF, ACCEPTWHOLESALERF, CREDITMNGCODERF, DEPODELCODERF, ACCRECDIVCDRF, CUSTSLIPNOMNGCDRF, PURECODERF, CUSTCTAXLAYREFCDRF, CONSTAXLAYMETHODRF, TOTALAMOUNTDISPWAYCDRF, TOTALAMNTDSPWAYREFRF, ACCOUNTNOINFO1RF, ACCOUNTNOINFO2RF, ACCOUNTNOINFO3RF, SALESUNPRCFRCPROCCDRF, SALESMONEYFRCPROCCDRF, SALESCNSTAXFRCPROCCDRF, CUSTOMERSLIPNODIVRF, NTIMECALCSTDATERF, CUSTOMERAGENTRF, CLAIMSECTIONCODERF, CARMNGDIVCDRF, BILLPARTSNOPRTCDRF, DELIPARTSNOPRTCDRF, DEFSALESSLIPCDRF, LAVORRATERANKRF, SLIPTTLPRNRF, DEPOBANKCODERF, CUSTWAREHOUSECDRF, QRCODEPRTCDRF, DELIHONORIFICTTLRF, BILLHONORIFICTTLRF, ESTMHONORIFICTTLRF, RECTHONORIFICTTLRF, DELIHONORTTLPRTDIVRF, BILLHONORTTLPRTDIVRF, ESTMHONORTTLPRTDIVRF, RECTHONORTTLPRTDIVRF, NOTE1RF, NOTE2RF, NOTE3RF, NOTE4RF, NOTE5RF, NOTE6RF, NOTE7RF, NOTE8RF, NOTE9RF, NOTE10RF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, ACPODRRSLIPPRTDIVRF, ESTIMATEPRTDIVRF, UOESLIPPRTDIVRF, RECEIPTOUTPUTCODERF, CUSTOMEREPCODERF, CUSTOMERSECCODERF, ONLINEKINDDIVRF, TOTALBILLOUTPUTDIVRF, DETAILBILLOUTPUTCODERF, SLIPTTLBILLOUTPUTDIVRF FROM CUSTOMERRF ";
        //        sqlStr += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

        //        if (param.UpdateDateTimeBegin != 0)
        //        {
        //            sqlStr += " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
        //            SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
        //            findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
        //        }
        //        if (param.UpdateDateTimeEnd != 0)
        //        {
        //            sqlStr += " AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
        //            SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
        //            findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
        //        }
        //        if (param.CustomerCodeBeginRF != 0)
        //        {
        //            sqlStr += " AND CUSTOMERCODERF >= @CUSTOMERCODEBEGINRF";
        //            SqlParameter customerCodeBeginRF = sqlCommand.Parameters.Add("@CUSTOMERCODEBEGINRF", SqlDbType.Int);
        //            customerCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeBeginRF);
        //        }
        //        if (param.CustomerCodeEndRF != 0)
        //        {
        //            sqlStr += " AND CUSTOMERCODERF <= @CUSTOMERCODEENDRF";
        //            SqlParameter customerCodeEndRF = sqlCommand.Parameters.Add("@CUSTOMERCODEENDRF", SqlDbType.Int);
        //            customerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeEndRF);
        //        }

        //        if (!string.IsNullOrEmpty(param.KanaBeginRF))
        //        {
        //            sqlStr += " AND KANARF >= @KANABEGINRF";
        //            SqlParameter kanaBeginRF = sqlCommand.Parameters.Add("@KANABEGINRF", SqlDbType.NVarChar);
        //            kanaBeginRF.Value = SqlDataMediator.SqlSetString(param.KanaBeginRF);
        //        }

        //        if (!string.IsNullOrEmpty(param.KanaEndRF))
        //        {
        //            sqlStr += " AND KANARF <= @KANAENDRF";
        //            SqlParameter kanaEndRF = sqlCommand.Parameters.Add("@KANAENDRF", SqlDbType.NVarChar);
        //            kanaEndRF.Value = SqlDataMediator.SqlSetString(param.KanaEndRF);
        //        }

        //        if (!string.IsNullOrEmpty(param.MngSectionCodeBeginRF))
        //        {
        //            sqlStr += " AND MNGSECTIONCODERF >= @MNGSECTIONCODEBEGINRF";
        //            SqlParameter mngSectionCodeBeginRF = sqlCommand.Parameters.Add("@MNGSECTIONCODEBEGINRF", SqlDbType.NChar);
        //            mngSectionCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.MngSectionCodeBeginRF);
        //        }

        //        if (!string.IsNullOrEmpty(param.MngSectionCodeEndRF))
        //        {
        //            sqlStr += " AND MNGSECTIONCODERF <= @MNGSECTIONCODEENDRF";
        //            SqlParameter mngSectionCodeEndRF = sqlCommand.Parameters.Add("@MNGSECTIONCODEENDRF", SqlDbType.NChar);
        //            mngSectionCodeEndRF.Value = SqlDataMediator.SqlSetString(param.MngSectionCodeEndRF);
        //        }

        //        if (!string.IsNullOrEmpty(param.CustomerAgentCdBeginRF))
        //        {
        //            sqlStr += " AND CUSTOMERAGENTCDRF >= @CUSTOMERAGENTCDBEGINRF";
        //            SqlParameter customerAgentCdBeginRF = sqlCommand.Parameters.Add("@CUSTOMERAGENTCDBEGINRF", SqlDbType.NChar);
        //            customerAgentCdBeginRF.Value = SqlDataMediator.SqlSetString(param.CustomerAgentCdBeginRF);
        //        }

        //        if (!string.IsNullOrEmpty(param.CustomerAgentCdEndRF))
        //        {
        //            sqlStr += " AND CUSTOMERAGENTCDRF <= @CUSTOMERAGENTCDENDRF";
        //            SqlParameter customerAgentCdEndRF = sqlCommand.Parameters.Add("@CUSTOMERAGENTCDENDRF", SqlDbType.NChar);
        //            customerAgentCdEndRF.Value = SqlDataMediator.SqlSetString(param.CustomerAgentCdEndRF);
        //        }

        //        if (param.SalesAreaCodeBeginRF != 0)
        //        {
        //            sqlStr += " AND SALESAREACODERF >= @SALESAREACODEBEGINRF";
        //            SqlParameter salesAreaCodeBeginRF = sqlCommand.Parameters.Add("@SALESAREACODEBEGINRF", SqlDbType.Int);
        //            salesAreaCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SalesAreaCodeBeginRF);
        //        }

        //        if (param.SalesAreaCodeEndRF != 0)
        //        {
        //            sqlStr += " AND SALESAREACODERF <= @SALESAREACODEENDRF";
        //            SqlParameter salesAreaCodeEndRF = sqlCommand.Parameters.Add("@SALESAREACODEENDRF", SqlDbType.Int);
        //            salesAreaCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.SalesAreaCodeEndRF);
        //        }

        //        if (param.BusinessTypeCodeBeginRF != 0)
        //        {
        //            sqlStr += " AND BUSINESSTYPECODERF >= @BUSINESSTYPECODEBEGINRF";
        //            SqlParameter businessTypeCodeBeginRF = sqlCommand.Parameters.Add("@BUSINESSTYPECODEBEGINRF", SqlDbType.Int);
        //            businessTypeCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BusinessTypeCodeBeginRF);
        //        }

        //        if (param.BusinessTypeCodeEndRF != 0)
        //        {
        //            sqlStr += " AND BUSINESSTYPECODERF <= @BUSINESSTYPECODEENDRF";
        //            SqlParameter businessTypeCodeEndRF = sqlCommand.Parameters.Add("@BUSINESSTYPECODEENDRF", SqlDbType.Int);
        //            businessTypeCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BusinessTypeCodeEndRF);
        //        }

        //        //Prameter�I�u�W�F�N�g�̍쐬
        //        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

        //        //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);


        //        //���Ӑ�}�X�^�f�[�^�pSQL
        //        sqlCommand.CommandText = sqlStr;

        //        // �ǂݍ���
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            #region DEL
        //            //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        //            //customerWork = new DCCustomerWork();

        //            //customerWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //            //customerWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //            //customerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //            //customerWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //            //customerWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //            //customerWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //            //customerWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //            //customerWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //            //customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //            //customerWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
        //            //customerWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
        //            //customerWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
        //            //customerWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
        //            //customerWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
        //            //customerWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
        //            //customerWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
        //            //customerWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
        //            //customerWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
        //            //customerWork.CustomerAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERATTRIBUTEDIVRF"));
        //            //customerWork.JobTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOBTYPECODERF"));
        //            //customerWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
        //            //customerWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
        //            //customerWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
        //            //customerWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
        //            //customerWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
        //            //customerWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
        //            //customerWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
        //            //customerWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
        //            //customerWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
        //            //customerWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
        //            //customerWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
        //            //customerWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
        //            //customerWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
        //            //customerWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
        //            //customerWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
        //            //customerWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
        //            //customerWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
        //            //customerWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
        //            //customerWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
        //            //customerWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
        //            //customerWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
        //            //customerWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
        //            //customerWork.BillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLOUTPUTCODERF"));
        //            //customerWork.BillOutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLOUTPUTNAMERF"));
        //            //customerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
        //            //customerWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
        //            //customerWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
        //            //customerWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
        //            //customerWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
        //            //customerWork.CollectSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTSIGHTRF"));
        //            //customerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
        //            //customerWork.TransStopDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TRANSSTOPDATERF"));
        //            //customerWork.DmOutCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTCODERF"));
        //            //customerWork.DmOutName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMOUTNAMERF"));
        //            //customerWork.MainSendMailAddrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINSENDMAILADDRCDRF"));
        //            //customerWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
        //            //customerWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
        //            //customerWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
        //            //customerWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
        //            //customerWork.MailSendName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME1RF"));
        //            //customerWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
        //            //customerWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
        //            //customerWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
        //            //customerWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));
        //            //customerWork.MailSendName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME2RF"));
        //            //customerWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
        //            //customerWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
        //            //customerWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
        //            //customerWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF"));
        //            //customerWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
        //            //customerWork.CreditMngCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITMNGCODERF"));
        //            //customerWork.DepoDelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPODELCODERF"));
        //            //customerWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
        //            //customerWork.CustSlipNoMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNOMNGCDRF"));
        //            //customerWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
        //            //customerWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));
        //            //customerWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
        //            //customerWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
        //            //customerWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMNTDSPWAYREFRF"));
        //            //customerWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
        //            //customerWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
        //            //customerWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
        //            //customerWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));
        //            //customerWork.SalesMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESMONEYFRCPROCCDRF"));
        //            //customerWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));
        //            //customerWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));
        //            //customerWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
        //            //customerWork.CustomerAgent = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTRF"));
        //            //customerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
        //            //customerWork.CarMngDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGDIVCDRF"));
        //            //customerWork.BillPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPARTSNOPRTCDRF"));
        //            //customerWork.DeliPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIPARTSNOPRTCDRF"));
        //            //customerWork.DefSalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSALESSLIPCDRF"));
        //            //customerWork.LavorRateRank = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAVORRATERANKRF"));
        //            //customerWork.SlipTtlPrn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLPRNRF"));
        //            //customerWork.DepoBankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOBANKCODERF"));
        //            //customerWork.CustWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSECDRF"));
        //            //customerWork.QrcodePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRTCDRF"));
        //            //customerWork.DeliHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORIFICTTLRF"));
        //            //customerWork.BillHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORIFICTTLRF"));
        //            //customerWork.EstmHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORIFICTTLRF"));
        //            //customerWork.RectHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORIFICTTLRF"));
        //            //customerWork.DeliHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIHONORTTLPRTDIVRF"));
        //            //customerWork.BillHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLHONORTTLPRTDIVRF"));
        //            //customerWork.EstmHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMHONORTTLPRTDIVRF"));
        //            //customerWork.RectHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECTHONORTTLPRTDIVRF"));
        //            //customerWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
        //            //customerWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
        //            //customerWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
        //            //customerWork.Note4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
        //            //customerWork.Note5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
        //            //customerWork.Note6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
        //            //customerWork.Note7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
        //            //customerWork.Note8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
        //            //customerWork.Note9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
        //            //customerWork.Note10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
        //            //customerWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
        //            //customerWork.ShipmSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPPRTDIVRF"));
        //            //customerWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
        //            //customerWork.EstimatePrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));
        //            //customerWork.UOESlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESLIPPRTDIVRF"));
        //            //customerWork.ReceiptOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIPTOUTPUTCODERF"));
        //            //customerWork.CustomerEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMEREPCODERF"));
        //            //customerWork.CustomerSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSECCODERF"));
        //            //customerWork.OnlineKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEKINDDIVRF"));
        //            //customerWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));  // ���v�������o�͋敪
        //            //customerWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));  // ���א������o�͋敪
        //            //customerWork.SlipTtlBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLBILLOUTPUTDIVRF"));  // �`�[���v�������o�͋敪

        //            //customerArrList.Add(customerWork);
        //            //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<
        //            #endregion DEL
        //            customerArrList.Add(CopyFromMyReaderToDCCustomerWork(myReader));//ADD 2011/08/20 �r���[�i�`�F�b�N
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        base.WriteErrorLog(ex, "DCCustomerDB.SearchCustomer Exception=" + ex.Message);
        //        retMessage = ex.Message;
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (myReader != null)
        //            if (!myReader.IsClosed) myReader.Close();

        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Cancel();
        //            sqlCommand.Dispose();
        //        }
        //    }
        //    return status;
        //}
        #endregion

        /// <summary>
        /// �܂��Ӑ�}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="pagamList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="customerArrList">���Ӑ�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �܂��Ӑ�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        public int SearchAllCustomer(string enterpriseCodes, object pagamList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList customerArrList, out string retMessage)
        {
            return SearchALLCustomerProc(enterpriseCodes, pagamList, sqlConnection,
                            sqlTransaction, out customerArrList, out retMessage);
        }
        /// <summary>
        /// �܂��Ӑ�}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="customerArrList">���Ӑ�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �܂��Ӑ�}�X�^�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
        private int SearchALLCustomerProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList customerArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            customerArrList = new ArrayList();
            ArrayList customerList = new ArrayList();
            ArrayList custRateGroupList = new ArrayList();
            ArrayList customerChangeList = new ArrayList();
            ArrayList customerMemoList = new ArrayList(); // ADD 2021/04/12 ���O FOR PMKOBETSU-4136
            ArrayList custSlipMngList = new ArrayList();
            ArrayList custSlipNoList = new ArrayList();

            Hashtable customerHashTbl = new Hashtable();
            Hashtable custRateGroupHashTbl = new Hashtable();
            Hashtable customerChangeHashTbl = new Hashtable();
            Hashtable customerMemoHashTbl = new Hashtable();// ADD 2021/04/12 ���O FOR PMKOBETSU-4136
            Hashtable custSlipMngHashTbl = new Hashtable();
            Hashtable custSlipNoHashTbl = new Hashtable();
            string aPK = "";
            string bPK = "";
            string cPK = "";
            string dPK = "";
            string ePK = "";
            string space = "�@";//�S�p
            string emptyValue = "";

            retMessage = string.Empty;
            StringBuilder sqlStr = new StringBuilder();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            CustomerProcParamWork param = paramList as CustomerProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                #region SELECT
                sqlStr.Append("SELECT ");

                #region ���Ӑ�}�X�^
                sqlStr.Append("A.CREATEDATETIMERF AS ACREATEDATETIMERF,");
                sqlStr.Append("A.UPDATEDATETIMERF AS AUPDATEDATETIMERF,");
                sqlStr.Append("A.ENTERPRISECODERF AS AENTERPRISECODERF,");
                sqlStr.Append("A.FILEHEADERGUIDRF AS AFILEHEADERGUIDRF,");
                sqlStr.Append("A.UPDEMPLOYEECODERF AS AUPDEMPLOYEECODERF,");
                sqlStr.Append("A.UPDASSEMBLYID1RF AS AUPDASSEMBLYID1RF,");
                sqlStr.Append("A.UPDASSEMBLYID2RF AS AUPDASSEMBLYID2RF,");
                sqlStr.Append("A.LOGICALDELETECODERF AS ALOGICALDELETECODERF,");
                sqlStr.Append("A.CUSTOMERCODERF AS ACUSTOMERCODERF,");
                sqlStr.Append("A.CUSTOMERSUBCODERF AS ACUSTOMERSUBCODERF,");
                sqlStr.Append("A.NAMERF AS ANAMERF,");
                sqlStr.Append("A.NAME2RF AS ANAME2RF,");
                sqlStr.Append("A.HONORIFICTITLERF AS AHONORIFICTITLERF,");
                sqlStr.Append("A.KANARF AS AKANARF,");
                sqlStr.Append("A.CUSTOMERSNMRF AS ACUSTOMERSNMRF,");
                sqlStr.Append("A.OUTPUTNAMECODERF AS AOUTPUTNAMECODERF,");
                sqlStr.Append("A.OUTPUTNAMERF AS AOUTPUTNAMERF,");
                sqlStr.Append("A.CORPORATEDIVCODERF AS ACORPORATEDIVCODERF,");
                sqlStr.Append("A.CUSTOMERATTRIBUTEDIVRF AS ACUSTOMERATTRIBUTEDIVRF,");
                sqlStr.Append("A.JOBTYPECODERF AS AJOBTYPECODERF,");
                sqlStr.Append("A.BUSINESSTYPECODERF AS ABUSINESSTYPECODERF,");
                sqlStr.Append("A.SALESAREACODERF AS ASALESAREACODERF,");
                sqlStr.Append("A.POSTNORF AS APOSTNORF,");
                sqlStr.Append("A.ADDRESS1RF AS AADDRESS1RF,");
                sqlStr.Append("A.ADDRESS3RF AS AADDRESS3RF,");
                sqlStr.Append("A.ADDRESS4RF AS AADDRESS4RF,");
                sqlStr.Append("A.HOMETELNORF AS AHOMETELNORF,");
                sqlStr.Append("A.OFFICETELNORF AS AOFFICETELNORF,");
                sqlStr.Append("A.PORTABLETELNORF AS APORTABLETELNORF,");
                sqlStr.Append("A.HOMEFAXNORF AS AHOMEFAXNORF,");
                sqlStr.Append("A.OFFICEFAXNORF AS AOFFICEFAXNORF,");
                sqlStr.Append("A.OTHERSTELNORF AS AOTHERSTELNORF,");
                sqlStr.Append("A.MAINCONTACTCODERF AS AMAINCONTACTCODERF,");
                sqlStr.Append("A.SEARCHTELNORF AS ASEARCHTELNORF,");
                sqlStr.Append("A.MNGSECTIONCODERF AS AMNGSECTIONCODERF,");
                sqlStr.Append("A.INPSECTIONCODERF AS AINPSECTIONCODERF,");
                sqlStr.Append("A.CUSTANALYSCODE1RF AS ACUSTANALYSCODE1RF,");
                sqlStr.Append("A.CUSTANALYSCODE2RF AS ACUSTANALYSCODE2RF,");
                sqlStr.Append("A.CUSTANALYSCODE3RF AS ACUSTANALYSCODE3RF,");
                sqlStr.Append("A.CUSTANALYSCODE4RF AS ACUSTANALYSCODE4RF,");
                sqlStr.Append("A.CUSTANALYSCODE5RF AS ACUSTANALYSCODE5RF,");
                sqlStr.Append("A.CUSTANALYSCODE6RF AS ACUSTANALYSCODE6RF,");
                sqlStr.Append("A.BILLOUTPUTCODERF AS ABILLOUTPUTCODERF,");
                sqlStr.Append("A.BILLOUTPUTNAMERF AS ABILLOUTPUTNAMERF,");
                sqlStr.Append("A.TOTALDAYRF AS ATOTALDAYRF,");
                sqlStr.Append("A.COLLECTMONEYCODERF AS ACOLLECTMONEYCODERF,");
                sqlStr.Append("A.COLLECTMONEYNAMERF AS ACOLLECTMONEYNAMERF,");
                sqlStr.Append("A.COLLECTMONEYDAYRF AS ACOLLECTMONEYDAYRF,");
                sqlStr.Append("A.COLLECTCONDRF AS ACOLLECTCONDRF,");
                sqlStr.Append("A.COLLECTSIGHTRF AS ACOLLECTSIGHTRF,");
                sqlStr.Append("A.CLAIMCODERF AS ACLAIMCODERF,");
                sqlStr.Append("A.TRANSSTOPDATERF AS ATRANSSTOPDATERF,");
                sqlStr.Append("A.DMOUTCODERF AS ADMOUTCODERF,");
                sqlStr.Append("A.DMOUTNAMERF AS ADMOUTNAMERF,");
                sqlStr.Append("A.MAINSENDMAILADDRCDRF AS AMAINSENDMAILADDRCDRF,");
                sqlStr.Append("A.MAILADDRKINDCODE1RF AS AMAILADDRKINDCODE1RF,");
                sqlStr.Append("A.MAILADDRKINDNAME1RF AS AMAILADDRKINDNAME1RF,");
                sqlStr.Append("A.MAILADDRESS1RF AS AMAILADDRESS1RF,");
                sqlStr.Append("A.MAILSENDCODE1RF AS AMAILSENDCODE1RF,");
                sqlStr.Append("A.MAILSENDNAME1RF AS AMAILSENDNAME1RF,");
                sqlStr.Append("A.MAILADDRKINDCODE2RF AS AMAILADDRKINDCODE2RF,");
                sqlStr.Append("A.MAILADDRKINDNAME2RF AS AMAILADDRKINDNAME2RF,");
                sqlStr.Append("A.MAILADDRESS2RF AS AMAILADDRESS2RF,");
                sqlStr.Append("A.MAILSENDCODE2RF AS AMAILSENDCODE2RF,");
                sqlStr.Append("A.MAILSENDNAME2RF AS AMAILSENDNAME2RF,");
                sqlStr.Append("A.CUSTOMERAGENTCDRF AS ACUSTOMERAGENTCDRF,");
                sqlStr.Append("A.BILLCOLLECTERCDRF AS ABILLCOLLECTERCDRF,");
                sqlStr.Append("A.OLDCUSTOMERAGENTCDRF AS AOLDCUSTOMERAGENTCDRF,");
                sqlStr.Append("A.CUSTAGENTCHGDATERF AS ACUSTAGENTCHGDATERF,");
                sqlStr.Append("A.ACCEPTWHOLESALERF AS AACCEPTWHOLESALERF,");
                sqlStr.Append("A.CREDITMNGCODERF AS ACREDITMNGCODERF,");
                sqlStr.Append("A.DEPODELCODERF AS ADEPODELCODERF,");
                sqlStr.Append("A.ACCRECDIVCDRF AS AACCRECDIVCDRF,");
                sqlStr.Append("A.CUSTSLIPNOMNGCDRF AS ACUSTSLIPNOMNGCDRF,");
                sqlStr.Append("A.PURECODERF AS APURECODERF,");
                sqlStr.Append("A.CUSTCTAXLAYREFCDRF AS ACUSTCTAXLAYREFCDRF,");
                sqlStr.Append("A.CONSTAXLAYMETHODRF AS ACONSTAXLAYMETHODRF,");
                sqlStr.Append("A.TOTALAMOUNTDISPWAYCDRF AS ATOTALAMOUNTDISPWAYCDRF,");
                sqlStr.Append("A.TOTALAMNTDSPWAYREFRF AS ATOTALAMNTDSPWAYREFRF,");
                sqlStr.Append("A.ACCOUNTNOINFO1RF AS AACCOUNTNOINFO1RF,");
                sqlStr.Append("A.ACCOUNTNOINFO2RF AS AACCOUNTNOINFO2RF,");
                sqlStr.Append("A.ACCOUNTNOINFO3RF AS AACCOUNTNOINFO3RF,");
                sqlStr.Append("A.SALESUNPRCFRCPROCCDRF AS ASALESUNPRCFRCPROCCDRF,");
                sqlStr.Append("A.SALESMONEYFRCPROCCDRF AS ASALESMONEYFRCPROCCDRF,");
                sqlStr.Append("A.SALESCNSTAXFRCPROCCDRF AS ASALESCNSTAXFRCPROCCDRF,");
                sqlStr.Append("A.CUSTOMERSLIPNODIVRF AS ACUSTOMERSLIPNODIVRF,");
                sqlStr.Append("A.NTIMECALCSTDATERF AS ANTIMECALCSTDATERF,");
                sqlStr.Append("A.CUSTOMERAGENTRF AS ACUSTOMERAGENTRF,");
                sqlStr.Append("A.CLAIMSECTIONCODERF AS ACLAIMSECTIONCODERF,");
                sqlStr.Append("A.CARMNGDIVCDRF AS ACARMNGDIVCDRF,");
                sqlStr.Append("A.BILLPARTSNOPRTCDRF AS ABILLPARTSNOPRTCDRF,");
                sqlStr.Append("A.DELIPARTSNOPRTCDRF AS ADELIPARTSNOPRTCDRF,");
                sqlStr.Append("A.DEFSALESSLIPCDRF AS ADEFSALESSLIPCDRF,");
                sqlStr.Append("A.LAVORRATERANKRF AS ALAVORRATERANKRF,");
                sqlStr.Append("A.SLIPTTLPRNRF AS ASLIPTTLPRNRF,");
                sqlStr.Append("A.DEPOBANKCODERF AS ADEPOBANKCODERF,");
                sqlStr.Append("A.CUSTWAREHOUSECDRF AS ACUSTWAREHOUSECDRF,");
                sqlStr.Append("A.QRCODEPRTCDRF AS AQRCODEPRTCDRF,");
                sqlStr.Append("A.DELIHONORIFICTTLRF AS ADELIHONORIFICTTLRF,");
                sqlStr.Append("A.BILLHONORIFICTTLRF AS ABILLHONORIFICTTLRF,");
                sqlStr.Append("A.ESTMHONORIFICTTLRF AS AESTMHONORIFICTTLRF,");
                sqlStr.Append("A.RECTHONORIFICTTLRF AS ARECTHONORIFICTTLRF,");
                sqlStr.Append("A.DELIHONORTTLPRTDIVRF AS ADELIHONORTTLPRTDIVRF,");
                sqlStr.Append("A.BILLHONORTTLPRTDIVRF AS ABILLHONORTTLPRTDIVRF,");
                sqlStr.Append("A.ESTMHONORTTLPRTDIVRF AS AESTMHONORTTLPRTDIVRF,");
                sqlStr.Append("A.RECTHONORTTLPRTDIVRF AS ARECTHONORTTLPRTDIVRF,");
                sqlStr.Append("A.NOTE1RF AS ANOTE1RF,");
                sqlStr.Append("A.NOTE2RF AS ANOTE2RF,");
                sqlStr.Append("A.NOTE3RF AS ANOTE3RF,");
                sqlStr.Append("A.NOTE4RF AS ANOTE4RF,");
                sqlStr.Append("A.NOTE5RF AS ANOTE5RF,");
                sqlStr.Append("A.NOTE6RF AS ANOTE6RF,");
                sqlStr.Append("A.NOTE7RF AS ANOTE7RF,");
                sqlStr.Append("A.NOTE8RF AS ANOTE8RF,");
                sqlStr.Append("A.NOTE9RF AS ANOTE9RF,");
                sqlStr.Append("A.NOTE10RF AS ANOTE10RF,");
                sqlStr.Append("A.SALESSLIPPRTDIVRF AS ASALESSLIPPRTDIVRF,");
                sqlStr.Append("A.SHIPMSLIPPRTDIVRF AS ASHIPMSLIPPRTDIVRF,");
                sqlStr.Append("A.ACPODRRSLIPPRTDIVRF AS AACPODRRSLIPPRTDIVRF,");
                sqlStr.Append("A.ESTIMATEPRTDIVRF AS AESTIMATEPRTDIVRF,");
                sqlStr.Append("A.UOESLIPPRTDIVRF AS AUOESLIPPRTDIVRF,");
                sqlStr.Append("A.RECEIPTOUTPUTCODERF AS ARECEIPTOUTPUTCODERF,");
                sqlStr.Append("A.CUSTOMEREPCODERF AS ACUSTOMEREPCODERF,");
                sqlStr.Append("A.CUSTOMERSECCODERF AS ACUSTOMERSECCODERF,");
                sqlStr.Append("A.ONLINEKINDDIVRF AS AONLINEKINDDIVRF,");

                sqlStr.Append("A.TOTALBILLOUTPUTDIVRF AS ATOTALBILLOUTPUTDIVRF,");
                sqlStr.Append("A.DETAILBILLOUTPUTCODERF AS ADETAILBILLOUTPUTCODERF,");
                sqlStr.Append("A.SLIPTTLBILLOUTPUTDIVRF AS ASLIPTTLBILLOUTPUTDIVRF,");
                #endregion

                #region ���Ӑ�}�X�^�i�|���O���[�v�j
                sqlStr.Append("B.CREATEDATETIMERF AS BCREATEDATETIMERF,");
                sqlStr.Append("B.UPDATEDATETIMERF AS BUPDATEDATETIMERF,");
                sqlStr.Append("B.ENTERPRISECODERF AS BENTERPRISECODERF,");
                sqlStr.Append("B.FILEHEADERGUIDRF AS BFILEHEADERGUIDRF,");
                sqlStr.Append("B.UPDEMPLOYEECODERF AS BUPDEMPLOYEECODERF,");
                sqlStr.Append("B.UPDASSEMBLYID1RF AS BUPDASSEMBLYID1RF,");
                sqlStr.Append("B.UPDASSEMBLYID2RF AS BUPDASSEMBLYID2RF,");
                sqlStr.Append("B.LOGICALDELETECODERF AS BLOGICALDELETECODERF,");
                sqlStr.Append("B.CUSTOMERCODERF AS BCUSTOMERCODERF,");
                sqlStr.Append("B.PURECODERF AS BPURECODERF,");
                sqlStr.Append("B.GOODSMAKERCDRF AS BGOODSMAKERCDRF,");
                sqlStr.Append("B.CUSTRATEGRPCODERF AS BCUSTRATEGRPCODERF,");

                #endregion

                #region ���Ӑ�}�X�^(�ϓ����)
                sqlStr.Append("C.CREATEDATETIMERF AS CCREATEDATETIMERF,");
                sqlStr.Append("C.UPDATEDATETIMERF AS CUPDATEDATETIMERF,");
                sqlStr.Append("C.ENTERPRISECODERF AS CENTERPRISECODERF,");
                sqlStr.Append("C.FILEHEADERGUIDRF AS CFILEHEADERGUIDRF,");
                sqlStr.Append("C.UPDEMPLOYEECODERF AS CUPDEMPLOYEECODERF,");
                sqlStr.Append("C.UPDASSEMBLYID1RF AS CUPDASSEMBLYID1RF,");
                sqlStr.Append("C.UPDASSEMBLYID2RF AS CUPDASSEMBLYID2RF,");
                sqlStr.Append("C.LOGICALDELETECODERF AS CLOGICALDELETECODERF,");
                sqlStr.Append("C.CUSTOMERCODERF AS CCUSTOMERCODERF,");
                sqlStr.Append("C.CREDITMONEYRF AS CCREDITMONEYRF,");
                sqlStr.Append("C.WARNINGCREDITMONEYRF AS CWARNINGCREDITMONEYRF,");
                sqlStr.Append("C.PRSNTACCRECBALANCERF AS CPRSNTACCRECBALANCERF,");
                #endregion

                #region ���Ӑ�}�X�^�i�`�[�Ǘ��j
                sqlStr.Append("D.CREATEDATETIMERF AS DCREATEDATETIMERF,");
                sqlStr.Append("D.UPDATEDATETIMERF AS DUPDATEDATETIMERF,");
                sqlStr.Append("D.ENTERPRISECODERF AS DENTERPRISECODERF,");
                sqlStr.Append("D.FILEHEADERGUIDRF AS DFILEHEADERGUIDRF,");
                sqlStr.Append("D.UPDEMPLOYEECODERF AS DUPDEMPLOYEECODERF,");
                sqlStr.Append("D.UPDASSEMBLYID1RF AS DUPDASSEMBLYID1RF,");
                sqlStr.Append("D.UPDASSEMBLYID2RF AS DUPDASSEMBLYID2RF,");
                sqlStr.Append("D.LOGICALDELETECODERF AS DLOGICALDELETECODERF,");
                sqlStr.Append("D.DATAINPUTSYSTEMRF AS DDATAINPUTSYSTEMRF,");
                sqlStr.Append("D.SLIPPRTKINDRF AS DSLIPPRTKINDRF,");
                sqlStr.Append("D.SECTIONCODERF AS DSECTIONCODERF,");
                sqlStr.Append("D.CUSTOMERCODERF AS DCUSTOMERCODERF,");
                sqlStr.Append("D.SLIPPRTSETPAPERIDRF AS DSLIPPRTSETPAPERIDRF,");
                #endregion

                // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                #region ���Ӑ�}�X�^(�������)
                sqlStr.Append("CUSMEMO.CREATEDATETIMERF AS FCREATEDATETIMERF,");
                sqlStr.Append("CUSMEMO.UPDATEDATETIMERF AS FUPDATEDATETIMERF,");
                sqlStr.Append("CUSMEMO.ENTERPRISECODERF AS FENTERPRISECODERF,");
                sqlStr.Append("CUSMEMO.FILEHEADERGUIDRF AS FFILEHEADERGUIDRF,");
                sqlStr.Append("CUSMEMO.UPDEMPLOYEECODERF AS FUPDEMPLOYEECODERF,");
                sqlStr.Append("CUSMEMO.UPDASSEMBLYID1RF AS FUPDASSEMBLYID1RF,");
                sqlStr.Append("CUSMEMO.UPDASSEMBLYID2RF AS FUPDASSEMBLYID2RF,");
                sqlStr.Append("CUSMEMO.LOGICALDELETECODERF AS FLOGICALDELETECODERF,");
                sqlStr.Append("CUSMEMO.CUSTOMERCODERF AS FCUSTOMERCODERF,");
                sqlStr.Append("CUSMEMO.NOTEINFORF AS FNOTEINFORF,");
                sqlStr.Append("ISNULL(CUSMEMO.DISPLAYDIVCODERF, 0) AS FDISPLAYDIVCODERF,");
                #endregion
                // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<

                #region ���Ӑ�}�X�^(�`�[�ԍ�)
                sqlStr.Append("E.CREATEDATETIMERF AS ECREATEDATETIMERF,");
                sqlStr.Append("E.UPDATEDATETIMERF AS EUPDATEDATETIMERF,");
                sqlStr.Append("E.ENTERPRISECODERF AS EENTERPRISECODERF,");
                sqlStr.Append("E.FILEHEADERGUIDRF AS EFILEHEADERGUIDRF,");
                sqlStr.Append("E.UPDEMPLOYEECODERF AS EUPDEMPLOYEECODERF,");
                sqlStr.Append("E.UPDASSEMBLYID1RF AS EUPDASSEMBLYID1RF,");
                sqlStr.Append("E.UPDASSEMBLYID2RF AS EUPDASSEMBLYID2RF,");
                sqlStr.Append("E.LOGICALDELETECODERF AS ELOGICALDELETECODERF,");
                sqlStr.Append("E.CUSTOMERCODERF AS ECUSTOMERCODERF,");
                sqlStr.Append("E.ADDUPYEARMONTHRF AS EADDUPYEARMONTHRF,");
                sqlStr.Append("E.PRESENTCUSTSLIPNORF AS EPRESENTCUSTSLIPNORF,");
                sqlStr.Append("E.STARTCUSTSLIPNORF AS ESTARTCUSTSLIPNORF,");
                sqlStr.Append("E.ENDCUSTSLIPNORF AS EENDCUSTSLIPNORF");
                #endregion
                #endregion

                #region FROM
                sqlStr.Append(" FROM  CUSTOMERRF AS A ");
                sqlStr.Append(" LEFT JOIN CUSTRATEGROUPRF AS B ");
                sqlStr.Append(" ON B.ENTERPRISECODERF = A.ENTERPRISECODERF ");
                sqlStr.Append(" AND B.CUSTOMERCODERF = A.CUSTOMERCODERF ");
                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND B.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");   
                }
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND B.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                }

                sqlStr.Append(" LEFT JOIN CUSTOMERCHANGERF AS C ");
                sqlStr.Append(" ON C.ENTERPRISECODERF = A.ENTERPRISECODERF ");
                sqlStr.Append(" AND C.CUSTOMERCODERF = A.CUSTOMERCODERF ");
                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND C.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                }
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND C.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                }

                sqlStr.Append(" LEFT JOIN CUSTSLIPMNGRF AS D ");
                sqlStr.Append(" ON D.ENTERPRISECODERF = A.ENTERPRISECODERF ");
                sqlStr.Append(" AND D.CUSTOMERCODERF = A.CUSTOMERCODERF ");
                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND D.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                }
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND D.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                }

                sqlStr.Append(" LEFT JOIN CUSTSLIPNOSETRF AS E ");
                sqlStr.Append(" ON E.ENTERPRISECODERF = A.ENTERPRISECODERF ");
                sqlStr.Append(" AND E.CUSTOMERCODERF = A.CUSTOMERCODERF ");
                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND E.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                }
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND E.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                }

                // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                sqlStr.Append(" LEFT JOIN CUSTOMERMEMORF AS CUSMEMO ");
                sqlStr.Append(" ON CUSMEMO.ENTERPRISECODERF = A.ENTERPRISECODERF ");
                sqlStr.Append(" AND CUSMEMO.CUSTOMERCODERF = A.CUSTOMERCODERF ");
                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND CUSMEMO.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                }
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND CUSMEMO.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                }
                // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                #endregion

                #region WHERE
                //���Ӑ�}�X�^�D��ƃR�[�h���p�����[�^�D��ƃR�[�h
                sqlStr.Append(" WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);

                //���Ӑ�}�X�^�D���Ӑ�R�[�h���p�����[�^�D�J�n����1
                if (param.CustomerCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND A.CUSTOMERCODERF >= @CUSTOMERCODEBEGINRF");
                    SqlParameter customerCodeBeginRF = sqlCommand.Parameters.Add("@CUSTOMERCODEBEGINRF", SqlDbType.Int);
                    customerCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeBeginRF);
                }
                //���Ӑ�}�X�^�D���Ӑ�R�[�h���p�����[�^�D�I������1
                if (param.CustomerCodeEndRF != 0)
                {
                    sqlStr.Append(" AND A.CUSTOMERCODERF <= @CUSTOMERCODEENDRF");
                    SqlParameter customerCodeEndRF = sqlCommand.Parameters.Add("@CUSTOMERCODEENDRF", SqlDbType.Int);
                    customerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeEndRF);
                }
                //���Ӑ�}�X�^�D�J�i���p�����[�^�D�J�n����2
                if (!string.IsNullOrEmpty(param.KanaBeginRF))
                {
                    sqlStr.Append(" AND A.KANARF >= @KANABEGINRF");
                    SqlParameter kanaBeginRF = sqlCommand.Parameters.Add("@KANABEGINRF", SqlDbType.NVarChar);
                    kanaBeginRF.Value = SqlDataMediator.SqlSetString(param.KanaBeginRF);
                }
                //���Ӑ�}�X�^�D�J�i���p�����[�^�D�I������2
                if (!string.IsNullOrEmpty(param.KanaEndRF))
                {
                    sqlStr.Append(" AND A.KANARF <= @KANAENDRF");
                    SqlParameter kanaEndRF = sqlCommand.Parameters.Add("@KANAENDRF", SqlDbType.NVarChar);
                    kanaEndRF.Value = SqlDataMediator.SqlSetString(param.KanaEndRF);
                }
                //���Ӑ�}�X�^�D�Ǘ����_�R�[�h���p�����[�^�D�J�n����3
                if (!string.IsNullOrEmpty(param.MngSectionCodeBeginRF))
                {
                    sqlStr.Append(" AND A.MNGSECTIONCODERF >= @MNGSECTIONCODEBEGINRF");
                    SqlParameter mngSectionCodeBeginRF = sqlCommand.Parameters.Add("@MNGSECTIONCODEBEGINRF", SqlDbType.NChar);
                    mngSectionCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.MngSectionCodeBeginRF);
                }
                //���Ӑ�}�X�^�D�Ǘ����_�R�[�h���p�����[�^�D�I������3
                if (!string.IsNullOrEmpty(param.MngSectionCodeEndRF))
                {
                    sqlStr.Append(" AND A.MNGSECTIONCODERF <= @MNGSECTIONCODEENDRF");
                    SqlParameter mngSectionCodeEndRF = sqlCommand.Parameters.Add("@MNGSECTIONCODEENDRF", SqlDbType.NChar);
                    mngSectionCodeEndRF.Value = SqlDataMediator.SqlSetString(param.MngSectionCodeEndRF);
                }
                //���Ӑ�}�X�^�D�ڋq�S���]�ƈ��R�[�h���p�����[�^�D�J�n����4
                if (!string.IsNullOrEmpty(param.CustomerAgentCdBeginRF))
                {
                    sqlStr.Append(" AND A.CUSTOMERAGENTCDRF >= @CUSTOMERAGENTCDBEGINRF");
                    SqlParameter customerAgentCdBeginRF = sqlCommand.Parameters.Add("@CUSTOMERAGENTCDBEGINRF", SqlDbType.NChar);
                    customerAgentCdBeginRF.Value = SqlDataMediator.SqlSetString(param.CustomerAgentCdBeginRF);
                }
                //���Ӑ�}�X�^�D�ڋq�S���]�ƈ��R�[�h���p�����[�^�D�I������4
                if (!string.IsNullOrEmpty(param.CustomerAgentCdEndRF))
                {
                    sqlStr.Append(" AND A.CUSTOMERAGENTCDRF <= @CUSTOMERAGENTCDENDRF");
                    SqlParameter customerAgentCdEndRF = sqlCommand.Parameters.Add("@CUSTOMERAGENTCDENDRF", SqlDbType.NChar);
                    customerAgentCdEndRF.Value = SqlDataMediator.SqlSetString(param.CustomerAgentCdEndRF);
                }
                //���Ӑ�}�X�^�D�̔��G���A�R�[�h���p�����[�^�D�J�n����5
                if (param.SalesAreaCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND A.SALESAREACODERF >= @SALESAREACODEBEGINRF");
                    SqlParameter salesAreaCodeBeginRF = sqlCommand.Parameters.Add("@SALESAREACODEBEGINRF", SqlDbType.Int);
                    salesAreaCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SalesAreaCodeBeginRF);
                }
                //���Ӑ�}�X�^�D�̔��G���A�R�[�h���p�����[�^�D�I������5
                if (param.SalesAreaCodeEndRF != 0)
                {
                    sqlStr.Append(" AND A.SALESAREACODERF <= @SALESAREACODEENDRF");
                    SqlParameter salesAreaCodeEndRF = sqlCommand.Parameters.Add("@SALESAREACODEENDRF", SqlDbType.Int);
                    salesAreaCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.SalesAreaCodeEndRF);
                }
                //���Ӑ�}�X�^�D�Ǝ�R�[�h���p�����[�^�D�J�n����6
                if (param.BusinessTypeCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND A.BUSINESSTYPECODERF >= @BUSINESSTYPECODEBEGINRF");
                    SqlParameter businessTypeCodeBeginRF = sqlCommand.Parameters.Add("@BUSINESSTYPECODEBEGINRF", SqlDbType.Int);
                    businessTypeCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BusinessTypeCodeBeginRF);
                }
                //���Ӑ�}�X�^�D�Ǝ�R�[�h���p�����[�^�D�I������6
                if (param.BusinessTypeCodeEndRF != 0)
                {
                    sqlStr.Append(" AND A.BUSINESSTYPECODERF <= @BUSINESSTYPECODEENDRF");
                    SqlParameter businessTypeCodeEndRF = sqlCommand.Parameters.Add("@BUSINESSTYPECODEENDRF", SqlDbType.Int);
                    businessTypeCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BusinessTypeCodeEndRF);
                }
                //���Ӑ�}�X�^�D�X�V���t>�p�����[�^�D�J�n���t
                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND A.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                }
                //���Ӑ�}�X�^�D�X�V���t���p�����[�^�D�I�����t
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND A.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                }
                #endregion

                #region ORDER BY
                sqlStr.Append(" ORDER BY A.ENTERPRISECODERF,A.CUSTOMERCODERF,B.PURECODERF,B.GOODSMAKERCDRF,D.DATAINPUTSYSTEMRF,D.SLIPPRTKINDRF,D.SECTIONCODERF,E.ADDUPYEARMONTHRF");
                #endregion

                //���Ӑ�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr.ToString();

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();                
                if (myReader.HasRows)
                {
                    SetCustomerIndex(myReader);
                    SetCustRateGroupIndex(myReader);
                    SetCustomerChangeIndex(myReader);
                    SetCustSlipMngIndex(myReader);
                    SetCustSlipNoIndex(myReader);
                    SetCustomerMemoIndex(myReader); // ADD 2021/04/12 ���O FOR PMKOBETSU-4136
                }
                DateTime min = DateTime.MinValue;
                while (myReader.Read())
                {
                    aPK = SqlDataMediator.SqlGetInt32(myReader, _indexACustomerCode).ToString();
                    if (!customerHashTbl.Contains(aPK))
                    {
                        customerHashTbl.Add(aPK, emptyValue);
                        customerList.Add(CopyFromMyReaderToDCCustomerWork(myReader));
                    }
                    if (min.CompareTo(SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexBUpdateDateTime)) < 0)
                    {
                        bPK = SqlDataMediator.SqlGetInt32(myReader, _indexBCustomerCode).ToString() + space + SqlDataMediator.SqlGetInt32(myReader, _indexBGoodsMakerCd).ToString() + space + SqlDataMediator.SqlGetInt32(myReader, _indexBPureCode).ToString();
                        if (!custRateGroupHashTbl.Contains(bPK))
                        {
                            custRateGroupHashTbl.Add(bPK, emptyValue);
                            custRateGroupList.Add(CopyFromMyReaderToDCCustRateGroupWork(myReader));
                        }
                    }
                    if (min.CompareTo(SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexCUpdateDateTime)) < 0)
                    {
                        cPK = SqlDataMediator.SqlGetInt32(myReader, _indexCCustomerCode).ToString();
                        if (!customerChangeHashTbl.Contains(cPK))
                        {
                            customerChangeHashTbl.Add(cPK, emptyValue);
                            customerChangeList.Add(CopyFromMyReaderToDCCustomerChangeWork(myReader));
                        }
                    }
                    // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                    if (min.CompareTo(SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexFUpdateDateTime)) < 0)
                    {
                        cPK = SqlDataMediator.SqlGetInt32(myReader, _indexFCustomerCode).ToString();
                        if (!customerMemoHashTbl.Contains(cPK))
                        {
                            customerMemoHashTbl.Add(cPK, emptyValue);
                            customerMemoList.Add(CopyFromMyReaderToAPCustomerMemoWork(myReader));
                        }
                    }
                    // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                    if (min.CompareTo(SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexDUpdateDateTime)) < 0)
                    {
                        dPK = SqlDataMediator.SqlGetInt32(myReader, _indexDDataInputSystem).ToString() + space + SqlDataMediator.SqlGetInt32(myReader, _indexDSlipPrtKind).ToString() + space + SqlDataMediator.SqlGetString(myReader, _indexDSectionCode) + space + SqlDataMediator.SqlGetInt32(myReader, _indexDCustomerCode);
                        if (!custSlipMngHashTbl.Contains(dPK))
                        {
                            custSlipMngHashTbl.Add(dPK, emptyValue);
                            custSlipMngList.Add(CopyFromMyReaderToDCCustSlipMngWork(myReader));
                        }
                    }
                    if (min.CompareTo(SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexEUpdateDateTime)) < 0)
                    {
                        ePK = SqlDataMediator.SqlGetInt32(myReader, _indexECustomerCode).ToString() + space + SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, _indexEAddUpYearMonth).ToString();
                        if (!custSlipNoHashTbl.Contains(ePK))
                        {
                            custSlipNoHashTbl.Add(ePK, emptyValue);
                            custSlipNoList.Add(CopyFromMyReaderToDCCustSlipNoSetWork(myReader));
                        }
                    }
                }
                customerArrList.Add(customerList);
                customerArrList.Add(custRateGroupList);
                customerArrList.Add(customerChangeList);
                customerArrList.Add(custSlipMngList);
                customerArrList.Add(custSlipNoList);
                customerArrList.Add(customerMemoList); // ADD 2021/04/12 ���O FOR PMKOBETSU-4136
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DCCustomerDB.SearchALLCustomerProc Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }            
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        //-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        /// <summary>
        /// ���Ӑ�}�X�^�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>���Ӑ�}�X�^�f�[�^</returns>
        /// <br>Note       : ���Ӑ�}�X�^�f�[�^��߂��܂�</br>
        /// <br>Programmer : �g���Y</br>
        /// <br>Date       : 2011/08/20</br>
        private DCCustomerWork CopyFromMyReaderToDCCustomerWork(SqlDataReader myReader)
        {
            DCCustomerWork customerWork = new DCCustomerWork();

            #region DEL #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�
            //customerWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            //customerWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            //customerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            //customerWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            //customerWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            //customerWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            //customerWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            //customerWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            //customerWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
            //customerWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
            //customerWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
            //customerWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
            //customerWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
            //customerWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            //customerWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
            //customerWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
            //customerWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
            //customerWork.CustomerAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERATTRIBUTEDIVRF"));
            //customerWork.JobTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOBTYPECODERF"));
            //customerWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            //customerWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            //customerWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
            //customerWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
            //customerWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
            //customerWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
            //customerWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
            //customerWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
            //customerWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
            //customerWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
            //customerWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
            //customerWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
            //customerWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
            //customerWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
            //customerWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
            //customerWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
            //customerWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
            //customerWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
            //customerWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
            //customerWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
            //customerWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
            //customerWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
            //customerWork.BillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLOUTPUTCODERF"));
            //customerWork.BillOutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLOUTPUTNAMERF"));
            //customerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
            //customerWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
            //customerWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
            //customerWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
            //customerWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
            //customerWork.CollectSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTSIGHTRF"));
            //customerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            //customerWork.TransStopDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TRANSSTOPDATERF"));
            //customerWork.DmOutCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTCODERF"));
            //customerWork.DmOutName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMOUTNAMERF"));
            //customerWork.MainSendMailAddrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINSENDMAILADDRCDRF"));
            //customerWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
            //customerWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
            //customerWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
            //customerWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
            //customerWork.MailSendName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME1RF"));
            //customerWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
            //customerWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
            //customerWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
            //customerWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));
            //customerWork.MailSendName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME2RF"));
            //customerWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
            //customerWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
            //customerWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
            //customerWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF"));
            //customerWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
            //customerWork.CreditMngCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITMNGCODERF"));
            //customerWork.DepoDelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPODELCODERF"));
            //customerWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            //customerWork.CustSlipNoMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNOMNGCDRF"));
            //customerWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
            //customerWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));
            //customerWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            //customerWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            //customerWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMNTDSPWAYREFRF"));
            //customerWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
            //customerWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
            //customerWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
            //customerWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));
            //customerWork.SalesMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESMONEYFRCPROCCDRF"));
            //customerWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));
            //customerWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));
            //customerWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
            //customerWork.CustomerAgent = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTRF"));
            //customerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
            //customerWork.CarMngDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGDIVCDRF"));
            //customerWork.BillPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPARTSNOPRTCDRF"));
            //customerWork.DeliPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIPARTSNOPRTCDRF"));
            //customerWork.DefSalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSALESSLIPCDRF"));
            //customerWork.LavorRateRank = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAVORRATERANKRF"));
            //customerWork.SlipTtlPrn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLPRNRF"));
            //customerWork.DepoBankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOBANKCODERF"));
            //customerWork.CustWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSECDRF"));
            //customerWork.QrcodePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRTCDRF"));
            //customerWork.DeliHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORIFICTTLRF"));
            //customerWork.BillHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORIFICTTLRF"));
            //customerWork.EstmHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORIFICTTLRF"));
            //customerWork.RectHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORIFICTTLRF"));
            //customerWork.DeliHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIHONORTTLPRTDIVRF"));
            //customerWork.BillHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLHONORTTLPRTDIVRF"));
            //customerWork.EstmHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMHONORTTLPRTDIVRF"));
            //customerWork.RectHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECTHONORTTLPRTDIVRF"));
            //customerWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
            //customerWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
            //customerWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
            //customerWork.Note4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
            //customerWork.Note5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
            //customerWork.Note6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
            //customerWork.Note7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
            //customerWork.Note8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
            //customerWork.Note9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
            //customerWork.Note10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
            //customerWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
            //customerWork.ShipmSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPPRTDIVRF"));
            //customerWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
            //customerWork.EstimatePrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));
            //customerWork.UOESlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESLIPPRTDIVRF"));
            //customerWork.ReceiptOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIPTOUTPUTCODERF"));
            //customerWork.CustomerEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMEREPCODERF"));
            //customerWork.CustomerSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSECCODERF"));
            //customerWork.OnlineKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEKINDDIVRF"));
            //customerWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));  // ���v�������o�͋敪
            //customerWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));  // ���א������o�͋敪
            //customerWork.SlipTtlBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLBILLOUTPUTDIVRF"));  // �`�[���v�������o�͋敪
            #endregion DEL #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�

            //ADD 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�--------------------------------------->>>>>
            customerWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexACreateDateTime);
            customerWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexAUpdateDateTime);
            customerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _indexAEnterpriseCode);
            customerWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _indexAFileHeaderGuid);
            customerWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _indexAUpdEmployeeCode);
            customerWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _indexAUpdAssemblyId1);
            customerWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _indexAUpdAssemblyId2);
            customerWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _indexALogicalDeleteCode);
            customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, _indexACustomerCode);
            customerWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, _indexACustomerSubCode);
            customerWork.Name = SqlDataMediator.SqlGetString(myReader, _indexAName);
            customerWork.Name2 = SqlDataMediator.SqlGetString(myReader, _indexAName2);
            customerWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, _indexAHonorificTitle);
            customerWork.Kana = SqlDataMediator.SqlGetString(myReader, _indexAKana);
            customerWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, _indexACustomerSnm);
            customerWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, _indexAOutputNameCode);
            customerWork.OutputName = SqlDataMediator.SqlGetString(myReader, _indexAOutputName);
            customerWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, _indexACorporateDivCode);
            customerWork.CustomerAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, _indexACustomerAttributeDiv);
            customerWork.JobTypeCode = SqlDataMediator.SqlGetInt32(myReader, _indexAJobTypeCode);
            customerWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, _indexABusinessTypeCode);
            customerWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, _indexASalesAreaCode);
            customerWork.PostNo = SqlDataMediator.SqlGetString(myReader, _indexAPostNo);
            customerWork.Address1 = SqlDataMediator.SqlGetString(myReader, _indexAAddress1);
            customerWork.Address3 = SqlDataMediator.SqlGetString(myReader, _indexAAddress3);
            customerWork.Address4 = SqlDataMediator.SqlGetString(myReader, _indexAAddress4);
            customerWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, _indexAHomeTelNo);
            customerWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, _indexAOfficeTelNo);
            customerWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, _indexAPortableTelNo);
            customerWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, _indexAHomeFaxNo);
            customerWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, _indexAOfficeFaxNo);
            customerWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, _indexAOthersTelNo);
            customerWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, _indexAMainContactCode);
            customerWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, _indexASearchTelNo);
            customerWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, _indexAMngSectionCode);
            customerWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, _indexAInpSectionCode);
            customerWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, _indexACustAnalysCode1);
            customerWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, _indexACustAnalysCode2);
            customerWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, _indexACustAnalysCode3);
            customerWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, _indexACustAnalysCode4);
            customerWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, _indexACustAnalysCode5);
            customerWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, _indexACustAnalysCode6);
            customerWork.BillOutputCode = SqlDataMediator.SqlGetInt32(myReader, _indexABillOutputCode);
            customerWork.BillOutputName = SqlDataMediator.SqlGetString(myReader, _indexABillOutputName);
            customerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, _indexATotalDay);
            customerWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, _indexACollectMoneyCode);
            customerWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, _indexACollectMoneyName);
            customerWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, _indexACollectMoneyDay);
            customerWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, _indexACollectCond);
            customerWork.CollectSight = SqlDataMediator.SqlGetInt32(myReader, _indexACollectSight);
            customerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, _indexAClaimCode);
            customerWork.TransStopDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexATransStopDate);
            customerWork.DmOutCode = SqlDataMediator.SqlGetInt32(myReader, _indexADmOutCode);
            customerWork.DmOutName = SqlDataMediator.SqlGetString(myReader, _indexADmOutName);
            customerWork.MainSendMailAddrCd = SqlDataMediator.SqlGetInt32(myReader, _indexAMainSendMailAddrCd);
            customerWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, _indexAMailAddrKindCode1);
            customerWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, _indexAMailAddrKindName1);
            customerWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, _indexAMailAddress1);
            customerWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, _indexAMailSendCode1);
            customerWork.MailSendName1 = SqlDataMediator.SqlGetString(myReader, _indexAMailSendName1);
            customerWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, _indexAMailAddrKindCode2);
            customerWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, _indexAMailAddrKindName2);
            customerWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, _indexAMailAddress2);
            customerWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, _indexAMailSendCode2);
            customerWork.MailSendName2 = SqlDataMediator.SqlGetString(myReader, _indexAMailSendName2);
            customerWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, _indexACustomerAgentCd);
            customerWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, _indexABillCollecterCd);
            customerWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, _indexAOldCustomerAgentCd);
            customerWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexACustAgentChgDate);
            customerWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, _indexAAcceptWholeSale);
            customerWork.CreditMngCode = SqlDataMediator.SqlGetInt32(myReader, _indexACreditMngCode);
            customerWork.DepoDelCode = SqlDataMediator.SqlGetInt32(myReader, _indexADepoDelCode);
            customerWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, _indexAAccRecDivCd);
            customerWork.CustSlipNoMngCd = SqlDataMediator.SqlGetInt32(myReader, _indexACustSlipNoMngCd);
            customerWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, _indexAPureCode);
            customerWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, _indexACustCTaXLayRefCd);
            customerWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, _indexAConsTaxLayMethod);
            customerWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, _indexATotalAmountDispWayCd);
            customerWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, _indexATotalAmntDspWayRef);
            customerWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, _indexAAccountNoInfo1);
            customerWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, _indexAAccountNoInfo2);
            customerWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, _indexAAccountNoInfo3);
            customerWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, _indexASalesUnPrcFrcProcCd);
            customerWork.SalesMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, _indexASalesMoneyFrcProcCd);
            customerWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, _indexASalesCnsTaxFrcProcCd);
            customerWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, _indexACustomerSlipNoDiv);
            customerWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, _indexANTimeCalcStDate);
            customerWork.CustomerAgent = SqlDataMediator.SqlGetString(myReader, _indexACustomerAgent);
            customerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, _indexAClaimSectionCode);
            customerWork.CarMngDivCd = SqlDataMediator.SqlGetInt32(myReader, _indexACarMngDivCd);
            customerWork.BillPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, _indexABillPartsNoPrtCd);
            customerWork.DeliPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, _indexADeliPartsNoPrtCd);
            customerWork.DefSalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, _indexADefSalesSlipCd);
            customerWork.LavorRateRank = SqlDataMediator.SqlGetInt32(myReader, _indexALavorRateRank);
            customerWork.SlipTtlPrn = SqlDataMediator.SqlGetInt32(myReader, _indexASlipTtlPrn);
            customerWork.DepoBankCode = SqlDataMediator.SqlGetInt32(myReader, _indexADepoBankCode);
            customerWork.CustWarehouseCd = SqlDataMediator.SqlGetString(myReader, _indexACustWarehouseCd);
            customerWork.QrcodePrtCd = SqlDataMediator.SqlGetInt32(myReader, _indexAQrcodePrtCd);
            customerWork.DeliHonorificTtl = SqlDataMediator.SqlGetString(myReader, _indexADeliHonorificTtl);
            customerWork.BillHonorificTtl = SqlDataMediator.SqlGetString(myReader, _indexABillHonorificTtl);
            customerWork.EstmHonorificTtl = SqlDataMediator.SqlGetString(myReader, _indexAEstmHonorificTtl);
            customerWork.RectHonorificTtl = SqlDataMediator.SqlGetString(myReader, _indexARectHonorificTtl);
            customerWork.DeliHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, _indexADeliHonorTtlPrtDiv);
            customerWork.BillHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, _indexABillHonorTtlPrtDiv);
            customerWork.EstmHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, _indexAEstmHonorTtlPrtDiv);
            customerWork.RectHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, _indexARectHonorTtlPrtDiv);
            customerWork.Note1 = SqlDataMediator.SqlGetString(myReader, _indexANote1);
            customerWork.Note2 = SqlDataMediator.SqlGetString(myReader, _indexANote2);
            customerWork.Note3 = SqlDataMediator.SqlGetString(myReader, _indexANote3);
            customerWork.Note4 = SqlDataMediator.SqlGetString(myReader, _indexANote4);
            customerWork.Note5 = SqlDataMediator.SqlGetString(myReader, _indexANote5);
            customerWork.Note6 = SqlDataMediator.SqlGetString(myReader, _indexANote6);
            customerWork.Note7 = SqlDataMediator.SqlGetString(myReader, _indexANote7);
            customerWork.Note8 = SqlDataMediator.SqlGetString(myReader, _indexANote8);
            customerWork.Note9 = SqlDataMediator.SqlGetString(myReader, _indexANote9);
            customerWork.Note10 = SqlDataMediator.SqlGetString(myReader, _indexANote10);
            customerWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, _indexASalesSlipPrtDiv);
            customerWork.ShipmSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, _indexAShipmSlipPrtDiv);
            customerWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, _indexAAcpOdrrSlipPrtDiv);
            customerWork.EstimatePrtDiv = SqlDataMediator.SqlGetInt32(myReader, _indexAEstimatePrtDiv);
            customerWork.UOESlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, _indexAUOESlipPrtDiv);
            customerWork.ReceiptOutputCode = SqlDataMediator.SqlGetInt32(myReader, _indexAReceiptOutputCode);
            customerWork.CustomerEpCode = SqlDataMediator.SqlGetString(myReader, _indexACustomerEpCode);
            customerWork.CustomerSecCode = SqlDataMediator.SqlGetString(myReader, _indexACustomerSecCode);
            customerWork.OnlineKindDiv = SqlDataMediator.SqlGetInt32(myReader, _indexAOnlineKindDiv);
            customerWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, _indexATotalBillOutPutDiv);  // ���v�������o�͋敪
            customerWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, _indexADetailBillOutputCode);  // ���א������o�͋敪
            customerWork.SlipTtlBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, _indexASlipTtlBillOutputDiv);  // �`�[���v�������o�͋敪
            //ADD 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�---------------------------------------<<<<<
            return customerWork;
        }
        //-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<

        /// <summary>
        /// ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        private DCCustRateGroupWork CopyFromMyReaderToDCCustRateGroupWork(SqlDataReader myReader)
        {
            DCCustRateGroupWork custRateGroupWork = new DCCustRateGroupWork();

            custRateGroupWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexBCreateDateTime);
            custRateGroupWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexBUpdateDateTime);
            custRateGroupWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _indexBEnterpriseCode);
            custRateGroupWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _indexBFileHeaderGuid);
            custRateGroupWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _indexBUpdEmployeeCode);
            custRateGroupWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _indexBUpdAssemblyId1);
            custRateGroupWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _indexBUpdAssemblyId2);
            custRateGroupWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _indexBLogicalDeleteCode);
            custRateGroupWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, _indexBCustomerCode);
            custRateGroupWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, _indexBPureCode);
            custRateGroupWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, _indexBGoodsMakerCd);
            custRateGroupWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, _indexBCustRateGrpCode);

            return custRateGroupWork;
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�ϓ����)�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>���Ӑ�}�X�^(�ϓ����)�f�[�^</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�ϓ����)�f�[�^��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        private DCCustomerChangeWork CopyFromMyReaderToDCCustomerChangeWork(SqlDataReader myReader)
        {
            DCCustomerChangeWork customerChangeWork = new DCCustomerChangeWork();

            customerChangeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexCCreateDateTime);
            customerChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexCUpdateDateTime);
            customerChangeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _indexCEnterpriseCode);
            customerChangeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _indexCFileHeaderGuid);
            customerChangeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _indexCUpdEmployeeCode);
            customerChangeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _indexCUpdAssemblyId1);
            customerChangeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _indexCUpdAssemblyId2);
            customerChangeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _indexCLogicalDeleteCode);
            customerChangeWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, _indexCCustomerCode);
            customerChangeWork.CreditMoney = SqlDataMediator.SqlGetInt64(myReader, _indexCCreditMoney);
            customerChangeWork.WarningCreditMoney = SqlDataMediator.SqlGetInt64(myReader, _indexCWarningCreditMoney);
            customerChangeWork.PrsntAccRecBalance = SqlDataMediator.SqlGetInt64(myReader, _indexCPrsntAccRecBalance);

            return customerChangeWork;
        }

        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
        /// <summary>
        /// ���Ӑ�}�X�^(�������)�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>���Ӑ�}�X�^(�������)�f�[�^</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�������)�f�[�^��߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/04/12</br>
        private DCCustomerMemoWork CopyFromMyReaderToAPCustomerMemoWork(SqlDataReader myReader)
        {
            DCCustomerMemoWork customerMemoWork = new DCCustomerMemoWork();

            customerMemoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexFCreateDateTime);
            customerMemoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexFUpdateDateTime);
            customerMemoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _indexFEnterpriseCode);
            customerMemoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _indexFFileHeaderGuid);
            customerMemoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _indexFUpdEmployeeCode);
            customerMemoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _indexFUpdAssemblyId1);
            customerMemoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _indexFUpdAssemblyId2);
            customerMemoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _indexFLogicalDeleteCode);
            customerMemoWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, _indexFCustomerCode);
            customerMemoWork.NoteInfo = SqlDataMediator.SqlGetString(myReader, _indexFNoteInfo);
            customerMemoWork.DisplayDivCode = SqlDataMediator.SqlGetInt32(myReader, _indexFDisplayDivCode);

            return customerMemoWork;
        }
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        private DCCustSlipMngWork CopyFromMyReaderToDCCustSlipMngWork(SqlDataReader myReader)
        {
            DCCustSlipMngWork custSlipMngWork = new DCCustSlipMngWork();

            custSlipMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexDCreateDateTime);
            custSlipMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexDUpdateDateTime);
            custSlipMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _indexDEnterpriseCode);
            custSlipMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _indexDFileHeaderGuid);
            custSlipMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _indexDUpdEmployeeCode);
            custSlipMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _indexDUpdAssemblyId1);
            custSlipMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _indexDUpdAssemblyId2);
            custSlipMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _indexDLogicalDeleteCode);
            custSlipMngWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, _indexDDataInputSystem);
            custSlipMngWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, _indexDSlipPrtKind);
            custSlipMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, _indexDSectionCode);
            custSlipMngWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, _indexDCustomerCode);
            custSlipMngWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, _indexDSlipPrtSetPaperId);

            return custSlipMngWork;
        }

        /// <summary>
        /// ���Ӑ�}�X�^(�`�[�ԍ�)�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>���Ӑ�}�X�^(�`�[�ԍ�)�f�[�^</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�ԍ�)�f�[�^��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        private DCCustSlipNoSetWork CopyFromMyReaderToDCCustSlipNoSetWork(SqlDataReader myReader)
        {
            DCCustSlipNoSetWork custSlipNoSetWork = new DCCustSlipNoSetWork();

            custSlipNoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexECreateDateTime);
            custSlipNoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexEUpdateDateTime);
            custSlipNoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _indexEEnterpriseCode);
            custSlipNoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _indexEFileHeaderGuid);
            custSlipNoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _indexEUpdEmployeeCode);
            custSlipNoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _indexEUpdAssemblyId1);
            custSlipNoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _indexEUpdAssemblyId2);
            custSlipNoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _indexELogicalDeleteCode);
            custSlipNoSetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, _indexECustomerCode);
            custSlipNoSetWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, _indexEAddUpYearMonth);
            custSlipNoSetWork.PresentCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, _indexEPresentCustSlipNo);
            custSlipNoSetWork.StartCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, _indexEStartCustSlipNo);
            custSlipNoSetWork.EndCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, _indexEEndCustSlipNo);

            return custSlipNoSetWork;
        }

        /// <summary>
        /// �J�����C���f�b�N�X�i�[����
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : �J�����C���f�b�N�X�i�[�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        /// </remarks>
        private void SetCustomerIndex(SqlDataReader myReader)
        {
            _indexACreateDateTime = myReader.GetOrdinal("ACREATEDATETIMERF");
            _indexAUpdateDateTime = myReader.GetOrdinal("AUPDATEDATETIMERF");
            _indexAEnterpriseCode = myReader.GetOrdinal("AENTERPRISECODERF");
            _indexAFileHeaderGuid = myReader.GetOrdinal("AFILEHEADERGUIDRF");
            _indexAUpdEmployeeCode = myReader.GetOrdinal("AUPDEMPLOYEECODERF");
            _indexAUpdAssemblyId1 = myReader.GetOrdinal("AUPDASSEMBLYID1RF");
            _indexAUpdAssemblyId2 = myReader.GetOrdinal("AUPDASSEMBLYID2RF");
            _indexALogicalDeleteCode = myReader.GetOrdinal("ALOGICALDELETECODERF");
            _indexACustomerCode = myReader.GetOrdinal("ACUSTOMERCODERF");
            _indexACustomerSubCode = myReader.GetOrdinal("ACUSTOMERSUBCODERF");
            _indexAName = myReader.GetOrdinal("ANAMERF");
            _indexAName2 = myReader.GetOrdinal("ANAME2RF");
            _indexAHonorificTitle = myReader.GetOrdinal("AHONORIFICTITLERF");
            _indexAKana = myReader.GetOrdinal("AKANARF");
            _indexACustomerSnm = myReader.GetOrdinal("ACUSTOMERSNMRF");
            _indexAOutputNameCode = myReader.GetOrdinal("AOUTPUTNAMECODERF");
            _indexAOutputName = myReader.GetOrdinal("AOUTPUTNAMERF");
            _indexACorporateDivCode = myReader.GetOrdinal("ACORPORATEDIVCODERF");
            _indexACustomerAttributeDiv = myReader.GetOrdinal("ACUSTOMERATTRIBUTEDIVRF");
            _indexAJobTypeCode = myReader.GetOrdinal("AJOBTYPECODERF");
            _indexABusinessTypeCode = myReader.GetOrdinal("ABUSINESSTYPECODERF");
            _indexASalesAreaCode = myReader.GetOrdinal("ASALESAREACODERF");
            _indexAPostNo = myReader.GetOrdinal("APOSTNORF");
            _indexAAddress1 = myReader.GetOrdinal("AADDRESS1RF");
            _indexAAddress3 = myReader.GetOrdinal("AADDRESS3RF");
            _indexAAddress4 = myReader.GetOrdinal("AADDRESS4RF");
            _indexAHomeTelNo = myReader.GetOrdinal("AHOMETELNORF");
            _indexAOfficeTelNo = myReader.GetOrdinal("AOFFICETELNORF");
            _indexAPortableTelNo = myReader.GetOrdinal("APORTABLETELNORF");
            _indexAHomeFaxNo = myReader.GetOrdinal("AHOMEFAXNORF");
            _indexAOfficeFaxNo = myReader.GetOrdinal("AOFFICEFAXNORF");
            _indexAOthersTelNo = myReader.GetOrdinal("AOTHERSTELNORF");
            _indexAMainContactCode = myReader.GetOrdinal("AMAINCONTACTCODERF");
            _indexASearchTelNo = myReader.GetOrdinal("ASEARCHTELNORF");
            _indexAMngSectionCode = myReader.GetOrdinal("AMNGSECTIONCODERF");
            _indexAInpSectionCode = myReader.GetOrdinal("AINPSECTIONCODERF");
            _indexACustAnalysCode1 = myReader.GetOrdinal("ACUSTANALYSCODE1RF");
            _indexACustAnalysCode2 = myReader.GetOrdinal("ACUSTANALYSCODE2RF");
            _indexACustAnalysCode3 = myReader.GetOrdinal("ACUSTANALYSCODE3RF");
            _indexACustAnalysCode4 = myReader.GetOrdinal("ACUSTANALYSCODE4RF");
            _indexACustAnalysCode5 = myReader.GetOrdinal("ACUSTANALYSCODE5RF");
            _indexACustAnalysCode6 = myReader.GetOrdinal("ACUSTANALYSCODE6RF");
            _indexABillOutputCode = myReader.GetOrdinal("ABILLOUTPUTCODERF");
            _indexABillOutputName = myReader.GetOrdinal("ABILLOUTPUTNAMERF");
            _indexATotalDay = myReader.GetOrdinal("ATOTALDAYRF");
            _indexACollectMoneyCode = myReader.GetOrdinal("ACOLLECTMONEYCODERF");
            _indexACollectMoneyName = myReader.GetOrdinal("ACOLLECTMONEYNAMERF");
            _indexACollectMoneyDay = myReader.GetOrdinal("ACOLLECTMONEYDAYRF");
            _indexACollectCond = myReader.GetOrdinal("ACOLLECTCONDRF");
            _indexACollectSight = myReader.GetOrdinal("ACOLLECTSIGHTRF");
            _indexAClaimCode = myReader.GetOrdinal("ACLAIMCODERF");
            _indexATransStopDate = myReader.GetOrdinal("ATRANSSTOPDATERF");
            _indexADmOutCode = myReader.GetOrdinal("ADMOUTCODERF");
            _indexADmOutName = myReader.GetOrdinal("ADMOUTNAMERF");
            _indexAMainSendMailAddrCd = myReader.GetOrdinal("AMAINSENDMAILADDRCDRF");
            _indexAMailAddrKindCode1 = myReader.GetOrdinal("AMAILADDRKINDCODE1RF");
            _indexAMailAddrKindName1 = myReader.GetOrdinal("AMAILADDRKINDNAME1RF");
            _indexAMailAddress1 = myReader.GetOrdinal("AMAILADDRESS1RF");
            _indexAMailSendCode1 = myReader.GetOrdinal("AMAILSENDCODE1RF");
            _indexAMailSendName1 = myReader.GetOrdinal("AMAILSENDNAME1RF");
            _indexAMailAddrKindCode2 = myReader.GetOrdinal("AMAILADDRKINDCODE2RF");
            _indexAMailAddrKindName2 = myReader.GetOrdinal("AMAILADDRKINDNAME2RF");
            _indexAMailAddress2 = myReader.GetOrdinal("AMAILADDRESS2RF");
            _indexAMailSendCode2 = myReader.GetOrdinal("AMAILSENDCODE2RF");
            _indexAMailSendName2 = myReader.GetOrdinal("AMAILSENDNAME2RF");
            _indexACustomerAgentCd = myReader.GetOrdinal("ACUSTOMERAGENTCDRF");
            _indexABillCollecterCd = myReader.GetOrdinal("ABILLCOLLECTERCDRF");
            _indexAOldCustomerAgentCd = myReader.GetOrdinal("AOLDCUSTOMERAGENTCDRF");
            _indexACustAgentChgDate = myReader.GetOrdinal("ACUSTAGENTCHGDATERF");
            _indexAAcceptWholeSale = myReader.GetOrdinal("AACCEPTWHOLESALERF");
            _indexACreditMngCode = myReader.GetOrdinal("ACREDITMNGCODERF");
            _indexADepoDelCode = myReader.GetOrdinal("ADEPODELCODERF");
            _indexAAccRecDivCd = myReader.GetOrdinal("AACCRECDIVCDRF");
            _indexACustSlipNoMngCd = myReader.GetOrdinal("ACUSTSLIPNOMNGCDRF");
            _indexAPureCode = myReader.GetOrdinal("APURECODERF");
            _indexACustCTaXLayRefCd = myReader.GetOrdinal("ACUSTCTAXLAYREFCDRF");
            _indexAConsTaxLayMethod = myReader.GetOrdinal("ACONSTAXLAYMETHODRF");
            _indexATotalAmountDispWayCd = myReader.GetOrdinal("ATOTALAMOUNTDISPWAYCDRF");
            _indexATotalAmntDspWayRef = myReader.GetOrdinal("ATOTALAMNTDSPWAYREFRF");
            _indexAAccountNoInfo1 = myReader.GetOrdinal("AACCOUNTNOINFO1RF");
            _indexAAccountNoInfo2 = myReader.GetOrdinal("AACCOUNTNOINFO2RF");
            _indexAAccountNoInfo3 = myReader.GetOrdinal("AACCOUNTNOINFO3RF");
            _indexASalesUnPrcFrcProcCd = myReader.GetOrdinal("ASALESUNPRCFRCPROCCDRF");
            _indexASalesMoneyFrcProcCd = myReader.GetOrdinal("ASALESMONEYFRCPROCCDRF");
            _indexASalesCnsTaxFrcProcCd = myReader.GetOrdinal("ASALESCNSTAXFRCPROCCDRF");
            _indexACustomerSlipNoDiv = myReader.GetOrdinal("ACUSTOMERSLIPNODIVRF");
            _indexANTimeCalcStDate = myReader.GetOrdinal("ANTIMECALCSTDATERF");
            _indexACustomerAgent = myReader.GetOrdinal("ACUSTOMERAGENTRF");
            _indexAClaimSectionCode = myReader.GetOrdinal("ACLAIMSECTIONCODERF");
            _indexACarMngDivCd = myReader.GetOrdinal("ACARMNGDIVCDRF");
            _indexABillPartsNoPrtCd = myReader.GetOrdinal("ABILLPARTSNOPRTCDRF");
            _indexADeliPartsNoPrtCd = myReader.GetOrdinal("ADELIPARTSNOPRTCDRF");
            _indexADefSalesSlipCd = myReader.GetOrdinal("ADEFSALESSLIPCDRF");
            _indexALavorRateRank = myReader.GetOrdinal("ALAVORRATERANKRF");
            _indexASlipTtlPrn = myReader.GetOrdinal("ASLIPTTLPRNRF");
            _indexADepoBankCode = myReader.GetOrdinal("ADEPOBANKCODERF");
            _indexACustWarehouseCd = myReader.GetOrdinal("ACUSTWAREHOUSECDRF");
            _indexAQrcodePrtCd = myReader.GetOrdinal("AQRCODEPRTCDRF");
            _indexADeliHonorificTtl = myReader.GetOrdinal("ADELIHONORIFICTTLRF");
            _indexABillHonorificTtl = myReader.GetOrdinal("ABILLHONORIFICTTLRF");
            _indexAEstmHonorificTtl = myReader.GetOrdinal("AESTMHONORIFICTTLRF");
            _indexARectHonorificTtl = myReader.GetOrdinal("ARECTHONORIFICTTLRF");
            _indexADeliHonorTtlPrtDiv = myReader.GetOrdinal("ADELIHONORTTLPRTDIVRF");
            _indexABillHonorTtlPrtDiv = myReader.GetOrdinal("ABILLHONORTTLPRTDIVRF");
            _indexAEstmHonorTtlPrtDiv = myReader.GetOrdinal("AESTMHONORTTLPRTDIVRF");
            _indexARectHonorTtlPrtDiv = myReader.GetOrdinal("ARECTHONORTTLPRTDIVRF");
            _indexANote1 = myReader.GetOrdinal("ANOTE1RF");
            _indexANote2 = myReader.GetOrdinal("ANOTE2RF");
            _indexANote3 = myReader.GetOrdinal("ANOTE3RF");
            _indexANote4 = myReader.GetOrdinal("ANOTE4RF");
            _indexANote5 = myReader.GetOrdinal("ANOTE5RF");
            _indexANote6 = myReader.GetOrdinal("ANOTE6RF");
            _indexANote7 = myReader.GetOrdinal("ANOTE7RF");
            _indexANote8 = myReader.GetOrdinal("ANOTE8RF");
            _indexANote9 = myReader.GetOrdinal("ANOTE9RF");
            _indexANote10 = myReader.GetOrdinal("ANOTE10RF");
            _indexASalesSlipPrtDiv = myReader.GetOrdinal("ASALESSLIPPRTDIVRF");
            _indexAShipmSlipPrtDiv = myReader.GetOrdinal("ASHIPMSLIPPRTDIVRF");
            _indexAAcpOdrrSlipPrtDiv = myReader.GetOrdinal("AACPODRRSLIPPRTDIVRF");
            _indexAEstimatePrtDiv = myReader.GetOrdinal("AESTIMATEPRTDIVRF");
            _indexAUOESlipPrtDiv = myReader.GetOrdinal("AUOESLIPPRTDIVRF");
            _indexAReceiptOutputCode = myReader.GetOrdinal("ARECEIPTOUTPUTCODERF");
            _indexACustomerEpCode = myReader.GetOrdinal("ACUSTOMEREPCODERF");
            _indexACustomerSecCode = myReader.GetOrdinal("ACUSTOMERSECCODERF");
            _indexAOnlineKindDiv = myReader.GetOrdinal("AONLINEKINDDIVRF");
            _indexATotalBillOutPutDiv = myReader.GetOrdinal("ATOTALBILLOUTPUTDIVRF");// ���v�������o�͋敪
            _indexADetailBillOutputCode = myReader.GetOrdinal("ADETAILBILLOUTPUTCODERF");
            _indexASlipTtlBillOutputDiv = myReader.GetOrdinal("ASLIPTTLBILLOUTPUTDIVRF");
        }

        /// <summary>
        /// �J�����C���f�b�N�X�i�[����
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : �J�����C���f�b�N�X�i�[�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        /// </remarks>
        private void SetCustRateGroupIndex(SqlDataReader myReader)
        {
            _indexBCreateDateTime = myReader.GetOrdinal("BCREATEDATETIMERF");
            _indexBUpdateDateTime = myReader.GetOrdinal("BUPDATEDATETIMERF");
            _indexBEnterpriseCode = myReader.GetOrdinal("BENTERPRISECODERF");
            _indexBFileHeaderGuid = myReader.GetOrdinal("BFILEHEADERGUIDRF");
            _indexBUpdEmployeeCode = myReader.GetOrdinal("BUPDEMPLOYEECODERF");
            _indexBUpdAssemblyId1 = myReader.GetOrdinal("BUPDASSEMBLYID1RF");
            _indexBUpdAssemblyId2 = myReader.GetOrdinal("BUPDASSEMBLYID2RF");
            _indexBLogicalDeleteCode = myReader.GetOrdinal("BLOGICALDELETECODERF");
            _indexBCustomerCode = myReader.GetOrdinal("BCUSTOMERCODERF");
            _indexBPureCode = myReader.GetOrdinal("BPURECODERF");
            _indexBGoodsMakerCd = myReader.GetOrdinal("BGOODSMAKERCDRF");
            _indexBCustRateGrpCode = myReader.GetOrdinal("BCUSTRATEGRPCODERF");

        }

        /// <summary>
        /// �J�����C���f�b�N�X�i�[����
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : �J�����C���f�b�N�X�i�[�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        /// </remarks>
        private void SetCustomerChangeIndex(SqlDataReader myReader)
        {
            _indexCCreateDateTime = myReader.GetOrdinal("CCREATEDATETIMERF");
            _indexCUpdateDateTime = myReader.GetOrdinal("CUPDATEDATETIMERF");
            _indexCEnterpriseCode = myReader.GetOrdinal("CENTERPRISECODERF");
            _indexCFileHeaderGuid = myReader.GetOrdinal("CFILEHEADERGUIDRF");
            _indexCUpdEmployeeCode = myReader.GetOrdinal("CUPDEMPLOYEECODERF");
            _indexCUpdAssemblyId1 = myReader.GetOrdinal("CUPDASSEMBLYID1RF");
            _indexCUpdAssemblyId2 = myReader.GetOrdinal("CUPDASSEMBLYID2RF");
            _indexCLogicalDeleteCode = myReader.GetOrdinal("CLOGICALDELETECODERF");
            _indexCCustomerCode = myReader.GetOrdinal("CCUSTOMERCODERF");
            _indexCCreditMoney = myReader.GetOrdinal("CCREDITMONEYRF");
            _indexCWarningCreditMoney = myReader.GetOrdinal("CWARNINGCREDITMONEYRF");
            _indexCPrsntAccRecBalance = myReader.GetOrdinal("CPRSNTACCRECBALANCERF");
        }

        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
        /// <summary>
        /// �J�����C���f�b�N�X�i�[����
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : �J�����C���f�b�N�X�i�[�������s��</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/04/12</br>
        /// </remarks>
        private void SetCustomerMemoIndex(SqlDataReader myReader)
        {
            _indexFCreateDateTime = myReader.GetOrdinal("FCREATEDATETIMERF");
            _indexFUpdateDateTime = myReader.GetOrdinal("FUPDATEDATETIMERF");
            _indexFEnterpriseCode = myReader.GetOrdinal("FENTERPRISECODERF");
            _indexFFileHeaderGuid = myReader.GetOrdinal("FFILEHEADERGUIDRF");
            _indexFUpdEmployeeCode = myReader.GetOrdinal("FUPDEMPLOYEECODERF");
            _indexFUpdAssemblyId1 = myReader.GetOrdinal("FUPDASSEMBLYID1RF");
            _indexFUpdAssemblyId2 = myReader.GetOrdinal("FUPDASSEMBLYID2RF");
            _indexFLogicalDeleteCode = myReader.GetOrdinal("FLOGICALDELETECODERF");
            _indexFCustomerCode = myReader.GetOrdinal("FCUSTOMERCODERF");
            _indexFNoteInfo = myReader.GetOrdinal("FNOTEINFORF");
            _indexFDisplayDivCode = myReader.GetOrdinal("FDISPLAYDIVCODERF");
        }
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<

        /// <summary>
        /// �J�����C���f�b�N�X�i�[����
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : �J�����C���f�b�N�X�i�[�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        /// </remarks>
        private void SetCustSlipMngIndex(SqlDataReader myReader)
        {
            _indexDCreateDateTime = myReader.GetOrdinal("DCREATEDATETIMERF");
            _indexDUpdateDateTime = myReader.GetOrdinal("DUPDATEDATETIMERF");
            _indexDEnterpriseCode = myReader.GetOrdinal("DENTERPRISECODERF");
            _indexDFileHeaderGuid = myReader.GetOrdinal("DFILEHEADERGUIDRF");
            _indexDUpdEmployeeCode = myReader.GetOrdinal("DUPDEMPLOYEECODERF");
            _indexDUpdAssemblyId1 = myReader.GetOrdinal("DUPDASSEMBLYID1RF");
            _indexDUpdAssemblyId2 = myReader.GetOrdinal("DUPDASSEMBLYID2RF");
            _indexDLogicalDeleteCode = myReader.GetOrdinal("DLOGICALDELETECODERF");
            _indexDDataInputSystem = myReader.GetOrdinal("DDATAINPUTSYSTEMRF");
            _indexDSlipPrtKind = myReader.GetOrdinal("DSLIPPRTKINDRF");
            _indexDSectionCode = myReader.GetOrdinal("DSECTIONCODERF");
            _indexDCustomerCode = myReader.GetOrdinal("DCUSTOMERCODERF");
            _indexDSlipPrtSetPaperId = myReader.GetOrdinal("DSLIPPRTSETPAPERIDRF");

        }
        /// <summary>
        /// �J�����C���f�b�N�X�i�[����
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : �J�����C���f�b�N�X�i�[�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        /// </remarks>
        private void SetCustSlipNoIndex(SqlDataReader myReader)
        {
            _indexECreateDateTime = myReader.GetOrdinal("ECREATEDATETIMERF");
            _indexEUpdateDateTime = myReader.GetOrdinal("EUPDATEDATETIMERF");
            _indexEEnterpriseCode = myReader.GetOrdinal("EENTERPRISECODERF");
            _indexEFileHeaderGuid = myReader.GetOrdinal("EFILEHEADERGUIDRF");
            _indexEUpdEmployeeCode = myReader.GetOrdinal("EUPDEMPLOYEECODERF");
            _indexEUpdAssemblyId1 = myReader.GetOrdinal("EUPDASSEMBLYID1RF");
            _indexEUpdAssemblyId2 = myReader.GetOrdinal("EUPDASSEMBLYID2RF");
            _indexELogicalDeleteCode = myReader.GetOrdinal("ELOGICALDELETECODERF");
            _indexECustomerCode = myReader.GetOrdinal("ECUSTOMERCODERF");
            _indexEAddUpYearMonth = myReader.GetOrdinal("EADDUPYEARMONTHRF");
            _indexEPresentCustSlipNo = myReader.GetOrdinal("EPRESENTCUSTSLIPNORF");
            _indexEStartCustSlipNo = myReader.GetOrdinal("ESTARTCUSTSLIPNORF");
            _indexEEndCustSlipNo = myReader.GetOrdinal("EENDCUSTSLIPNORF");
        }
        #endregion
        #endregion 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j

        // ADD 2011.08.26 ---------->>>>>
        # region [Clear]DEL by Liangsd     2011/09/06
        //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
        //// R�N���X�� Method��SQL�������ʖ�
        ///// <summary>
        ///// �f�[�^�N���A
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="sqlTransaction">�g�����U�N�V�������</param>
        ///// <param name="sqlCommand">SQL�R�����g</param>
        ///// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    ClearProc(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        //}
        ///// <summary>
        ///// �f�[�^�N���A
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="sqlTransaction">�g�����U�N�V�������</param>
        ///// <param name="sqlCommand">SQL�R�����g</param>
        ///// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //    // Delete�R�}���h�̐���
        //    sqlCommand.CommandText = "DELETE FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
        //    //Prameter�I�u�W�F�N�g�̍쐬
        //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //    //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //    findParaEnterpriseCode.Value = enterpriseCode;

        //    // ���_���ݒ�}�X�^�f�[�^���폜����
        //    sqlCommand.ExecuteNonQuery();
        //}
        //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
        #endregion
		// ADD 2011.08.26 ----------<<<<<
    }
}