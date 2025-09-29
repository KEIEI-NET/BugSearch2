//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/11  �C�����e : R�N���X��public Method��SQL�������ʖ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/18  �C�����e : Redmine#23746
//                                  �Ⴄ��ƃR�[�h�Ԃ̑���M�ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/29  �C�����e : Redmine #23896 No.16 ���t�͈̔̓`�F�b�N���폜
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/06 �C�����e :  Redmine#23918���_�Ǘ�����PG�ύX�ǉ��˗���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/09/08  �C�����e : Redmine #24562 �d�����׃f�[�^�̑��M�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/09/15  �C�����e : Redmine #24562 �d�����׃f�[�^�̑��M�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����Y
// �C �� ��  2011/10/08  �C�����e : #25780 �f�[�^���M�����@���㗚���f�[�^���M���̃^�C���A�E�g�ݒ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/11/01  �C�����e : �d�l�A�� #26228: ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/11/11  �C�����e : �d�l�A�� #26228: ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �� �� ��  2011/11/14  �C�����e : �d�l�A�� #26228: ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/30  �C�����e : Redmine#8293 ���_�Ǘ��^�`�[���t���t���o����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : �e�c ���V
// �C �� ��  2014/03/26  �C�����e : �d�|�ꗗ��2292�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���f�[�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCStockSlipDB : RemoteDB
    {
        /// <summary>
        /// �d���f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCStockSlipDB()
            : base("PMKYO07471D", "Broadleaf.Application.Remoting.ParamData.DCStockSlipWork", "STOCKSLIPRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �d���f�[�^�擾
        /// </summary>
        /// <param name="stockSlipList">�d���f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int Search(out ArrayList stockSlipList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  stockSlipList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �d���f�[�^�擾
        /// </summary>
        /// <param name="stockSlipList">�d���f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList stockSlipList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            stockSlipList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, SECTIONCODERF, SUBSECTIONCODERF, DEBITNOTEDIVRF, DEBITNLNKSUPPSLIPNORF, SUPPLIERSLIPCDRF, STOCKGOODSCDRF, ACCPAYDIVCDRF, STOCKSECTIONCDRF, STOCKADDUPSECTIONCDRF, STOCKSLIPUPDATECDRF, INPUTDAYRF, ARRIVALGOODSDAYRF, STOCKDATERF, STOCKADDUPADATERF, DELAYPAYMENTDIVRF, PAYEECODERF, PAYEESNMRF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, BUSINESSTYPECODERF, BUSINESSTYPENAMERF, SALESAREACODERF, SALESAREANAMERF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, SUPPTTLAMNTDSPWAYCDRF, TTLAMNTDISPRATEAPYRF, STOCKTOTALPRICERF, STOCKSUBTTLPRICERF, STOCKTTLPRICTAXINCRF, STOCKTTLPRICTAXEXCRF, STOCKNETPRICERF, STOCKPRICECONSTAXRF, TTLITDEDSTCOUTTAXRF, TTLITDEDSTCINTAXRF, TTLITDEDSTCTAXFREERF, STOCKOUTTAXRF, STCKPRCCONSTAXINCLURF, STCKDISTTLTAXEXCRF, ITDEDSTOCKDISOUTTAXRF, ITDEDSTOCKDISINTAXRF, ITDEDSTOCKDISTAXFRERF, STOCKDISOUTTAXRF, STCKDISTTLTAXINCLURF, TAXADJUSTRF, BALANCEADJUSTRF, SUPPCTAXLAYCDRF, SUPPLIERCONSTAXRATERF, ACCPAYCONSTAXRF, STOCKFRACTIONPROCCDRF, AUTOPAYMENTRF, AUTOPAYSLIPNUMRF, RETGOODSREASONDIVRF, RETGOODSREASONRF, PARTYSALESLIPNUMRF, SUPPLIERSLIPNOTE1RF, SUPPLIERSLIPNOTE2RF, DETAILROWCOUNTRF, EDISENDDATERF, EDITAKEINDATERF, UOEREMARK1RF, UOEREMARK2RF, SLIPPRINTDIVCDRF, SLIPPRINTFINISHCDRF, STOCKSLIPPRINTDATERF, SLIPPRTSETPAPERIDRF, SLIPADDRESSDIVRF, ADDRESSEECODERF, ADDRESSEENAMERF, ADDRESSEENAME2RF, ADDRESSEEPOSTNORF, ADDRESSEEADDR1RF, ADDRESSEEADDR3RF, ADDRESSEEADDR4RF, ADDRESSEETELNORF, ADDRESSEEFAXNORF, DIRECTSENDINGCDRF FROM STOCKSLIPRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
            SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
            findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
            findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;

            // SQL��
            sqlCommand.CommandText = sqlText;

            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                stockSlipList.Add(this.CopyToStockSlipWorkFromReader(ref myReader));
            }

            if (stockSlipList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            if (myReader != null)
            {
                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
            }

            return status;
        }
         /// <summary>
        /// �N���X�i�[���� Reader �� stockSlipWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCStockSlipWork CopyToStockSlipWorkFromReader(ref SqlDataReader myReader)
        {
            DCStockSlipWork stockSlipWork = new DCStockSlipWork();

			this.CopyToStockSlipWorkFromReader(ref myReader, ref stockSlipWork);

            return stockSlipWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� stockSlipWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stockSlipWork">stockSlipWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
		private void CopyToStockSlipWorkFromReader(ref SqlDataReader myReader, ref DCStockSlipWork stockSlipWork)
        {
            if (myReader != null && stockSlipWork != null)
            {
				# region �N���X�֊i�[
				stockSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				stockSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				stockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				stockSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				stockSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				stockSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				stockSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				stockSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				stockSlipWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
				stockSlipWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
				stockSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				stockSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
				stockSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
				stockSlipWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
				stockSlipWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
				stockSlipWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
				stockSlipWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
				stockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
				stockSlipWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
				stockSlipWork.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPUPDATECDRF"));
				stockSlipWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
				stockSlipWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
				stockSlipWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
				stockSlipWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
				stockSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
				stockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
				stockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
				stockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
				stockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
				stockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
				stockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
				stockSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
				stockSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
				stockSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
				stockSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
				stockSlipWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
				stockSlipWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
				stockSlipWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
				stockSlipWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
				stockSlipWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
				stockSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
				stockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
				stockSlipWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
				stockSlipWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
				stockSlipWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
				stockSlipWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));
				stockSlipWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
				stockSlipWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
				stockSlipWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
				stockSlipWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
				stockSlipWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));
				stockSlipWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
				stockSlipWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
				stockSlipWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));
				stockSlipWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));
				stockSlipWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));
				stockSlipWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
				stockSlipWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
				stockSlipWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
				stockSlipWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
				stockSlipWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
				stockSlipWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
				stockSlipWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));
				stockSlipWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));
				stockSlipWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
				stockSlipWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));
				stockSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
				stockSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
				stockSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
				stockSlipWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
				stockSlipWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
				stockSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
				stockSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
				stockSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
				stockSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
				stockSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
				stockSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
				stockSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
				stockSlipWork.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));
				stockSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
				stockSlipWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
				stockSlipWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
				stockSlipWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
				stockSlipWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
				stockSlipWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
				stockSlipWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
				stockSlipWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
				stockSlipWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
				stockSlipWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
				stockSlipWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
				stockSlipWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
				# endregion
            }
        }
 
 */
        // DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
        #endregion [--- DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j---]


        // ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		/// <summary>
		/// �d���f�[�^�擾
		/// </summary>
		/// <param name="resultList">���ʃf�[�^</param>
		/// <param name="acpOdrList">acpOdrList</param>
		/// <param name="receiveDataWork">��M�f�[�^</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <returns></returns>
		// DEL 2011/09/15 ---------->>>>>
		//public int SearchSCM(out ArrayList resultList, out ArrayList outSstockDtlList, out ArrayList acpOdrList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		//{
		//    return SearchSCMProc(out  resultList, out outSstockDtlList, out acpOdrList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
		//}
		// DEL 2011/09/15 ----------<<<<<
		// ADD 2011/09/15 ---------->>>>>
		public int SearchSCM(out ArrayList resultList, out ArrayList acpOdrList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchSCMProc(out  resultList, out acpOdrList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
		}
		// ADD 2011/09/15 ----------<<<<<

		/// <summary>
		/// �d���f�[�^�擾
		/// </summary>
		/// <param name="resultList">���ʃf�[�^</param>
		/// <param name="acpOdrList">acpOdrList</param>
		/// <param name="receiveDataWork">��M�f�[�^</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <returns></returns>
		//private int SearchSCMProc(out ArrayList resultList, out ArrayList outSstockDtlList, out ArrayList acpOdrList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// DEL 2011/09/15
		private int SearchSCMProc(out ArrayList resultList, out ArrayList acpOdrList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD 2011/09/15
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			resultList = new ArrayList();
			acpOdrList = new ArrayList();
			//outSstockDtlList = new ArrayList();// DEL 2011/09/15
			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

			StringBuilder sb = new StringBuilder();
			sb.Append(" SELECT I.CREATEDATETIMERF as I_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.UPDATEDATETIMERF as I_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.ENTERPRISECODERF as I_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.FILEHEADERGUIDRF as I_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.UPDEMPLOYEECODERF as I_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.UPDASSEMBLYID1RF as I_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.UPDASSEMBLYID2RF as I_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.LOGICALDELETECODERF as I_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERFORMALRF as I_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSLIPNORF as I_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.SECTIONCODERF as I_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUBSECTIONCODERF as I_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.DEBITNOTEDIVRF as I_DEBITNOTEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,I.DEBITNLNKSUPPSLIPNORF as I_DEBITNLNKSUPPSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSLIPCDRF as I_SUPPLIERSLIPCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKGOODSCDRF as I_STOCKGOODSCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ACCPAYDIVCDRF as I_ACCPAYDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKSECTIONCDRF as I_STOCKSECTIONCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKADDUPSECTIONCDRF as I_STOCKADDUPSECTIONCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKSLIPUPDATECDRF as I_STOCKSLIPUPDATECDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.INPUTDAYRF as I_INPUTDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ARRIVALGOODSDAYRF as I_ARRIVALGOODSDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKDATERF as I_STOCKDATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKADDUPADATERF as I_STOCKADDUPADATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.DELAYPAYMENTDIVRF as I_DELAYPAYMENTDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,I.PAYEECODERF as I_PAYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.PAYEESNMRF as I_PAYEESNMRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERCDRF as I_SUPPLIERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERNM1RF as I_SUPPLIERNM1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERNM2RF as I_SUPPLIERNM2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSNMRF as I_SUPPLIERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,I.BUSINESSTYPECODERF as I_BUSINESSTYPECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.BUSINESSTYPENAMERF as I_BUSINESSTYPENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SALESAREACODERF as I_SALESAREACODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SALESAREANAMERF as I_SALESAREANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKINPUTCODERF as I_STOCKINPUTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKINPUTNAMERF as I_STOCKINPUTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKAGENTCODERF as I_STOCKAGENTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKAGENTNAMERF as I_STOCKAGENTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPTTLAMNTDSPWAYCDRF as I_SUPPTTLAMNTDSPWAYCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.TTLAMNTDISPRATEAPYRF as I_TTLAMNTDISPRATEAPYRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKTOTALPRICERF as I_STOCKTOTALPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKSUBTTLPRICERF as I_STOCKSUBTTLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKTTLPRICTAXINCRF as I_STOCKTTLPRICTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKTTLPRICTAXEXCRF as I_STOCKTTLPRICTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKNETPRICERF as I_STOCKNETPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKPRICECONSTAXRF as I_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.TTLITDEDSTCOUTTAXRF as I_TTLITDEDSTCOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.TTLITDEDSTCINTAXRF as I_TTLITDEDSTCINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.TTLITDEDSTCTAXFREERF as I_TTLITDEDSTCTAXFREERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKOUTTAXRF as I_STOCKOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STCKPRCCONSTAXINCLURF as I_STCKPRCCONSTAXINCLURF ").Append(Environment.NewLine);
			sb.Append(" ,I.STCKDISTTLTAXEXCRF as I_STCKDISTTLTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ITDEDSTOCKDISOUTTAXRF as I_ITDEDSTOCKDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ITDEDSTOCKDISINTAXRF as I_ITDEDSTOCKDISINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ITDEDSTOCKDISTAXFRERF as I_ITDEDSTOCKDISTAXFRERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKDISOUTTAXRF as I_STOCKDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STCKDISTTLTAXINCLURF as I_STCKDISTTLTAXINCLURF ").Append(Environment.NewLine);
			sb.Append(" ,I.TAXADJUSTRF as I_TAXADJUSTRF ").Append(Environment.NewLine);
			sb.Append(" ,I.BALANCEADJUSTRF as I_BALANCEADJUSTRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPCTAXLAYCDRF as I_SUPPCTAXLAYCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERCONSTAXRATERF as I_SUPPLIERCONSTAXRATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.ACCPAYCONSTAXRF as I_ACCPAYCONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKFRACTIONPROCCDRF as I_STOCKFRACTIONPROCCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.AUTOPAYMENTRF as I_AUTOPAYMENTRF ").Append(Environment.NewLine);
			sb.Append(" ,I.AUTOPAYSLIPNUMRF as I_AUTOPAYSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,I.RETGOODSREASONDIVRF as I_RETGOODSREASONDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,I.RETGOODSREASONRF as I_RETGOODSREASONRF ").Append(Environment.NewLine);
			sb.Append(" ,I.PARTYSALESLIPNUMRF as I_PARTYSALESLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSLIPNOTE1RF as I_SUPPLIERSLIPNOTE1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSLIPNOTE2RF as I_SUPPLIERSLIPNOTE2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.DETAILROWCOUNTRF as I_DETAILROWCOUNTRF ").Append(Environment.NewLine);
			sb.Append(" ,I.EDISENDDATERF as I_EDISENDDATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.EDITAKEINDATERF as I_EDITAKEINDATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.UOEREMARK1RF as I_UOEREMARK1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.UOEREMARK2RF as I_UOEREMARK2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.SLIPPRINTDIVCDRF as I_SLIPPRINTDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SLIPPRINTFINISHCDRF as I_SLIPPRINTFINISHCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKSLIPPRINTDATERF as I_STOCKSLIPPRINTDATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SLIPPRTSETPAPERIDRF as I_SLIPPRTSETPAPERIDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SLIPADDRESSDIVRF as I_SLIPADDRESSDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEECODERF as I_ADDRESSEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEENAMERF as I_ADDRESSEENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEENAME2RF as I_ADDRESSEENAME2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEPOSTNORF as I_ADDRESSEEPOSTNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEADDR1RF as I_ADDRESSEEADDR1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEADDR3RF as I_ADDRESSEEADDR3RF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEADDR4RF as I_ADDRESSEEADDR4RF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEETELNORF as I_ADDRESSEETELNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEFAXNORF as I_ADDRESSEEFAXNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.DIRECTSENDINGCDRF as I_DIRECTSENDINGCDRF ").Append(Environment.NewLine);
			//�d�����׃f�[�^
			sb.Append(" ,J.CREATEDATETIMERF as J_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.UPDATEDATETIMERF as J_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ENTERPRISECODERF as J_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.FILEHEADERGUIDRF as J_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.UPDEMPLOYEECODERF as J_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.UPDASSEMBLYID1RF as J_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,J.UPDASSEMBLYID2RF as J_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,J.LOGICALDELETECODERF as J_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ACCEPTANORDERNORF as J_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERFORMALRF as J_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERSLIPNORF as J_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKROWNORF as J_STOCKROWNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.SECTIONCODERF as J_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUBSECTIONCODERF as J_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.COMMONSEQNORF as J_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKSLIPDTLNUMRF as J_STOCKSLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERFORMALSRCRF as J_SUPPLIERFORMALSRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKSLIPDTLNUMSRCRF as J_STOCKSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ACPTANODRSTATUSSYNCRF as J_ACPTANODRSTATUSSYNCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SALESSLIPDTLNUMSYNCRF as J_SALESSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKSLIPCDDTLRF as J_STOCKSLIPCDDTLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKINPUTCODERF as J_STOCKINPUTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKINPUTNAMERF as J_STOCKINPUTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKAGENTCODERF as J_STOCKAGENTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKAGENTNAMERF as J_STOCKAGENTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSKINDCODERF as J_GOODSKINDCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSMAKERCDRF as J_GOODSMAKERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.MAKERNAMERF as J_MAKERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.MAKERKANANAMERF as J_MAKERKANANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.CMPLTMAKERKANANAMERF as J_CMPLTMAKERKANANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSNORF as J_GOODSNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSNAMERF as J_GOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSNAMEKANARF as J_GOODSNAMEKANARF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSLGROUPRF as J_GOODSLGROUPRF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSLGROUPNAMERF as J_GOODSLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSMGROUPRF as J_GOODSMGROUPRF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSMGROUPNAMERF as J_GOODSMGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.BLGROUPCODERF as J_BLGROUPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.BLGROUPNAMERF as J_BLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.BLGOODSCODERF as J_BLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.BLGOODSFULLNAMERF as J_BLGOODSFULLNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ENTERPRISEGANRECODERF as J_ENTERPRISEGANRECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ENTERPRISEGANRENAMERF as J_ENTERPRISEGANRENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.WAREHOUSECODERF as J_WAREHOUSECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.WAREHOUSENAMERF as J_WAREHOUSENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.WAREHOUSESHELFNORF as J_WAREHOUSESHELFNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKORDERDIVCDRF as J_STOCKORDERDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.OPENPRICEDIVRF as J_OPENPRICEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSRATERANKRF as J_GOODSRATERANKRF ").Append(Environment.NewLine);
			sb.Append(" ,J.CUSTRATEGRPCODERF as J_CUSTRATEGRPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPRATEGRPCODERF as J_SUPPRATEGRPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.LISTPRICETAXEXCFLRF as J_LISTPRICETAXEXCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.LISTPRICETAXINCFLRF as J_LISTPRICETAXINCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKRATERF as J_STOCKRATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATESECTSTCKUNPRCRF as J_RATESECTSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEDIVSTCKUNPRCRF as J_RATEDIVSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.UNPRCCALCCDSTCKUNPRCRF as J_UNPRCCALCCDSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.PRICECDSTCKUNPRCRF as J_PRICECDSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STDUNPRCSTCKUNPRCRF as J_STDUNPRCSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.FRACPROCUNITSTCUNPRCRF as J_FRACPROCUNITSTCUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.FRACPROCSTCKUNPRCRF as J_FRACPROCSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKUNITPRICEFLRF as J_STOCKUNITPRICEFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKUNITTAXPRICEFLRF as J_STOCKUNITTAXPRICEFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKUNITCHNGDIVRF as J_STOCKUNITCHNGDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,J.BFSTOCKUNITPRICEFLRF as J_BFSTOCKUNITPRICEFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.BFLISTPRICERF as J_BFLISTPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEBLGOODSCODERF as J_RATEBLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEBLGOODSNAMERF as J_RATEBLGOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEGOODSRATEGRPCDRF as J_RATEGOODSRATEGRPCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEGOODSRATEGRPNMRF as J_RATEGOODSRATEGRPNMRF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEBLGROUPCODERF as J_RATEBLGROUPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEBLGROUPNAMERF as J_RATEBLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKCOUNTRF as J_STOCKCOUNTRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERCNTRF as J_ORDERCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERADJUSTCNTRF as J_ORDERADJUSTCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERREMAINCNTRF as J_ORDERREMAINCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,J.REMAINCNTUPDDATERF as J_REMAINCNTUPDDATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKPRICETAXEXCRF as J_STOCKPRICETAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKPRICETAXINCRF as J_STOCKPRICETAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKGOODSCDRF as J_STOCKGOODSCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKPRICECONSTAXRF as J_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,J.TAXATIONCODERF as J_TAXATIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKDTISLIPNOTE1RF as J_STOCKDTISLIPNOTE1RF ").Append(Environment.NewLine);
			sb.Append(" ,J.SALESCUSTOMERCODERF as J_SALESCUSTOMERCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.SALESCUSTOMERSNMRF as J_SALESCUSTOMERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SLIPMEMO1RF as J_SLIPMEMO1RF ").Append(Environment.NewLine);
			sb.Append(" ,J.SLIPMEMO2RF as J_SLIPMEMO2RF ").Append(Environment.NewLine);
			sb.Append(" ,J.SLIPMEMO3RF as J_SLIPMEMO3RF ").Append(Environment.NewLine);
			sb.Append(" ,J.INSIDEMEMO1RF as J_INSIDEMEMO1RF ").Append(Environment.NewLine);
			sb.Append(" ,J.INSIDEMEMO2RF as J_INSIDEMEMO2RF ").Append(Environment.NewLine);
			sb.Append(" ,J.INSIDEMEMO3RF as J_INSIDEMEMO3RF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERCDRF as J_SUPPLIERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERSNMRF as J_SUPPLIERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ADDRESSEECODERF as J_ADDRESSEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ADDRESSEENAMERF as J_ADDRESSEENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.DIRECTSENDINGCDRF as J_DIRECTSENDINGCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERNUMBERRF as J_ORDERNUMBERRF ").Append(Environment.NewLine);
			sb.Append(" ,J.WAYTOORDERRF as J_WAYTOORDERRF ").Append(Environment.NewLine);
			sb.Append(" ,J.DELIGDSCMPLTDUEDATERF as J_DELIGDSCMPLTDUEDATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.EXPECTDELIVERYDATERF as J_EXPECTDELIVERYDATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERDATACREATEDIVRF as J_ORDERDATACREATEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERDATACREATEDATERF as J_ORDERDATACREATEDATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERFORMISSUEDDIVRF  as J_ORDERFORMISSUEDDIVRF  ").Append(Environment.NewLine);
			//�󒍃}�X�^
			sb.Append(" ,C2.CREATEDATETIMERF as C2_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.UPDATEDATETIMERF as C2_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.ENTERPRISECODERF as C2_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.FILEHEADERGUIDRF as C2_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.UPDEMPLOYEECODERF as C2_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.UPDASSEMBLYID1RF as C2_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,C2.UPDASSEMBLYID2RF as C2_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,C2.LOGICALDELETECODERF as C2_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SECTIONCODERF as C2_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.ACCEPTANORDERNORF as C2_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			sb.Append(" ,C2.ACPTANODRSTATUSRF as C2_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SALESSLIPNUMRF as C2_SALESSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.DATAINPUTSYSTEMRF as C2_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.COMMONSEQNORF as C2_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SLIPDTLNUMRF as C2_SLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SLIPDTLNUMDERIVNORF as C2_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SRCLINKDATACODERF as C2_SRCLINKDATACODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SRCSLIPDTLNUMRF as C2_SRCSLIPDTLNUMRF ").Append(Environment.NewLine);

			sb.Append(" FROM STOCKSLIPRF I WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
			//�d�����׃f�[�^
			sb.Append(" INNER JOIN STOCKDETAILRF J WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
			//	�d���f�[�^.��ƃR�[�h�@���@�d�����׃f�[�^.��ƃR�[�h
			sb.Append(" ON I.ENTERPRISECODERF = J.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	�d���f�[�^.�d���`���@���@�d�����׃f�[�^.�d���`��
			sb.Append(" AND I.SUPPLIERFORMALRF = J.SUPPLIERFORMALRF ").Append(Environment.NewLine);
			//	�d���f�[�^.�d���`�[�ԍ��@���@�d�����׃f�[�^.�d���`�[�ԍ�
			sb.Append(" AND I.SUPPLIERSLIPNORF = J.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			// DEL 2011.08.29 ------->>>>>
			////	�d�����׃f�[�^.�X�V�����@>�@�p�����[�^.�J�n���t
			//sb.Append(" AND J.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_J ").Append(Environment.NewLine);
			////	�d�����׃f�[�^.�X�V�����@���@�p�����[�^.�I�����t
			//sb.Append(" AND J.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_J ").Append(Environment.NewLine);
			// DEL 2011.08.29 -------<<<<<

			//�󒍃}�X�^
			sb.Append(" LEFT JOIN ACCEPTODRRF C2 WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
			//	�d�����׃f�[�^.��ƃR�[�h�@���@�󒍃}�X�^.��ƃR�[�h
			sb.Append(" ON I.ENTERPRISECODERF = C2.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	�d�����׃f�[�^.�d���`���@���@�󒍃}�X�^.�󒍃X�e�[�^�X
			sb.Append(" AND ((I.SUPPLIERFORMALRF = 0 AND C2.ACPTANODRSTATUSRF =6)  ").Append(Environment.NewLine);
			sb.Append(" OR (I.SUPPLIERFORMALRF = 1 AND C2.ACPTANODRSTATUSRF =4)  ").Append(Environment.NewLine);
			sb.Append(" OR (I.SUPPLIERFORMALRF = 2 AND C2.ACPTANODRSTATUSRF =2))  ").Append(Environment.NewLine);
			//	�d�����׃f�[�^.�d���`�[�ԍ��@���@�󒍃}�X�^.�`�[�ԍ�
			sb.Append(" AND I.SUPPLIERSLIPNORF = C2.SALESSLIPNUMRF ").Append(Environment.NewLine);
			// DEL 2011.08.29 ------->>>>>
			////	�󒍃}�X�^.�X�V�����@>�@�p�����[�^.�J�n���t
			//sb.Append(" AND C2.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_C2 ").Append(Environment.NewLine);
			////	�󒍃}�X�^.�X�V�����@���@�p�����[�^.�I�����t
			//sb.Append(" AND C2.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_C2 ").Append(Environment.NewLine);
			// DEL 2011.08.29 -------<<<<<

			//	�d���f�[�^.�d���v�㋒�_�R�[�h�@���@�p�����[�^.���_�R�[�h
            //sb.Append(" WHERE I.STOCKADDUPSECTIONCDRF=@FINDSECTIONCODE ").Append(Environment.NewLine);// DEL 2011/11/14 xupz
            sb.Append(" WHERE I.STOCKSECTIONCDRF=@FINDSECTIONCODE ").Append(Environment.NewLine);// ADD 2011/11/14 xupz
           
            //-----Add 2011/11/01 ���� for #26228 start----->>>>>
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
            {
                //-----Add 2011/11/11 ���� for #26228 start----->>>>>
                //1:����=>���ד��t
                //sb.Append(" AND ((I.SUPPLIERFORMALRF=1 ").Append(Environment.NewLine); // DEL 2011/11/30
                sb.Append(" AND (((I.SUPPLIERFORMALRF=1 ").Append(Environment.NewLine); // ADD 2011/11/30
                //	�d���f�[�^.���ד��t�@���@�p�����[�^.�J�n���t
                sb.Append(" AND I.ARRIVALGOODSDAYRF>=@FINDUPDATESTARTDATETIME_I").Append(Environment.NewLine);
                //	�d���f�[�^.���ד��t�@���@�p�����[�^.�I�����t
                sb.Append(" AND I.ARRIVALGOODSDAYRF<=@FINDUPDATEENDDATETIME_I ").Append(Environment.NewLine);
                sb.Append(" ) OR ").Append(Environment.NewLine);
                //0:�d��,2:����=>�d�����t
                sb.Append(" (I.SUPPLIERFORMALRF<>1 ").Append(Environment.NewLine);
                //-----Add 2011/11/01 ���� for #26228 end-----<<<<<<    
                //	�d���f�[�^.�d�����@���@�p�����[�^.�J�n���t
                sb.Append(" AND I.STOCKDATERF>=@FINDUPDATESTARTDATETIME_I ").Append(Environment.NewLine);
                //	�d���f�[�^.�d�����@���@�p�����[�^.�I�����t
                sb.Append(" AND I.STOCKDATERF<=@FINDUPDATEENDDATETIME_I ").Append(Environment.NewLine);
                sb.Append(" ))");//Add 2011/11/11 ���� for #26228

                // ----- ADD 2011/11/30 tanh---------->>>>>
                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //sb.Append("    OR ((I.UPDATEDATETIMERF >= @FINDSYNCEXECDATERF) ").Append(Environment.NewLine);
                sb.Append("    OR ((I.UPDATEDATETIMERF > @FINDSYNCEXECDATERF) ").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
                sb.Append("       AND (I.UPDATEDATETIMERF <= @FINDENDTIMERF) ").Append(Environment.NewLine);
                sb.Append("       AND (((I.SUPPLIERFORMALRF=1) ").Append(Environment.NewLine);
                sb.Append("           AND (I.ARRIVALGOODSDAYRF<=@FINDUPDATEENDDATETIME_I)) ").Append(Environment.NewLine);
                sb.Append("            OR ((I.SUPPLIERFORMALRF<>1) ").Append(Environment.NewLine);
                sb.Append("           AND (I.STOCKDATERF<=@FINDUPDATEENDDATETIME_I))))) ").Append(Environment.NewLine);
                // ----- ADD 2011/11/30 tanh----------<<<<<
            }
		    else
            {
            //-----Add 2011/11/01 ���� for #26228 end-----<<<<<<    
                //	�d���f�[�^.�X�V�����@>�@�p�����[�^.�J�n���t
                sb.Append(" AND I.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_I ").Append(Environment.NewLine);
                //	�d���f�[�^.�X�V�����@���@�p�����[�^.�I�����t
                sb.Append(" AND I.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_I ").Append(Environment.NewLine);
            }//Add 2011/11/01 ���� for #26228
			//	�d���f�[�^.��ƃR�[�h�@���@�p�����[�^.��ƃR�[�h
			sb.Append(" AND I.ENTERPRISECODERF=@FINDENTERPRISECODERF ").Append(Environment.NewLine);// ADD 2011/08/18 ���仁@Redmine#23746

			// DEL 2011.08.29 ------>>>>>
			//sb.Append(" ORDER BY ").Append(Environment.NewLine);
			//sb.Append(" I_ENTERPRISECODERF ").Append(Environment.NewLine);
			//sb.Append(" ,I_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			//sb.Append(" ,I_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			//sb.Append(" ,J_SUPPLIERFORMALRF  ").Append(Environment.NewLine);
			//sb.Append(" ,J_STOCKSLIPDTLNUMRF ").Append(Environment.NewLine);
			//sb.Append(" ,C2_SECTIONCODERF ").Append(Environment.NewLine);
			//sb.Append(" ,C2_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			//sb.Append(" ,C2_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
			//sb.Append(" ,C2_COMMONSEQNORF ").Append(Environment.NewLine);
			//sb.Append(" ,C2_SLIPDTLNUMRF ").Append(Environment.NewLine);
			//sb.Append(" ,C2_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);
			// DEL 2011.08.29 ------<<<<<

            // ----- DEL 2011/11/01 xupz---------->>>>>
            //// ADD 2011.08.29 ------>>>>>
            //sb.Append(" UNION ").Append(Environment.NewLine);
            ////�d���f�[�^
            //sb.Append(" SELECT I.CREATEDATETIMERF as I_CREATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.UPDATEDATETIMERF as I_UPDATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ENTERPRISECODERF as I_ENTERPRISECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.FILEHEADERGUIDRF as I_FILEHEADERGUIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.UPDEMPLOYEECODERF as I_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.UPDASSEMBLYID1RF as I_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.UPDASSEMBLYID2RF as I_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.LOGICALDELETECODERF as I_LOGICALDELETECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERFORMALRF as I_SUPPLIERFORMALRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERSLIPNORF as I_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SECTIONCODERF as I_SECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUBSECTIONCODERF as I_SUBSECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.DEBITNOTEDIVRF as I_DEBITNOTEDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.DEBITNLNKSUPPSLIPNORF as I_DEBITNLNKSUPPSLIPNORF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERSLIPCDRF as I_SUPPLIERSLIPCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKGOODSCDRF as I_STOCKGOODSCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ACCPAYDIVCDRF as I_ACCPAYDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKSECTIONCDRF as I_STOCKSECTIONCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKADDUPSECTIONCDRF as I_STOCKADDUPSECTIONCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKSLIPUPDATECDRF as I_STOCKSLIPUPDATECDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.INPUTDAYRF as I_INPUTDAYRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ARRIVALGOODSDAYRF as I_ARRIVALGOODSDAYRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKDATERF as I_STOCKDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKADDUPADATERF as I_STOCKADDUPADATERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.DELAYPAYMENTDIVRF as I_DELAYPAYMENTDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.PAYEECODERF as I_PAYEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.PAYEESNMRF as I_PAYEESNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERCDRF as I_SUPPLIERCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERNM1RF as I_SUPPLIERNM1RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERNM2RF as I_SUPPLIERNM2RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERSNMRF as I_SUPPLIERSNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.BUSINESSTYPECODERF as I_BUSINESSTYPECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.BUSINESSTYPENAMERF as I_BUSINESSTYPENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SALESAREACODERF as I_SALESAREACODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SALESAREANAMERF as I_SALESAREANAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKINPUTCODERF as I_STOCKINPUTCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKINPUTNAMERF as I_STOCKINPUTNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKAGENTCODERF as I_STOCKAGENTCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKAGENTNAMERF as I_STOCKAGENTNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPTTLAMNTDSPWAYCDRF as I_SUPPTTLAMNTDSPWAYCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.TTLAMNTDISPRATEAPYRF as I_TTLAMNTDISPRATEAPYRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKTOTALPRICERF as I_STOCKTOTALPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKSUBTTLPRICERF as I_STOCKSUBTTLPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKTTLPRICTAXINCRF as I_STOCKTTLPRICTAXINCRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKTTLPRICTAXEXCRF as I_STOCKTTLPRICTAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKNETPRICERF as I_STOCKNETPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKPRICECONSTAXRF as I_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.TTLITDEDSTCOUTTAXRF as I_TTLITDEDSTCOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.TTLITDEDSTCINTAXRF as I_TTLITDEDSTCINTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.TTLITDEDSTCTAXFREERF as I_TTLITDEDSTCTAXFREERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKOUTTAXRF as I_STOCKOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STCKPRCCONSTAXINCLURF as I_STCKPRCCONSTAXINCLURF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STCKDISTTLTAXEXCRF as I_STCKDISTTLTAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ITDEDSTOCKDISOUTTAXRF as I_ITDEDSTOCKDISOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ITDEDSTOCKDISINTAXRF as I_ITDEDSTOCKDISINTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ITDEDSTOCKDISTAXFRERF as I_ITDEDSTOCKDISTAXFRERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKDISOUTTAXRF as I_STOCKDISOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STCKDISTTLTAXINCLURF as I_STCKDISTTLTAXINCLURF ").Append(Environment.NewLine);
            //sb.Append(" ,I.TAXADJUSTRF as I_TAXADJUSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.BALANCEADJUSTRF as I_BALANCEADJUSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPCTAXLAYCDRF as I_SUPPCTAXLAYCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERCONSTAXRATERF as I_SUPPLIERCONSTAXRATERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ACCPAYCONSTAXRF as I_ACCPAYCONSTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKFRACTIONPROCCDRF as I_STOCKFRACTIONPROCCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.AUTOPAYMENTRF as I_AUTOPAYMENTRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.AUTOPAYSLIPNUMRF as I_AUTOPAYSLIPNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.RETGOODSREASONDIVRF as I_RETGOODSREASONDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.RETGOODSREASONRF as I_RETGOODSREASONRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.PARTYSALESLIPNUMRF as I_PARTYSALESLIPNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERSLIPNOTE1RF as I_SUPPLIERSLIPNOTE1RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERSLIPNOTE2RF as I_SUPPLIERSLIPNOTE2RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.DETAILROWCOUNTRF as I_DETAILROWCOUNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.EDISENDDATERF as I_EDISENDDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.EDITAKEINDATERF as I_EDITAKEINDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.UOEREMARK1RF as I_UOEREMARK1RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.UOEREMARK2RF as I_UOEREMARK2RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SLIPPRINTDIVCDRF as I_SLIPPRINTDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SLIPPRINTFINISHCDRF as I_SLIPPRINTFINISHCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKSLIPPRINTDATERF as I_STOCKSLIPPRINTDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SLIPPRTSETPAPERIDRF as I_SLIPPRTSETPAPERIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SLIPADDRESSDIVRF as I_SLIPADDRESSDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEECODERF as I_ADDRESSEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEENAMERF as I_ADDRESSEENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEENAME2RF as I_ADDRESSEENAME2RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEEPOSTNORF as I_ADDRESSEEPOSTNORF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEEADDR1RF as I_ADDRESSEEADDR1RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEEADDR3RF as I_ADDRESSEEADDR3RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEEADDR4RF as I_ADDRESSEEADDR4RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEETELNORF as I_ADDRESSEETELNORF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEEFAXNORF as I_ADDRESSEEFAXNORF ").Append(Environment.NewLine);
            //sb.Append(" ,I.DIRECTSENDINGCDRF as I_DIRECTSENDINGCDRF ").Append(Environment.NewLine);
            ////�d�����׃f�[�^
            //sb.Append(" ,J.CREATEDATETIMERF as J_CREATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.UPDATEDATETIMERF as J_UPDATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ENTERPRISECODERF as J_ENTERPRISECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.FILEHEADERGUIDRF as J_FILEHEADERGUIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.UPDEMPLOYEECODERF as J_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.UPDASSEMBLYID1RF as J_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.UPDASSEMBLYID2RF as J_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.LOGICALDELETECODERF as J_LOGICALDELETECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ACCEPTANORDERNORF as J_ACCEPTANORDERNORF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUPPLIERFORMALRF as J_SUPPLIERFORMALRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUPPLIERSLIPNORF as J_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKROWNORF as J_STOCKROWNORF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SECTIONCODERF as J_SECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUBSECTIONCODERF as J_SUBSECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.COMMONSEQNORF as J_COMMONSEQNORF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKSLIPDTLNUMRF as J_STOCKSLIPDTLNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUPPLIERFORMALSRCRF as J_SUPPLIERFORMALSRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKSLIPDTLNUMSRCRF as J_STOCKSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ACPTANODRSTATUSSYNCRF as J_ACPTANODRSTATUSSYNCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SALESSLIPDTLNUMSYNCRF as J_SALESSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKSLIPCDDTLRF as J_STOCKSLIPCDDTLRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKINPUTCODERF as J_STOCKINPUTCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKINPUTNAMERF as J_STOCKINPUTNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKAGENTCODERF as J_STOCKAGENTCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKAGENTNAMERF as J_STOCKAGENTNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSKINDCODERF as J_GOODSKINDCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSMAKERCDRF as J_GOODSMAKERCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.MAKERNAMERF as J_MAKERNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.MAKERKANANAMERF as J_MAKERKANANAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.CMPLTMAKERKANANAMERF as J_CMPLTMAKERKANANAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSNORF as J_GOODSNORF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSNAMERF as J_GOODSNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSNAMEKANARF as J_GOODSNAMEKANARF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSLGROUPRF as J_GOODSLGROUPRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSLGROUPNAMERF as J_GOODSLGROUPNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSMGROUPRF as J_GOODSMGROUPRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSMGROUPNAMERF as J_GOODSMGROUPNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.BLGROUPCODERF as J_BLGROUPCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.BLGROUPNAMERF as J_BLGROUPNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.BLGOODSCODERF as J_BLGOODSCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.BLGOODSFULLNAMERF as J_BLGOODSFULLNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ENTERPRISEGANRECODERF as J_ENTERPRISEGANRECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ENTERPRISEGANRENAMERF as J_ENTERPRISEGANRENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.WAREHOUSECODERF as J_WAREHOUSECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.WAREHOUSENAMERF as J_WAREHOUSENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.WAREHOUSESHELFNORF as J_WAREHOUSESHELFNORF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKORDERDIVCDRF as J_STOCKORDERDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.OPENPRICEDIVRF as J_OPENPRICEDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSRATERANKRF as J_GOODSRATERANKRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.CUSTRATEGRPCODERF as J_CUSTRATEGRPCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUPPRATEGRPCODERF as J_SUPPRATEGRPCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.LISTPRICETAXEXCFLRF as J_LISTPRICETAXEXCFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.LISTPRICETAXINCFLRF as J_LISTPRICETAXINCFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKRATERF as J_STOCKRATERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATESECTSTCKUNPRCRF as J_RATESECTSTCKUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEDIVSTCKUNPRCRF as J_RATEDIVSTCKUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.UNPRCCALCCDSTCKUNPRCRF as J_UNPRCCALCCDSTCKUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.PRICECDSTCKUNPRCRF as J_PRICECDSTCKUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STDUNPRCSTCKUNPRCRF as J_STDUNPRCSTCKUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.FRACPROCUNITSTCUNPRCRF as J_FRACPROCUNITSTCUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.FRACPROCSTCKUNPRCRF as J_FRACPROCSTCKUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKUNITPRICEFLRF as J_STOCKUNITPRICEFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKUNITTAXPRICEFLRF as J_STOCKUNITTAXPRICEFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKUNITCHNGDIVRF as J_STOCKUNITCHNGDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.BFSTOCKUNITPRICEFLRF as J_BFSTOCKUNITPRICEFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.BFLISTPRICERF as J_BFLISTPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEBLGOODSCODERF as J_RATEBLGOODSCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEBLGOODSNAMERF as J_RATEBLGOODSNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEGOODSRATEGRPCDRF as J_RATEGOODSRATEGRPCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEGOODSRATEGRPNMRF as J_RATEGOODSRATEGRPNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEBLGROUPCODERF as J_RATEBLGROUPCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEBLGROUPNAMERF as J_RATEBLGROUPNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKCOUNTRF as J_STOCKCOUNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERCNTRF as J_ORDERCNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERADJUSTCNTRF as J_ORDERADJUSTCNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERREMAINCNTRF as J_ORDERREMAINCNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.REMAINCNTUPDDATERF as J_REMAINCNTUPDDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKPRICETAXEXCRF as J_STOCKPRICETAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKPRICETAXINCRF as J_STOCKPRICETAXINCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKGOODSCDRF as J_STOCKGOODSCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKPRICECONSTAXRF as J_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.TAXATIONCODERF as J_TAXATIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKDTISLIPNOTE1RF as J_STOCKDTISLIPNOTE1RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SALESCUSTOMERCODERF as J_SALESCUSTOMERCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SALESCUSTOMERSNMRF as J_SALESCUSTOMERSNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SLIPMEMO1RF as J_SLIPMEMO1RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SLIPMEMO2RF as J_SLIPMEMO2RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SLIPMEMO3RF as J_SLIPMEMO3RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.INSIDEMEMO1RF as J_INSIDEMEMO1RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.INSIDEMEMO2RF as J_INSIDEMEMO2RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.INSIDEMEMO3RF as J_INSIDEMEMO3RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUPPLIERCDRF as J_SUPPLIERCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUPPLIERSNMRF as J_SUPPLIERSNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ADDRESSEECODERF as J_ADDRESSEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ADDRESSEENAMERF as J_ADDRESSEENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.DIRECTSENDINGCDRF as J_DIRECTSENDINGCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERNUMBERRF as J_ORDERNUMBERRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.WAYTOORDERRF as J_WAYTOORDERRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.DELIGDSCMPLTDUEDATERF as J_DELIGDSCMPLTDUEDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.EXPECTDELIVERYDATERF as J_EXPECTDELIVERYDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERDATACREATEDIVRF as J_ORDERDATACREATEDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERDATACREATEDATERF as J_ORDERDATACREATEDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERFORMISSUEDDIVRF  as J_ORDERFORMISSUEDDIVRF  ").Append(Environment.NewLine);
            ////�󒍃}�X�^
            //sb.Append(" ,C2.CREATEDATETIMERF as C2_CREATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.UPDATEDATETIMERF as C2_UPDATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.ENTERPRISECODERF as C2_ENTERPRISECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.FILEHEADERGUIDRF as C2_FILEHEADERGUIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.UPDEMPLOYEECODERF as C2_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.UPDASSEMBLYID1RF as C2_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.UPDASSEMBLYID2RF as C2_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.LOGICALDELETECODERF as C2_LOGICALDELETECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.SECTIONCODERF as C2_SECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.ACCEPTANORDERNORF as C2_ACCEPTANORDERNORF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.ACPTANODRSTATUSRF as C2_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.SALESSLIPNUMRF as C2_SALESSLIPNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.DATAINPUTSYSTEMRF as C2_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.COMMONSEQNORF as C2_COMMONSEQNORF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.SLIPDTLNUMRF as C2_SLIPDTLNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.SLIPDTLNUMDERIVNORF as C2_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.SRCLINKDATACODERF as C2_SRCLINKDATACODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.SRCSLIPDTLNUMRF as C2_SRCSLIPDTLNUMRF ").Append(Environment.NewLine);

            //sb.Append(" FROM STOCKSLIPRF I WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
            ////�d�����׃f�[�^
            //sb.Append(" INNER JOIN STOCKDETAILRF J WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
            ////	�d���f�[�^.��ƃR�[�h�@���@�d�����׃f�[�^.��ƃR�[�h
            //sb.Append(" ON I.ENTERPRISECODERF = J.ENTERPRISECODERF ").Append(Environment.NewLine);
            ////	�d���f�[�^.�d���`���@���@�d�����׃f�[�^.�d���`��
            //sb.Append(" AND I.SUPPLIERFORMALRF = J.SUPPLIERFORMALRF ").Append(Environment.NewLine);
            ////	�d���f�[�^.�d���`�[�ԍ��@���@�d�����׃f�[�^.�d���`�[�ԍ�
            //sb.Append(" AND I.SUPPLIERSLIPNORF = J.SUPPLIERSLIPNORF ").Append(Environment.NewLine);

            ////�󒍃}�X�^
            //sb.Append(" LEFT JOIN ACCEPTODRRF C2 WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            ////	�d�����׃f�[�^.��ƃR�[�h�@���@�󒍃}�X�^.��ƃR�[�h
            //sb.Append(" ON I.ENTERPRISECODERF = C2.ENTERPRISECODERF ").Append(Environment.NewLine);
            ////	�d�����׃f�[�^.�d���`���@���@�󒍃}�X�^.�󒍃X�e�[�^�X
            //sb.Append(" AND ((I.SUPPLIERFORMALRF = 0 AND C2.ACPTANODRSTATUSRF =6)  ").Append(Environment.NewLine);
            //sb.Append(" OR (I.SUPPLIERFORMALRF = 1 AND C2.ACPTANODRSTATUSRF =4)  ").Append(Environment.NewLine);
            //sb.Append(" OR (I.SUPPLIERFORMALRF = 2 AND C2.ACPTANODRSTATUSRF =2))  ").Append(Environment.NewLine);
            ////	�d�����׃f�[�^.�d���`�[�ԍ��@���@�󒍃}�X�^.�`�[�ԍ�
            //sb.Append(" AND I.SUPPLIERSLIPNORF = C2.SALESSLIPNUMRF ").Append(Environment.NewLine);

            ////���d���f�[�^
            //sb.Append(" INNER JOIN (  ").Append(Environment.NewLine);
            //sb.Append("    SELECT DISTINCT SSLIPRF.ENTERPRISECODERF ").Append(Environment.NewLine);
            //sb.Append("    ,SSLIPRF.SUPPLIERFORMALRF ").Append(Environment.NewLine);
            //sb.Append("    ,SSLIPRF.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            //sb.Append("    FROM STOCKSLIPRF SSLIPRF ").Append(Environment.NewLine);
            //sb.Append("    INNER JOIN STOCKDETAILRF SSLIPDTLRF ").Append(Environment.NewLine);
            ////	�d���f�[�^.��ƃR�[�h�@���@�d�����׃f�[�^.��ƃR�[�h
            //sb.Append("    ON SSLIPRF.ENTERPRISECODERF = SSLIPDTLRF.ENTERPRISECODERF  ").Append(Environment.NewLine);
            ////	�d���f�[�^.�d���`���@���@�d�����׃f�[�^.�d���`��
            //sb.Append("    AND SSLIPRF.SUPPLIERFORMALRF = SSLIPDTLRF.SUPPLIERFORMALRF  ").Append(Environment.NewLine);
            ////	�d���f�[�^.�d���`�[�ԍ��@���@�d�����׃f�[�^.�d���`�[�ԍ�			
            //sb.Append("    AND SSLIPRF.SUPPLIERSLIPNORF = SSLIPDTLRF.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            ////	�d���f�[�^.�d���v�㋒�_�R�[�h�@���@�p�����[�^.���_�R�[�h
            //sb.Append("    WHERE SSLIPRF.STOCKADDUPSECTIONCDRF=@FINDSECTIONCODE_SSLIPRF ").Append(Environment.NewLine);

            ////	�d���f�[�^.��ƃR�[�h�@���@�p�����[�^.��ƃR�[�h
            //sb.Append("    AND SSLIPRF.ENTERPRISECODERF=@FINDENTERPRISECODERF_SSLIPRF ").Append(Environment.NewLine);// ADD 2011/08/18 ���仁@Redmine#23746
          
            ////	�d�����׃f�[�^.�X�V�����@>�@�p�����[�^.�J�n���t
            //sb.Append("    AND SSLIPDTLRF.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_SSLIPRF ").Append(Environment.NewLine);
            ////	�d�����׃f�[�^.�X�V�����@���@�p�����[�^.�I�����t
            //sb.Append("    AND SSLIPDTLRF.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_SSLIPRF ").Append(Environment.NewLine);
            //sb.Append(" )AS II").Append(Environment.NewLine);

            ////	�d���f�[�^.��ƃR�[�h�@���@���d���f�[�^.��ƃR�[�h�@
            //sb.Append(" ON I.ENTERPRISECODERF = II.ENTERPRISECODERF ").Append(Environment.NewLine);
            ////	�d���f�[�^.�d���`���@���@���d���f�[�^.�d���`��
            //sb.Append(" AND I.SUPPLIERFORMALRF = II.SUPPLIERFORMALRF ").Append(Environment.NewLine);
            ////	�d���f�[�^.�d���`�[�ԍ��@���@���d���f�[�^.�d���`�[�ԍ�	
            //sb.Append(" AND I.SUPPLIERSLIPNORF = II.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            // ----- DEL 2011/11/01 xupz----------<<<<<

            // ----- ADD 2011/11/01 xupz---------->>>>>
            //�f�[�^���M���o�����敪���u�����v�̏ꍇ
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 0)
            {
                // ADD 2011.08.29 ------>>>>>
                sb.Append(" UNION ").Append(Environment.NewLine);
                //�d���f�[�^
                sb.Append(" SELECT I.CREATEDATETIMERF as I_CREATEDATETIMERF ").Append(Environment.NewLine);
                sb.Append(" ,I.UPDATEDATETIMERF as I_UPDATEDATETIMERF ").Append(Environment.NewLine);
                sb.Append(" ,I.ENTERPRISECODERF as I_ENTERPRISECODERF ").Append(Environment.NewLine);
                sb.Append(" ,I.FILEHEADERGUIDRF as I_FILEHEADERGUIDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.UPDEMPLOYEECODERF as I_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                sb.Append(" ,I.UPDASSEMBLYID1RF as I_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                sb.Append(" ,I.UPDASSEMBLYID2RF as I_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                sb.Append(" ,I.LOGICALDELETECODERF as I_LOGICALDELETECODERF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUPPLIERFORMALRF as I_SUPPLIERFORMALRF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUPPLIERSLIPNORF as I_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
                sb.Append(" ,I.SECTIONCODERF as I_SECTIONCODERF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUBSECTIONCODERF as I_SUBSECTIONCODERF ").Append(Environment.NewLine);
                sb.Append(" ,I.DEBITNOTEDIVRF as I_DEBITNOTEDIVRF ").Append(Environment.NewLine);
                sb.Append(" ,I.DEBITNLNKSUPPSLIPNORF as I_DEBITNLNKSUPPSLIPNORF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUPPLIERSLIPCDRF as I_SUPPLIERSLIPCDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKGOODSCDRF as I_STOCKGOODSCDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.ACCPAYDIVCDRF as I_ACCPAYDIVCDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKSECTIONCDRF as I_STOCKSECTIONCDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKADDUPSECTIONCDRF as I_STOCKADDUPSECTIONCDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKSLIPUPDATECDRF as I_STOCKSLIPUPDATECDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.INPUTDAYRF as I_INPUTDAYRF ").Append(Environment.NewLine);
                sb.Append(" ,I.ARRIVALGOODSDAYRF as I_ARRIVALGOODSDAYRF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKDATERF as I_STOCKDATERF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKADDUPADATERF as I_STOCKADDUPADATERF ").Append(Environment.NewLine);
                sb.Append(" ,I.DELAYPAYMENTDIVRF as I_DELAYPAYMENTDIVRF ").Append(Environment.NewLine);
                sb.Append(" ,I.PAYEECODERF as I_PAYEECODERF ").Append(Environment.NewLine);
                sb.Append(" ,I.PAYEESNMRF as I_PAYEESNMRF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUPPLIERCDRF as I_SUPPLIERCDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUPPLIERNM1RF as I_SUPPLIERNM1RF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUPPLIERNM2RF as I_SUPPLIERNM2RF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUPPLIERSNMRF as I_SUPPLIERSNMRF ").Append(Environment.NewLine);
                sb.Append(" ,I.BUSINESSTYPECODERF as I_BUSINESSTYPECODERF ").Append(Environment.NewLine);
                sb.Append(" ,I.BUSINESSTYPENAMERF as I_BUSINESSTYPENAMERF ").Append(Environment.NewLine);
                sb.Append(" ,I.SALESAREACODERF as I_SALESAREACODERF ").Append(Environment.NewLine);
                sb.Append(" ,I.SALESAREANAMERF as I_SALESAREANAMERF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKINPUTCODERF as I_STOCKINPUTCODERF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKINPUTNAMERF as I_STOCKINPUTNAMERF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKAGENTCODERF as I_STOCKAGENTCODERF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKAGENTNAMERF as I_STOCKAGENTNAMERF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUPPTTLAMNTDSPWAYCDRF as I_SUPPTTLAMNTDSPWAYCDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.TTLAMNTDISPRATEAPYRF as I_TTLAMNTDISPRATEAPYRF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKTOTALPRICERF as I_STOCKTOTALPRICERF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKSUBTTLPRICERF as I_STOCKSUBTTLPRICERF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKTTLPRICTAXINCRF as I_STOCKTTLPRICTAXINCRF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKTTLPRICTAXEXCRF as I_STOCKTTLPRICTAXEXCRF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKNETPRICERF as I_STOCKNETPRICERF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKPRICECONSTAXRF as I_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
                sb.Append(" ,I.TTLITDEDSTCOUTTAXRF as I_TTLITDEDSTCOUTTAXRF ").Append(Environment.NewLine);
                sb.Append(" ,I.TTLITDEDSTCINTAXRF as I_TTLITDEDSTCINTAXRF ").Append(Environment.NewLine);
                sb.Append(" ,I.TTLITDEDSTCTAXFREERF as I_TTLITDEDSTCTAXFREERF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKOUTTAXRF as I_STOCKOUTTAXRF ").Append(Environment.NewLine);
                sb.Append(" ,I.STCKPRCCONSTAXINCLURF as I_STCKPRCCONSTAXINCLURF ").Append(Environment.NewLine);
                sb.Append(" ,I.STCKDISTTLTAXEXCRF as I_STCKDISTTLTAXEXCRF ").Append(Environment.NewLine);
                sb.Append(" ,I.ITDEDSTOCKDISOUTTAXRF as I_ITDEDSTOCKDISOUTTAXRF ").Append(Environment.NewLine);
                sb.Append(" ,I.ITDEDSTOCKDISINTAXRF as I_ITDEDSTOCKDISINTAXRF ").Append(Environment.NewLine);
                sb.Append(" ,I.ITDEDSTOCKDISTAXFRERF as I_ITDEDSTOCKDISTAXFRERF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKDISOUTTAXRF as I_STOCKDISOUTTAXRF ").Append(Environment.NewLine);
                sb.Append(" ,I.STCKDISTTLTAXINCLURF as I_STCKDISTTLTAXINCLURF ").Append(Environment.NewLine);
                sb.Append(" ,I.TAXADJUSTRF as I_TAXADJUSTRF ").Append(Environment.NewLine);
                sb.Append(" ,I.BALANCEADJUSTRF as I_BALANCEADJUSTRF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUPPCTAXLAYCDRF as I_SUPPCTAXLAYCDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUPPLIERCONSTAXRATERF as I_SUPPLIERCONSTAXRATERF ").Append(Environment.NewLine);
                sb.Append(" ,I.ACCPAYCONSTAXRF as I_ACCPAYCONSTAXRF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKFRACTIONPROCCDRF as I_STOCKFRACTIONPROCCDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.AUTOPAYMENTRF as I_AUTOPAYMENTRF ").Append(Environment.NewLine);
                sb.Append(" ,I.AUTOPAYSLIPNUMRF as I_AUTOPAYSLIPNUMRF ").Append(Environment.NewLine);
                sb.Append(" ,I.RETGOODSREASONDIVRF as I_RETGOODSREASONDIVRF ").Append(Environment.NewLine);
                sb.Append(" ,I.RETGOODSREASONRF as I_RETGOODSREASONRF ").Append(Environment.NewLine);
                sb.Append(" ,I.PARTYSALESLIPNUMRF as I_PARTYSALESLIPNUMRF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUPPLIERSLIPNOTE1RF as I_SUPPLIERSLIPNOTE1RF ").Append(Environment.NewLine);
                sb.Append(" ,I.SUPPLIERSLIPNOTE2RF as I_SUPPLIERSLIPNOTE2RF ").Append(Environment.NewLine);
                sb.Append(" ,I.DETAILROWCOUNTRF as I_DETAILROWCOUNTRF ").Append(Environment.NewLine);
                sb.Append(" ,I.EDISENDDATERF as I_EDISENDDATERF ").Append(Environment.NewLine);
                sb.Append(" ,I.EDITAKEINDATERF as I_EDITAKEINDATERF ").Append(Environment.NewLine);
                sb.Append(" ,I.UOEREMARK1RF as I_UOEREMARK1RF ").Append(Environment.NewLine);
                sb.Append(" ,I.UOEREMARK2RF as I_UOEREMARK2RF ").Append(Environment.NewLine);
                sb.Append(" ,I.SLIPPRINTDIVCDRF as I_SLIPPRINTDIVCDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.SLIPPRINTFINISHCDRF as I_SLIPPRINTFINISHCDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.STOCKSLIPPRINTDATERF as I_STOCKSLIPPRINTDATERF ").Append(Environment.NewLine);
                sb.Append(" ,I.SLIPPRTSETPAPERIDRF as I_SLIPPRTSETPAPERIDRF ").Append(Environment.NewLine);
                sb.Append(" ,I.SLIPADDRESSDIVRF as I_SLIPADDRESSDIVRF ").Append(Environment.NewLine);
                sb.Append(" ,I.ADDRESSEECODERF as I_ADDRESSEECODERF ").Append(Environment.NewLine);
                sb.Append(" ,I.ADDRESSEENAMERF as I_ADDRESSEENAMERF ").Append(Environment.NewLine);
                sb.Append(" ,I.ADDRESSEENAME2RF as I_ADDRESSEENAME2RF ").Append(Environment.NewLine);
                sb.Append(" ,I.ADDRESSEEPOSTNORF as I_ADDRESSEEPOSTNORF ").Append(Environment.NewLine);
                sb.Append(" ,I.ADDRESSEEADDR1RF as I_ADDRESSEEADDR1RF ").Append(Environment.NewLine);
                sb.Append(" ,I.ADDRESSEEADDR3RF as I_ADDRESSEEADDR3RF ").Append(Environment.NewLine);
                sb.Append(" ,I.ADDRESSEEADDR4RF as I_ADDRESSEEADDR4RF ").Append(Environment.NewLine);
                sb.Append(" ,I.ADDRESSEETELNORF as I_ADDRESSEETELNORF ").Append(Environment.NewLine);
                sb.Append(" ,I.ADDRESSEEFAXNORF as I_ADDRESSEEFAXNORF ").Append(Environment.NewLine);
                sb.Append(" ,I.DIRECTSENDINGCDRF as I_DIRECTSENDINGCDRF ").Append(Environment.NewLine);
                //�d�����׃f�[�^
                sb.Append(" ,J.CREATEDATETIMERF as J_CREATEDATETIMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.UPDATEDATETIMERF as J_UPDATEDATETIMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.ENTERPRISECODERF as J_ENTERPRISECODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.FILEHEADERGUIDRF as J_FILEHEADERGUIDRF ").Append(Environment.NewLine);
                sb.Append(" ,J.UPDEMPLOYEECODERF as J_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.UPDASSEMBLYID1RF as J_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                sb.Append(" ,J.UPDASSEMBLYID2RF as J_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                sb.Append(" ,J.LOGICALDELETECODERF as J_LOGICALDELETECODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.ACCEPTANORDERNORF as J_ACCEPTANORDERNORF ").Append(Environment.NewLine);
                sb.Append(" ,J.SUPPLIERFORMALRF as J_SUPPLIERFORMALRF ").Append(Environment.NewLine);
                sb.Append(" ,J.SUPPLIERSLIPNORF as J_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKROWNORF as J_STOCKROWNORF ").Append(Environment.NewLine);
                sb.Append(" ,J.SECTIONCODERF as J_SECTIONCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.SUBSECTIONCODERF as J_SUBSECTIONCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.COMMONSEQNORF as J_COMMONSEQNORF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKSLIPDTLNUMRF as J_STOCKSLIPDTLNUMRF ").Append(Environment.NewLine);
                sb.Append(" ,J.SUPPLIERFORMALSRCRF as J_SUPPLIERFORMALSRCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKSLIPDTLNUMSRCRF as J_STOCKSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.ACPTANODRSTATUSSYNCRF as J_ACPTANODRSTATUSSYNCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.SALESSLIPDTLNUMSYNCRF as J_SALESSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKSLIPCDDTLRF as J_STOCKSLIPCDDTLRF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKINPUTCODERF as J_STOCKINPUTCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKINPUTNAMERF as J_STOCKINPUTNAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKAGENTCODERF as J_STOCKAGENTCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKAGENTNAMERF as J_STOCKAGENTNAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.GOODSKINDCODERF as J_GOODSKINDCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.GOODSMAKERCDRF as J_GOODSMAKERCDRF ").Append(Environment.NewLine);
                sb.Append(" ,J.MAKERNAMERF as J_MAKERNAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.MAKERKANANAMERF as J_MAKERKANANAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.CMPLTMAKERKANANAMERF as J_CMPLTMAKERKANANAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.GOODSNORF as J_GOODSNORF ").Append(Environment.NewLine);
                sb.Append(" ,J.GOODSNAMERF as J_GOODSNAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.GOODSNAMEKANARF as J_GOODSNAMEKANARF ").Append(Environment.NewLine);
                sb.Append(" ,J.GOODSLGROUPRF as J_GOODSLGROUPRF ").Append(Environment.NewLine);
                sb.Append(" ,J.GOODSLGROUPNAMERF as J_GOODSLGROUPNAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.GOODSMGROUPRF as J_GOODSMGROUPRF ").Append(Environment.NewLine);
                sb.Append(" ,J.GOODSMGROUPNAMERF as J_GOODSMGROUPNAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.BLGROUPCODERF as J_BLGROUPCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.BLGROUPNAMERF as J_BLGROUPNAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.BLGOODSCODERF as J_BLGOODSCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.BLGOODSFULLNAMERF as J_BLGOODSFULLNAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.ENTERPRISEGANRECODERF as J_ENTERPRISEGANRECODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.ENTERPRISEGANRENAMERF as J_ENTERPRISEGANRENAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.WAREHOUSECODERF as J_WAREHOUSECODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.WAREHOUSENAMERF as J_WAREHOUSENAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.WAREHOUSESHELFNORF as J_WAREHOUSESHELFNORF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKORDERDIVCDRF as J_STOCKORDERDIVCDRF ").Append(Environment.NewLine);
                sb.Append(" ,J.OPENPRICEDIVRF as J_OPENPRICEDIVRF ").Append(Environment.NewLine);
                sb.Append(" ,J.GOODSRATERANKRF as J_GOODSRATERANKRF ").Append(Environment.NewLine);
                sb.Append(" ,J.CUSTRATEGRPCODERF as J_CUSTRATEGRPCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.SUPPRATEGRPCODERF as J_SUPPRATEGRPCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.LISTPRICETAXEXCFLRF as J_LISTPRICETAXEXCFLRF ").Append(Environment.NewLine);
                sb.Append(" ,J.LISTPRICETAXINCFLRF as J_LISTPRICETAXINCFLRF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKRATERF as J_STOCKRATERF ").Append(Environment.NewLine);
                sb.Append(" ,J.RATESECTSTCKUNPRCRF as J_RATESECTSTCKUNPRCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.RATEDIVSTCKUNPRCRF as J_RATEDIVSTCKUNPRCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.UNPRCCALCCDSTCKUNPRCRF as J_UNPRCCALCCDSTCKUNPRCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.PRICECDSTCKUNPRCRF as J_PRICECDSTCKUNPRCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.STDUNPRCSTCKUNPRCRF as J_STDUNPRCSTCKUNPRCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.FRACPROCUNITSTCUNPRCRF as J_FRACPROCUNITSTCUNPRCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.FRACPROCSTCKUNPRCRF as J_FRACPROCSTCKUNPRCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKUNITPRICEFLRF as J_STOCKUNITPRICEFLRF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKUNITTAXPRICEFLRF as J_STOCKUNITTAXPRICEFLRF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKUNITCHNGDIVRF as J_STOCKUNITCHNGDIVRF ").Append(Environment.NewLine);
                sb.Append(" ,J.BFSTOCKUNITPRICEFLRF as J_BFSTOCKUNITPRICEFLRF ").Append(Environment.NewLine);
                sb.Append(" ,J.BFLISTPRICERF as J_BFLISTPRICERF ").Append(Environment.NewLine);
                sb.Append(" ,J.RATEBLGOODSCODERF as J_RATEBLGOODSCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.RATEBLGOODSNAMERF as J_RATEBLGOODSNAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.RATEGOODSRATEGRPCDRF as J_RATEGOODSRATEGRPCDRF ").Append(Environment.NewLine);
                sb.Append(" ,J.RATEGOODSRATEGRPNMRF as J_RATEGOODSRATEGRPNMRF ").Append(Environment.NewLine);
                sb.Append(" ,J.RATEBLGROUPCODERF as J_RATEBLGROUPCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.RATEBLGROUPNAMERF as J_RATEBLGROUPNAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKCOUNTRF as J_STOCKCOUNTRF ").Append(Environment.NewLine);
                sb.Append(" ,J.ORDERCNTRF as J_ORDERCNTRF ").Append(Environment.NewLine);
                sb.Append(" ,J.ORDERADJUSTCNTRF as J_ORDERADJUSTCNTRF ").Append(Environment.NewLine);
                sb.Append(" ,J.ORDERREMAINCNTRF as J_ORDERREMAINCNTRF ").Append(Environment.NewLine);
                sb.Append(" ,J.REMAINCNTUPDDATERF as J_REMAINCNTUPDDATERF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKPRICETAXEXCRF as J_STOCKPRICETAXEXCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKPRICETAXINCRF as J_STOCKPRICETAXINCRF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKGOODSCDRF as J_STOCKGOODSCDRF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKPRICECONSTAXRF as J_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
                sb.Append(" ,J.TAXATIONCODERF as J_TAXATIONCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.STOCKDTISLIPNOTE1RF as J_STOCKDTISLIPNOTE1RF ").Append(Environment.NewLine);
                sb.Append(" ,J.SALESCUSTOMERCODERF as J_SALESCUSTOMERCODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.SALESCUSTOMERSNMRF as J_SALESCUSTOMERSNMRF ").Append(Environment.NewLine);
                sb.Append(" ,J.SLIPMEMO1RF as J_SLIPMEMO1RF ").Append(Environment.NewLine);
                sb.Append(" ,J.SLIPMEMO2RF as J_SLIPMEMO2RF ").Append(Environment.NewLine);
                sb.Append(" ,J.SLIPMEMO3RF as J_SLIPMEMO3RF ").Append(Environment.NewLine);
                sb.Append(" ,J.INSIDEMEMO1RF as J_INSIDEMEMO1RF ").Append(Environment.NewLine);
                sb.Append(" ,J.INSIDEMEMO2RF as J_INSIDEMEMO2RF ").Append(Environment.NewLine);
                sb.Append(" ,J.INSIDEMEMO3RF as J_INSIDEMEMO3RF ").Append(Environment.NewLine);
                sb.Append(" ,J.SUPPLIERCDRF as J_SUPPLIERCDRF ").Append(Environment.NewLine);
                sb.Append(" ,J.SUPPLIERSNMRF as J_SUPPLIERSNMRF ").Append(Environment.NewLine);
                sb.Append(" ,J.ADDRESSEECODERF as J_ADDRESSEECODERF ").Append(Environment.NewLine);
                sb.Append(" ,J.ADDRESSEENAMERF as J_ADDRESSEENAMERF ").Append(Environment.NewLine);
                sb.Append(" ,J.DIRECTSENDINGCDRF as J_DIRECTSENDINGCDRF ").Append(Environment.NewLine);
                sb.Append(" ,J.ORDERNUMBERRF as J_ORDERNUMBERRF ").Append(Environment.NewLine);
                sb.Append(" ,J.WAYTOORDERRF as J_WAYTOORDERRF ").Append(Environment.NewLine);
                sb.Append(" ,J.DELIGDSCMPLTDUEDATERF as J_DELIGDSCMPLTDUEDATERF ").Append(Environment.NewLine);
                sb.Append(" ,J.EXPECTDELIVERYDATERF as J_EXPECTDELIVERYDATERF ").Append(Environment.NewLine);
                sb.Append(" ,J.ORDERDATACREATEDIVRF as J_ORDERDATACREATEDIVRF ").Append(Environment.NewLine);
                sb.Append(" ,J.ORDERDATACREATEDATERF as J_ORDERDATACREATEDATERF ").Append(Environment.NewLine);
                sb.Append(" ,J.ORDERFORMISSUEDDIVRF  as J_ORDERFORMISSUEDDIVRF  ").Append(Environment.NewLine);
                //�󒍃}�X�^
                sb.Append(" ,C2.CREATEDATETIMERF as C2_CREATEDATETIMERF ").Append(Environment.NewLine);
                sb.Append(" ,C2.UPDATEDATETIMERF as C2_UPDATEDATETIMERF ").Append(Environment.NewLine);
                sb.Append(" ,C2.ENTERPRISECODERF as C2_ENTERPRISECODERF ").Append(Environment.NewLine);
                sb.Append(" ,C2.FILEHEADERGUIDRF as C2_FILEHEADERGUIDRF ").Append(Environment.NewLine);
                sb.Append(" ,C2.UPDEMPLOYEECODERF as C2_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                sb.Append(" ,C2.UPDASSEMBLYID1RF as C2_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                sb.Append(" ,C2.UPDASSEMBLYID2RF as C2_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                sb.Append(" ,C2.LOGICALDELETECODERF as C2_LOGICALDELETECODERF ").Append(Environment.NewLine);
                sb.Append(" ,C2.SECTIONCODERF as C2_SECTIONCODERF ").Append(Environment.NewLine);
                sb.Append(" ,C2.ACCEPTANORDERNORF as C2_ACCEPTANORDERNORF ").Append(Environment.NewLine);
                sb.Append(" ,C2.ACPTANODRSTATUSRF as C2_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                sb.Append(" ,C2.SALESSLIPNUMRF as C2_SALESSLIPNUMRF ").Append(Environment.NewLine);
                sb.Append(" ,C2.DATAINPUTSYSTEMRF as C2_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
                sb.Append(" ,C2.COMMONSEQNORF as C2_COMMONSEQNORF ").Append(Environment.NewLine);
                sb.Append(" ,C2.SLIPDTLNUMRF as C2_SLIPDTLNUMRF ").Append(Environment.NewLine);
                sb.Append(" ,C2.SLIPDTLNUMDERIVNORF as C2_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);
                sb.Append(" ,C2.SRCLINKDATACODERF as C2_SRCLINKDATACODERF ").Append(Environment.NewLine);
                sb.Append(" ,C2.SRCSLIPDTLNUMRF as C2_SRCSLIPDTLNUMRF ").Append(Environment.NewLine);

                sb.Append(" FROM STOCKSLIPRF I WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                //�d�����׃f�[�^
                sb.Append(" INNER JOIN STOCKDETAILRF J WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                //	�d���f�[�^.��ƃR�[�h�@���@�d�����׃f�[�^.��ƃR�[�h
                sb.Append(" ON I.ENTERPRISECODERF = J.ENTERPRISECODERF ").Append(Environment.NewLine);
                //	�d���f�[�^.�d���`���@���@�d�����׃f�[�^.�d���`��
                sb.Append(" AND I.SUPPLIERFORMALRF = J.SUPPLIERFORMALRF ").Append(Environment.NewLine);
                //	�d���f�[�^.�d���`�[�ԍ��@���@�d�����׃f�[�^.�d���`�[�ԍ�
                sb.Append(" AND I.SUPPLIERSLIPNORF = J.SUPPLIERSLIPNORF ").Append(Environment.NewLine);

                //�󒍃}�X�^
                sb.Append(" LEFT JOIN ACCEPTODRRF C2 WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                //	�d�����׃f�[�^.��ƃR�[�h�@���@�󒍃}�X�^.��ƃR�[�h
                sb.Append(" ON I.ENTERPRISECODERF = C2.ENTERPRISECODERF ").Append(Environment.NewLine);
                //	�d�����׃f�[�^.�d���`���@���@�󒍃}�X�^.�󒍃X�e�[�^�X
                sb.Append(" AND ((I.SUPPLIERFORMALRF = 0 AND C2.ACPTANODRSTATUSRF =6)  ").Append(Environment.NewLine);
                sb.Append(" OR (I.SUPPLIERFORMALRF = 1 AND C2.ACPTANODRSTATUSRF =4)  ").Append(Environment.NewLine);
                sb.Append(" OR (I.SUPPLIERFORMALRF = 2 AND C2.ACPTANODRSTATUSRF =2))  ").Append(Environment.NewLine);
                //	�d�����׃f�[�^.�d���`�[�ԍ��@���@�󒍃}�X�^.�`�[�ԍ�
                sb.Append(" AND I.SUPPLIERSLIPNORF = C2.SALESSLIPNUMRF ").Append(Environment.NewLine);

                //���d���f�[�^
                sb.Append(" INNER JOIN (  ").Append(Environment.NewLine);
                sb.Append("    SELECT DISTINCT SSLIPRF.ENTERPRISECODERF ").Append(Environment.NewLine);
                sb.Append("    ,SSLIPRF.SUPPLIERFORMALRF ").Append(Environment.NewLine);
                sb.Append("    ,SSLIPRF.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
                sb.Append("    FROM STOCKSLIPRF SSLIPRF ").Append(Environment.NewLine);
                sb.Append("    INNER JOIN STOCKDETAILRF SSLIPDTLRF ").Append(Environment.NewLine);
                //	�d���f�[�^.��ƃR�[�h�@���@�d�����׃f�[�^.��ƃR�[�h
                sb.Append("    ON SSLIPRF.ENTERPRISECODERF = SSLIPDTLRF.ENTERPRISECODERF  ").Append(Environment.NewLine);
                //	�d���f�[�^.�d���`���@���@�d�����׃f�[�^.�d���`��
                sb.Append("    AND SSLIPRF.SUPPLIERFORMALRF = SSLIPDTLRF.SUPPLIERFORMALRF  ").Append(Environment.NewLine);
                //	�d���f�[�^.�d���`�[�ԍ��@���@�d�����׃f�[�^.�d���`�[�ԍ�			
                sb.Append("    AND SSLIPRF.SUPPLIERSLIPNORF = SSLIPDTLRF.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
                //	�d���f�[�^.�d���v�㋒�_�R�[�h�@���@�p�����[�^.���_�R�[�h
                //sb.Append("    WHERE SSLIPRF.STOCKADDUPSECTIONCDRF=@FINDSECTIONCODE_SSLIPRF ").Append(Environment.NewLine);// DEL 2011/11/14 xupz
                sb.Append("    WHERE SSLIPRF.STOCKSECTIONCDRF=@FINDSECTIONCODE_SSLIPRF ").Append(Environment.NewLine);// ADD 2011/11/14 xupz
                
                //	�d���f�[�^.��ƃR�[�h�@���@�p�����[�^.��ƃR�[�h
                sb.Append("    AND SSLIPRF.ENTERPRISECODERF=@FINDENTERPRISECODERF_SSLIPRF ").Append(Environment.NewLine);// ADD 2011/08/18 ���仁@Redmine#23746

                //	�d�����׃f�[�^.�X�V�����@>�@�p�����[�^.�J�n���t
                sb.Append("    AND SSLIPDTLRF.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_SSLIPRF ").Append(Environment.NewLine);
                //	�d�����׃f�[�^.�X�V�����@���@�p�����[�^.�I�����t
                sb.Append("    AND SSLIPDTLRF.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_SSLIPRF ").Append(Environment.NewLine);
                sb.Append(" )AS II").Append(Environment.NewLine);

                //	�d���f�[�^.��ƃR�[�h�@���@���d���f�[�^.��ƃR�[�h�@
                sb.Append(" ON I.ENTERPRISECODERF = II.ENTERPRISECODERF ").Append(Environment.NewLine);
                //	�d���f�[�^.�d���`���@���@���d���f�[�^.�d���`��
                sb.Append(" AND I.SUPPLIERFORMALRF = II.SUPPLIERFORMALRF ").Append(Environment.NewLine);
                //	�d���f�[�^.�d���`�[�ԍ��@���@���d���f�[�^.�d���`�[�ԍ�	
                sb.Append(" AND I.SUPPLIERSLIPNORF = II.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
             }
            // ----- ADD 2011/11/01 xupz----------<<<<<

			sb.Append(" ORDER BY ").Append(Environment.NewLine);
			sb.Append(" I_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,I_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,J_SUPPLIERFORMALRF  ").Append(Environment.NewLine);
			sb.Append(" ,J_STOCKSLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,C2_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,C2_SLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);

			sqlText = sb.ToString();
			// ADD 2011.08.29 ------<<<<<

			//Prameter�I�u�W�F�N�g�̍쐬
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
			SqlParameter findParaUpdateStartDateTime_I = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_I", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_I = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_I", SqlDbType.BigInt);
			// ADD 2011.08.29 ------>>>>>
			SqlParameter findParaSectionCode_sslip = sqlCommand.Parameters.Add("@FINDSECTIONCODE_SSLIPRF", SqlDbType.NChar);
			SqlParameter findParaUpdateStartDateTime_sslip = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_SSLIPRF", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_sslip = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_SSLIPRF", SqlDbType.BigInt);
			// ADD 2011.08.29 ------<<<<<
			// DEL 2011.08.29 ------->>>>>
			//SqlParameter findParaUpdateStartDateTime_C2 = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_C2", SqlDbType.BigInt);
			//SqlParameter findParaUpdateEndDateTime_C2 = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_C2", SqlDbType.BigInt);
			//SqlParameter findParaUpdateStartDateTime_J = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_J", SqlDbType.BigInt);
			//SqlParameter findParaUpdateEndDateTime_J = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_J", SqlDbType.BigInt);
			// DEL 2011.08.29 -------<<<<<
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);// ADD 2011/08/18 ���仁@Redmine#23746
			SqlParameter findParaEnterpriseCode_sslip = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF_SSLIPRF", SqlDbType.NChar);// ADD 2011/08/18 ���仁@Redmine#23746

			//Parameter�I�u�W�F�N�g�֒l�ݒ�
			findParaSectionCode.Value = receiveDataWork.PmSectionCode;
			findParaUpdateStartDateTime_I.Value = receiveDataWork.StartDateTime;
			findParaUpdateEndDateTime_I.Value = receiveDataWork.EndDateTime;
			// ADD 2011.08.29 ------>>>>>
			findParaSectionCode_sslip.Value = receiveDataWork.PmSectionCode;
			findParaUpdateStartDateTime_sslip.Value = receiveDataWork.StartDateTime;
			findParaUpdateEndDateTime_sslip.Value = receiveDataWork.EndDateTime;
			// ADD 2011.08.29 ------<<<<<
			// DEL 2011.08.29 ------->>>>>
			//findParaUpdateStartDateTime_C2.Value = receiveDataWork.StartDateTime;
			//findParaUpdateEndDateTime_C2.Value = receiveDataWork.EndDateTime;
			//findParaUpdateStartDateTime_J.Value = receiveDataWork.StartDateTime;
			//findParaUpdateEndDateTime_J.Value = receiveDataWork.EndDateTime;
			// DEL 2011.08.29 -------<<<<<
			findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;// ADD 2011/08/18 ���仁@Redmine#23746
			findParaEnterpriseCode_sslip.Value = receiveDataWork.PmEnterpriseCode;// ADD 2011/08/18 ���仁@Redmine#23746

            // ----- ADD 2011/11/30 tanh---------->>>>>
            //�f�[�^���M���o�����敪���u�`�[�敪�v�̏ꍇ
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
            {
                SqlParameter findParaSyncExecDate = sqlCommand.Parameters.Add("@FINDSYNCEXECDATERF", SqlDbType.BigInt);
                findParaSyncExecDate.Value = receiveDataWork.SyncExecDate;
                SqlParameter findParaEndTime = sqlCommand.Parameters.Add("@FINDENDTIMERF", SqlDbType.BigInt);
                findParaEndTime.Value = receiveDataWork.EndDateTimeTicks;
            }
            // ----- ADD 2011/11/30 tanh----------<<<<<

			// SQL��
			sqlCommand.CommandText = sqlText;
            //  ADD dingjx  2011/10/08  ---------------->>>>>>
            // Timeout
            sqlCommand.CommandTimeout = 600;
            //  ADD dingjx  2011/10/08  ----------------<<<<<<
			myReader = sqlCommand.ExecuteReader();

			ArrayList stockSlipList = new ArrayList();
			ArrayList stockDtlList = new ArrayList();
			ArrayList acceptodrList = new ArrayList();
			DCStockDetailDB dCSalesHistDtlDB = new DCStockDetailDB();
			DCAcceptOdrDB dCAcceptOdrDB = new DCAcceptOdrDB();
			DCStockSlipWork tmpWorkI = new DCStockSlipWork();
			DCStockDetailWork tmpWorkJ = new DCStockDetailWork();
			DCAcceptOdrWork tmpWorkC = new DCAcceptOdrWork();

			Dictionary<string, string> stockSlipDic = new Dictionary<string, string>();
			Dictionary<string, string> stockDtlDic = new Dictionary<string, string>();
			Dictionary<string, string> accOdrDic = new Dictionary<string, string>();

			while (myReader.Read())
			{
				//	�d���f�[�^
				tmpWorkI = this.CopyToStockSlipWorkFromReaderSCM(ref myReader, "I_");
				string workI_key = tmpWorkI.EnterpriseCode + tmpWorkI.SupplierFormal.ToString() + tmpWorkI.SupplierSlipNo.ToString();
				if (!string.Empty.Equals(tmpWorkI.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkI.SupplierFormal.ToString())
					&& !string.Empty.Equals(tmpWorkI.SupplierSlipNo.ToString())
					&& !stockSlipDic.ContainsKey(workI_key))
				{
					stockSlipDic.Add(workI_key, workI_key);
					stockSlipList.Add(tmpWorkI);
				}
				//	�d�����׃f�[�^
				tmpWorkJ = dCSalesHistDtlDB.CopyToStockDetailWorkFromReaderSCM(ref myReader, "J_");
				string workJ_key = tmpWorkJ.EnterpriseCode + tmpWorkJ.SupplierFormal.ToString() + tmpWorkJ.StockSlipDtlNum.ToString();
				if (!string.Empty.Equals(tmpWorkJ.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkJ.SupplierFormal.ToString())
					&& !string.Empty.Equals(tmpWorkJ.StockSlipDtlNum.ToString())
					&& !stockDtlDic.ContainsKey(workJ_key))
				{
					stockDtlDic.Add(workJ_key, workJ_key);
					stockDtlList.Add(tmpWorkJ);
				}
				// �󒍃}�X�^
				tmpWorkC = dCAcceptOdrDB.CopyToAcceptOdrWorkFromReaderSCM(ref myReader, "C2_");
				string workC_key = tmpWorkC.EnterpriseCode + tmpWorkC.SectionCode.Trim() + tmpWorkC.AcptAnOdrStatus.ToString()
								   + tmpWorkC.DataInputSystem.ToString() + tmpWorkC.CommonSeqNo.ToString() + tmpWorkC.SlipDtlNum.ToString()
								   + tmpWorkC.SlipDtlNumDerivNo.ToString();
				if (!string.Empty.Equals(tmpWorkC.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkC.SectionCode.Trim())
					&& !string.Empty.Equals(tmpWorkC.AcptAnOdrStatus.ToString())
					&& !string.Empty.Equals(tmpWorkC.DataInputSystem.ToString())
					&& !string.Empty.Equals(tmpWorkC.CommonSeqNo.ToString())
					&& !string.Empty.Equals(tmpWorkC.SlipDtlNum.ToString())
					&& !string.Empty.Equals(tmpWorkC.SlipDtlNumDerivNo.ToString())
					&& !accOdrDic.ContainsKey(workC_key))
				{
					accOdrDic.Add(workC_key, workC_key);
					acceptodrList.Add(tmpWorkC);
				}
			}

			// �d���v�ۃt���O
			if (receiveDataWork.DoSalesSlipFlg)
			{
				resultList.Add(stockSlipList);
			}
			// �d�����הۃt���O
			if (receiveDataWork.DoStockDetailFlg)
			{
				//resultList.Add(stockDtlList); // DEL 2011.09.08
				//outSstockDtlList = stockDtlList; // ADD 2011.09.08// DEL 2011/09/15
				resultList.Add(stockDtlList); // ADD 2011/09/15
			}
			// �󒍃}�X�^�v�ۃt���O
			if (receiveDataWork.DoAcceptOdrFlg)
			{
				acpOdrList = acceptodrList;
			}

			if (stockSlipList.Count > 0)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}

			if (myReader != null)
			{
				if (!myReader.IsClosed)
				{
					myReader.Close();
				}

				myReader.Dispose();
			}

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
			}

			return status;
		}
	
		/// <summary>
		/// �N���X�i�[���� Reader �� stockSlipWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>�I�u�W�F�N�g</returns>
		private DCStockSlipWork CopyToStockSlipWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCStockSlipWork stockSlipWork = new DCStockSlipWork();

			this.CopyToStockSlipWorkFromReaderSCM(ref myReader, ref stockSlipWork, tableNm);

			return stockSlipWork;
		}

		/// <summary>
		/// �N���X�i�[���� Reader �� stockSlipWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="stockSlipWork">stockSlipWork �I�u�W�F�N�g</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToStockSlipWorkFromReaderSCM(ref SqlDataReader myReader, ref DCStockSlipWork stockSlipWork, string tableNm)
		{
			if (myReader != null && stockSlipWork != null)
			{
				# region �N���X�֊i�[
				stockSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				stockSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				stockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				stockSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				stockSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				stockSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				stockSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				stockSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				stockSlipWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERFORMALRF"));
				stockSlipWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNORF"));
				stockSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SECTIONCODERF"));
				stockSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBSECTIONCODERF"));
				stockSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNOTEDIVRF"));
				stockSlipWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNLNKSUPPSLIPNORF"));
				stockSlipWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPCDRF"));
				stockSlipWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKGOODSCDRF"));
				stockSlipWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACCPAYDIVCDRF"));
				stockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKSECTIONCDRF"));
				stockSlipWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKADDUPSECTIONCDRF"));
				stockSlipWork.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPUPDATECDRF"));
				stockSlipWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "INPUTDAYRF"));
				stockSlipWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "ARRIVALGOODSDAYRF"));
				stockSlipWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "STOCKDATERF"));
				stockSlipWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "STOCKADDUPADATERF"));
				stockSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DELAYPAYMENTDIVRF"));
				stockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PAYEECODERF"));
				stockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYEESNMRF"));
				stockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERCDRF"));
				stockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERNM1RF"));
				stockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERNM2RF"));
				stockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSNMRF"));
				stockSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BUSINESSTYPECODERF"));
				stockSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BUSINESSTYPENAMERF"));
				stockSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESAREACODERF"));
				stockSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESAREANAMERF"));
				stockSlipWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKINPUTCODERF"));
				stockSlipWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKINPUTNAMERF"));
				stockSlipWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKAGENTCODERF"));
				stockSlipWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKAGENTNAMERF"));
				stockSlipWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPTTLAMNTDSPWAYCDRF"));
				stockSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "TTLAMNTDISPRATEAPYRF"));
				stockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKTOTALPRICERF"));
				stockSlipWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKSUBTTLPRICERF"));
				stockSlipWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKTTLPRICTAXINCRF"));
				stockSlipWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKTTLPRICTAXEXCRF"));
				stockSlipWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKNETPRICERF"));
				stockSlipWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKPRICECONSTAXRF"));
				stockSlipWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TTLITDEDSTCOUTTAXRF"));
				stockSlipWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TTLITDEDSTCINTAXRF"));
				stockSlipWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TTLITDEDSTCTAXFREERF"));
				stockSlipWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKOUTTAXRF"));
				stockSlipWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STCKPRCCONSTAXINCLURF"));
				stockSlipWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STCKDISTTLTAXEXCRF"));
				stockSlipWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSTOCKDISOUTTAXRF"));
				stockSlipWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSTOCKDISINTAXRF"));
				stockSlipWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSTOCKDISTAXFRERF"));
				stockSlipWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKDISOUTTAXRF"));
				stockSlipWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STCKDISTTLTAXINCLURF"));
				stockSlipWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TAXADJUSTRF"));
				stockSlipWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "BALANCEADJUSTRF"));
				stockSlipWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPCTAXLAYCDRF"));
				stockSlipWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERCONSTAXRATERF"));
				stockSlipWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ACCPAYCONSTAXRF"));
				stockSlipWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKFRACTIONPROCCDRF"));
				stockSlipWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTOPAYMENTRF"));
				stockSlipWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTOPAYSLIPNUMRF"));
				stockSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RETGOODSREASONDIVRF"));
				stockSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RETGOODSREASONRF"));
				stockSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PARTYSALESLIPNUMRF"));
				stockSlipWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNOTE1RF"));
				stockSlipWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNOTE2RF"));
				stockSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DETAILROWCOUNTRF"));
				stockSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "EDISENDDATERF"));
				stockSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "EDITAKEINDATERF"));
				stockSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UOEREMARK1RF"));
				stockSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UOEREMARK2RF"));
				stockSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPPRINTDIVCDRF"));
				stockSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPPRINTFINISHCDRF"));
				stockSlipWork.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPPRINTDATERF"));
				stockSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPPRTSETPAPERIDRF"));
				stockSlipWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPADDRESSDIVRF"));
				stockSlipWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEECODERF"));
				stockSlipWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEENAMERF"));
				stockSlipWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEENAME2RF"));
				stockSlipWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEPOSTNORF"));
				stockSlipWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEADDR1RF"));
				stockSlipWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEADDR3RF"));
				stockSlipWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEADDR4RF"));
				stockSlipWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEETELNORF"));
				stockSlipWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEFAXNORF"));
				stockSlipWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DIRECTSENDINGCDRF"));
				# endregion
			}
		}
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �d���f�[�^�폜
        /// </summary>
        /// <param name="dcStockSlipWorkList">�d���f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Delete(ArrayList dcStockSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcStockSlipWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �d���f�[�^�폜
        /// </summary>
        /// <param name="dcStockSlipWorkList">�d���f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcStockSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockSlipWork dcStockSlipWork in dcStockSlipWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "DELETE FROM STOCKSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO";
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = dcStockSlipWork.EnterpriseCode;
                findParaSupplierFormal.Value = dcStockSlipWork.SupplierFormal;
                findParaSupplierSlipNo.Value = dcStockSlipWork.SupplierSlipNo;

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �d���f�[�^���폜����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �d���f�[�^�o�^
        /// </summary>
        /// <param name="dcStockSlipWorkList">�d���f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Insert(ArrayList dcStockSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcStockSlipWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �d���f�[�^�o�^
        /// </summary>
        /// <param name="dcStockSlipWorkList">�d���f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcStockSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockSlipWork dcStockSlipWork in dcStockSlipWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "INSERT INTO STOCKSLIPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, SECTIONCODERF, SUBSECTIONCODERF, DEBITNOTEDIVRF, DEBITNLNKSUPPSLIPNORF, SUPPLIERSLIPCDRF, STOCKGOODSCDRF, ACCPAYDIVCDRF, STOCKSECTIONCDRF, STOCKADDUPSECTIONCDRF, STOCKSLIPUPDATECDRF, INPUTDAYRF, ARRIVALGOODSDAYRF, STOCKDATERF, STOCKADDUPADATERF, DELAYPAYMENTDIVRF, PAYEECODERF, PAYEESNMRF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, BUSINESSTYPECODERF, BUSINESSTYPENAMERF, SALESAREACODERF, SALESAREANAMERF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, SUPPTTLAMNTDSPWAYCDRF, TTLAMNTDISPRATEAPYRF, STOCKTOTALPRICERF, STOCKSUBTTLPRICERF, STOCKTTLPRICTAXINCRF, STOCKTTLPRICTAXEXCRF, STOCKNETPRICERF, STOCKPRICECONSTAXRF, TTLITDEDSTCOUTTAXRF, TTLITDEDSTCINTAXRF, TTLITDEDSTCTAXFREERF, STOCKOUTTAXRF, STCKPRCCONSTAXINCLURF, STCKDISTTLTAXEXCRF, ITDEDSTOCKDISOUTTAXRF, ITDEDSTOCKDISINTAXRF, ITDEDSTOCKDISTAXFRERF, STOCKDISOUTTAXRF, STCKDISTTLTAXINCLURF, TAXADJUSTRF, BALANCEADJUSTRF, SUPPCTAXLAYCDRF, SUPPLIERCONSTAXRATERF, ACCPAYCONSTAXRF, STOCKFRACTIONPROCCDRF, AUTOPAYMENTRF, AUTOPAYSLIPNUMRF, RETGOODSREASONDIVRF, RETGOODSREASONRF, PARTYSALESLIPNUMRF, SUPPLIERSLIPNOTE1RF, SUPPLIERSLIPNOTE2RF, DETAILROWCOUNTRF, EDISENDDATERF, EDITAKEINDATERF, UOEREMARK1RF, UOEREMARK2RF, SLIPPRINTDIVCDRF, SLIPPRINTFINISHCDRF, STOCKSLIPPRINTDATERF, SLIPPRTSETPAPERIDRF, SLIPADDRESSDIVRF, ADDRESSEECODERF, ADDRESSEENAMERF, ADDRESSEENAME2RF, ADDRESSEEPOSTNORF, ADDRESSEEADDR1RF, ADDRESSEEADDR3RF, ADDRESSEEADDR4RF, ADDRESSEETELNORF, ADDRESSEEFAXNORF, DIRECTSENDINGCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SUPPLIERFORMAL, @SUPPLIERSLIPNO, @SECTIONCODE, @SUBSECTIONCODE, @DEBITNOTEDIV, @DEBITNLNKSUPPSLIPNO, @SUPPLIERSLIPCD, @STOCKGOODSCD, @ACCPAYDIVCD, @STOCKSECTIONCD, @STOCKADDUPSECTIONCD, @STOCKSLIPUPDATECD, @INPUTDAY, @ARRIVALGOODSDAY, @STOCKDATE, @STOCKADDUPADATE, @DELAYPAYMENTDIV, @PAYEECODE, @PAYEESNM, @SUPPLIERCD, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPLIERSNM, @BUSINESSTYPECODE, @BUSINESSTYPENAME, @SALESAREACODE, @SALESAREANAME, @STOCKINPUTCODE, @STOCKINPUTNAME, @STOCKAGENTCODE, @STOCKAGENTNAME, @SUPPTTLAMNTDSPWAYCD, @TTLAMNTDISPRATEAPY, @STOCKTOTALPRICE, @STOCKSUBTTLPRICE, @STOCKTTLPRICTAXINC, @STOCKTTLPRICTAXEXC, @STOCKNETPRICE, @STOCKPRICECONSTAX, @TTLITDEDSTCOUTTAX, @TTLITDEDSTCINTAX, @TTLITDEDSTCTAXFREE, @STOCKOUTTAX, @STCKPRCCONSTAXINCLU, @STCKDISTTLTAXEXC, @ITDEDSTOCKDISOUTTAX, @ITDEDSTOCKDISINTAX, @ITDEDSTOCKDISTAXFRE, @STOCKDISOUTTAX, @STCKDISTTLTAXINCLU, @TAXADJUST, @BALANCEADJUST, @SUPPCTAXLAYCD, @SUPPLIERCONSTAXRATE, @ACCPAYCONSTAX, @STOCKFRACTIONPROCCD, @AUTOPAYMENT, @AUTOPAYSLIPNUM, @RETGOODSREASONDIV, @RETGOODSREASON, @PARTYSALESLIPNUM, @SUPPLIERSLIPNOTE1, @SUPPLIERSLIPNOTE2, @DETAILROWCOUNT, @EDISENDDATE, @EDITAKEINDATE, @UOEREMARK1, @UOEREMARK2, @SLIPPRINTDIVCD, @SLIPPRINTFINISHCD, @STOCKSLIPPRINTDATE, @SLIPPRTSETPAPERID, @SLIPADDRESSDIV, @ADDRESSEECODE, @ADDRESSEENAME, @ADDRESSEENAME2, @ADDRESSEEPOSTNO, @ADDRESSEEADDR1, @ADDRESSEEADDR3, @ADDRESSEEADDR4, @ADDRESSEETELNO, @ADDRESSEEFAXNO, @DIRECTSENDINGCD)";
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                SqlParameter paraDebitNLnkSuppSlipNo = sqlCommand.Parameters.Add("@DEBITNLNKSUPPSLIPNO", SqlDbType.Int);
                SqlParameter paraSupplierSlipCd = sqlCommand.Parameters.Add("@SUPPLIERSLIPCD", SqlDbType.Int);
                SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@STOCKGOODSCD", SqlDbType.Int);
                SqlParameter paraAccPayDivCd = sqlCommand.Parameters.Add("@ACCPAYDIVCD", SqlDbType.Int);
                SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);
                SqlParameter paraStockAddUpSectionCd = sqlCommand.Parameters.Add("@STOCKADDUPSECTIONCD", SqlDbType.NChar);
                SqlParameter paraStockSlipUpdateCd = sqlCommand.Parameters.Add("@STOCKSLIPUPDATECD", SqlDbType.Int);
                SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                SqlParameter paraArrivalGoodsDay = sqlCommand.Parameters.Add("@ARRIVALGOODSDAY", SqlDbType.Int);
                SqlParameter paraStockDate = sqlCommand.Parameters.Add("@STOCKDATE", SqlDbType.Int);
                SqlParameter paraStockAddUpADate = sqlCommand.Parameters.Add("@STOCKADDUPADATE", SqlDbType.Int);
                SqlParameter paraDelayPaymentDiv = sqlCommand.Parameters.Add("@DELAYPAYMENTDIV", SqlDbType.Int);
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                SqlParameter paraBusinessTypeName = sqlCommand.Parameters.Add("@BUSINESSTYPENAME", SqlDbType.NVarChar);
                SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                SqlParameter paraSalesAreaName = sqlCommand.Parameters.Add("@SALESAREANAME", SqlDbType.NVarChar);
                SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);
                SqlParameter paraStockInputName = sqlCommand.Parameters.Add("@STOCKINPUTNAME", SqlDbType.NVarChar);
                SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);
                SqlParameter paraSuppTtlAmntDspWayCd = sqlCommand.Parameters.Add("@SUPPTTLAMNTDSPWAYCD", SqlDbType.Int);
                SqlParameter paraTtlAmntDispRateApy = sqlCommand.Parameters.Add("@TTLAMNTDISPRATEAPY", SqlDbType.Int);
                SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                SqlParameter paraStockSubttlPrice = sqlCommand.Parameters.Add("@STOCKSUBTTLPRICE", SqlDbType.BigInt);
                SqlParameter paraStockTtlPricTaxInc = sqlCommand.Parameters.Add("@STOCKTTLPRICTAXINC", SqlDbType.BigInt);
                SqlParameter paraStockTtlPricTaxExc = sqlCommand.Parameters.Add("@STOCKTTLPRICTAXEXC", SqlDbType.BigInt);
                SqlParameter paraStockNetPrice = sqlCommand.Parameters.Add("@STOCKNETPRICE", SqlDbType.BigInt);
                SqlParameter paraStockPriceConsTax = sqlCommand.Parameters.Add("@STOCKPRICECONSTAX", SqlDbType.BigInt);
                SqlParameter paraTtlItdedStcOutTax = sqlCommand.Parameters.Add("@TTLITDEDSTCOUTTAX", SqlDbType.BigInt);
                SqlParameter paraTtlItdedStcInTax = sqlCommand.Parameters.Add("@TTLITDEDSTCINTAX", SqlDbType.BigInt);
                SqlParameter paraTtlItdedStcTaxFree = sqlCommand.Parameters.Add("@TTLITDEDSTCTAXFREE", SqlDbType.BigInt);
                SqlParameter paraStockOutTax = sqlCommand.Parameters.Add("@STOCKOUTTAX", SqlDbType.BigInt);
                SqlParameter paraStckPrcConsTaxInclu = sqlCommand.Parameters.Add("@STCKPRCCONSTAXINCLU", SqlDbType.BigInt);
                SqlParameter paraStckDisTtlTaxExc = sqlCommand.Parameters.Add("@STCKDISTTLTAXEXC", SqlDbType.BigInt);
                SqlParameter paraItdedStockDisOutTax = sqlCommand.Parameters.Add("@ITDEDSTOCKDISOUTTAX", SqlDbType.BigInt);
                SqlParameter paraItdedStockDisInTax = sqlCommand.Parameters.Add("@ITDEDSTOCKDISINTAX", SqlDbType.BigInt);
                SqlParameter paraItdedStockDisTaxFre = sqlCommand.Parameters.Add("@ITDEDSTOCKDISTAXFRE", SqlDbType.BigInt);
                SqlParameter paraStockDisOutTax = sqlCommand.Parameters.Add("@STOCKDISOUTTAX", SqlDbType.BigInt);
                SqlParameter paraStckDisTtlTaxInclu = sqlCommand.Parameters.Add("@STCKDISTTLTAXINCLU", SqlDbType.BigInt);
                SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                SqlParameter paraSuppCTaxLayCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYCD", SqlDbType.Int);
                SqlParameter paraSupplierConsTaxRate = sqlCommand.Parameters.Add("@SUPPLIERCONSTAXRATE", SqlDbType.Float);
                SqlParameter paraAccPayConsTax = sqlCommand.Parameters.Add("@ACCPAYCONSTAX", SqlDbType.BigInt);
                SqlParameter paraStockFractionProcCd = sqlCommand.Parameters.Add("@STOCKFRACTIONPROCCD", SqlDbType.Int);
                SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);
                SqlParameter paraAutoPaySlipNum = sqlCommand.Parameters.Add("@AUTOPAYSLIPNUM", SqlDbType.Int);
                SqlParameter paraRetGoodsReasonDiv = sqlCommand.Parameters.Add("@RETGOODSREASONDIV", SqlDbType.Int);
                SqlParameter paraRetGoodsReason = sqlCommand.Parameters.Add("@RETGOODSREASON", SqlDbType.NVarChar);
                SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@PARTYSALESLIPNUM", SqlDbType.NVarChar);
                SqlParameter paraSupplierSlipNote1 = sqlCommand.Parameters.Add("@SUPPLIERSLIPNOTE1", SqlDbType.NVarChar);
                SqlParameter paraSupplierSlipNote2 = sqlCommand.Parameters.Add("@SUPPLIERSLIPNOTE2", SqlDbType.NVarChar);
                SqlParameter paraDetailRowCount = sqlCommand.Parameters.Add("@DETAILROWCOUNT", SqlDbType.Int);
                SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);
                SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);
                SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@UOEREMARK1", SqlDbType.NVarChar);
                SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@UOEREMARK2", SqlDbType.NVarChar);
                SqlParameter paraSlipPrintDivCd = sqlCommand.Parameters.Add("@SLIPPRINTDIVCD", SqlDbType.Int);
                SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);
                SqlParameter paraStockSlipPrintDate = sqlCommand.Parameters.Add("@STOCKSLIPPRINTDATE", SqlDbType.Int);
                SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                SqlParameter paraSlipAddressDiv = sqlCommand.Parameters.Add("@SLIPADDRESSDIV", SqlDbType.Int);
                SqlParameter paraAddresseeCode = sqlCommand.Parameters.Add("@ADDRESSEECODE", SqlDbType.Int);
                SqlParameter paraAddresseeName = sqlCommand.Parameters.Add("@ADDRESSEENAME", SqlDbType.NVarChar);
                SqlParameter paraAddresseeName2 = sqlCommand.Parameters.Add("@ADDRESSEENAME2", SqlDbType.NVarChar);
                SqlParameter paraAddresseePostNo = sqlCommand.Parameters.Add("@ADDRESSEEPOSTNO", SqlDbType.NVarChar);
                SqlParameter paraAddresseeAddr1 = sqlCommand.Parameters.Add("@ADDRESSEEADDR1", SqlDbType.NVarChar);
                SqlParameter paraAddresseeAddr3 = sqlCommand.Parameters.Add("@ADDRESSEEADDR3", SqlDbType.NVarChar);
                SqlParameter paraAddresseeAddr4 = sqlCommand.Parameters.Add("@ADDRESSEEADDR4", SqlDbType.NVarChar);
                SqlParameter paraAddresseeTelNo = sqlCommand.Parameters.Add("@ADDRESSEETELNO", SqlDbType.NVarChar);
                SqlParameter paraAddresseeFaxNo = sqlCommand.Parameters.Add("@ADDRESSEEFAXNO", SqlDbType.NVarChar);
                SqlParameter paraDirectSendingCd = sqlCommand.Parameters.Add("@DIRECTSENDINGCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockSlipWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockSlipWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcStockSlipWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.LogicalDeleteCode);
                paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.SupplierFormal);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.SupplierSlipNo);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.SectionCode);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.SubSectionCode);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.DebitNoteDiv);
                paraDebitNLnkSuppSlipNo.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.DebitNLnkSuppSlipNo);
                paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.SupplierSlipCd);
                paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.StockGoodsCd);
                paraAccPayDivCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.AccPayDivCd);
                paraStockSectionCd.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.StockSectionCd);
                paraStockAddUpSectionCd.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.StockAddUpSectionCd);
                paraStockSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.StockSlipUpdateCd);
                paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockSlipWork.InputDay);
                paraArrivalGoodsDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockSlipWork.ArrivalGoodsDay);
                paraStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockSlipWork.StockDate);
                paraStockAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockSlipWork.StockAddUpADate);
                paraDelayPaymentDiv.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.DelayPaymentDiv);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.PayeeCode);
                paraPayeeSnm.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.PayeeSnm);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.SupplierCd);
                paraSupplierNm1.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.SupplierNm1);
                paraSupplierNm2.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.SupplierNm2);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.SupplierSnm);
                paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.BusinessTypeCode);
                paraBusinessTypeName.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.BusinessTypeName);
                paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.SalesAreaCode);
                paraSalesAreaName.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.SalesAreaName);
                paraStockInputCode.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.StockInputCode);
                paraStockInputName.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.StockInputName);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.StockAgentCode);
                paraStockAgentName.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.StockAgentName);
                paraSuppTtlAmntDspWayCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.SuppTtlAmntDspWayCd);
                paraTtlAmntDispRateApy.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.TtlAmntDispRateApy);
                paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.StockTotalPrice);
                paraStockSubttlPrice.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.StockSubttlPrice);
                paraStockTtlPricTaxInc.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.StockTtlPricTaxInc);
                paraStockTtlPricTaxExc.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.StockTtlPricTaxExc);
                paraStockNetPrice.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.StockNetPrice);
                paraStockPriceConsTax.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.StockPriceConsTax);
                paraTtlItdedStcOutTax.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.TtlItdedStcOutTax);
                paraTtlItdedStcInTax.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.TtlItdedStcInTax);
                paraTtlItdedStcTaxFree.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.TtlItdedStcTaxFree);
                paraStockOutTax.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.StockOutTax);
                paraStckPrcConsTaxInclu.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.StckPrcConsTaxInclu);
                paraStckDisTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.StckDisTtlTaxExc);
                paraItdedStockDisOutTax.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.ItdedStockDisOutTax);
                paraItdedStockDisInTax.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.ItdedStockDisInTax);
                paraItdedStockDisTaxFre.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.ItdedStockDisTaxFre);
                paraStockDisOutTax.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.StockDisOutTax);
                paraStckDisTtlTaxInclu.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.StckDisTtlTaxInclu);
                paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.TaxAdjust);
                paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.BalanceAdjust);
                paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.SuppCTaxLayCd);
                paraSupplierConsTaxRate.Value = SqlDataMediator.SqlSetDouble(dcStockSlipWork.SupplierConsTaxRate);
                paraAccPayConsTax.Value = SqlDataMediator.SqlSetInt64(dcStockSlipWork.AccPayConsTax);
                paraStockFractionProcCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.StockFractionProcCd);
                paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.AutoPayment);
                paraAutoPaySlipNum.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.AutoPaySlipNum);
                paraRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.RetGoodsReasonDiv);
                paraRetGoodsReason.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.RetGoodsReason);
                paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.PartySaleSlipNum);
                paraSupplierSlipNote1.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.SupplierSlipNote1);
                paraSupplierSlipNote2.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.SupplierSlipNote2);
                paraDetailRowCount.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.DetailRowCount);
                paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockSlipWork.EdiSendDate);
                paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockSlipWork.EdiTakeInDate);
                paraUoeRemark1.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.UoeRemark1);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.UoeRemark2);
                paraSlipPrintDivCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.SlipPrintDivCd);
                paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.SlipPrintFinishCd);
                paraStockSlipPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockSlipWork.StockSlipPrintDate);
                paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.SlipPrtSetPaperId);
                paraSlipAddressDiv.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.SlipAddressDiv);
                paraAddresseeCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.AddresseeCode);
                paraAddresseeName.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.AddresseeName);
                paraAddresseeName2.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.AddresseeName2);
                paraAddresseePostNo.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.AddresseePostNo);
                paraAddresseeAddr1.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.AddresseeAddr1);
                paraAddresseeAddr3.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.AddresseeAddr3);
                paraAddresseeAddr4.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.AddresseeAddr4);
                paraAddresseeTelNo.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.AddresseeTelNo);
                paraAddresseeFaxNo.Value = SqlDataMediator.SqlSetString(dcStockSlipWork.AddresseeFaxNo);
				paraDirectSendingCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlipWork.DirectSendingCd);


                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �d���f�[�^��o�^����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

		// ADD 2011.08.26 ���� ---------->>>>>
		# region [Clear]
		// R�N���X��public Method��SQL�������ʖ�
		/// <summary>
		/// �f�[�^�N���A
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <param name="sqlCommand">SQL�R�����g</param>
		/// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                       //DEL by Liangsd     2011/09/06
        public void Clear(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)      //ADD by Liangsd    2011/09/06
        {
            //ClearProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//DEL by Liangsd     2011/09/06
            ClearProc(sectionCode, enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//ADD by Liangsd    2011/09/06
        }
		/// <summary>
		/// �f�[�^�N���A
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <param name="sqlCommand">SQL�R�����g</param>
		/// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                  //DEL by Liangsd     2011/09/06
        private void ClearProc(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)//ADD by Liangsd    2011/09/06
        {
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Delete�R�}���h�̐���
            //sqlCommand.CommandText = "DELETE FROM STOCKSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";//DEL by Liangsd     2011/09/06
            sqlCommand.CommandText = "DELETE FROM STOCKSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND STOCKADDUPSECTIONCDRF = @FINDSECTIONCODERF";//ADD by Liangsd    2011/09/06
            
			//Prameter�I�u�W�F�N�g�̍쐬
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/06
			//Parameter�I�u�W�F�N�g�֒l�ݒ�
			findParaEnterpriseCode.Value = enterpriseCode;
            findParaSectionCode.Value = sectionCode;//ADD by Liangsd    2011/09/06
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // ����f�[�^���폜����
			sqlCommand.ExecuteNonQuery();

		}
		#endregion
		// ADD 2011.08.26 ���� ----------<<<<<
    }
}
